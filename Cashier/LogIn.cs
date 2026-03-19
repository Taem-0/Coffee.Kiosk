using Coffee.Kiosk.Cashier;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cashier
{
    public partial class LogIn : Form
    {
        private const string DEFAULT_PASSWORD = "cafe1234";

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

            /* UNCOMMENT WHEN DATABASE IS READY =================================
 
            try
            {
                using var conn = DBHelper.GetConnection();
                conn.Open();
 
                var cmd = new MySql.Data.MySqlClient.MySqlCommand(@"
                    SELECT id, username, role, password
                    FROM   users
                    WHERE  username  = @user
                    AND    is_active = 1",
                    conn);
                cmd.Parameters.AddWithValue("@user", user);
 
                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string dbPass = reader.GetString("password");
                    string role   = reader.GetString("role");
                    int    uid    = reader.GetInt32("id");
                    reader.Close();
 
                    if (dbPass == pass)
                    {
                        if (pass == DEFAULT_PASSWORD)
                        {
                            ShowChangePasswordDialog(uid, user, role);
                            return;
                        }
                        LoginSuccess(uid, user, role);
                    }
                    else
                    {
                        ShakeControl(txtUsername);
                        ShakeControl(txtPassword);
                        txtPassword.Clear();
                        txtPassword.Focus();
                    }
                }
                else
                {
                    ShakeControl(txtUsername);
                    ShakeControl(txtPassword);
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
 
            END UNCOMMENT ===================================================*/

            // ── HARDCODED LOGIN (delete this block when DB is ready) ──────────
            bool isValid =
                (user == "admin" && pass == "admin123") ||
                (user == "cashier" && pass == "cashier123") ||
                (user == "cashier" && pass == DEFAULT_PASSWORD);

            if (isValid)
            {
                if (pass == DEFAULT_PASSWORD)
                {
                    ShowChangePasswordDialogOffline(user);
                    return;
                }
                string role = user == "admin" ? "Admin" : "Cashier";
                LoginSuccess(1, user, role);
            }
            else
            {
                ShakeControl(txtUsername);
                ShakeControl(txtPassword);
                txtPassword.Clear();
                txtPassword.Focus();
            }
            // ── END HARDCODED BLOCK ───────────────────────────────────────────
        }

        private void LoginSuccess(int userId, string username, string role)
        {
            SessionManager.CurrentUser = new UserModel
            {
                UserID = userId,
                Username = username,
                Role = role
            };
            var home = new HomePage();
            home.Show();
            this.Hide();
        }

        private void ShowChangePasswordDialogOffline(string username)
        {
            ShowChangePasswordForm(username, (newPass) =>
            {
                MessageBox.Show("Password changed successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                string role = username == "admin" ? "Admin" : "Cashier";
                LoginSuccess(1, username, role);
            });
        }

        /* UNCOMMENT WHEN DATABASE IS READY =====================================
 
        private void ShowChangePasswordDialog(int userId, string username, string role)
        {
            ShowChangePasswordForm(username, (newPass) =>
            {
                try
                {
                    using var conn = DBHelper.GetConnection();
                    conn.Open();
                    var cmd = new MySql.Data.MySqlClient.MySqlCommand(
                        "UPDATE users SET password = @newPass WHERE id = @uid", conn);
                    cmd.Parameters.AddWithValue("@newPass", newPass);
                    cmd.Parameters.AddWithValue("@uid",     userId);
                    cmd.ExecuteNonQuery();
 
                    MessageBox.Show("Password changed successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoginSuccess(userId, username, role);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Could not save password:\n{ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
        }
 
        END UNCOMMENT =======================================================*/

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

            var lblTitle = new Label
            {
                Text = $"Welcome, {username}!",
                Font = new Font("Segoe UI", 13f, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = false,
                Width = 380,
                Height = 30,
                Location = new Point(20, 20),
                TextAlign = ContentAlignment.MiddleCenter
            };
            var lblSub = new Label
            {
                Text = "You are using the default password.\nPlease set a new password to continue.",
                Font = new Font("Segoe UI", 9f),
                ForeColor = Color.FromArgb(200, 170, 140),
                AutoSize = false,
                Width = 380,
                Height = 40,
                Location = new Point(20, 55),
                TextAlign = ContentAlignment.MiddleCenter
            };
            var txtNew = new TextBox
            {
                PlaceholderText = "New password (min 6 characters)",
                UseSystemPasswordChar = true,
                Width = 340,
                Height = 30,
                Location = new Point(30, 110),
                Font = new Font("Segoe UI", 10f)
            };
            var txtConfirm = new TextBox
            {
                PlaceholderText = "Confirm new password",
                UseSystemPasswordChar = true,
                Width = 340,
                Height = 30,
                Location = new Point(30, 150),
                Font = new Font("Segoe UI", 10f)
            };
            var lblError = new Label
            {
                Text = "",
                ForeColor = Color.FromArgb(220, 80, 80),
                Font = new Font("Segoe UI", 8f),
                AutoSize = false,
                Width = 340,
                Height = 20,
                Location = new Point(30, 185)
            };
            var btnSave = new Button
            {
                Text = "Save New Password",
                Width = 340,
                Height = 40,
                Location = new Point(30, 210),
                BackColor = Color.FromArgb(107, 79, 58),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnSave.FlatAppearance.BorderSize = 0;

            btnSave.Click += (s, ev) =>
            {
                string newPass = txtNew.Text.Trim();
                string confirmPass = txtConfirm.Text.Trim();

                if (newPass.Length < 6)
                { lblError.Text = "Password must be at least 6 characters."; return; }

                if (newPass == DEFAULT_PASSWORD)
                { lblError.Text = "Cannot reuse the default password."; return; }

                if (newPass != confirmPass)
                { lblError.Text = "Passwords do not match."; return; }

                dlg.Close();
                onSave(newPass);
            };

            dlg.Controls.AddRange(new Control[]
                { lblTitle, lblSub, txtNew, txtConfirm, lblError, btnSave });
            dlg.ShowDialog(this);
        }

        // ── SHAKE ANIMATION ───────────────────────────────────────────────────
        // Renamed to ShakeControl to avoid any conflicts
        private void ShakeControl(Control ctrl)
        {
            Point orig = ctrl.Location;
            int[] offsets = new[] { -6, 6, -4, 4, -2, 2, 0 };

            System.Threading.Timer? timer = null;
            int index = 0;

            timer = new System.Threading.Timer(_ =>
            {
                if (index >= offsets.Length)
                {
                    timer?.Dispose();
                    return;
                }
                int offset = offsets[index++];
                if (ctrl.IsHandleCreated)
                {
                    ctrl.BeginInvoke(new Action(() =>
                    {
                        ctrl.Location = new Point(orig.X + offset, orig.Y);
                    }));
                }
            }, null, 0, 30);
        }

        // ── KEYBOARD SHORTCUTS ────────────────────────────────────────────────
        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        { if (e.KeyCode == Keys.Enter) txtPassword.Focus(); }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        { if (e.KeyCode == Keys.Enter) btnLogin_Click(sender, e); }

        // ── EMPTY STUBS ───────────────────────────────────────────────────────
        private void txtUsername_TextChanged(object sender, EventArgs e) { }
        private void txtPassword_TextChanged(object sender, EventArgs e) { }
    }
}