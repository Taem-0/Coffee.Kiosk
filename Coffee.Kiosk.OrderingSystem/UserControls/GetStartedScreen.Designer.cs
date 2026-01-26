namespace Coffee.Kiosk.OrderingSystem
{
    partial class GetStartedScreen
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panelButtonGetStarted = new Panel();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            panelButtonGetStarted.SuspendLayout();
            SuspendLayout();
            // 
            // panelButtonGetStarted
            // 
            panelButtonGetStarted.BackColor = Color.Transparent;
            panelButtonGetStarted.Controls.Add(guna2Button1);
            panelButtonGetStarted.Location = new Point(203, 433);
            panelButtonGetStarted.Margin = new Padding(3, 2, 3, 2);
            panelButtonGetStarted.Name = "panelButtonGetStarted";
            panelButtonGetStarted.Size = new Size(262, 50);
            panelButtonGetStarted.TabIndex = 1;
            // 
            // guna2Button1
            // 
            guna2Button1.Animated = true;
            guna2Button1.AutoRoundedCorners = true;
            guna2Button1.BorderRadius = 24;
            guna2Button1.BorderThickness = 2;
            guna2Button1.CustomizableEdges = customizableEdges1;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2Button1.ForeColor = Color.Wheat;
            guna2Button1.Location = new Point(0, 0);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Button1.Size = new Size(259, 50);
            guna2Button1.TabIndex = 2;
            guna2Button1.Text = "Get Started";
            guna2Button1.Click += guna2Button1_Click;
            // 
            // GetStartedScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Zoom;
            Controls.Add(panelButtonGetStarted);
            Margin = new Padding(3, 2, 3, 2);
            Name = "GetStartedScreen";
            Size = new Size(675, 559);
            Load += GetStartedScreen_Load;
            Resize += GetStartedScreen_Resize;
            panelButtonGetStarted.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panelButtonGetStarted;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}
