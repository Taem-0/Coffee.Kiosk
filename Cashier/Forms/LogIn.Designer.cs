namespace Cashier
{
    partial class LogIn
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            LogoPath = new PictureBox();
            ShopName = new Label();
            txtUsername = new Guna.UI2.WinForms.Guna2TextBox();
            label2 = new Label();
            btnLogin = new Guna.UI2.WinForms.Guna2Button();
            txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            lblError = new Label();
            ((System.ComponentModel.ISupportInitialize)LogoPath).BeginInit();
            SuspendLayout();
            // 
            // LogoPath
            // 
            LogoPath.BackColor = Color.FromArgb(107, 77, 58);
            LogoPath.BackgroundImageLayout = ImageLayout.Zoom;
            LogoPath.Location = new Point(757, 350);
            LogoPath.Margin = new Padding(4, 4, 4, 4);
            LogoPath.Name = "LogoPath";
            LogoPath.Size = new Size(185, 185);
            LogoPath.TabIndex = 1;
            LogoPath.TabStop = false;
            // 
            // ShopName
            // 
            ShopName.AutoSize = true;
            ShopName.BackColor = Color.Transparent;
            ShopName.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ShopName.ForeColor = Color.White;
            ShopName.Location = new Point(950, 366);
            ShopName.Margin = new Padding(4, 0, 4, 0);
            ShopName.Name = "ShopName";
            ShopName.Size = new Size(706, 128);
            ShopName.TabIndex = 2;
            ShopName.Text = "CAFÉ FILIPINO";
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.Transparent;
            txtUsername.BorderColor = Color.FromArgb(107, 79, 58);
            txtUsername.BorderRadius = 20;
            txtUsername.BorderThickness = 3;
            txtUsername.CustomizableEdges = customizableEdges1;
            txtUsername.DefaultText = "";
            txtUsername.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtUsername.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtUsername.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtUsername.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtUsername.FillColor = Color.FromArgb(44, 44, 42);
            txtUsername.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtUsername.Font = new Font("Segoe UI", 10F);
            txtUsername.ForeColor = Color.White;
            txtUsername.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtUsername.Location = new Point(838, 600);
            txtUsername.Margin = new Padding(4, 6, 4, 6);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Email";
            txtUsername.SelectedText = "";
            txtUsername.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtUsername.Size = new Size(775, 80);
            txtUsername.TabIndex = 3;
            txtUsername.TextChanged += txtUsername_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(880, 592);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(0, 32);
            label2.TabIndex = 5;
            // 
            // btnLogin
            // 
            btnLogin.BorderRadius = 20;
            btnLogin.CustomizableEdges = customizableEdges3;
            btnLogin.DisabledState.BorderColor = Color.DarkGray;
            btnLogin.DisabledState.CustomBorderColor = Color.DarkGray;
            btnLogin.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnLogin.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnLogin.FillColor = Color.FromArgb(107, 79, 58);
            btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(1029, 900);
            btnLogin.Margin = new Padding(4, 4, 4, 4);
            btnLogin.Name = "btnLogin";
            btnLogin.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnLogin.Size = new Size(394, 70);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "Login";
            btnLogin.Click += btnLogin_Click;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.Transparent;
            txtPassword.BorderColor = Color.FromArgb(107, 79, 58);
            txtPassword.BorderRadius = 20;
            txtPassword.BorderThickness = 3;
            txtPassword.CustomizableEdges = customizableEdges5;
            txtPassword.DefaultText = "";
            txtPassword.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtPassword.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtPassword.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtPassword.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtPassword.FillColor = Color.FromArgb(44, 44, 42);
            txtPassword.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPassword.Font = new Font("Segoe UI", 10F);
            txtPassword.ForeColor = Color.White;
            txtPassword.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPassword.Location = new Point(838, 730);
            txtPassword.Margin = new Padding(4, 6, 4, 6);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Password";
            txtPassword.SelectedText = "";
            txtPassword.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtPassword.Size = new Size(775, 80);
            txtPassword.TabIndex = 7;
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.TextChanged += txtPassword_TextChanged;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.BackColor = Color.Transparent;
            lblError.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblError.ForeColor = Color.White;
            lblError.Location = new Point(1078, 856);
            lblError.Margin = new Padding(4, 0, 4, 0);
            lblError.Name = "lblError";
            lblError.Size = new Size(305, 30);
            lblError.TabIndex = 8;
            lblError.Text = "Invalid username or password.";
            lblError.Visible = false;
            // 
            // LogIn
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(44, 44, 42);
            ClientSize = new Size(1946, 1226);
            Controls.Add(lblError);
            Controls.Add(txtPassword);
            Controls.Add(btnLogin);
            Controls.Add(label2);
            Controls.Add(txtUsername);
            Controls.Add(ShopName);
            Controls.Add(LogoPath);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 4, 4, 4);
            Name = "LogIn";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Log In";
            Load += LogIn_Load;
            ((System.ComponentModel.ISupportInitialize)LogoPath).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox LogoPath;
        private Label ShopName;
        private Guna.UI2.WinForms.Guna2TextBox txtUsername;
        private Label label2;
        private Guna.UI2.WinForms.Guna2Button btnLogin;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private Label lblError;
    }
}
