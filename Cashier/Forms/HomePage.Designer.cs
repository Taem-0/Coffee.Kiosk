namespace Coffee.Kiosk.Cashier
{
    partial class HomePage
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlTopBar = new Panel();
            btnBell = new Guna.UI2.WinForms.Guna2CircleButton();
            btnLogout = new Guna.UI2.WinForms.Guna2Button();
            lblClock = new Label();
            lblCashier = new Label();
            ShopName = new Label();
            LogoPath = new PictureBox();
            pnlContainer = new Panel();
            tmrClock = new System.Windows.Forms.Timer(components);
            pnlTopBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LogoPath).BeginInit();
            SuspendLayout();
            // 
            // pnlTopBar
            // 
            pnlTopBar.BackColor = Color.FromArgb(107, 77, 58);
            pnlTopBar.Controls.Add(btnBell);
            pnlTopBar.Controls.Add(btnLogout);
            pnlTopBar.Controls.Add(lblClock);
            pnlTopBar.Controls.Add(lblCashier);
            pnlTopBar.Controls.Add(ShopName);
            pnlTopBar.Controls.Add(LogoPath);
            pnlTopBar.Dock = DockStyle.Top;
            pnlTopBar.Location = new Point(0, 0);
            pnlTopBar.Margin = new Padding(4, 4, 4, 4);
            pnlTopBar.Name = "pnlTopBar";
            pnlTopBar.Size = new Size(1946, 99);
            pnlTopBar.TabIndex = 0;
            // 
            // btnBell
            // 
            btnBell.BorderColor = Color.FromArgb(111, 77, 56);
            btnBell.BorderThickness = 3;
            btnBell.DisabledState.BorderColor = Color.DarkGray;
            btnBell.DisabledState.CustomBorderColor = Color.DarkGray;
            btnBell.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnBell.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnBell.FillColor = Color.FromArgb(212, 184, 150);
            btnBell.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBell.ForeColor = Color.FromArgb(111, 77, 56);
            btnBell.Location = new Point(1566, 15);
            btnBell.Margin = new Padding(4, 4, 4, 4);
            btnBell.Name = "btnBell";
            btnBell.ShadowDecoration.CustomizableEdges = customizableEdges1;
            btnBell.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            btnBell.Size = new Size(69, 69);
            btnBell.TabIndex = 7;
            btnBell.Text = "🔔";
            btnBell.Click += btnBell_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(111, 77, 56);
            btnLogout.BorderRadius = 10;
            btnLogout.CustomizableEdges = customizableEdges2;
            btnLogout.DisabledState.BorderColor = Color.DarkGray;
            btnLogout.DisabledState.CustomBorderColor = Color.DarkGray;
            btnLogout.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnLogout.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnLogout.FillColor = Color.FromArgb(212, 184, 150);
            btnLogout.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.FromArgb(59, 35, 20);
            btnLogout.Location = new Point(2214, 21);
            btnLogout.Margin = new Padding(4, 4, 4, 4);
            btnLogout.Name = "btnLogout";
            btnLogout.ShadowDecoration.CustomizableEdges = customizableEdges3;
            btnLogout.Size = new Size(164, 49);
            btnLogout.TabIndex = 6;
            btnLogout.Text = "Logout";
            btnLogout.Click += btnLogout_Click;
            // 
            // lblClock
            // 
            lblClock.BackColor = Color.Transparent;
            lblClock.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblClock.ForeColor = Color.White;
            lblClock.Location = new Point(2016, 26);
            lblClock.Margin = new Padding(4, 0, 4, 0);
            lblClock.Name = "lblClock";
            lblClock.Size = new Size(150, 44);
            lblClock.TabIndex = 5;
            lblClock.Text = "Time In";
            lblClock.TextAlign = ContentAlignment.TopCenter;
            lblClock.Click += lblClock_Click;
            // 
            // lblCashier
            // 
            lblCashier.BackColor = Color.Transparent;
            lblCashier.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCashier.ForeColor = Color.White;
            lblCashier.Location = new Point(1656, 26);
            lblCashier.Margin = new Padding(4, 0, 4, 0);
            lblCashier.Name = "lblCashier";
            lblCashier.Size = new Size(341, 44);
            lblCashier.TabIndex = 4;
            lblCashier.Text = "Cashier Staff -";
            lblCashier.Click += lblCashier_Click;
            // 
            // ShopName
            // 
            ShopName.AutoSize = true;
            ShopName.BackColor = Color.Transparent;
            ShopName.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ShopName.ForeColor = Color.White;
            ShopName.Location = new Point(121, 22);
            ShopName.Margin = new Padding(4, 0, 4, 0);
            ShopName.Name = "ShopName";
            ShopName.Size = new Size(296, 54);
            ShopName.TabIndex = 3;
            ShopName.Text = "CAFÉ FILIPINO";
            // 
            // LogoPath
            // 
            LogoPath.BackColor = Color.FromArgb(255, 224, 192);
            LogoPath.BackgroundImageLayout = ImageLayout.Zoom;
            LogoPath.Location = new Point(33, 11);
            LogoPath.Margin = new Padding(4, 4, 4, 4);
            LogoPath.Name = "LogoPath";
            LogoPath.Size = new Size(80, 80);
            LogoPath.TabIndex = 2;
            LogoPath.TabStop = false;
            // 
            // pnlContainer
            // 
            pnlContainer.BackColor = Color.FromArgb(250, 246, 243);
            pnlContainer.Dock = DockStyle.Fill;
            pnlContainer.Location = new Point(0, 99);
            pnlContainer.Margin = new Padding(4, 4, 4, 4);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Size = new Size(1946, 1127);
            pnlContainer.TabIndex = 1;
            // 
            // tmrClock
            // 
            tmrClock.Enabled = true;
            tmrClock.Interval = 1000;
            tmrClock.Tick += tmrClock_Tick;
            // 
            // HomePage
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(250, 246, 243);
            ClientSize = new Size(1946, 1226);
            Controls.Add(pnlContainer);
            Controls.Add(pnlTopBar);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 4, 4, 4);
            Name = "HomePage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HomePage";
            WindowState = FormWindowState.Maximized;
            pnlTopBar.ResumeLayout(false);
            pnlTopBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)LogoPath).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTopBar;
        private PictureBox LogoPath;
        private Label ShopName;
        private Label lblCashier;
        private Label lblClock;
        private Guna.UI2.WinForms.Guna2Button btnLogout;
        private Panel pnlContainer;
        private System.Windows.Forms.Timer tmrClock;
        private Guna.UI2.WinForms.Guna2CircleButton btnBell;
    }
}