namespace HardwareManagement
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // 로그인 창 먼저 표시
            using var login = new LoginForm();
            if (login.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Application.Run(new Form1());
            }
        }
    }
}
