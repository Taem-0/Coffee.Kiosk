namespace Coffee.Kiosk.OrderingSystem.UserControls
{
    partial class PayOptionScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PayOptionScreen));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panel1 = new Panel();
            panel3 = new Panel();
            panel8 = new Panel();
            CompanyLogo = new PictureBox();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            BackButton = new MaterialSkin.Controls.MaterialFloatingActionButton();
            panel2 = new Panel();
            panel6 = new Panel();
            panel7 = new Panel();
            BackButton2 = new Guna.UI2.WinForms.Guna2Button();
            panel4 = new Panel();
            PayWithGcashBtn = new Guna.UI2.WinForms.Guna2Button();
            panel5 = new Panel();
            guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CompanyLogo).BeginInit();
            panel2.SuspendLayout();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(BackButton);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(676, 345);
            panel1.TabIndex = 3;
            // 
            // panel3
            // 
            panel3.Controls.Add(panel8);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 84);
            panel3.MinimumSize = new Size(426, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(676, 261);
            panel3.TabIndex = 3;
            // 
            // panel8
            // 
            panel8.Controls.Add(CompanyLogo);
            panel8.Controls.Add(guna2HtmlLabel1);
            panel8.Location = new Point(193, 3);
            panel8.Name = "panel8";
            panel8.Size = new Size(395, 259);
            panel8.TabIndex = 3;
            // 
            // CompanyLogo
            // 
            CompanyLogo.Image = Properties.Resources.default_icon;
            CompanyLogo.Location = new Point(121, 0);
            CompanyLogo.Margin = new Padding(0);
            CompanyLogo.Name = "CompanyLogo";
            CompanyLogo.Size = new Size(167, 167);
            CompanyLogo.SizeMode = PictureBoxSizeMode.Zoom;
            CompanyLogo.TabIndex = 1;
            CompanyLogo.TabStop = false;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.Location = new Point(34, 166);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(331, 92);
            guna2HtmlLabel1.TabIndex = 2;
            guna2HtmlLabel1.Text = "Where would you like \r\n<br>\r\n<div style='text-align:center;'>to pay?</div>";
            // 
            // BackButton
            // 
            BackButton.AnimateShowHideButton = true;
            BackButton.Depth = 0;
            BackButton.DrawShadows = false;
            BackButton.Icon = (Image)resources.GetObject("BackButton.Icon");
            BackButton.Location = new Point(19, 20);
            BackButton.Margin = new Padding(0);
            BackButton.MouseState = MaterialSkin.MouseState.HOVER;
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(59, 61);
            BackButton.TabIndex = 2;
            BackButton.Text = "materialFloatingActionButton1";
            BackButton.UseVisualStyleBackColor = true;
            BackButton.Click += BackButton_Click;
            // 
            // panel2
            // 
            panel2.AutoScroll = true;
            panel2.Controls.Add(panel6);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 345);
            panel2.MinimumSize = new Size(0, 510);
            panel2.Name = "panel2";
            panel2.Size = new Size(676, 510);
            panel2.TabIndex = 4;
            // 
            // panel6
            // 
            panel6.Controls.Add(panel7);
            panel6.Controls.Add(panel4);
            panel6.Location = new Point(64, 20);
            panel6.Name = "panel6";
            panel6.Size = new Size(558, 444);
            panel6.TabIndex = 7;
            // 
            // panel7
            // 
            panel7.Controls.Add(BackButton2);
            panel7.Dock = DockStyle.Bottom;
            panel7.Location = new Point(0, 394);
            panel7.Name = "panel7";
            panel7.Size = new Size(558, 50);
            panel7.TabIndex = 8;
            // 
            // BackButton2
            // 
            BackButton2.BorderColor = Color.FromArgb(77, 61, 51);
            BackButton2.BorderRadius = 13;
            BackButton2.BorderThickness = 1;
            BackButton2.CustomizableEdges = customizableEdges1;
            BackButton2.DisabledState.BorderColor = Color.DarkGray;
            BackButton2.DisabledState.CustomBorderColor = Color.DarkGray;
            BackButton2.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            BackButton2.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            BackButton2.FillColor = Color.FromArgb(128, 103, 86);
            BackButton2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BackButton2.ForeColor = Color.White;
            BackButton2.Location = new Point(171, 3);
            BackButton2.Name = "BackButton2";
            BackButton2.ShadowDecoration.CustomizableEdges = customizableEdges2;
            BackButton2.Size = new Size(219, 45);
            BackButton2.TabIndex = 7;
            BackButton2.Text = "Back";
            BackButton2.Click += BackButton2_Click;
            // 
            // panel4
            // 
            panel4.Controls.Add(PayWithGcashBtn);
            panel4.Controls.Add(panel5);
            panel4.Controls.Add(guna2Button2);
            panel4.Location = new Point(0, 0);
            panel4.Margin = new Padding(0);
            panel4.Name = "panel4";
            panel4.Size = new Size(554, 280);
            panel4.TabIndex = 6;
            // 
            // PayWithGcashBtn
            // 
            PayWithGcashBtn.BorderRadius = 17;
            PayWithGcashBtn.BorderThickness = 1;
            PayWithGcashBtn.CustomizableEdges = customizableEdges3;
            PayWithGcashBtn.DisabledState.BorderColor = Color.DarkGray;
            PayWithGcashBtn.DisabledState.CustomBorderColor = Color.DarkGray;
            PayWithGcashBtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            PayWithGcashBtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            PayWithGcashBtn.Dock = DockStyle.Left;
            PayWithGcashBtn.FillColor = Color.White;
            PayWithGcashBtn.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PayWithGcashBtn.ForeColor = Color.Black;
            PayWithGcashBtn.Image = Properties.Resources.PayWithGcash;
            PayWithGcashBtn.ImageOffset = new Point(0, 125);
            PayWithGcashBtn.ImageSize = new Size(300, 300);
            PayWithGcashBtn.Location = new Point(301, 0);
            PayWithGcashBtn.Name = "PayWithGcashBtn";
            PayWithGcashBtn.ShadowDecoration.CustomizableEdges = customizableEdges4;
            PayWithGcashBtn.Size = new Size(250, 280);
            PayWithGcashBtn.TabIndex = 4;
            PayWithGcashBtn.Text = "Pay Using Gcash";
            PayWithGcashBtn.Tile = true;
            // 
            // panel5
            // 
            panel5.Dock = DockStyle.Left;
            panel5.Location = new Point(250, 0);
            panel5.Margin = new Padding(0);
            panel5.Name = "panel5";
            panel5.Size = new Size(51, 280);
            panel5.TabIndex = 3;
            // 
            // guna2Button2
            // 
            guna2Button2.BorderRadius = 17;
            guna2Button2.BorderThickness = 1;
            guna2Button2.CustomizableEdges = customizableEdges5;
            guna2Button2.DisabledState.BorderColor = Color.DarkGray;
            guna2Button2.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button2.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button2.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button2.Dock = DockStyle.Left;
            guna2Button2.FillColor = Color.White;
            guna2Button2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2Button2.ForeColor = Color.Black;
            guna2Button2.Image = Properties.Resources.PayCash;
            guna2Button2.ImageOffset = new Point(0, 125);
            guna2Button2.ImageSize = new Size(300, 300);
            guna2Button2.Location = new Point(0, 0);
            guna2Button2.Name = "guna2Button2";
            guna2Button2.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2Button2.Size = new Size(250, 280);
            guna2Button2.TabIndex = 5;
            guna2Button2.Text = "Pay Cash";
            guna2Button2.Tile = true;
            // 
            // PayOptionScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            Controls.Add(panel2);
            Controls.Add(panel1);
            MinimumSize = new Size(0, 855);
            Name = "PayOptionScreen";
            Size = new Size(676, 855);
            Load += PayOptionScreen_Load;
            Resize += PayOptionScreen_Resize;
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)CompanyLogo).EndInit();
            panel2.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private MaterialSkin.Controls.MaterialFloatingActionButton BackButton;
        private PictureBox CompanyLogo;
        private Panel panel2;
        private Panel panel4;
        private Guna.UI2.WinForms.Guna2Button PayWithGcashBtn;
        private Panel panel5;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Panel panel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Panel panel6;
        private Guna.UI2.WinForms.Guna2Button BackButton2;
        private Panel panel7;
        private Panel panel8;
    }
}
