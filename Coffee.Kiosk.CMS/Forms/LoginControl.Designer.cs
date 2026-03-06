namespace Coffee.Kiosk.CMS.Forms
{
    partial class LoginControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginControl));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            hideButton = new Guna.UI2.WinForms.Guna2ImageButton();
            loginButton = new Guna.UI2.WinForms.Guna2Button();
            label3 = new Label();
            passwordTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            label2 = new Label();
            emailTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            label1 = new Label();
            logoPictureBox = new Guna.UI2.WinForms.Guna2PictureBox();
            guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).BeginInit();
            SuspendLayout();
            // 
            // guna2Panel1
            // 
            guna2Panel1.Controls.Add(hideButton);
            guna2Panel1.Controls.Add(loginButton);
            guna2Panel1.Controls.Add(label3);
            guna2Panel1.Controls.Add(passwordTextBox);
            guna2Panel1.Controls.Add(label2);
            guna2Panel1.Controls.Add(emailTextBox);
            guna2Panel1.Controls.Add(label1);
            guna2Panel1.CustomizableEdges = customizableEdges8;
            guna2Panel1.Dock = DockStyle.Left;
            guna2Panel1.Location = new Point(0, 0);
            guna2Panel1.Margin = new Padding(2, 2, 2, 2);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges9;
            guna2Panel1.Size = new Size(360, 480);
            guna2Panel1.TabIndex = 0;
            // 
            // hideButton
            // 
            hideButton.CheckedState.ImageSize = new Size(64, 64);
            hideButton.HoverState.ImageSize = new Size(64, 64);
            hideButton.Image = (Image)resources.GetObject("hideButton.Image");
            hideButton.ImageOffset = new Point(0, 0);
            hideButton.ImageRotate = 0F;
            hideButton.ImageSize = new Size(35, 35);
            hideButton.Location = new Point(302, 266);
            hideButton.Margin = new Padding(2, 2, 2, 2);
            hideButton.Name = "hideButton";
            hideButton.PressedState.ImageSize = new Size(64, 64);
            hideButton.ShadowDecoration.CustomizableEdges = customizableEdges1;
            hideButton.Size = new Size(28, 28);
            hideButton.TabIndex = 3;
            hideButton.Click += hideButton_Click;
            // 
            // loginButton
            // 
            loginButton.BorderRadius = 8;
            loginButton.CustomizableEdges = customizableEdges2;
            loginButton.DisabledState.BorderColor = Color.DarkGray;
            loginButton.DisabledState.CustomBorderColor = Color.DarkGray;
            loginButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            loginButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            loginButton.Font = new Font("Segoe UI", 9F);
            loginButton.ForeColor = Color.White;
            loginButton.Location = new Point(23, 342);
            loginButton.Margin = new Padding(2, 2, 2, 2);
            loginButton.Name = "loginButton";
            loginButton.ShadowDecoration.CustomizableEdges = customizableEdges3;
            loginButton.Size = new Size(314, 57);
            loginButton.TabIndex = 4;
            loginButton.Text = "LogIn";
            loginButton.Click += loginButton_Click_1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 230);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(70, 20);
            label3.TabIndex = 4;
            label3.Text = "Password";
            // 
            // passwordTextBox
            // 
            passwordTextBox.CustomizableEdges = customizableEdges4;
            passwordTextBox.DefaultText = "";
            passwordTextBox.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            passwordTextBox.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            passwordTextBox.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            passwordTextBox.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            passwordTextBox.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            passwordTextBox.Font = new Font("Segoe UI", 9F);
            passwordTextBox.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            passwordTextBox.Location = new Point(23, 258);
            passwordTextBox.Margin = new Padding(3, 4, 3, 4);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PlaceholderText = "";
            passwordTextBox.SelectedText = "";
            passwordTextBox.ShadowDecoration.CustomizableEdges = customizableEdges5;
            passwordTextBox.Size = new Size(314, 44);
            passwordTextBox.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 134);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(46, 20);
            label2.TabIndex = 2;
            label2.Text = "Email";
            // 
            // emailTextBox
            // 
            emailTextBox.CustomizableEdges = customizableEdges6;
            emailTextBox.DefaultText = "";
            emailTextBox.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            emailTextBox.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            emailTextBox.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            emailTextBox.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            emailTextBox.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            emailTextBox.Font = new Font("Segoe UI", 9F);
            emailTextBox.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            emailTextBox.Location = new Point(23, 162);
            emailTextBox.Margin = new Padding(3, 4, 3, 4);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.PlaceholderText = "";
            emailTextBox.SelectedText = "";
            emailTextBox.ShadowDecoration.CustomizableEdges = customizableEdges7;
            emailTextBox.Size = new Size(314, 44);
            emailTextBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            label1.Location = new Point(136, 81);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(95, 40);
            label1.TabIndex = 0;
            label1.Text = "LogIn";
            // 
            // logoPictureBox
            // 
            logoPictureBox.BackColor = Color.White;
            logoPictureBox.CustomizableEdges = customizableEdges10;
            logoPictureBox.FillColor = Color.Transparent;
            logoPictureBox.Image = Properties.Resources._CITYPNG_COM_Brown_Coffee_Cup_Logo_Design_HD_PNG___4000x4000;
            logoPictureBox.ImageRotate = 0F;
            logoPictureBox.InitialImage = (Image)resources.GetObject("logoPictureBox.InitialImage");
            logoPictureBox.Location = new Point(368, 68);
            logoPictureBox.Margin = new Padding(2, 2, 2, 2);
            logoPictureBox.Name = "logoPictureBox";
            logoPictureBox.ShadowDecoration.CustomizableEdges = customizableEdges11;
            logoPictureBox.Size = new Size(344, 344);
            logoPictureBox.TabIndex = 1;
            logoPictureBox.TabStop = false;
            // 
            // LoginControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            Controls.Add(logoPictureBox);
            Controls.Add(guna2Panel1);
            Margin = new Padding(2, 2, 2, 2);
            Name = "LoginControl";
            Size = new Size(720, 480);
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Label label1;
        private Label label2;
        private Guna.UI2.WinForms.Guna2TextBox emailTextBox;
        private Label label3;
        private Guna.UI2.WinForms.Guna2TextBox passwordTextBox;
        private Guna.UI2.WinForms.Guna2Button loginButton;
        private Guna.UI2.WinForms.Guna2PictureBox logoPictureBox;
        private Guna.UI2.WinForms.Guna2ImageButton hideButton;
    }
}
