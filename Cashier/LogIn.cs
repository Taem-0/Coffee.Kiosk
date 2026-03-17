using Coffee.Kiosk.Cashier;

namespace Cashier
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
            this.Load += (s, e) => CenterControls();
            this.Resize += (s, e) => CenterControls();
        }

        private void CenterControls()
        {
            int cx = this.ClientSize.Width / 2;
            int cy = this.ClientSize.Height / 2;

            int logoRowW = picLogo.Width + 12 + lblBrand.Width;
            picLogo.Location = new Point(cx - logoRowW / 2, cy - 150);
            lblBrand.Location = new Point(
                picLogo.Right + 12,
                picLogo.Top + (picLogo.Height - lblBrand.Height) / 2);

            txtUsername.Location = new Point(cx - txtUsername.Width / 2, picLogo.Bottom + 40);
            txtPassword.Location = new Point(cx - txtPassword.Width / 2, txtUsername.Bottom + 14);
            btnLogin.Location = new Point(cx - btnLogin.Width / 2, txtPassword.Bottom + 28);
        }

        private void txtUsername_TextChanged(object sender, EventArgs e) { }
        private void txtPassword_TextChanged(object sender, EventArgs e) { }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                Shake(txtUsername);
                Shake(txtPassword);
                return;
            }

            if ((user == "admin" && pass == "admin123") ||
                (user == "cashier" && pass == "cashier123"))
            {
                SessionManager.CurrentUser = new UserModel
                {
                    UserID = 1,
                    Username = user,
                    Role = user == "admin" ? "Admin" : "Cashier"
                };
                var home = new Coffee.Kiosk.Cashier.HomePage();
                home.Show();
                this.Hide();
            }
            else
            {
                Shake(txtUsername);
                Shake(txtPassword);
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        private async void Shake(Control ctrl)
        {
            Point orig = ctrl.Location;
            foreach (int o in new[] { -6, 6, -4, 4, -2, 2, 0 })
            {
                ctrl.Location = new Point(orig.X + o, orig.Y);
                await Task.Delay(30);
            }
            ctrl.Location = orig;
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txtPassword.Focus();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnLogin_Click(sender, e);
        }
    }
}