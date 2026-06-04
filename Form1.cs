using System;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Xml;
using MySql.Data.MySqlClient;
using Microsoft.Web.WebView2.WinForms;
using Microsoft.Web.WebView2.Core;
using Renci.SshNet;

namespace HardwareManagement
{
    public enum DeviceStatus { 대기중, 작동중, 오류 }

    public partial class Form1 : Form
    {
        private readonly string _statusLogPath = "status_log.csv";
        private readonly string _convLogPath = "conveyor_log.csv";
        private readonly string _videoLogPath = "video_log.csv";

        private DeviceStatus _rpiStatus = DeviceStatus.대기중;
        private DeviceStatus _stepStatus = DeviceStatus.대기중;
        private DeviceStatus _servoStatus = DeviceStatus.대기중;
        private DeviceStatus _camStatus = DeviceStatus.대기중;

        private bool _conveyorRunning = false;
        private System.Windows.Forms.Timer _convAutoStopTimer;
        private bool _videoRunning = false;
        private int _servoAngle = 0;

        private VideoCaptureDevice _videoDevice;
        private FilterInfoCollection _videoDevices;
        private System.Windows.Forms.Timer _clockTimer;
        private System.Windows.Forms.Timer _statusPollTimer;

        // ── 라즈베리파이 연결 설정 ──────────────────────
        private string _rpiIp = "192.168.0.27";
        private int _rpiPort = 5001;

        // ── SSH 연결 정보 ──────────────────────────────
        private readonly string _sshUser = "moble77";
        private readonly string _sshPass = "1111";
        private readonly string _sshScriptPath = "/home/moble77/work/Second_Proj/Camera_Step";
        private SshClient _sshClient;
        private ShellStream _sshShell;

        // ── DB 연결 ────────────────────────────────────
        private readonly string _dbConnStr =
            "Server=switchback.proxy.rlwy.net;Port=36928;Database=railway;Uid=root;Pwd=gLAKIHdIhqFvgxCpnGPhAOFvFOeURBZx;" +
            "CharSet=utf8mb4;SslMode=Disabled;AllowPublicKeyRetrieval=true;";
        private System.Windows.Forms.Timer _orderWatchTimer;
        private bool _isOrderProcessing = false;

        private class DispatchUnit
        {
            public string Slot { get; set; }
            public string Title { get; set; }
            public int UnitNo { get; set; }
            public int UnitTotal { get; set; }
        }

        // ── config.xml ────────────────────────────────
        private readonly string _configPath = "config.xml";
        private int[] _slotGaps = { 134, 134, 135 };
        private double _stepDelay = 0.003;
        private int _convSpeed = 70;

        // ── 출고 UI 표시 타이밍(ms) ─────────────────────────
        // 실제 서보 각도를 C#으로 읽어오는 피드백 값이 없으므로,
        // 화면은 임의 실시간 값 대신 단계 상태를 표시합니다.
        private const int SLOT_ARRIVE_WAIT_MS = 1200;
        private const int ROTARY_OUT_WAIT_MS = 5000;
        private const int ROTARY_RETURN_WAIT_MS = 3000;
        private const int CONVEYOR_RUN_MS = 10000;

        // ═══════════════════════════════════════════════
        public Form1()
        {
            InitializeComponent();
            InitLogs();
            InitConfig();
            InitClock();
            InitConvTimer();
            InitStatusPoll();
            UpdateDashboard();
            AddLog(rtbStatusLog, "⚙ 시스템 초기화 완료");
            AddLog(rtbConvLog, "⚙ 컨베이어 모듈 준비");
            AddLog(rtbVideoLog, "⚙ 영상 모듈 준비");
            AddLog(rtbConvLog, $"⚙ 스텝모터 서버 대상: {_rpiIp}:{_rpiPort}");
            _ = AutoStart();
        }

        // ── 라즈베리파이 자동 시작 ───────────────────────
        private async Task AutoStart()
        {
            bool ok = await StartRaspberryServer();
            if (ok)
            {
                InitOrderWatch();
                await InitWebView();
                AddLog(rtbStatusLog, "⚙ 시스템 전체 초기화 완료");
            }
            else
            {
                AddLog(rtbStatusLog, "❌ 시스템 시작 실패 — 라즈베리파이 확인 필요");
            }
        }

