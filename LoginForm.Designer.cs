namespace HardwareManagement
{
    partial class LoginForm
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
            var cText = System.Drawing.Color.FromArgb(210, 220, 240);
            var cSubText = System.Drawing.Color.FromArgb(90, 110, 155);
            var cBtnFwd = System.Drawing.Color.FromArgb(0, 130, 200);
            var cDanger = System.Drawing.Color.FromArgb(255, 65, 65);

            this.pnlBg = new System.Windows.Forms.Panel();
            this.pnlAccentTop = new System.Windows.Forms.Panel();
            this.pnlCard = new System.Windows.Forms.Panel();
            this.pnlCardAccent = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.pnlDivider = new System.Windows.Forms.Panel();
            this.lblIdLabel = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblPwLabel = new System.Windows.Forms.Label();
            this.txtPw = new System.Windows.Forms.TextBox();
            this.lblError = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblFooter = new System.Windows.Forms.Label();

            this.pnlBg.SuspendLayout();
            this.pnlCard.SuspendLayout();
            this.SuspendLayout();

            // ── Form ──
            this.Text = "로그인 - 하드웨어 관리 시스템";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.BackColor = cBgDark;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);

            // ── 전체 배경 패널 ──
            this.pnlBg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBg.BackColor = cBgDark;

            // ── 상단 강조 바 ──
            this.pnlAccentTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAccentTop.Height = 4;
            this.pnlAccentTop.BackColor = cAccent;

            // ── 카드 패널 (화면 중앙) ──
            this.pnlCard.Size = new System.Drawing.Size(480, 630);
            this.pnlCard.BackColor = cBgCard;
            this.pnlCard.Anchor = System.Windows.Forms.AnchorStyles.None;
            // 위치는 Resize 이벤트로 동적으로 중앙 정렬

            // 카드 상단 강조 바
            this.pnlCardAccent.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCardAccent.Height = 3;
            this.pnlCardAccent.BackColor = cAccent;

            // ── 로고 ──
            this.lblLogo.Text = "⬡";
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = cAccent;
            this.lblLogo.AutoSize = true;
            this.lblLogo.Location = new System.Drawing.Point(196, 55);

            // ── 타이틀 ──
            this.lblTitle.Text = "하드웨어 관리 시스템";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = cText;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(88, 158);

            // ── 서브타이틀 ──
            this.lblSubtitle.Text = "HARDWARE MANAGEMENT SYSTEM";
            this.lblSubtitle.Font = new System.Drawing.Font("Consolas", 8.5F);
            this.lblSubtitle.ForeColor = cSubText;
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Location = new System.Drawing.Point(106, 190);

            // ── 구분선 ──
            this.pnlDivider.Location = new System.Drawing.Point(40, 222);
            this.pnlDivider.Size = new System.Drawing.Size(400, 1);
            this.pnlDivider.BackColor = System.Drawing.Color.FromArgb(38, 48, 78);

            // ── 아이디 레이블 ──
            this.lblIdLabel.Text = "아이디";
            this.lblIdLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblIdLabel.ForeColor = cSubText;
            this.lblIdLabel.AutoSize = true;
            this.lblIdLabel.Location = new System.Drawing.Point(40, 244);

            // ── 아이디 입력 ──
            this.txtId.Location = new System.Drawing.Point(40, 266);
            this.txtId.Size = new System.Drawing.Size(400, 46);
            this.txtId.BackColor = cBgInput;
            this.txtId.ForeColor = cText;
            this.txtId.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtId.TabIndex = 0;
            this.txtId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);

            // ── 비밀번호 레이블 ──
            this.lblPwLabel.Text = "비밀번호";
            this.lblPwLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPwLabel.ForeColor = cSubText;
            this.lblPwLabel.AutoSize = true;
            this.lblPwLabel.Location = new System.Drawing.Point(40, 330);

            // ── 비밀번호 입력 ──
            this.txtPw.Location = new System.Drawing.Point(40, 352);
            this.txtPw.Size = new System.Drawing.Size(400, 46);
            this.txtPw.BackColor = cBgInput;
            this.txtPw.ForeColor = cText;
            this.txtPw.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPw.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPw.PasswordChar = '●';
            this.txtPw.TabIndex = 1;
            this.txtPw.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);

            // ── 오류 메시지 ──
            this.lblError.Text = "";
            this.lblError.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblError.ForeColor = cDanger;
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(40, 408);

            // ── 로그인 버튼 ──
            this.btnLogin.Text = "로  그  인";
            this.btnLogin.Location = new System.Drawing.Point(40, 436);
            this.btnLogin.Size = new System.Drawing.Size(400, 56);
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.BackColor = cBtnFwd;
            this.btnLogin.ForeColor = cText;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // ── 하단 텍스트 ──
            this.lblFooter.Text = "© 2026 Hardware Management System";
            this.lblFooter.Font = new System.Drawing.Font("Consolas", 8F);
            this.lblFooter.ForeColor = cSubText;
            this.lblFooter.AutoSize = true;
            this.lblFooter.Location = new System.Drawing.Point(122, 568);

            this.pnlCard.Controls.Add(this.lblLogo);
            this.pnlCard.Controls.Add(this.lblTitle);
            this.pnlCard.Controls.Add(this.lblSubtitle);
            this.pnlCard.Controls.Add(this.pnlDivider);
            this.pnlCard.Controls.Add(this.lblIdLabel);
            this.pnlCard.Controls.Add(this.txtId);
            this.pnlCard.Controls.Add(this.lblPwLabel);
            this.pnlCard.Controls.Add(this.txtPw);
            this.pnlCard.Controls.Add(this.lblError);
            this.pnlCard.Controls.Add(this.btnLogin);
            this.pnlCard.Controls.Add(this.lblFooter);
            this.pnlCard.Controls.Add(this.pnlCardAccent);

            this.pnlBg.Controls.Add(this.pnlCard);
            this.pnlBg.Controls.Add(this.pnlAccentTop);

            this.Controls.Add(this.pnlBg);

            this.pnlCard.ResumeLayout(false);
            this.pnlCard.PerformLayout();
            this.pnlBg.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Panel pnlBg;
        private System.Windows.Forms.Panel pnlAccentTop;
        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Panel pnlCardAccent;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlDivider;
        private System.Windows.Forms.Label lblIdLabel;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblPwLabel;
        private System.Windows.Forms.TextBox txtPw;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblFooter;
    }
}