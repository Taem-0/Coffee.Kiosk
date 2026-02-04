namespace Coffee.Kiosk.CMS.Forms.WizardWoopWoop
{
    partial class StartUpWizard
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            BannerPanel = new Panel();
            panel1 = new Panel();
            label1 = new Label();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // BannerPanel
            // 
            BannerPanel.BackColor = Color.RosyBrown;
            BannerPanel.Dock = DockStyle.Left;
            BannerPanel.Location = new Point(0, 0);
            BannerPanel.Name = "BannerPanel";
            BannerPanel.Size = new Size(288, 544);
            BannerPanel.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(288, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(600, 117);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("MS PGothic", 15F, FontStyle.Bold);
            label1.Location = new Point(6, 15);
            label1.Name = "label1";
            label1.Size = new Size(486, 30);
            label1.TabIndex = 2;
            label1.Text = "Welcome to the Coffee Kiosk CMS ";
            label1.Click += label1_Click;
            // 
            // guna2Button1
            // 
            guna2Button1.BorderRadius = 15;
            guna2Button1.CustomizableEdges = customizableEdges5;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.Font = new Font("Segoe UI", 9F);
            guna2Button1.ForeColor = Color.White;
            guna2Button1.Location = new Point(745, 484);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2Button1.Size = new Size(131, 48);
            guna2Button1.TabIndex = 2;
            guna2Button1.Text = "Cancel";
            // 
            // guna2Button2
            // 
            guna2Button2.BorderRadius = 15;
            guna2Button2.CustomizableEdges = customizableEdges7;
            guna2Button2.DisabledState.BorderColor = Color.DarkGray;
            guna2Button2.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button2.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button2.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button2.Font = new Font("Segoe UI", 9F);
            guna2Button2.ForeColor = Color.White;
            guna2Button2.Location = new Point(598, 484);
            guna2Button2.Name = "guna2Button2";
            guna2Button2.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2Button2.Size = new Size(131, 48);
            guna2Button2.TabIndex = 3;
            guna2Button2.Text = "Next >";
            // 
            // StartUpWizard
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(888, 544);
            Controls.Add(guna2Button2);
            Controls.Add(guna2Button1);
            Controls.Add(panel1);
            Controls.Add(BannerPanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "StartUpWizard";
            Text = "Coffee CMS Utility Setup";
            Load += StartUpWizard_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel BannerPanel;
        private Panel panel1;
        private Label label1;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
    }
}