namespace Coffee.Kiosk.OrderingSystem
{
    partial class CoffeeKioskMainForm
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            mainPanel = new Panel();
            modalOverlayPanel = new Guna.UI2.WinForms.Guna2Panel();
            modalMainScreen = new Guna.UI2.WinForms.Guna2Panel();
            modalOverlayPanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.PapayaWhip;
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(676, 675);
            mainPanel.TabIndex = 0;
            // 
            // modalOverlayPanel
            // 
            modalOverlayPanel.BackColor = Color.Transparent;
            modalOverlayPanel.Controls.Add(modalMainScreen);
            modalOverlayPanel.CustomizableEdges = customizableEdges3;
            modalOverlayPanel.Dock = DockStyle.Fill;
            modalOverlayPanel.Location = new Point(0, 0);
            modalOverlayPanel.Name = "modalOverlayPanel";
            modalOverlayPanel.ShadowDecoration.CustomizableEdges = customizableEdges4;
            modalOverlayPanel.Size = new Size(676, 675);
            modalOverlayPanel.TabIndex = 2;
            modalOverlayPanel.UseTransparentBackground = true;
            modalOverlayPanel.Visible = false;
            // 
            // modalMainScreen
            // 
            modalMainScreen.BackColor = Color.White;
            modalMainScreen.CustomizableEdges = customizableEdges1;
            modalMainScreen.Location = new Point(0, 0);
            modalMainScreen.Margin = new Padding(150);
            modalMainScreen.Name = "modalMainScreen";
            modalMainScreen.ShadowDecoration.CustomizableEdges = customizableEdges2;
            modalMainScreen.Size = new Size(676, 675);
            modalMainScreen.TabIndex = 3;
            // 
            // CoffeeKioskMainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(676, 675);
            Controls.Add(modalOverlayPanel);
            Controls.Add(mainPanel);
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new Size(0, 675);
            Name = "CoffeeKioskMainForm";
            RightToLeft = RightToLeft.No;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "KIOSK";
            Load += CoffeeKiosk_Load;
            Resize += CoffeeKioskMainForm_Resize;
            modalOverlayPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel mainPanel;
        private Guna.UI2.WinForms.Guna2Panel modalOverlayPanel;
        private Guna.UI2.WinForms.Guna2Panel modalMainScreen;
    }
}
