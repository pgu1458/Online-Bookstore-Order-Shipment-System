using System;
using System.Drawing;
using System.Windows.Forms;

namespace HardwareManagement
{
    public partial class LoginForm : Form
    {
        private const string VALID_ID = "hard1";
        private const string VALID_PW = "1234";
        private int _failCount = 0;

        public LoginForm()
        {
            InitializeComponent();

            // 카드 중앙 정렬
            this.Resize += (s, e) => CenterCard();
            this.Load += (s, e) => CenterCard();

            // 입력칸 포커스 효과
            txtId.GotFocus += (s, e) => txtId.BackColor = Color.FromArgb(34, 44, 70);
            txtId.LostFocus += (s, e) => txtId.BackColor = Color.FromArgb(26, 32, 52);
            txtPw.GotFocus += (s, e) => txtPw.BackColor = Color.FromArgb(34, 44, 70);
            txtPw.LostFocus += (s, e) => txtPw.BackColor = Color.FromArgb(26, 32, 52);
        }

        private void CenterCard()
        {
            pnlCard.Location = new Point(
                (this.ClientSize.Width - pnlCard.Width) / 2,
                (this.ClientSize.Height - pnlCard.Height) / 2
            );
        }

        private void btnLogin_Click(object sender, EventArgs e) => DoLogin();

        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) DoLogin();
        }

        private void DoLogin()
        {
            string id = txtId.Text.Trim();
            string pw = txtPw.Text;

            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(pw))
            {
                ShowError("아이디와 비밀번호를 입력해주세요."); return;
            }

            if (id == VALID_ID && pw == VALID_PW)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                _failCount++;
                ShowError(_failCount >= 3
                    ? $"로그인 실패 ({_failCount}회) — 아이디 또는 비밀번호를 확인하세요."
                    : "아이디 또는 비밀번호가 올바르지 않습니다.");
                txtPw.Clear();
                txtPw.Focus();
                ShakeButton();
            }
        }

        private void ShowError(string msg) => lblError.Text = $"⚠  {msg}";

        private async void ShakeButton()
        {
            var orig = btnLogin.Location;
            foreach (int dx in new[] { -6, 6, -4, 4, -2, 2, 0 })
            {
                btnLogin.Location = new Point(orig.X + dx, orig.Y);
                await System.Threading.Tasks.Task.Delay(30);
            }
            btnLogin.Location = orig;
        }
    }
}