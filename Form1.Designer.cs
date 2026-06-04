namespace HardwareManagement
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            var cBgDark = System.Drawing.Color.FromArgb(10, 12, 20);
            var cBgCard = System.Drawing.Color.FromArgb(18, 22, 36);
            var cBgInput = System.Drawing.Color.FromArgb(26, 32, 52);
            var cAccent = System.Drawing.Color.FromArgb(0, 180, 255);
            var cSuccess = System.Drawing.Color.FromArgb(0, 210, 110);
            var cWarning = System.Drawing.Color.FromArgb(255, 170, 0);
            var cText = System.Drawing.Color.FromArgb(210, 220, 240);
            var cSubText = System.Drawing.Color.FromArgb(90, 110, 155);
            var cBtnFwd = System.Drawing.Color.FromArgb(0, 130, 200);
            var cBtnStop = System.Drawing.Color.FromArgb(160, 30, 30);
            var cBtnNeu = System.Drawing.Color.FromArgb(35, 45, 70);

            var fontTitle = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            var fontSub = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            var fontSubSm = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            var fontBody = new System.Drawing.Font("Segoe UI", 10F);
            var fontSmall = new System.Drawing.Font("Segoe UI", 9F);
            var fontConsole = new System.Drawing.Font("Consolas", 9.5F);
            var fontBig = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold);
            var fontMid = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            var fontLed = new System.Drawing.Font("Segoe UI", 16F);

            // ── 컨트롤 생성 ──────────────────────────────
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlHeaderLine = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.tabMain = new System.Windows.Forms.TabControl();

            // Tab1
            this.tabStatus = new System.Windows.Forms.TabPage();
            this.pnlStatusTop = new System.Windows.Forms.Panel();
            this.pnlStatusLeft = new System.Windows.Forms.Panel();
            this.lblStatusTitle = new System.Windows.Forms.Label();
            this.pnlCardRpi = new System.Windows.Forms.Panel();
            this.lblLedRpi = new System.Windows.Forms.Label();
            this.lblRpiKey = new System.Windows.Forms.Label();
            this.lblRpiVal = new System.Windows.Forms.Label();
            this.pnlCardStep = new System.Windows.Forms.Panel();
            this.lblLedStep = new System.Windows.Forms.Label();
            this.lblStepKey = new System.Windows.Forms.Label();
            this.lblStepVal = new System.Windows.Forms.Label();
            this.pnlCardServo = new System.Windows.Forms.Panel();
            this.lblLedServo = new System.Windows.Forms.Label();
            this.lblServoKey = new System.Windows.Forms.Label();
            this.lblServoVal = new System.Windows.Forms.Label();
            this.pnlCardCam = new System.Windows.Forms.Panel();
            this.lblLedCam = new System.Windows.Forms.Label();
            this.lblCamKey = new System.Windows.Forms.Label();
            this.lblCamVal = new System.Windows.Forms.Label();
            this.btnCheckStatus = new System.Windows.Forms.Button();
            this.pnlStatusRight = new System.Windows.Forms.Panel();
            this.lblDashHeader = new System.Windows.Forms.Label();
            this.tblDash = new System.Windows.Forms.TableLayoutPanel();
            this.pnlDash1 = new System.Windows.Forms.Panel();
            this.lblDashTtl1 = new System.Windows.Forms.Label();
            this.lblDashVal1 = new System.Windows.Forms.Label();
            this.pnlDash2 = new System.Windows.Forms.Panel();
            this.lblDashTtl2 = new System.Windows.Forms.Label();
            this.lblDashVal2 = new System.Windows.Forms.Label();
            this.pnlDash3 = new System.Windows.Forms.Panel();
            this.lblDashTtl3 = new System.Windows.Forms.Label();
            this.lblDashVal3 = new System.Windows.Forms.Label();
            this.pnlDash4 = new System.Windows.Forms.Panel();
            this.lblDashTtl4 = new System.Windows.Forms.Label();
            this.lblDashVal4 = new System.Windows.Forms.Label();
            this.pnlStatus1Log = new System.Windows.Forms.Panel();
            this.lblLogTitle1 = new System.Windows.Forms.Label();
            this.rtbStatusLog = new System.Windows.Forms.RichTextBox();

            // Tab2
            this.tabConveyor = new System.Windows.Forms.TabPage();
            this.pnlConvBottom = new System.Windows.Forms.Panel();
            this.lblConvLogTitle = new System.Windows.Forms.Label();
            this.rtbConvLog = new System.Windows.Forms.RichTextBox();
            this.tblConv = new System.Windows.Forms.TableLayoutPanel();

            // 컨베이어 GroupBox
            this.grpConvFull = new System.Windows.Forms.GroupBox();
            this.tblConvInner = new System.Windows.Forms.TableLayoutPanel();
            this.lblConvState = new System.Windows.Forms.Label();
            this.lblConvStateVal = new System.Windows.Forms.Label();
            this.lblStepCount = new System.Windows.Forms.Label();
            this.nudStepCount = new System.Windows.Forms.NumericUpDown();
            this.lblDuration = new System.Windows.Forms.Label();
            this.nudDuration = new System.Windows.Forms.NumericUpDown();
            this.pnlConvBtns = new System.Windows.Forms.Panel();
            this.btnFwd = new System.Windows.Forms.Button();
            this.btnRev = new System.Windows.Forms.Button();
            this.btnConvStop = new System.Windows.Forms.Button();

            // 영상 모니터링 GroupBox (기존 grpServoFull 재활용)
            this.grpServoFull = new System.Windows.Forms.GroupBox();
            this.tblServoInner = new System.Windows.Forms.TableLayoutPanel();
            this.lblServoCur = new System.Windows.Forms.Label();
            this.lblServoCurVal = new System.Windows.Forms.Label();
            this.pnlServoBtns = new System.Windows.Forms.Panel();
            this.btnServo0 = new System.Windows.Forms.Button();
            this.btnServo90 = new System.Windows.Forms.Button();
            this.btnServo180 = new System.Windows.Forms.Button();

            // 스텝모터 + 서보모터 통합 GroupBox
            this.grpStepFull = new System.Windows.Forms.GroupBox();
            this.tblStepInner = new System.Windows.Forms.TableLayoutPanel();
            this.lblStepPos = new System.Windows.Forms.Label();
            this.lblStepPosVal = new System.Windows.Forms.Label();
            this.btnStepFwd = new System.Windows.Forms.Button();
            this.btnStepBack = new System.Windows.Forms.Button();
            this.btnStepHome = new System.Windows.Forms.Button();
            // 서보모터 (스텝모터 패널 하단)
            this.pnlServoDivider = new System.Windows.Forms.Panel();
            this.lblServoTitle2 = new System.Windows.Forms.Label();
            this.lblServoAngle2 = new System.Windows.Forms.Label();
            this.pnlServoBtns2 = new System.Windows.Forms.Panel();
            this.btnServo0_2 = new System.Windows.Forms.Button();
            this.btnServo180_2 = new System.Windows.Forms.Button();

            // WebView2 카메라 + A/B/C 주문 버튼
            this.webCamera = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.pnlOrderBtns = new System.Windows.Forms.Panel();
            this.btnOrderA = new System.Windows.Forms.Button();
            this.btnOrderB = new System.Windows.Forms.Button();
            this.btnOrderC = new System.Windows.Forms.Button();

            // Tab3
            this.tabVideo = new System.Windows.Forms.TabPage();
            this.lblVideoTitle = new System.Windows.Forms.Label();
            this.pnlVideoBtn = new System.Windows.Forms.Panel();
            this.btnVideoStart = new System.Windows.Forms.Button();
            this.btnCapture = new System.Windows.Forms.Button();
            this.lblVideoLogTitle = new System.Windows.Forms.Label();
            this.rtbVideoLog = new System.Windows.Forms.RichTextBox();
            this.picVideo = new System.Windows.Forms.PictureBox();

            this.pnlHeader.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabStatus.SuspendLayout();
            this.pnlStatusTop.SuspendLayout(); this.pnlStatusLeft.SuspendLayout();
            this.pnlCardRpi.SuspendLayout(); this.pnlCardStep.SuspendLayout();
            this.pnlCardServo.SuspendLayout(); this.pnlCardCam.SuspendLayout();
            this.pnlStatusRight.SuspendLayout();
            this.tblDash.SuspendLayout();
            this.pnlDash1.SuspendLayout(); this.pnlDash2.SuspendLayout();
            this.pnlDash3.SuspendLayout(); this.pnlDash4.SuspendLayout();
            this.pnlStatus1Log.SuspendLayout();
            this.tabConveyor.SuspendLayout();
            this.pnlConvBottom.SuspendLayout();
            this.tblConv.SuspendLayout();
            this.grpConvFull.SuspendLayout(); this.tblConvInner.SuspendLayout(); this.pnlConvBtns.SuspendLayout();
            this.grpServoFull.SuspendLayout(); this.tblServoInner.SuspendLayout(); this.pnlServoBtns.SuspendLayout();
            this.grpStepFull.SuspendLayout(); this.tblStepInner.SuspendLayout();
            this.tabVideo.SuspendLayout(); this.pnlVideoBtn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStepCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVideo)).BeginInit();
            this.SuspendLayout();

            // ══ FORM ══
            this.Text = "하드웨어 관리 시스템";
            this.MinimumSize = new System.Drawing.Size(1200, 800);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Font = fontBody; this.BackColor = cBgDark;

            // ══ HEADER ══
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top; this.pnlHeader.Height = 68; this.pnlHeader.BackColor = cBgCard;
            this.pnlHeaderLine.Dock = System.Windows.Forms.DockStyle.Bottom; this.pnlHeaderLine.Height = 2; this.pnlHeaderLine.BackColor = cAccent;
            this.lblTitle.Text = "⬡  하드웨어 관리 시스템"; this.lblTitle.Font = fontTitle; this.lblTitle.ForeColor = cText; this.lblTitle.AutoSize = true; this.lblTitle.Location = new System.Drawing.Point(20, 14);
            this.lblDateTime.Text = ""; this.lblDateTime.Font = new System.Drawing.Font("Consolas", 11F); this.lblDateTime.ForeColor = cSubText; this.lblDateTime.AutoSize = true;
            this.lblDateTime.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right; this.lblDateTime.Location = new System.Drawing.Point(1100, 22);

            this.btnClose.Text = "✕"; this.btnClose.Size = new System.Drawing.Size(52, 68); this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(18, 22, 36); this.btnClose.ForeColor = System.Drawing.Color.FromArgb(200, 210, 230); this.btnClose.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.btnClose.FlatAppearance.BorderSize = 0; this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(196, 43, 28);
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand; this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            this.btnMinimize.Text = "─"; this.btnMinimize.Size = new System.Drawing.Size(52, 68); this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.BackColor = System.Drawing.Color.FromArgb(18, 22, 36); this.btnMinimize.ForeColor = System.Drawing.Color.FromArgb(200, 210, 230); this.btnMinimize.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.btnMinimize.FlatAppearance.BorderSize = 0; this.btnMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(38, 48, 78);
            this.btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand; this.btnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);

            this.pnlHeader.Controls.Add(this.pnlHeaderLine); this.pnlHeader.Controls.Add(this.lblTitle); this.pnlHeader.Controls.Add(this.lblDateTime);
            this.pnlHeader.Controls.Add(this.btnMinimize); this.pnlHeader.Controls.Add(this.btnClose);

            // ══ TAB CONTROL ══
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill; this.tabMain.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.tabMain.Padding = new System.Drawing.Point(20, 8); this.tabMain.BackColor = cBgDark;
            this.tabMain.TabPages.AddRange(new System.Windows.Forms.TabPage[] { this.tabStatus, this.tabConveyor });

            // ══════════ TAB 1 ══════════
            this.tabStatus.Text = "  작동 상태  "; this.tabStatus.BackColor = cBgDark;
            this.pnlStatus1Log.Dock = System.Windows.Forms.DockStyle.Bottom; this.pnlStatus1Log.Height = 190; this.pnlStatus1Log.BackColor = cBgDark;
            this.lblLogTitle1.Text = "시스템 로그"; this.lblLogTitle1.Font = fontSubSm; this.lblLogTitle1.ForeColor = cAccent; this.lblLogTitle1.Dock = System.Windows.Forms.DockStyle.Top; this.lblLogTitle1.Height = 28; this.lblLogTitle1.TextAlign = System.Drawing.ContentAlignment.BottomLeft; this.lblLogTitle1.Padding = new System.Windows.Forms.Padding(6, 0, 0, 2); this.lblLogTitle1.BackColor = cBgDark;
            this.rtbStatusLog.Dock = System.Windows.Forms.DockStyle.Fill; this.rtbStatusLog.ReadOnly = true; this.rtbStatusLog.BackColor = cBgCard; this.rtbStatusLog.ForeColor = cText; this.rtbStatusLog.Font = fontConsole; this.rtbStatusLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pnlStatus1Log.Controls.Add(this.rtbStatusLog); this.pnlStatus1Log.Controls.Add(this.lblLogTitle1);
            this.pnlStatusTop.Dock = System.Windows.Forms.DockStyle.Fill; this.pnlStatusTop.BackColor = cBgDark;
            this.pnlStatusLeft.Dock = System.Windows.Forms.DockStyle.Left; this.pnlStatusLeft.Width = 600; this.pnlStatusLeft.BackColor = cBgDark;
            this.lblStatusTitle.Text = "장치 상태 모니터링"; this.lblStatusTitle.Font = fontSub; this.lblStatusTitle.ForeColor = cAccent; this.lblStatusTitle.AutoSize = true; this.lblStatusTitle.Location = new System.Drawing.Point(24, 18);

            this.pnlCardRpi.Location = new System.Drawing.Point(24, 55); this.pnlCardRpi.Size = new System.Drawing.Size(540, 52); this.pnlCardRpi.BackColor = cBgCard;
            this.pnlCardStep.Location = new System.Drawing.Point(24, 119); this.pnlCardStep.Size = new System.Drawing.Size(540, 52); this.pnlCardStep.BackColor = cBgCard;
            this.pnlCardServo.Location = new System.Drawing.Point(24, 183); this.pnlCardServo.Size = new System.Drawing.Size(540, 52); this.pnlCardServo.BackColor = cBgCard;
            this.pnlCardCam.Location = new System.Drawing.Point(24, 247); this.pnlCardCam.Size = new System.Drawing.Size(540, 52); this.pnlCardCam.BackColor = cBgCard;

            this.lblLedRpi.Text = "●"; this.lblLedRpi.Font = fontLed; this.lblLedRpi.ForeColor = cWarning; this.lblLedRpi.Location = new System.Drawing.Point(14, 10); this.lblLedRpi.AutoSize = true;
            this.lblRpiKey.Text = "라즈베리파이"; this.lblRpiKey.Font = fontBody; this.lblRpiKey.ForeColor = cSubText; this.lblRpiKey.Location = new System.Drawing.Point(48, 16); this.lblRpiKey.AutoSize = true;
            this.lblRpiVal.Text = "대기 중"; this.lblRpiVal.Font = fontSubSm; this.lblRpiVal.ForeColor = cWarning; this.lblRpiVal.Location = new System.Drawing.Point(240, 16); this.lblRpiVal.AutoSize = true;
            this.lblLedStep.Text = "●"; this.lblLedStep.Font = fontLed; this.lblLedStep.ForeColor = cWarning; this.lblLedStep.Location = new System.Drawing.Point(14, 10); this.lblLedStep.AutoSize = true;
            this.lblStepKey.Text = "스텝 모터"; this.lblStepKey.Font = fontBody; this.lblStepKey.ForeColor = cSubText; this.lblStepKey.Location = new System.Drawing.Point(48, 16); this.lblStepKey.AutoSize = true;
            this.lblStepVal.Text = "대기 중"; this.lblStepVal.Font = fontSubSm; this.lblStepVal.ForeColor = cWarning; this.lblStepVal.Location = new System.Drawing.Point(240, 16); this.lblStepVal.AutoSize = true;
            this.lblLedServo.Text = "●"; this.lblLedServo.Font = fontLed; this.lblLedServo.ForeColor = cWarning; this.lblLedServo.Location = new System.Drawing.Point(14, 10); this.lblLedServo.AutoSize = true;
            this.lblServoKey.Text = "서보모터"; this.lblServoKey.Font = fontBody; this.lblServoKey.ForeColor = cSubText; this.lblServoKey.Location = new System.Drawing.Point(48, 16); this.lblServoKey.AutoSize = true;
            this.lblServoVal.Text = "대기 중"; this.lblServoVal.Font = fontSubSm; this.lblServoVal.ForeColor = cWarning; this.lblServoVal.Location = new System.Drawing.Point(240, 16); this.lblServoVal.AutoSize = true;
            this.lblLedCam.Text = "●"; this.lblLedCam.Font = fontLed; this.lblLedCam.ForeColor = cWarning; this.lblLedCam.Location = new System.Drawing.Point(14, 10); this.lblLedCam.AutoSize = true;
            this.lblCamKey.Text = "카메라"; this.lblCamKey.Font = fontBody; this.lblCamKey.ForeColor = cSubText; this.lblCamKey.Location = new System.Drawing.Point(48, 16); this.lblCamKey.AutoSize = true;
            this.lblCamVal.Text = "대기 중"; this.lblCamVal.Font = fontSubSm; this.lblCamVal.ForeColor = cWarning; this.lblCamVal.Location = new System.Drawing.Point(240, 16); this.lblCamVal.AutoSize = true;

            this.pnlCardRpi.Controls.Add(this.lblLedRpi); this.pnlCardRpi.Controls.Add(this.lblRpiKey); this.pnlCardRpi.Controls.Add(this.lblRpiVal);
            this.pnlCardStep.Controls.Add(this.lblLedStep); this.pnlCardStep.Controls.Add(this.lblStepKey); this.pnlCardStep.Controls.Add(this.lblStepVal);
            this.pnlCardServo.Controls.Add(this.lblLedServo); this.pnlCardServo.Controls.Add(this.lblServoKey); this.pnlCardServo.Controls.Add(this.lblServoVal);
            this.pnlCardCam.Controls.Add(this.lblLedCam); this.pnlCardCam.Controls.Add(this.lblCamKey); this.pnlCardCam.Controls.Add(this.lblCamVal);

            this.btnCheckStatus.Text = "▶  상태 확인"; this.btnCheckStatus.Size = new System.Drawing.Size(180, 46); this.btnCheckStatus.Location = new System.Drawing.Point(24, 325);
            this.btnCheckStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnCheckStatus.BackColor = cBtnFwd; this.btnCheckStatus.ForeColor = cText; this.btnCheckStatus.Font = fontSubSm; this.btnCheckStatus.FlatAppearance.BorderSize = 0; this.btnCheckStatus.Cursor = System.Windows.Forms.Cursors.Hand; this.btnCheckStatus.Click += new System.EventHandler(this.btnCheckStatus_Click);
            this.pnlStatusLeft.Controls.Add(this.lblStatusTitle); this.pnlStatusLeft.Controls.Add(this.pnlCardRpi); this.pnlStatusLeft.Controls.Add(this.pnlCardStep); this.pnlStatusLeft.Controls.Add(this.pnlCardServo); this.pnlStatusLeft.Controls.Add(this.pnlCardCam); this.pnlStatusLeft.Controls.Add(this.btnCheckStatus);

            this.pnlStatusRight.Dock = System.Windows.Forms.DockStyle.Fill; this.pnlStatusRight.BackColor = cBgDark; this.pnlStatusRight.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.lblDashHeader.Text = "시스템 요약"; this.lblDashHeader.Font = fontSub; this.lblDashHeader.ForeColor = cAccent; this.lblDashHeader.Dock = System.Windows.Forms.DockStyle.Top; this.lblDashHeader.Height = 44; this.lblDashHeader.TextAlign = System.Drawing.ContentAlignment.BottomLeft; this.lblDashHeader.BackColor = cBgDark;
            this.tblDash.Dock = System.Windows.Forms.DockStyle.Fill; this.tblDash.BackColor = cBgDark; this.tblDash.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.None; this.tblDash.ColumnCount = 2; this.tblDash.RowCount = 2;
            this.tblDash.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F)); this.tblDash.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblDash.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F)); this.tblDash.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));

            this.pnlDash1.Dock = System.Windows.Forms.DockStyle.Fill; this.pnlDash1.BackColor = cBgCard; this.pnlDash1.Margin = new System.Windows.Forms.Padding(8);
            this.lblDashTtl1.Text = "전체 장치"; this.lblDashTtl1.Font = fontSmall; this.lblDashTtl1.ForeColor = cSubText; this.lblDashTtl1.Dock = System.Windows.Forms.DockStyle.Top; this.lblDashTtl1.Height = 30; this.lblDashTtl1.TextAlign = System.Drawing.ContentAlignment.BottomLeft; this.lblDashTtl1.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0); this.lblDashTtl1.BackColor = cBgCard;
            this.lblDashVal1.Text = "4"; this.lblDashVal1.Font = fontBig; this.lblDashVal1.ForeColor = cText; this.lblDashVal1.Dock = System.Windows.Forms.DockStyle.Fill; this.lblDashVal1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter; this.lblDashVal1.BackColor = cBgCard;
            this.pnlDash1.Controls.Add(this.lblDashVal1); this.pnlDash1.Controls.Add(this.lblDashTtl1);

            this.pnlDash2.Dock = System.Windows.Forms.DockStyle.Fill; this.pnlDash2.BackColor = cBgCard; this.pnlDash2.Margin = new System.Windows.Forms.Padding(8);
            this.lblDashTtl2.Text = "정상 장치"; this.lblDashTtl2.Font = fontSmall; this.lblDashTtl2.ForeColor = cSubText; this.lblDashTtl2.Dock = System.Windows.Forms.DockStyle.Top; this.lblDashTtl2.Height = 30; this.lblDashTtl2.TextAlign = System.Drawing.ContentAlignment.BottomLeft; this.lblDashTtl2.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0); this.lblDashTtl2.BackColor = cBgCard;
            this.lblDashVal2.Text = "0 / 4"; this.lblDashVal2.Font = fontBig; this.lblDashVal2.ForeColor = cWarning; this.lblDashVal2.Dock = System.Windows.Forms.DockStyle.Fill; this.lblDashVal2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter; this.lblDashVal2.BackColor = cBgCard;
            this.pnlDash2.Controls.Add(this.lblDashVal2); this.pnlDash2.Controls.Add(this.lblDashTtl2);

            this.pnlDash3.Dock = System.Windows.Forms.DockStyle.Fill; this.pnlDash3.BackColor = cBgCard; this.pnlDash3.Margin = new System.Windows.Forms.Padding(8);
            this.lblDashTtl3.Text = "알람 현황"; this.lblDashTtl3.Font = fontSmall; this.lblDashTtl3.ForeColor = cSubText; this.lblDashTtl3.Dock = System.Windows.Forms.DockStyle.Top; this.lblDashTtl3.Height = 30; this.lblDashTtl3.TextAlign = System.Drawing.ContentAlignment.BottomLeft; this.lblDashTtl3.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0); this.lblDashTtl3.BackColor = cBgCard;
            this.lblDashVal3.Text = "없음"; this.lblDashVal3.Font = fontBig; this.lblDashVal3.ForeColor = cSuccess; this.lblDashVal3.Dock = System.Windows.Forms.DockStyle.Fill; this.lblDashVal3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter; this.lblDashVal3.BackColor = cBgCard;
            this.pnlDash3.Controls.Add(this.lblDashVal3); this.pnlDash3.Controls.Add(this.lblDashTtl3);

            this.pnlDash4.Dock = System.Windows.Forms.DockStyle.Fill; this.pnlDash4.BackColor = cBgCard; this.pnlDash4.Margin = new System.Windows.Forms.Padding(8);
            this.lblDashTtl4.Text = "마지막 확인"; this.lblDashTtl4.Font = fontSmall; this.lblDashTtl4.ForeColor = cSubText; this.lblDashTtl4.Dock = System.Windows.Forms.DockStyle.Top; this.lblDashTtl4.Height = 30; this.lblDashTtl4.TextAlign = System.Drawing.ContentAlignment.BottomLeft; this.lblDashTtl4.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0); this.lblDashTtl4.BackColor = cBgCard;
            this.lblDashVal4.Text = "--:--:--"; this.lblDashVal4.Font = fontBig; this.lblDashVal4.ForeColor = cSubText; this.lblDashVal4.Dock = System.Windows.Forms.DockStyle.Fill; this.lblDashVal4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter; this.lblDashVal4.BackColor = cBgCard;
            this.pnlDash4.Controls.Add(this.lblDashVal4); this.pnlDash4.Controls.Add(this.lblDashTtl4);

            this.tblDash.Controls.Add(this.pnlDash1, 0, 0); this.tblDash.Controls.Add(this.pnlDash2, 1, 0);
            this.tblDash.Controls.Add(this.pnlDash3, 0, 1); this.tblDash.Controls.Add(this.pnlDash4, 1, 1);
            this.pnlStatusRight.Controls.Add(this.tblDash); this.pnlStatusRight.Controls.Add(this.lblDashHeader);
            this.pnlStatusTop.Controls.Add(this.pnlStatusRight); this.pnlStatusTop.Controls.Add(this.pnlStatusLeft);
            this.tabStatus.Controls.Add(this.pnlStatusTop); this.tabStatus.Controls.Add(this.pnlStatus1Log);

            // ══════════ TAB 2 ══════════
            this.tabConveyor.Text = "  장비 설정  "; this.tabConveyor.BackColor = cBgDark;
            this.pnlConvBottom.Dock = System.Windows.Forms.DockStyle.Bottom; this.pnlConvBottom.Height = 190; this.pnlConvBottom.BackColor = cBgDark;
            this.lblConvLogTitle.Text = "장비 로그"; this.lblConvLogTitle.Font = fontSubSm; this.lblConvLogTitle.ForeColor = cAccent; this.lblConvLogTitle.Dock = System.Windows.Forms.DockStyle.Top; this.lblConvLogTitle.Height = 28; this.lblConvLogTitle.TextAlign = System.Drawing.ContentAlignment.BottomLeft; this.lblConvLogTitle.Padding = new System.Windows.Forms.Padding(6, 0, 0, 2); this.lblConvLogTitle.BackColor = cBgDark;
            this.rtbConvLog.Dock = System.Windows.Forms.DockStyle.Fill; this.rtbConvLog.ReadOnly = true; this.rtbConvLog.BackColor = cBgCard; this.rtbConvLog.ForeColor = cText; this.rtbConvLog.Font = fontConsole; this.rtbConvLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pnlConvBottom.Controls.Add(this.rtbConvLog); this.pnlConvBottom.Controls.Add(this.lblConvLogTitle);

            // 3열 외부 TableLayout
            this.tblConv.Dock = System.Windows.Forms.DockStyle.Fill; this.tblConv.BackColor = cBgDark; this.tblConv.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.None;
            this.tblConv.ColumnCount = 3; this.tblConv.RowCount = 1;
            this.tblConv.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblConv.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblConv.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblConv.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblConv.Padding = new System.Windows.Forms.Padding(16);

            // ────── 컨베이어 GroupBox ──────
            this.grpConvFull.Text = "컨베이어"; this.grpConvFull.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpConvFull.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.grpConvFull.ForeColor = cAccent; this.grpConvFull.BackColor = cBgCard; this.grpConvFull.Font = fontSubSm;

            this.tblConvInner.Dock = System.Windows.Forms.DockStyle.Fill; this.tblConvInner.BackColor = cBgCard; this.tblConvInner.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.None;
            this.tblConvInner.ColumnCount = 2; this.tblConvInner.RowCount = 6;
            this.tblConvInner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tblConvInner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblConvInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblConvInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblConvInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblConvInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tblConvInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tblConvInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tblConvInner.Padding = new System.Windows.Forms.Padding(10, 6, 10, 10);

            this.lblConvState.Text = "현재 상태"; this.lblConvState.ForeColor = cSubText; this.lblConvState.Font = fontSmall; this.lblConvState.Dock = System.Windows.Forms.DockStyle.Fill; this.lblConvState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblConvStateVal.Text = "정지"; this.lblConvStateVal.ForeColor = cWarning; this.lblConvStateVal.Font = fontSubSm; this.lblConvStateVal.Dock = System.Windows.Forms.DockStyle.Fill; this.lblConvStateVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStepCount.Text = "속도 (%);"; this.lblStepCount.ForeColor = cSubText; this.lblStepCount.Font = fontSmall; this.lblStepCount.Dock = System.Windows.Forms.DockStyle.Fill; this.lblStepCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.nudStepCount.Dock = System.Windows.Forms.DockStyle.Fill; this.nudStepCount.Minimum = 1; this.nudStepCount.Maximum = 100; this.nudStepCount.Value = 70; this.nudStepCount.BackColor = cBgInput; this.nudStepCount.ForeColor = cText; this.nudStepCount.Margin = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.lblDuration.Text = "시간 (ms)"; this.lblDuration.ForeColor = cSubText; this.lblDuration.Font = fontSmall; this.lblDuration.Dock = System.Windows.Forms.DockStyle.Fill; this.lblDuration.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.nudDuration.Dock = System.Windows.Forms.DockStyle.Fill; this.nudDuration.Minimum = 0; this.nudDuration.Maximum = 9999; this.nudDuration.Increment = 100; this.nudDuration.Value = 1000; this.nudDuration.BackColor = cBgInput; this.nudDuration.ForeColor = cText; this.nudDuration.Margin = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.btnFwd.Text = "▶  정방향 구동"; this.btnFwd.Dock = System.Windows.Forms.DockStyle.Fill; this.btnFwd.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnFwd.BackColor = cBtnFwd; this.btnFwd.ForeColor = cText; this.btnFwd.Font = fontSubSm; this.btnFwd.FlatAppearance.BorderSize = 0; this.btnFwd.Cursor = System.Windows.Forms.Cursors.Hand; this.btnFwd.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4); this.btnFwd.Click += new System.EventHandler(this.btnFwd_Click);
            this.btnRev.Text = "◀  역방향 구동"; this.btnRev.Dock = System.Windows.Forms.DockStyle.Fill; this.btnRev.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnRev.BackColor = cBtnNeu; this.btnRev.ForeColor = cText; this.btnRev.Font = fontSubSm; this.btnRev.FlatAppearance.BorderSize = 0; this.btnRev.Cursor = System.Windows.Forms.Cursors.Hand; this.btnRev.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4); this.btnRev.Click += new System.EventHandler(this.btnRev_Click);
            this.btnConvStop.Text = "■  정  지"; this.btnConvStop.Dock = System.Windows.Forms.DockStyle.Fill; this.btnConvStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnConvStop.BackColor = cBtnStop; this.btnConvStop.ForeColor = cText; this.btnConvStop.Font = fontSubSm; this.btnConvStop.FlatAppearance.BorderSize = 0; this.btnConvStop.Cursor = System.Windows.Forms.Cursors.Hand; this.btnConvStop.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0); this.btnConvStop.Click += new System.EventHandler(this.btnConvStop_Click);

            this.tblConvInner.Controls.Add(this.lblConvState, 0, 0); this.tblConvInner.Controls.Add(this.lblConvStateVal, 1, 0);
            this.tblConvInner.Controls.Add(this.lblStepCount, 0, 1); this.tblConvInner.Controls.Add(this.nudStepCount, 1, 1);
            this.tblConvInner.Controls.Add(this.lblDuration, 0, 2); this.tblConvInner.Controls.Add(this.nudDuration, 1, 2);
            this.tblConvInner.SetColumnSpan(this.btnFwd, 2); this.tblConvInner.Controls.Add(this.btnFwd, 0, 3);
            this.tblConvInner.SetColumnSpan(this.btnRev, 2); this.tblConvInner.Controls.Add(this.btnRev, 0, 4);
            this.tblConvInner.SetColumnSpan(this.btnConvStop, 2); this.tblConvInner.Controls.Add(this.btnConvStop, 0, 5);
            this.grpConvFull.Controls.Add(this.tblConvInner);

            // ────── 영상 모니터링 GroupBox ──────
            this.grpServoFull.Text = "영상 모니터링";
            this.grpServoFull.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpServoFull.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.grpServoFull.ForeColor = cAccent; this.grpServoFull.BackColor = cBgCard; this.grpServoFull.Font = fontSubSm;

            this.tblServoInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblServoInner.BackColor = cBgCard;
            this.tblServoInner.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.None;
            this.tblServoInner.ColumnCount = 1; this.tblServoInner.RowCount = 3;
            this.tblServoInner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblServoInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F)); // 카메라
            this.tblServoInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F)); // 제어 버튼
            this.tblServoInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F)); // 주문 버튼
            this.tblServoInner.Padding = new System.Windows.Forms.Padding(8, 6, 8, 8);

            // WebView2 카메라
            this.webCamera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webCamera.BackColor = System.Drawing.Color.FromArgb(8, 10, 18);

            // ── ROI / 긴급정지 / 드럼테스트 버튼 패널 ──
            this.pnlServoBtns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlServoBtns.BackColor = cBgCard;
            this.pnlServoBtns.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);

            this.btnServo0.Text = "ROI 초기화";
            this.btnServo0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServo0.BackColor = System.Drawing.Color.FromArgb(40, 55, 85);
            this.btnServo0.ForeColor = cText; this.btnServo0.Font = fontSmall;
            this.btnServo0.FlatAppearance.BorderSize = 0; this.btnServo0.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnServo0.Click += async (s, e) => {
                var r = await SendStepCommandAsync("RESET_ROI");
                AddLog(rtbConvLog, r.StartsWith("OK:") ? "✔ ROI 초기화" : $"❌ {r}");
            };

            this.btnServo90.Text = "⛔ 긴급정지";
            this.btnServo90.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServo90.BackColor = System.Drawing.Color.FromArgb(160, 30, 30);
            this.btnServo90.ForeColor = cText; this.btnServo90.Font = fontSmall;
            this.btnServo90.FlatAppearance.BorderSize = 0; this.btnServo90.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnServo90.Click += async (s, e) => {
                await SendStepCommandAsync("EMERGENCY_STOP");
                AddLog(rtbConvLog, "⛔ 긴급정지");
                UpdateStepStatus("-\n긴급정지", System.Drawing.Color.FromArgb(255, 65, 65));
                UpdateServoStatus("정지", System.Drawing.Color.FromArgb(255, 65, 65));
            };

            this.btnServo180.Text = "드럼 테스트";
            this.btnServo180.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServo180.BackColor = System.Drawing.Color.FromArgb(20, 80, 50);
            this.btnServo180.ForeColor = cText; this.btnServo180.Font = fontSmall;
            this.btnServo180.FlatAppearance.BorderSize = 0; this.btnServo180.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnServo180.Click += async (s, e) => {
                var r = await SendStepCommandAsync("DRUM_TEST");
                AddLog(rtbConvLog, r.StartsWith("OK:") ? "✔ 드럼 테스트" : $"❌ {r}");
            };

            this.pnlServoBtns.Resize += (s, e) => {
                int w = (pnlServoBtns.Width - 16) / 3;
                int h = pnlServoBtns.Height - 8;
                btnServo0.SetBounds(0, 4, w, h);
                btnServo90.SetBounds(w + 8, 4, w, h);
                btnServo180.SetBounds((w + 8) * 2, 4, w, h);
            };
            this.pnlServoBtns.Controls.Add(this.btnServo0);
            this.pnlServoBtns.Controls.Add(this.btnServo90);
            this.pnlServoBtns.Controls.Add(this.btnServo180);

            // ── A / B / C 주문 버튼 ──
            this.pnlOrderBtns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOrderBtns.BackColor = cBgCard;

            this.btnOrderA.Text = "🔴  A 주문"; this.btnOrderA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrderA.BackColor = System.Drawing.Color.FromArgb(200, 50, 50); this.btnOrderA.ForeColor = cText;
            this.btnOrderA.Font = fontSub; this.btnOrderA.FlatAppearance.BorderSize = 0; this.btnOrderA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrderA.Click += new System.EventHandler(this.btnOrderA_Click);

            this.btnOrderB.Text = "🟡  B 주문"; this.btnOrderB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrderB.BackColor = System.Drawing.Color.FromArgb(210, 185, 40); this.btnOrderB.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.btnOrderB.Font = fontSub; this.btnOrderB.FlatAppearance.BorderSize = 0; this.btnOrderB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrderB.Click += new System.EventHandler(this.btnOrderB_Click);

            this.btnOrderC.Text = "🔵  C 주문"; this.btnOrderC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrderC.BackColor = System.Drawing.Color.FromArgb(50, 100, 210); this.btnOrderC.ForeColor = cText;
            this.btnOrderC.Font = fontSub; this.btnOrderC.FlatAppearance.BorderSize = 0; this.btnOrderC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrderC.Click += new System.EventHandler(this.btnOrderC_Click);

            this.pnlOrderBtns.Resize += new System.EventHandler(this.pnlOrderBtns_Resize);
            this.pnlOrderBtns.Controls.Add(this.btnOrderA);
            this.pnlOrderBtns.Controls.Add(this.btnOrderB);
            this.pnlOrderBtns.Controls.Add(this.btnOrderC);

            this.tblServoInner.Controls.Add(this.webCamera, 0, 0);
            this.tblServoInner.Controls.Add(this.pnlServoBtns, 0, 1);
            this.tblServoInner.Controls.Add(this.pnlOrderBtns, 0, 2);
            this.grpServoFull.Controls.Add(this.tblServoInner);

            // ────── 스텝모터 + 서보모터 통합 GroupBox ──────
            this.grpStepFull.Text = "스텝모터 / 서보모터";
            this.grpStepFull.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpStepFull.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.grpStepFull.ForeColor = cAccent; this.grpStepFull.BackColor = cBgCard; this.grpStepFull.Font = fontSubSm;

            this.tblStepInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblStepInner.BackColor = cBgCard;
            this.tblStepInner.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.None;
            this.tblStepInner.ColumnCount = 1; this.tblStepInner.RowCount = 6;
            this.tblStepInner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblStepInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));  // 스텝 레이블
            this.tblStepInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42F));   // 스텝 값
            this.tblStepInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));  // 구분선
            this.tblStepInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));  // 서보 레이블
            this.tblStepInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36F));   // 서보 각도
            this.tblStepInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));  // 서보 버튼
            this.tblStepInner.Padding = new System.Windows.Forms.Padding(8, 6, 8, 8);

            // 스텝모터 레이블
            this.lblStepPos.Text = "현재 선반 위치 (A / B / C)";
            this.lblStepPos.ForeColor = cSubText; this.lblStepPos.Font = fontSmall;
            this.lblStepPos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStepPos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 스텝모터 위치 값 (대형)
            this.lblStepPosVal.Text = "-";
            this.lblStepPosVal.Font = fontBig;
            this.lblStepPosVal.ForeColor = cAccent;
            this.lblStepPosVal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStepPosVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 구분선
            this.pnlServoDivider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlServoDivider.BackColor = System.Drawing.Color.FromArgb(38, 48, 78);
            this.pnlServoDivider.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);

            // 서보모터 레이블
            this.lblServoTitle2.Text = "서보모터 각도 (0° ~ 180°)";
            this.lblServoTitle2.ForeColor = cSubText; this.lblServoTitle2.Font = fontSmall;
            this.lblServoTitle2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblServoTitle2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 서보모터 각도 표시
            this.lblServoAngle2.Text = "0°";
            this.lblServoAngle2.Font = fontMid;
            this.lblServoAngle2.ForeColor = cSuccess;
            this.lblServoAngle2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblServoAngle2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 서보 제어 버튼 패널
            this.pnlServoBtns2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlServoBtns2.BackColor = cBgCard;

            this.btnServo0_2.Text = "◀  0°  초기화";
            this.btnServo0_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServo0_2.BackColor = System.Drawing.Color.FromArgb(35, 45, 70);
            this.btnServo0_2.ForeColor = cText; this.btnServo0_2.Font = fontSubSm;
            this.btnServo0_2.FlatAppearance.BorderSize = 0; this.btnServo0_2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnServo0_2.Click += (s, e) => SetServo(0);

            this.btnServo180_2.Text = "180°  배출 ▶";
            this.btnServo180_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServo180_2.BackColor = System.Drawing.Color.FromArgb(0, 100, 160);
            this.btnServo180_2.ForeColor = cText; this.btnServo180_2.Font = fontSubSm;
            this.btnServo180_2.FlatAppearance.BorderSize = 0; this.btnServo180_2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnServo180_2.Click += (s, e) => SetServo(180);

            this.pnlServoBtns2.Resize += (s, e) => {
                int w = (pnlServoBtns2.Width - 8) / 2;
                int h = pnlServoBtns2.Height;
                btnServo0_2.SetBounds(0, 0, w, h);
                btnServo180_2.SetBounds(w + 8, 0, w, h);
            };
            this.pnlServoBtns2.Controls.Add(this.btnServo0_2);
            this.pnlServoBtns2.Controls.Add(this.btnServo180_2);

            // 숨김 처리 (미사용)
            this.btnStepFwd.Visible = false;
            this.btnStepBack.Visible = false;
            this.btnStepHome.Visible = false;

            this.tblStepInner.Controls.Add(this.lblStepPos, 0, 0);
            this.tblStepInner.Controls.Add(this.lblStepPosVal, 0, 1);
            this.tblStepInner.Controls.Add(this.pnlServoDivider, 0, 2);
            this.tblStepInner.Controls.Add(this.lblServoTitle2, 0, 3);
            this.tblStepInner.Controls.Add(this.lblServoAngle2, 0, 4);
            this.tblStepInner.Controls.Add(this.pnlServoBtns2, 0, 5);
            this.grpStepFull.Controls.Add(this.tblStepInner);

            this.tblConv.Controls.Add(this.grpConvFull, 0, 0);
            this.tblConv.Controls.Add(this.grpServoFull, 1, 0);
            this.tblConv.Controls.Add(this.grpStepFull, 2, 0);
            this.tabConveyor.Controls.Add(this.tblConv);
            this.tabConveyor.Controls.Add(this.pnlConvBottom);

            // ══════════ TAB 3 ══════════
            this.tabVideo.Text = "  영상 모니터링  "; this.tabVideo.BackColor = cBgDark;
            this.lblVideoTitle.Text = "영상 모니터링"; this.lblVideoTitle.Font = fontSub; this.lblVideoTitle.ForeColor = cAccent; this.lblVideoTitle.Dock = System.Windows.Forms.DockStyle.Top; this.lblVideoTitle.Height = 44; this.lblVideoTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; this.lblVideoTitle.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0); this.lblVideoTitle.BackColor = cBgDark;
            this.pnlVideoBtn.Dock = System.Windows.Forms.DockStyle.Bottom; this.pnlVideoBtn.Height = 220; this.pnlVideoBtn.BackColor = cBgDark;
            this.btnVideoStart.Text = "▶  영상 시작"; this.btnVideoStart.Size = new System.Drawing.Size(160, 46); this.btnVideoStart.Location = new System.Drawing.Point(16, 12);
            this.btnVideoStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnVideoStart.BackColor = cBtnFwd; this.btnVideoStart.ForeColor = cText; this.btnVideoStart.Font = fontSubSm; this.btnVideoStart.FlatAppearance.BorderSize = 0; this.btnVideoStart.Cursor = System.Windows.Forms.Cursors.Hand; this.btnVideoStart.Click += new System.EventHandler(this.btnVideoStart_Click);
            this.btnCapture.Text = "◎  캡  처"; this.btnCapture.Size = new System.Drawing.Size(160, 46); this.btnCapture.Location = new System.Drawing.Point(190, 12);
            this.btnCapture.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnCapture.BackColor = cBtnNeu; this.btnCapture.ForeColor = cText; this.btnCapture.Font = fontSubSm; this.btnCapture.FlatAppearance.BorderSize = 0; this.btnCapture.Cursor = System.Windows.Forms.Cursors.Hand; this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            this.lblVideoLogTitle.Text = "영상 로그"; this.lblVideoLogTitle.Font = fontSubSm; this.lblVideoLogTitle.ForeColor = cAccent; this.lblVideoLogTitle.Location = new System.Drawing.Point(16, 68); this.lblVideoLogTitle.AutoSize = true; this.lblVideoLogTitle.BackColor = cBgDark;
            this.rtbVideoLog.Location = new System.Drawing.Point(16, 94); this.rtbVideoLog.Size = new System.Drawing.Size(400, 116);
            this.rtbVideoLog.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.rtbVideoLog.ReadOnly = true; this.rtbVideoLog.BackColor = cBgCard; this.rtbVideoLog.ForeColor = cText; this.rtbVideoLog.Font = fontConsole; this.rtbVideoLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pnlVideoBtn.Controls.Add(this.btnVideoStart); this.pnlVideoBtn.Controls.Add(this.btnCapture); this.pnlVideoBtn.Controls.Add(this.lblVideoLogTitle); this.pnlVideoBtn.Controls.Add(this.rtbVideoLog);
            this.picVideo.Dock = System.Windows.Forms.DockStyle.Fill; this.picVideo.BorderStyle = System.Windows.Forms.BorderStyle.None; this.picVideo.BackColor = System.Drawing.Color.FromArgb(8, 10, 18); this.picVideo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.tabVideo.Controls.Add(this.picVideo); this.tabVideo.Controls.Add(this.pnlVideoBtn); this.tabVideo.Controls.Add(this.lblVideoTitle);

            // ══ FORM ══
            this.Controls.Add(this.tabMain); this.Controls.Add(this.pnlHeader);

            this.pnlHeader.ResumeLayout(false); this.pnlHeader.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabStatus.ResumeLayout(false);
            this.pnlStatusTop.ResumeLayout(false); this.pnlStatusLeft.ResumeLayout(false); this.pnlStatusLeft.PerformLayout();
            this.pnlCardRpi.ResumeLayout(false); this.pnlCardRpi.PerformLayout(); this.pnlCardStep.ResumeLayout(false); this.pnlCardStep.PerformLayout();
            this.pnlCardServo.ResumeLayout(false); this.pnlCardServo.PerformLayout(); this.pnlCardCam.ResumeLayout(false); this.pnlCardCam.PerformLayout();
            this.pnlStatusRight.ResumeLayout(false);
            this.tblDash.ResumeLayout(false);
            this.pnlDash1.ResumeLayout(false); this.pnlDash2.ResumeLayout(false); this.pnlDash3.ResumeLayout(false); this.pnlDash4.ResumeLayout(false);
            this.pnlStatus1Log.ResumeLayout(false);
            this.tabConveyor.ResumeLayout(false);
            this.pnlConvBottom.ResumeLayout(false); this.pnlConvBottom.PerformLayout();
            this.tblConv.ResumeLayout(false);
            this.grpConvFull.ResumeLayout(false); this.tblConvInner.ResumeLayout(false); this.pnlConvBtns.ResumeLayout(false);
            this.grpServoFull.ResumeLayout(false); this.tblServoInner.ResumeLayout(false); this.pnlServoBtns.ResumeLayout(false);
            this.grpStepFull.ResumeLayout(false); this.tblStepInner.ResumeLayout(false);
            this.tabVideo.ResumeLayout(false); this.pnlVideoBtn.ResumeLayout(false); this.pnlVideoBtn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStepCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVideo)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Panel pnlHeader, pnlHeaderLine;
        private System.Windows.Forms.Button btnClose, btnMinimize;
        private System.Windows.Forms.Label lblTitle, lblDateTime;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabStatus;
        private System.Windows.Forms.Panel pnlStatusTop, pnlStatusLeft, pnlStatusRight;
        private System.Windows.Forms.Label lblStatusTitle;
        private System.Windows.Forms.Panel pnlCardRpi, pnlCardStep, pnlCardServo, pnlCardCam;
        private System.Windows.Forms.Label lblLedRpi, lblRpiKey, lblRpiVal;
        private System.Windows.Forms.Label lblLedStep, lblStepKey, lblStepVal;
        private System.Windows.Forms.Label lblLedServo, lblServoKey, lblServoVal;
        private System.Windows.Forms.Label lblLedCam, lblCamKey, lblCamVal;
        private System.Windows.Forms.Button btnCheckStatus;
        private System.Windows.Forms.Label lblDashHeader;
        private System.Windows.Forms.TableLayoutPanel tblDash;
        private System.Windows.Forms.Panel pnlDash1, pnlDash2, pnlDash3, pnlDash4;
        private System.Windows.Forms.Label lblDashTtl1, lblDashVal1, lblDashTtl2, lblDashVal2;
        private System.Windows.Forms.Label lblDashTtl3, lblDashVal3, lblDashTtl4, lblDashVal4;
        private System.Windows.Forms.Panel pnlStatus1Log;
        private System.Windows.Forms.Label lblLogTitle1;
        private System.Windows.Forms.RichTextBox rtbStatusLog;
        private System.Windows.Forms.TabPage tabConveyor;
        private System.Windows.Forms.Panel pnlConvBottom;
        private System.Windows.Forms.Label lblConvLogTitle;
        private System.Windows.Forms.RichTextBox rtbConvLog;
        private System.Windows.Forms.TableLayoutPanel tblConv;
        private System.Windows.Forms.GroupBox grpConvFull, grpServoFull, grpStepFull;
        private System.Windows.Forms.TableLayoutPanel tblConvInner, tblServoInner, tblStepInner;
        private System.Windows.Forms.Label lblConvState, lblConvStateVal;
        private System.Windows.Forms.Panel pnlConvBtns;
        private System.Windows.Forms.Label lblStepCount, lblDuration;
        private System.Windows.Forms.NumericUpDown nudStepCount, nudDuration;
        private System.Windows.Forms.Button btnFwd, btnRev, btnConvStop;
        private System.Windows.Forms.Label lblServoCur, lblServoCurVal;
        private System.Windows.Forms.Panel pnlServoBtns;
        private System.Windows.Forms.Button btnServo0, btnServo90, btnServo180;
        private System.Windows.Forms.Label lblStepPos, lblStepPosVal;
        private System.Windows.Forms.Button btnStepFwd, btnStepBack, btnStepHome;
        // 서보모터 (스텝모터 패널 하단)
        private System.Windows.Forms.Panel pnlServoDivider;
        private System.Windows.Forms.Label lblServoTitle2;
        private System.Windows.Forms.Label lblServoAngle2;
        private System.Windows.Forms.Panel pnlServoBtns2;
        private System.Windows.Forms.Button btnServo0_2;
        private System.Windows.Forms.Button btnServo180_2;
        private System.Windows.Forms.TabPage tabVideo;
        private System.Windows.Forms.Label lblVideoTitle;
        private System.Windows.Forms.PictureBox picVideo;
        private System.Windows.Forms.Panel pnlVideoBtn;
        private System.Windows.Forms.Button btnVideoStart, btnCapture;
        private System.Windows.Forms.Label lblVideoLogTitle;
        private System.Windows.Forms.RichTextBox rtbVideoLog;
        private Microsoft.Web.WebView2.WinForms.WebView2 webCamera;
        private System.Windows.Forms.Panel pnlOrderBtns;
        private System.Windows.Forms.Button btnOrderA, btnOrderB, btnOrderC;
    }
}