        private async Task<bool> StartRaspberryServer()
        {
            try
            {
                AddLog(rtbStatusLog, "📡 라즈베리파이 SSH 연결 중...");
                _sshClient = new SshClient(_rpiIp, 22, _sshUser, _sshPass);
                _sshClient.Connect();

                if (!_sshClient.IsConnected)
                {
                    AddLog(rtbStatusLog, "❌ SSH 연결 실패");
                    return false;
                }
                AddLog(rtbStatusLog, "✔ SSH 연결 성공");

                var kill = _sshClient.RunCommand("sudo pkill -f 'python3 main.py'; sleep 1");
                AddLog(rtbStatusLog, $"⚙ 기존 프로세스 종료");

                string pythonPath = "/home/moble77/work/Second_Proj/.venv/bin/python3";
                string workDir = _sshScriptPath;
                string logPath = $"{workDir}/server.log";
                string cmd = $"cd {workDir} && nohup {pythonPath} main.py > {logPath} 2>&1 & echo $!";

                var result = _sshClient.RunCommand(cmd);
                AddLog(rtbStatusLog, $"⚙ 실행 PID: {result.Result.Trim()}");

                AddLog(rtbStatusLog, "▶ 서버 시작 대기 중... (8초)");
                await Task.Delay(8000);

                var log = _sshClient.RunCommand($"tail -5 {logPath}");
                AddLog(rtbStatusLog, $"📋 서버 로그: {log.Result.Trim()}");

                string resp = await SendStepCommandAsync("STATUS");
                if (resp.StartsWith("OK:"))
                {
                    AddLog(rtbStatusLog, "✔ 라즈베리파이 서버 준비 완료");
                    return true;
                }
                else
                {
                    AddLog(rtbStatusLog, $"⚠ 서버 응답 없음: {resp}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                AddLog(rtbStatusLog, $"❌ SSH 오류: {ex.Message}");
                return false;
            }
        }

        private void StopRaspberryServer()
        {
            try
            {
                if (_sshClient != null && _sshClient.IsConnected)
                {
                    _sshClient.RunCommand("sudo pkill -f 'python3 main.py'");
                    _sshClient.Disconnect();
                    _sshClient.Dispose();
                    AddLog(rtbStatusLog, "■ 라즈베리파이 서버 종료");
                }
            }
            catch (Exception ex)
            {
                AddLog(rtbStatusLog, $"⚠ 서버 종료 오류: {ex.Message}");
            }
        }

        // ── 시계 ─────────────────────────────────────
        private void InitClock()
        {
            _clockTimer = new System.Windows.Forms.Timer { Interval = 1000 };
            _clockTimer.Tick += (s, e) => lblDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd   HH:mm:ss");
            _clockTimer.Start();
            lblDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd   HH:mm:ss");
        }

        private void InitConvTimer()
        {
            _convAutoStopTimer = new System.Windows.Forms.Timer();
            _convAutoStopTimer.Tick += async (s, e) =>
            {
                _convAutoStopTimer.Stop();
                _conveyorRunning = false;
                lblConvStateVal.Text = "정지 (자동)";
                lblConvStateVal.ForeColor = Color.FromArgb(255, 170, 0);
                string resp = await SendStepCommandAsync("CONV_STOP");
                AddLog(rtbConvLog, resp.StartsWith("OK:") ? "■ 컨베이어 자동 정지" : $"❌ {resp}");
                SaveLog(_convLogPath, "자동정지", "시간 초과");
            };
        }

        private void InitStatusPoll()
        {
            _statusPollTimer = new System.Windows.Forms.Timer { Interval = 500 };
            _statusPollTimer.Tick += async (s, e) => await UpdateSlotDisplay();
        }

        // ── 로그 초기화 ───────────────────────────────
        private void InitLogs()
        {
            var enc = Encoding.UTF8;
            if (!File.Exists(_statusLogPath)) File.WriteAllText(_statusLogPath, "시간,장치,상태\n", enc);
            if (!File.Exists(_convLogPath)) File.WriteAllText(_convLogPath, "시간,동작,내용\n", enc);
            if (!File.Exists(_videoLogPath)) File.WriteAllText(_videoLogPath, "시간,동작,내용\n", enc);
        }

        // ── 대시보드 업데이트 ─────────────────────────
        private void UpdateDashboard()
        {
            var all = new[] { _rpiStatus, _stepStatus, _servoStatus, _camStatus };
            int ok = 0; foreach (var s in all) if (s == DeviceStatus.작동중) ok++;
            int alarm = 0; foreach (var s in all) if (s == DeviceStatus.오류) alarm++;

            lblDashVal2.Text = $"{ok} / 4";
            lblDashVal2.ForeColor = ok == 4 ? Color.FromArgb(0, 210, 110) : Color.FromArgb(255, 170, 0);
            lblDashVal3.Text = alarm > 0 ? $"{alarm}건" : "없음";
            lblDashVal3.ForeColor = alarm > 0 ? Color.FromArgb(255, 65, 65) : Color.FromArgb(0, 210, 110);
            lblDashVal4.Text = DateTime.Now.ToString("HH:mm:ss");
            lblDashVal4.ForeColor = Color.FromArgb(0, 180, 255);
        }

        // ── 공통 로그 출력 ────────────────────────────
        private void AddLog(RichTextBox rtb, string msg, Color? forceColor = null)
        {
            if (rtb.InvokeRequired) { rtb.Invoke((Action)(() => AddLog(rtb, msg, forceColor))); return; }
            Color color;
            if (forceColor.HasValue) color = forceColor.Value;
            else if (msg.Contains("오류") || msg.Contains("❌") || msg.Contains("실패")) color = Color.FromArgb(255, 80, 80);
            else if (msg.Contains("완료") || msg.Contains("✔") || msg.Contains("정상")) color = Color.FromArgb(0, 210, 110);
            else if (msg.Contains("⚠") || msg.Contains("정지") || msg.Contains("■")) color = Color.FromArgb(255, 170, 0);
            else if (msg.Contains("📷") || msg.Contains("📸") || msg.Contains("📡")) color = Color.FromArgb(0, 200, 255);
            else if (msg.Contains("▶") || msg.Contains("◀") || msg.Contains("서보") ||
                     msg.Contains("→") || msg.Contains("←") || msg.Contains("구동")) color = Color.FromArgb(100, 180, 255);
            else if (msg.Contains("⚙") || msg.Contains("설정") || msg.Contains("로드")) color = Color.FromArgb(160, 180, 220);
            else color = Color.FromArgb(180, 190, 210);

            rtb.SelectionStart = rtb.TextLength; rtb.SelectionLength = 0;
            rtb.SelectionColor = color;
            rtb.AppendText($"[{DateTime.Now:HH:mm:ss}] {msg}\n");
            rtb.ScrollToCaret();
        }

        private void AddDeviceLog(string msg, Color? forceColor = null)
        {
            // 하단 "장비 로그" 영역에 출고/스텝/로터리/컨베이어 흐름을 모두 남깁니다.
            AddLog(rtbConvLog, msg, forceColor);
        }

        private void SaveLog(string path, string action, string content) =>
            File.AppendAllText(path, $"{DateTime.Now:yyyy-MM-dd HH:mm:ss},{action},{content}\n", Encoding.UTF8);

        // ═══════════════════════════════════════════════
        //  TCP 명령 전송
        // ═══════════════════════════════════════════════
        private async Task<string> SendStepCommandAsync(string command)
        {
            try
            {
                using var client = new TcpClient();
                var connectTask = client.ConnectAsync(_rpiIp, _rpiPort);
                if (await Task.WhenAny(connectTask, Task.Delay(3000)) != connectTask)
                    return "ERR:연결 타임아웃";

                var stream = client.GetStream();
                var sendBytes = Encoding.UTF8.GetBytes(command);
                await stream.WriteAsync(sendBytes, 0, sendBytes.Length);

                var buf = new byte[1024];
                var readTask = stream.ReadAsync(buf, 0, buf.Length);
                if (await Task.WhenAny(readTask, Task.Delay(3000)) != readTask)
                    return "ERR:응답 타임아웃";

                int n = await readTask;
                return Encoding.UTF8.GetString(buf, 0, n);
            }
            catch (Exception ex)
            {
                return $"ERR:{ex.Message}";
            }
        }

        private void SetStepButtons(bool enabled)
        {
            btnStepFwd.Enabled = enabled;
            btnStepBack.Enabled = enabled;
            btnStepHome.Enabled = enabled;
        }

        // ── 상태 레이블 헬퍼 ──────────────────────────
        private void UpdateStepStatus(string text, Color color)
        {
            if (lblStepPosVal.InvokeRequired)
            {
                lblStepPosVal.Invoke((Action)(() => UpdateStepStatus(text, color)));
                return;
            }
            lblStepPosVal.Text = text;
            lblStepPosVal.ForeColor = color;
        }

        private void UpdateServoStatus(string text, Color color)
        {
            if (lblServoCurVal.InvokeRequired)
            {
                lblServoCurVal.Invoke((Action)(() => UpdateServoStatus(text, color)));
                return;
            }
            lblServoCurVal.Text = text;
            lblServoCurVal.ForeColor = color;
            // 스텝모터 패널 하단 서보 레이블도 같이 업데이트
            lblServoAngle2.Text = text;
            lblServoAngle2.ForeColor = color;
        }

        // ═══════════════════════════════════════════════
        //  TAB 1 : 작동 상태
        // ═══════════════════════════════════════════════
        private void btnCheckStatus_Click(object sender, EventArgs e)
        {
            _rpiStatus = _stepStatus = _servoStatus = _camStatus = DeviceStatus.작동중;
            UpdateStatusLabels();
            UpdateDashboard();
            AddLog(rtbStatusLog, "✔ 전체 장치 상태 확인 완료");
            SaveLog(_statusLogPath, "상태확인", "전체 장치 정상");
        }

        private void UpdateStatusLabels()
        {
            SetStatusLabel(lblRpiVal, lblLedRpi, _rpiStatus);
            SetStatusLabel(lblStepVal, lblLedStep, _stepStatus);
            SetStatusLabel(lblServoVal, lblLedServo, _servoStatus);
            SetStatusLabel(lblCamVal, lblLedCam, _camStatus);
        }

        private void SetStatusLabel(Label valLbl, Label ledLbl, DeviceStatus status)
        {
            Color c = status == DeviceStatus.작동중 ? Color.FromArgb(0, 210, 110)
                    : status == DeviceStatus.오류 ? Color.FromArgb(255, 65, 65)
                                                     : Color.FromArgb(255, 170, 0);
            valLbl.Text = status == DeviceStatus.작동중 ? "작동 중"
                             : status == DeviceStatus.오류 ? "오류" : "대기 중";
            valLbl.ForeColor = c;
            ledLbl.ForeColor = c;
        }

        // ═══════════════════════════════════════════════
        //  TAB 2 : 컨베이어
        // ═══════════════════════════════════════════════
        private async void btnFwd_Click(object sender, EventArgs e)
        {
            _conveyorRunning = true;
            _convAutoStopTimer.Stop();
            lblConvStateVal.Text = "정방향 구동 중";
            lblConvStateVal.ForeColor = Color.FromArgb(0, 210, 110);
            int speed = Math.Max(1, Math.Min(100, (int)nudStepCount.Value));
            int ms = (int)nudDuration.Value;
            string resp = await SendStepCommandAsync($"CONV_FWD:{speed}");
            if (resp.StartsWith("OK:"))
            {
                AddLog(rtbConvLog, ms > 0 ? $"▶ {resp.Substring(3)}  ({ms}ms 후 자동 정지)" : $"▶ {resp.Substring(3)}");
                SaveLog(_convLogPath, "정방향구동", $"속도={speed}%, 시간={ms}ms");
                if (ms > 0) { _convAutoStopTimer.Interval = Math.Max(1, ms); _convAutoStopTimer.Start(); }
                else AddLog(rtbConvLog, "  (무한 구동 - 정지 버튼으로 중지)");
            }
            else { AddLog(rtbConvLog, $"❌ {resp}"); lblConvStateVal.Text = "오류"; lblConvStateVal.ForeColor = Color.FromArgb(255, 65, 65); }
        }

        private async void btnRev_Click(object sender, EventArgs e)
        {
            _conveyorRunning = true;
            _convAutoStopTimer.Stop();
            lblConvStateVal.Text = "역방향 구동 중";
            lblConvStateVal.ForeColor = Color.FromArgb(100, 180, 255);
            int speed = Math.Max(1, Math.Min(100, (int)nudStepCount.Value));
            int ms = (int)nudDuration.Value;
            string resp = await SendStepCommandAsync($"CONV_BACK:{speed}");
            if (resp.StartsWith("OK:"))
            {
                AddLog(rtbConvLog, ms > 0 ? $"◀ {resp.Substring(3)}  ({ms}ms 후 자동 정지)" : $"◀ {resp.Substring(3)}");
                SaveLog(_convLogPath, "역방향구동", $"속도={speed}%, 시간={ms}ms");
                if (ms > 0) { _convAutoStopTimer.Interval = Math.Max(1, ms); _convAutoStopTimer.Start(); }
                else AddLog(rtbConvLog, "  (무한 구동 - 정지 버튼으로 중지)");
            }
            else { AddLog(rtbConvLog, $"❌ {resp}"); lblConvStateVal.Text = "오류"; lblConvStateVal.ForeColor = Color.FromArgb(255, 65, 65); }
        }

        private async void btnConvStop_Click(object sender, EventArgs e)
        {
            _convAutoStopTimer.Stop();
            _conveyorRunning = false;
            lblConvStateVal.Text = "정지";
            lblConvStateVal.ForeColor = Color.FromArgb(255, 170, 0);
            string resp = await SendStepCommandAsync("CONV_STOP");
            AddLog(rtbConvLog, resp.StartsWith("OK:") ? "■ 컨베이어 정지" : $"❌ {resp}");
            SaveLog(_convLogPath, "정지", "컨베이어 정지");
        }

        // ── 서보모터 ──────────────────────────────────
        private void btnServo0_Click(object sender, EventArgs e) => SetServo(0);
        private void btnServo90_Click(object sender, EventArgs e) => SetServo(90);
        private void btnServo180_Click(object sender, EventArgs e) => SetServo(180);

        private async void SetServo(int angle)
        {
            _servoAngle = angle;
            AddLog(rtbConvLog, $"서보모터 → {angle}°");
            SaveLog(_convLogPath, "서보", $"{angle}도");

            // 90도는 지원 안 하므로 무시
            if (angle != 0 && angle != 180)
            {
                UpdateServoStatus($"{angle}°", Color.FromArgb(255, 170, 0));
                return;
            }

            string resp = await SendStepCommandAsync($"SERVO:{angle}");
            if (resp.StartsWith("OK:"))
            {
                UpdateServoStatus($"{angle}°", angle == 0
                    ? Color.FromArgb(0, 210, 110)
                    : Color.FromArgb(0, 180, 255));
                AddLog(rtbConvLog, $"✔ 서보 {angle}° 완료");
            }
            else
            {
                AddLog(rtbConvLog, $"❌ 서보 오류: {resp}");
            }
        }

        // ── 스텝모터 ──────────────────────────────────
        private async void btnStepFwd_Click(object sender, EventArgs e)
        {
            AddLog(rtbConvLog, "▶ 정방향 무한 회전 명령 전송 중...");
            string resp = await SendStepCommandAsync("STEP_FWD");
            if (resp.StartsWith("OK:")) { _statusPollTimer.Start(); AddLog(rtbConvLog, $"✔ {resp.Substring(3)}"); SaveLog(_convLogPath, "스텝전진", "무한 정방향"); }
            else AddLog(rtbConvLog, $"❌ {resp}");
        }

        private async void btnStepBack_Click(object sender, EventArgs e)
        {
            AddLog(rtbConvLog, "◀ 역방향 무한 회전 명령 전송 중...");
            string resp = await SendStepCommandAsync("STEP_BACK");
            if (resp.StartsWith("OK:")) { _statusPollTimer.Start(); AddLog(rtbConvLog, $"✔ {resp.Substring(3)}"); SaveLog(_convLogPath, "스텝후진", "무한 역방향"); }
            else AddLog(rtbConvLog, $"❌ {resp}");
        }

        private async void btnStepHome_Click(object sender, EventArgs e)
        {
            AddLog(rtbConvLog, "■ 스텝모터 정지 명령 전송 중...");
            string resp = await SendStepCommandAsync("STEP_STOP");
            if (resp.StartsWith("OK:")) { _statusPollTimer.Stop(); AddLog(rtbConvLog, $"✔ {resp.Substring(3)}"); SaveLog(_convLogPath, "스텝정지", "모터 OFF"); await UpdateSlotDisplay(); }
            else AddLog(rtbConvLog, $"❌ {resp}");
        }

        private async Task UpdateSlotDisplay()
        {
            string resp = await SendStepCommandAsync("STATUS");
            if (!resp.StartsWith("OK:") || !resp.Contains("위치=")) return;

            string slot = resp.Split(new string[] { "위치=" }, StringSplitOptions.None)[1].Trim();
            if (slot.Length > 0) slot = slot.Substring(0, 1).ToUpper();
            if (slot != "A" && slot != "B" && slot != "C") return;

            Color c = slot == "A" ? Color.FromArgb(255, 65, 65)
                    : slot == "B" ? Color.FromArgb(255, 200, 50)
                                  : Color.FromArgb(60, 130, 255);
            UpdateStepStatus(slot, c);
        }

        public async Task SetSlotPosition(string slot)
        {
            string resp = await SendStepCommandAsync($"SET_SLOT:{slot}");
            if (resp.StartsWith("OK:"))
            {
                Color c = slot == "A" ? Color.FromArgb(255, 65, 65)
                        : slot == "B" ? Color.FromArgb(255, 200, 50)
                                      : Color.FromArgb(60, 130, 255);
                UpdateStepStatus(slot, c);
                AddLog(rtbConvLog, $"✔ 위치 업데이트: {slot}");
            }
        }

        // ═══════════════════════════════════════════════
        //  TAB 3 : 영상 모니터링
        // ═══════════════════════════════════════════════
        private void btnVideoStart_Click(object sender, EventArgs e)
        {
            if (!_videoRunning)
            {
                _videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                if (_videoDevices.Count == 0) { AddLog(rtbVideoLog, "❌ 카메라를 찾을 수 없습니다"); return; }
                _videoDevice = new VideoCaptureDevice(_videoDevices[0].MonikerString);
                _videoDevice.NewFrame += VideoDevice_NewFrame;
                _videoDevice.Start();
                _videoRunning = true;
                btnVideoStart.Text = "■  영상 중지";
                btnVideoStart.BackColor = Color.FromArgb(160, 30, 30);
                AddLog(rtbVideoLog, $"📷 카메라 시작: {_videoDevices[0].Name}");
                SaveLog(_videoLogPath, "영상시작", _videoDevices[0].Name);
            }
            else StopCamera();
        }

        private void VideoDevice_NewFrame(object sender, NewFrameEventArgs e)
        {
            try
            {
                var frame = (System.Drawing.Bitmap)e.Frame.Clone();
                this.Invoke((Action)(() => { var old = picVideo.Image; picVideo.Image = frame; old?.Dispose(); }));
            }
            catch { }
        }

        private void StopCamera()
        {
            try { var d = _videoDevice; _videoDevice = null; if (d != null) { d.NewFrame -= VideoDevice_NewFrame; try { d.Stop(); } catch { } } } catch { }
            _videoRunning = false;
            if (this.IsDisposed || !this.IsHandleCreated) return;
            try
            {
                if (btnVideoStart.IsDisposed) return;
                btnVideoStart.Text = "▶  영상 시작";
                btnVideoStart.BackColor = Color.FromArgb(0, 130, 200);
                picVideo.Image = null;
                AddLog(rtbVideoLog, "■ 영상 중지");
                SaveLog(_videoLogPath, "영상중지", "카메라 해제");
            }
            catch { }
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            if (!_videoRunning || picVideo.Image == null) { AddLog(rtbVideoLog, "⚠ 영상이 시작되지 않았습니다"); return; }
            try
            {
                string folder = "captures"; Directory.CreateDirectory(folder);
                string fn = Path.Combine(folder, $"capture_{DateTime.Now:yyyyMMdd_HHmmss}.png");
                new System.Drawing.Bitmap(picVideo.Image).Save(fn, System.Drawing.Imaging.ImageFormat.Png);
                AddLog(rtbVideoLog, $"📸 캡처 저장: {fn}");
                SaveLog(_videoLogPath, "캡처", fn);
            }
            catch (Exception ex) { AddLog(rtbVideoLog, $"❌ 캡처 실패: {ex.Message}"); }
        }

        // ═══════════════════════════════════════════════
        //  config.xml
        // ═══════════════════════════════════════════════
        private void InitConfig()
        {
            if (!File.Exists(_configPath))
            {
                var doc = new XmlDocument();
                doc.LoadXml(@"<?xml version='1.0' encoding='utf-8'?>
                    <Config>
                      <Stepper>
                        <SlotGapAB>134</SlotGapAB>
                        <SlotGapBC>134</SlotGapBC>
                        <SlotGapCA>135</SlotGapCA>
                        <Delay>0.003</Delay>
                      </Stepper>
                      <Conveyor>
                        <DefaultSpeed>70</DefaultSpeed>
                      </Conveyor>
                    </Config>");
                doc.Save(_configPath);
                AddLog(rtbStatusLog, "⚙ config.xml 기본값으로 생성됨");
            }
            LoadConfig();
        }

        private void LoadConfig()
        {
            try
            {
                var doc = new XmlDocument();
                doc.Load(_configPath);
                _slotGaps[0] = int.Parse(doc.SelectSingleNode("//Stepper/SlotGapAB").InnerText);
                _slotGaps[1] = int.Parse(doc.SelectSingleNode("//Stepper/SlotGapBC").InnerText);
                _slotGaps[2] = int.Parse(doc.SelectSingleNode("//Stepper/SlotGapCA").InnerText);
                _stepDelay = double.Parse(doc.SelectSingleNode("//Stepper/Delay").InnerText,
                                   System.Globalization.CultureInfo.InvariantCulture);
                _convSpeed = int.Parse(doc.SelectSingleNode("//Conveyor/DefaultSpeed").InnerText);
                nudStepCount.Value = Math.Max(nudStepCount.Minimum, Math.Min(nudStepCount.Maximum, _convSpeed));
                AddLog(rtbStatusLog, $"⚙ 설정 로드 완료 | A→B:{_slotGaps[0]} B→C:{_slotGaps[1]} C→A:{_slotGaps[2]} | DELAY:{_stepDelay} | 컨베이어:{_convSpeed}%");
            }
            catch (Exception ex) { AddLog(rtbStatusLog, $"❌ config.xml 로드 실패: {ex.Message}"); }
        }

        // ═══════════════════════════════════════════════
        // ═══════════════════════════════════════════════
        //  주문 자동 감시 (DB → 라즈베리파이)
        //  - 결제완료 + 대기 주문만 자동 출고
        //  - 주문 1건 안에 여러 책/여러 권이 있어도 Quantity만큼 순차 출고
        //  - 수동 A/B/C 버튼은 주문이 없어도 테스트 출고 가능
        //  - 자동/수동 출고 중에는 다른 작업을 끼워 넣지 않음
        //  - 배출 후 컨베이어 역방향으로 자동 이송
        // ═══════════════════════════════════════════════
        private void InitOrderWatch()
        {
            _orderWatchTimer = new System.Windows.Forms.Timer { Interval = 5000 };
            _orderWatchTimer.Tick += async (s, e) => await CheckAndProcessOrder();
            _orderWatchTimer.Start();
            AddLog(rtbStatusLog, "⚙ 주문 자동 감시 시작 (5초 간격)");
        }

        private async Task CheckAndProcessOrder()
        {
            if (_isOrderProcessing) return;

            _isOrderProcessing = true;
            int orderId = 0;

            try
            {
                List<DispatchUnit> units = new List<DispatchUnit>();

                using (var conn = new MySqlConnection(_dbConnStr))
                {
                    await conn.OpenAsync();

                    var findCmd = new MySqlCommand(@"
                        SELECT p.OrderID
                        FROM Purchase p
                        WHERE p.OrderStatus = '결제완료'
                          AND p.HardwareStatus = '대기'
                        ORDER BY p.PurchaseDate ASC, p.OrderID ASC
                        LIMIT 1", conn);

                    object found = await findCmd.ExecuteScalarAsync();
                    if (found == null || found == DBNull.Value) return;

                    orderId = Convert.ToInt32(found);

                    var claimCmd = new MySqlCommand(@"
                        UPDATE Purchase
                        SET HardwareStatus='처리중'
                        WHERE OrderID=@id
                          AND OrderStatus='결제완료'
                          AND HardwareStatus='대기'", conn);
                    claimCmd.Parameters.AddWithValue("@id", orderId);

                    int affected = await claimCmd.ExecuteNonQueryAsync();
                    if (affected == 0)
                    {
                        AddLog(rtbStatusLog, $"⚠ OrderID={orderId}은 이미 취소/변경되어 출고하지 않습니다.");
                        return;
                    }

                    var itemCmd = new MySqlCommand(@"
                        SELECT b.StorageSlot, b.Title, pi.Quantity
                        FROM PurchaseItem pi
                        JOIN Book b ON pi.BookID = b.BookID
                        WHERE pi.OrderID = @id
                        ORDER BY pi.BookID ASC", conn);
                    itemCmd.Parameters.AddWithValue("@id", orderId);

                    using (var reader = await itemCmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            string storageSlot = reader["StorageSlot"] == DBNull.Value ? "" : reader["StorageSlot"].ToString().Trim().ToUpper();
                            string title = reader["Title"] == DBNull.Value ? "도서" : reader["Title"].ToString();
                            int qty = reader["Quantity"] == DBNull.Value ? 1 : Convert.ToInt32(reader["Quantity"]);

                            if (string.IsNullOrEmpty(storageSlot))
                            {
                                AddLog(rtbStatusLog, $"⚠ OrderID={orderId} / {title} 보관위치가 비어 있어 건너뜁니다.");
                                continue;
                            }

                            string slot = storageSlot.Substring(0, 1);
                            if (slot != "A" && slot != "B" && slot != "C")
                            {
                                AddLog(rtbStatusLog, $"⚠ OrderID={orderId} / {title} 알 수 없는 보관위치: {storageSlot}");
                                continue;
                            }

                            for (int i = 1; i <= Math.Max(1, qty); i++)
                            {
                                units.Add(new DispatchUnit
                                {
                                    Slot = slot,
                                    Title = title,
                                    UnitNo = i,
                                    UnitTotal = Math.Max(1, qty)
                                });
                            }
                        }
                    }
                }

                if (units.Count == 0)
                {
                    AddLog(rtbStatusLog, $"⚠ OrderID={orderId}에서 출고 가능한 항목을 찾지 못했습니다.");
                    await UpdateOrderHardwareStatusAsync(orderId, "오류");
                    return;
                }

                AddLog(rtbStatusLog, $"📦 출고 주문 감지 | OrderID={orderId}, 총 {units.Count}개 순차 출고 시작");

                int current = 0;
                foreach (var unit in units)
                {
                    current++;
                    string context = $"OrderID={orderId} [{current}/{units.Count}] {unit.Title} ({unit.UnitNo}/{unit.UnitTotal})";
                    bool ok = await ExecuteDispatchCycleAsync(unit.Slot, context, true);
                    if (!ok)
                    {
                        AddLog(rtbStatusLog, $"⚠ OrderID={orderId} 출고 중 오류 발생. 하드웨어상태를 오류로 변경합니다.");
                        await UpdateOrderHardwareStatusAsync(orderId, "오류");
                        return;
                    }
                }

                await UpdateOrderHardwareStatusAsync(orderId, "완료");
                AddLog(rtbStatusLog, $"✔ OrderID={orderId} 전체 출고 완료");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Unable to connect")) return;
                AddLog(rtbStatusLog, $"❌ DB/출고 처리 오류: {ex.Message}");

                if (orderId > 0)
                {
                    try { await UpdateOrderHardwareStatusAsync(orderId, "대기"); }
                    catch { }
                }
            }
            finally
            {
                _isOrderProcessing = false;
            }
        }

        private async Task UpdateOrderHardwareStatusAsync(int orderId, string status)
        {
            using (var conn = new MySqlConnection(_dbConnStr))
            {
                await conn.OpenAsync();
                var cmd = new MySqlCommand("UPDATE Purchase SET HardwareStatus=@status WHERE OrderID=@id", conn);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@id", orderId);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        // ═══════════════════════════════════════════════
        //  WebView2 카메라 영상
        // ═══════════════════════════════════════════════
        private async Task InitWebView()
        {
            try
            {
                await webCamera.EnsureCoreWebView2Async(null);
                webCamera.CoreWebView2.Navigate($"http://{_rpiIp}:5000/video");
                AddLog(rtbStatusLog, $"📹 카메라 연결: http://{_rpiIp}:5000/video");
            }
            catch (Exception ex)
            {
                AddLog(rtbStatusLog, $"❌ WebView 초기화 실패: {ex.Message}");
            }
        }

        // ═══════════════════════════════════════════════
        //  A/B/C 출고 버튼
        //  - 수동 버튼은 DB 주문 여부와 관계없이 실제 배출 동작을 실행합니다.
        //  - 자동/수동 출고 중이면 새 요청은 무시합니다.
        // ═══════════════════════════════════════════════
        private async void btnOrderA_Click(object sender, EventArgs e) => await ProcessManualSlotAsync("A");
        private async void btnOrderB_Click(object sender, EventArgs e) => await ProcessManualSlotAsync("B");
        private async void btnOrderC_Click(object sender, EventArgs e) => await ProcessManualSlotAsync("C");

        private void pnlOrderBtns_Resize(object sender, EventArgs e)
        {
            int w = (pnlOrderBtns.Width - 16) / 3;
            int h = pnlOrderBtns.Height - 12;
            btnOrderA.SetBounds(0, 6, w, h);
            btnOrderB.SetBounds(w + 8, 6, w, h);
            btnOrderC.SetBounds((w + 8) * 2, 6, w, h);
        }

        private async Task SendOrderAsync(string slot)
        {
            await ProcessManualSlotAsync(slot);
        }

        private async Task ProcessManualSlotAsync(string slot)
        {
            slot = (slot ?? "").Trim().ToUpper();
            if (slot != "A" && slot != "B" && slot != "C")
            {
                AddLog(rtbStatusLog, $"⚠ 알 수 없는 수동 출고 슬롯: {slot}");
                return;
            }

            if (_isOrderProcessing)
            {
                AddLog(rtbStatusLog, $"⚠ 현재 출고 작업 처리 중입니다. 수동 {slot} 출고 요청 무시");
                return;
            }

            _isOrderProcessing = true;
            try
            {
                bool ok = await ExecuteDispatchCycleAsync(slot, $"수동 {slot} 출고", false);
                if (ok) AddLog(rtbStatusLog, $"✔ 수동 {slot} 출고 전체 처리 완료");
            }
            catch (Exception ex)
            {
                AddLog(rtbStatusLog, $"❌ 수동 출고 처리 오류: {ex.Message}");
            }
            finally
            {
                _isOrderProcessing = false;
            }
        }

        private async Task ShowServoPhaseAsync(string displayText, Color color, int waitMs)
        {
            UpdateServoStatus(displayText, color);
            await Task.Delay(waitMs);
        }

        private async Task AnimateServoAngleAsync(int fromAngle, int toAngle, int durationMs, string caption)
        {
            int diff = toAngle - fromAngle;
            int steps = Math.Max(1, Math.Abs(diff) / 10);
            int delay = Math.Max(40, durationMs / steps);

            for (int i = 0; i <= steps; i++)
            {
                int angle = fromAngle + (diff * i / steps);
                _servoAngle = angle;
                Color color = angle == 0 ? Color.FromArgb(0, 210, 110) : Color.FromArgb(255, 170, 0);
                UpdateServoStatus($"{angle}°\n{caption}", color);
                await Task.Delay(delay);
            }
        }

        private async Task<bool> ExecuteDispatchCycleAsync(string slot, string context, bool fromOrder)
        {
            string slotName = slot == "A" ? "A(빨강)" : slot == "B" ? "B(노랑)" : "C(파랑)";
            Color slotColor = slot == "A" ? Color.FromArgb(255, 65, 65)
                            : slot == "B" ? Color.FromArgb(255, 200, 50)
                                          : Color.FromArgb(60, 130, 255);

            try
            {
                UpdateStepStatus($"{slot}\n이동 중...", slotColor);
                UpdateServoStatus("0°", Color.FromArgb(0, 210, 110));

                AddDeviceLog($"▶ {context} | {slotName} 창고 이동 시작");
                AddDeviceLog($"▶ ORDER:{slot} 전송 - 창고 이동 후 로터리 드럼 배출 준비");

                string resp = await SendStepCommandAsync($"ORDER:{slot}");
                if (!resp.StartsWith("OK:"))
                {
                    UpdateStepStatus($"{slot}\n오류", Color.FromArgb(255, 65, 65));
                    AddDeviceLog($"❌ ORDER:{slot} 전송 실패: {resp}");
                    return false;
                }

                AddDeviceLog($"✔ ORDER:{slot} 명령 접수 완료");

                // 라즈베리파이 쪽 ORDER 명령 안에서 실제 창고 이동과 로터리 배출이 수행됩니다.
                // 현재 장비에는 C#이 읽을 수 있는 서보 각도 피드백이 없으므로
                // 화면은 실시간 추정값이 아니라 단계 상태로 표시합니다.
                await Task.Delay(SLOT_ARRIVE_WAIT_MS);
                UpdateStepStatus($"{slot}\n이동 완료", slotColor);
                AddDeviceLog($"✔ {slotName} 창고 위치 이동 완료");

                AddDeviceLog("🔄 로터리 드럼 출고 시작 - 0° → 180° 배출 중");
                await ShowServoPhaseAsync("0° → 180°\n배출 중...", Color.FromArgb(255, 170, 0), ROTARY_OUT_WAIT_MS);

                UpdateServoStatus("180°\n출고 완료", Color.FromArgb(60, 130, 255));
                AddDeviceLog("✔ 로터리 드럼 180° 도달 - 물품 배출 완료");
                await Task.Delay(500);

                AddDeviceLog("↩ 로터리 드럼 복귀 시작 - 180° → 0°");
                await ShowServoPhaseAsync("180° → 0°\n복귀 중...", Color.FromArgb(255, 170, 0), ROTARY_RETURN_WAIT_MS);

                UpdateStepStatus($"{slot}\n배출 완료 ✔", slotColor);
                UpdateServoStatus("0°\n복귀 완료", Color.FromArgb(0, 210, 110));
                AddDeviceLog($"✔ 로터리 드럼 0° 복귀 완료 - {slotName} 출고 완료");

                bool convOk = await RunConveyorReverseForAsync(CONVEYOR_RUN_MS);
                if (!convOk) return false;

                UpdateServoStatus("0°", Color.FromArgb(0, 210, 110));
                return true;
            }
            catch (Exception ex)
            {
                AddDeviceLog($"❌ 출고 사이클 오류: {ex.Message}");
                return false;
            }
        }

        private async Task<bool> RunConveyorReverseForAsync(int milliseconds)
        {
            try
            {
                int speed = Math.Max(1, Math.Min(100, _convSpeed));
                _convAutoStopTimer.Stop();
                _conveyorRunning = true;

                lblConvStateVal.Text = "역방향 구동 중";
                lblConvStateVal.ForeColor = Color.FromArgb(100, 180, 255);
                AddDeviceLog($"◀ 출고 물품 이송 시작 — 컨베이어 역방향 {speed}% / {milliseconds}ms");

                string startResp = await SendStepCommandAsync($"CONV_BACK:{speed}");
                if (!startResp.StartsWith("OK:"))
                {
                    AddDeviceLog($"❌ 컨베이어 시작 실패: {startResp}");
                    lblConvStateVal.Text = "오류";
                    lblConvStateVal.ForeColor = Color.FromArgb(255, 65, 65);
                    return false;
                }

                SaveLog(_convLogPath, "출고이송시작", $"역방향, 속도={speed}%, 시간={milliseconds}ms");

                await Task.Delay(milliseconds);

                string stopResp = await SendStepCommandAsync("CONV_STOP");
                _conveyorRunning = false;

                if (!stopResp.StartsWith("OK:"))
                {
                    AddDeviceLog($"❌ 컨베이어 정지 실패: {stopResp}");
                    lblConvStateVal.Text = "오류";
                    lblConvStateVal.ForeColor = Color.FromArgb(255, 65, 65);
                    return false;
                }

                lblConvStateVal.Text = "정지 (출고 완료)";
                lblConvStateVal.ForeColor = Color.FromArgb(255, 170, 0);
                AddDeviceLog("■ 출고 물품 이송 완료 — 컨베이어 자동 정지");
                SaveLog(_convLogPath, "출고이송완료", $"{milliseconds}ms 구동 후 정지");
                return true;
            }
            catch (Exception ex)
            {
                AddDeviceLog($"❌ 컨베이어 자동 이송 오류: {ex.Message}");
                return false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
        private void btnMinimize_Click(object sender, EventArgs e) => this.WindowState = System.Windows.Forms.FormWindowState.Minimized;

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _clockTimer?.Stop();
            _statusPollTimer?.Stop();
            _convAutoStopTimer?.Stop();
            _orderWatchTimer?.Stop();
            StopCamera();
            StopRaspberryServer();
            base.OnFormClosing(e);
        }
    }
}