using DBHelper = Coffee.Kiosk.Cashier.CashierDBHelper.CashierDBHelper;
using Coffee.Kiosk.Cashier.CashierDBHelper;
using Coffee.Kiosk.Cashier.ModelClassHelper;
using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Cashier
{
    public partial class LogIn : Form
    {
        private Button btnShowPass = new();

        public LogIn()
        {
            InitializeComponent();

            btnShowPass.Size = new Size(28, 28);
            btnShowPass.FlatStyle = FlatStyle.Flat;
            btnShowPass.FlatAppearance.BorderSize = 0;
            btnShowPass.BackColor = Color.Transparent;
            btnShowPass.Text = "👁";
            btnShowPass.Font = new Font("Segoe UI", 11f);
            btnShowPass.Cursor = Cursors.Hand;
            btnShowPass.TabStop = false;
            btnShowPass.MouseDown += (s, e) => txtPassword.UseSystemPasswordChar = false;
            btnShowPass.MouseUp += (s, e) => txtPassword.UseSystemPasswordChar = true;
            this.Controls.Add(btnShowPass);

            txtUsername.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) txtPassword.Focus(); };
            txtPassword.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) btnLogin_Click(s, e); };

            this.Load += (s, e) =>
            {
                try
                {
                    var theme = DBHelper.GetShopTheme();
                    SessionManager.Theme = theme;

                    this.BackColor = theme.BackgroundColor;
                    ShopName.ForeColor = GetContrastColor(theme.BackgroundColor);
                    ShopName.Text = theme.ShopName;

                    btnLogin.FillColor = theme.PrimaryColor;
                    btnLogin.ForeColor = Color.White;

                    txtUsername.BorderColor = theme.PrimaryColor;
                    txtPassword.BorderColor = theme.PrimaryColor;

                    btnShowPass.ForeColor = theme.PrimaryColor;

                    if (!string.IsNullOrEmpty(theme.LogoPath))
                    {
                        string fullPath = Path.IsPathRooted(theme.LogoPath)
                            ? theme.LogoPath
                            : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, theme.LogoPath);

                        if (File.Exists(fullPath))
                        {
                            LogoPath.Image = Image.FromFile(fullPath);
                            LogoPath.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                        else
                        {
                            Console.WriteLine($"Logo file not found at: {fullPath}");
                        }
                    }
                }
                catch { }

                CenterControls();
                btnShowPass.BringToFront();
            };

            this.Resize += (s, e) => CenterControls();
        }

        private static Color GetContrastColor(Color bg)
        {
            double luminance = (0.299 * bg.R + 0.587 * bg.G + 0.114 * bg.B) / 255;
            return luminance > 0.5 ? Color.FromArgb(30, 20, 15) : Color.White;
        }

        private void CenterControls()
        {
            int cx = this.ClientSize.Width / 2;
            int cy = this.ClientSize.Height / 2;

            int logoRowW = LogoPath.Width + 12 + ShopName.Width;
            LogoPath.Location = new Point(cx - logoRowW / 2, cy - 150);
            ShopName.Location = new Point(
                LogoPath.Right + 12,
                LogoPath.Top + (LogoPath.Height - ShopName.Height) / 2);

            txtUsername.Location = new Point(cx - txtUsername.Width / 2, LogoPath.Bottom + 40);
            txtPassword.Location = new Point(cx - txtPassword.Width / 2, txtUsername.Bottom + 14);
            btnLogin.Location = new Point(cx - btnLogin.Width / 2, txtPassword.Bottom + 28);

            btnShowPass.Location = new Point(
                txtPassword.Right - btnShowPass.Width - 6,
                txtPassword.Top + (txtPassword.Height - btnShowPass.Height) / 2);
        }

        private static string HashPassword(string password, string salt)
        {
            using var sha = SHA256.Create();
            byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
            return Convert.ToBase64String(bytes);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                ShakeControl(txtUsername);
                ShakeControl(txtPassword);
                return;
            }

            try
            {
                using var conn = DBHelper.GetConnection();
                conn.Open();

                var cmd = new MySqlCommand(
                    @"SELECT ID, First_Name, Last_Name, Role,
                             Password_Hash, Password_Salt, Is_First_Login
                      FROM accounts
                      WHERE Email_Address = @user
                        AND Status = 'ACTIVE'
                      LIMIT 1", conn);
                cmd.Parameters.AddWithValue("@user", user);

                using var reader = cmd.ExecuteReader();

                if (!reader.Read())
                {
                    ShakeControl(txtUsername);
                    ShakeControl(txtPassword);
                    txtPassword.Clear();
                    return;
                }

                int id = reader.GetInt32("ID");
                string firstName = reader.GetString("First_Name");
                string lastName = reader.GetString("Last_Name");
                string role = reader.GetString("Role");
                string storedHash = reader.GetString("Password_Hash");
                string storedSalt = reader.GetString("Password_Salt");
                bool isFirstLogin = reader.GetBoolean("Is_First_Login");
                reader.Close();

                string enteredHash = HashPassword(pass, storedSalt);
                if (enteredHash != storedHash)
                {
                    ShakeControl(txtUsername);
                    ShakeControl(txtPassword);
                    txtPassword.Clear();
                    txtPassword.Focus();
                    return;
                }

                if (isFirstLogin)
                {
                    ShowChangePasswordDialog(id, $"{firstName} {lastName}", role);
                    return;
                }

                LoginSuccess(id, $"{firstName} {lastName}", role);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Could not connect to database:\n{ex.Message}\n\n" +
                    "Make sure MySQL is running and CoffeeKioskDB exists.",
                    "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginSuccess(int userId, string fullName, string role)
        {
            SessionManager.CurrentUser = new Coffee.Kiosk.Cashier.ModelClassHelper.UserModel
            {
                UserID = userId,
                Username = fullName,
                Role = role
            };
            SessionManager.OrderNumber = DBHelper.GetNextCashierOrderNumber();
            SessionManager.ActiveSalesId = DBHelper.OpenShift(userId, fullName);

            var home = new Coffee.Kiosk.Cashier.HomePage();
            home.Show();
            this.Hide();
        }

        private void ShowChangePasswordDialog(int userId, string fullName, string role)
        {
            ShowChangePasswordForm(fullName, (newPass) =>
            {
                try
                {
                    string newSalt = Guid.NewGuid().ToString("N");
                    string newHash = HashPassword(newPass, newSalt);

                    using var conn = DBHelper.GetConnection();
                    conn.Open();
                    var cmd = new MySqlCommand(
                        "UPDATE accounts SET Password_Hash = @hash, Password_Salt = @salt, " +
                        "Is_First_Login = 0 WHERE ID = @id", conn);
                    cmd.Parameters.AddWithValue("@hash", newHash);
                    cmd.Parameters.AddWithValue("@salt", newSalt);
                    cmd.Parameters.AddWithValue("@id", userId);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Password changed successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoginSuccess(userId, fullName, role);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Could not save password:\n{ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
        }

        private void ShowChangePasswordForm(string username, Action<string> onSave)
        {
            var dlg = new Form
            {
                Text = "Set New Password",
                Size = new Size(420, 320),
                StartPosition = FormStartPosition.CenterScreen,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.FromArgb(30, 20, 15)
            };

            var lblTitle = new Label { Text = $"Welcome, {username}!", Font = new Font("Segoe UI", 13f, FontStyle.Bold), ForeColor = Color.White, AutoSize = false, Width = 380, Height = 30, Location = new Point(20, 20), TextAlign = ContentAlignment.MiddleCenter };
            var lblSub = new Label { Text = "You are logging in for the first time.\nPlease set a new password to continue.", Font = new Font("Segoe UI", 9f), ForeColor = Color.FromArgb(200, 170, 140), AutoSize = false, Width = 380, Height = 40, Location = new Point(20, 55), TextAlign = ContentAlignment.MiddleCenter };
            var txtNew = new TextBox { PlaceholderText = "New password (min 6 characters)", UseSystemPasswordChar = true, Width = 340, Height = 30, Location = new Point(30, 110), Font = new Font("Segoe UI", 10f) };
            var txtConfirm = new TextBox { PlaceholderText = "Confirm new password", UseSystemPasswordChar = true, Width = 340, Height = 30, Location = new Point(30, 150), Font = new Font("Segoe UI", 10f) };
            var lblError = new Label { Text = "", ForeColor = Color.FromArgb(220, 80, 80), Font = new Font("Segoe UI", 8f), AutoSize = false, Width = 340, Height = 20, Location = new Point(30, 185) };
            var btnSave = new Button { Text = "Save New Password", Width = 340, Height = 40, Location = new Point(30, 210), BackColor = SessionManager.Theme.PrimaryColor, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f, FontStyle.Bold), Cursor = Cursors.Hand };
            btnSave.FlatAppearance.BorderSize = 0;

            btnSave.Click += (s, ev) =>
            {
                string newPass = txtNew.Text.Trim();
                string confirmPass = txtConfirm.Text.Trim();

                if (newPass.Length < 6) { lblError.Text = "Password must be at least 6 characters."; return; }
                if (newPass != confirmPass) { lblError.Text = "Passwords do not match."; return; }

                dlg.Close();
                onSave(newPass);
            };

            dlg.Controls.AddRange(new Control[] { lblTitle, lblSub, txtNew, txtConfirm, lblError, btnSave });
            dlg.ShowDialog(this);
        }

        private void ShakeControl(Control ctrl)
        {
            Point orig = ctrl.Location;
            int[] offsets = new[] { -6, 6, -4, 4, -2, 2, 0 };
            int index = 0;

            System.Threading.Timer? timer = null;
            timer = new System.Threading.Timer(_ =>
            {
                if (index >= offsets.Length) { timer?.Dispose(); return; }
                int offset = offsets[index++];
                if (ctrl.IsHandleCreated)
                    ctrl.BeginInvoke(new Action(() =>
                        ctrl.Location = new Point(orig.X + offset, orig.Y)));
            }, null, 0, 30);
        }

        private void txtUsername_TextChanged(object sender, EventArgs e) { }
        private void txtPassword_TextChanged(object sender, EventArgs e) { }
        private void LogIn_Load(object sender, EventArgs e) { }
    }
}