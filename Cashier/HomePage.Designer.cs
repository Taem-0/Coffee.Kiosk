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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePage));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlTopBar = new Panel();
            lblClock = new Label();
            lblCashier = new Label();
            lnlBrand = new Label();
            picLogo = new PictureBox();
            btnLogout = new Guna.UI2.WinForms.Guna2Button();
            pnlContainer = new Panel();
            pnlTopBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // pnlTopBar
            // 
            pnlTopBar.Anchor = AnchorStyles.Top;
            pnlTopBar.BackColor = Color.FromArgb(107, 77, 58);
            pnlTopBar.Controls.Add(btnLogout);
            pnlTopBar.Controls.Add(lblClock);
            pnlTopBar.Controls.Add(lblCashier);
            pnlTopBar.Controls.Add(lnlBrand);
            pnlTopBar.Controls.Add(picLogo);
            pnlTopBar.Location = new Point(-1, -1);
            pnlTopBar.Name = "pnlTopBar";
            pnlTopBar.Size = new Size(1929, 79);
            pnlTopBar.TabIndex = 0;
            // 
            // lblClock
            // 
            lblClock.BackColor = Color.Transparent;
            lblClock.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblClock.ForeColor = Color.White;
            lblClock.Location = new Point(1613, 21);
            lblClock.Name = "lblClock";
            lblClock.Size = new Size(120, 35);
            lblClock.TabIndex = 5;
            lblClock.Text = "Time In";
            lblClock.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblCashier
            // 
            lblCashier.BackColor = Color.Transparent;
            lblCashier.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCashier.ForeColor = Color.White;
            lblCashier.Location = new Point(1325, 21);
            lblCashier.Name = "lblCashier";
            lblCashier.Size = new Size(273, 35);
            lblCashier.TabIndex = 4;
            lblCashier.Text = "Cashier Staff -";
            // 
            // lnlBrand
            // 
            lnlBrand.AutoSize = true;
            lnlBrand.BackColor = Color.Transparent;
            lnlBrand.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lnlBrand.ForeColor = Color.White;
            lnlBrand.Location = new Point(92, 18);
            lnlBrand.Name = "lnlBrand";
            lnlBrand.Size = new Size(252, 46);
            lnlBrand.TabIndex = 3;
            lnlBrand.Text = "CAFÉ FILIPINO";
            // 
            // picLogo
            // 
            picLogo.BackgroundImage = (Image)resources.GetObject("picLogo.BackgroundImage");
            picLogo.BackgroundImageLayout = ImageLayout.Zoom;
            picLogo.Location = new Point(12, 8);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(81, 65);
            picLogo.TabIndex = 2;
            picLogo.TabStop = false;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(111, 77, 56);
            btnLogout.BorderRadius = 10;
            btnLogout.CustomizableEdges = customizableEdges3;
            btnLogout.DisabledState.BorderColor = Color.DarkGray;
            btnLogout.DisabledState.CustomBorderColor = Color.DarkGray;
            btnLogout.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnLogout.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnLogout.FillColor = Color.FromArgb(212, 184, 150);
            btnLogout.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.FromArgb(59, 35, 20);
            btnLogout.Location = new Point(1771, 17);
            btnLogout.Name = "btnLogout";
            btnLogout.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnLogout.Size = new Size(131, 39);
            btnLogout.TabIndex = 6;
            btnLogout.Text = "Logout";
            // 
            // pnlContainer
            // 
            pnlContainer.BackColor = Color.FromArgb(250, 246, 243);
            pnlContainer.Location = new Point(-1, 78);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Size = new Size(1921, 1002);
            pnlContainer.TabIndex = 1;
            // 
            // HomePage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(250, 246, 243);
            ClientSize = new Size(1920, 1080);
            Controls.Add(pnlContainer);
            Controls.Add(pnlTopBar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "HomePage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HomePage";
            WindowState = FormWindowState.Maximized;
            pnlTopBar.ResumeLayout(false);
            pnlTopBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTopBar;
        private PictureBox picLogo;
        private Label lnlBrand;
        private Label lblCashier;
        private Label lblClock;
        private Guna.UI2.WinForms.Guna2Button btnLogout;
        private Panel pnlContainer;
    }
}