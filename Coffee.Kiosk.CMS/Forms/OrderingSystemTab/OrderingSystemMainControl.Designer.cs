namespace Coffee.Kiosk.CMS.Forms.OrderingSystemTab
{
    partial class OrderingSystemMainControl
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
            MainScreen = new Panel();
            DarkOverlayPanel = new Guna.UI2.WinForms.Guna2Panel();
            SuspendLayout();
            // 
            // MainScreen
            // 
            MainScreen.Dock = DockStyle.Fill;
            MainScreen.Location = new Point(0, 0);
            MainScreen.Name = "MainScreen";
            MainScreen.Size = new Size(1008, 657);
            MainScreen.TabIndex = 2;
            // 
            // DarkOverlayPanel
            // 
            DarkOverlayPanel.BackColor = Color.Transparent;
            DarkOverlayPanel.CustomizableEdges = customizableEdges1;
            DarkOverlayPanel.Dock = DockStyle.Fill;
            DarkOverlayPanel.FillColor = Color.FromArgb(67, 0, 0, 0);
            DarkOverlayPanel.Location = new Point(0, 0);
            DarkOverlayPanel.Name = "DarkOverlayPanel";
            DarkOverlayPanel.ShadowDecoration.CustomizableEdges = customizableEdges2;
            DarkOverlayPanel.Size = new Size(1008, 657);
            DarkOverlayPanel.TabIndex = 0;
            DarkOverlayPanel.UseTransparentBackground = true;
            DarkOverlayPanel.Visible = false;
            DarkOverlayPanel.Click += DarkOverlayPanel_Click;
            // 
            // OrderingSystemMainControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(MainScreen);
            Controls.Add(DarkOverlayPanel);
            Name = "OrderingSystemMainControl";
            Size = new Size(1008, 657);
            Load += OrderingSystemMainControl_Load;
            ResumeLayout(false);
        }

        #endregion

        private Panel MainScreen;
        private Guna.UI2.WinForms.Guna2Panel DarkOverlayPanel;
    }
}
