namespace Coffee.Kiosk.CMS.Forms.OrderingSystemTab.UserControls
{
    partial class TipButton
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
            TIpBtn = new Guna.UI2.WinForms.Guna2Button();
            SuspendLayout();
            // 
            // TIpBtn
            // 
            TIpBtn.CustomizableEdges = customizableEdges1;
            TIpBtn.DisabledState.BorderColor = Color.DarkGray;
            TIpBtn.DisabledState.CustomBorderColor = Color.DarkGray;
            TIpBtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            TIpBtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            TIpBtn.Dock = DockStyle.Fill;
            TIpBtn.FillColor = Color.Transparent;
            TIpBtn.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TIpBtn.ForeColor = Color.Black;
            TIpBtn.Image = Properties.Resources.default_icon;
            TIpBtn.ImageSize = new Size(30, 30);
            TIpBtn.Location = new Point(0, 0);
            TIpBtn.Name = "TIpBtn";
            TIpBtn.ShadowDecoration.CustomizableEdges = customizableEdges2;
            TIpBtn.Size = new Size(40, 40);
            TIpBtn.TabIndex = 26;
            TIpBtn.Tile = true;
            TIpBtn.MouseEnter += TIpBtn_MouseEnter;
            TIpBtn.MouseLeave += TIpBtn_MouseLeave;
            // 
            // TipButton
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Controls.Add(TIpBtn);
            Name = "TipButton";
            Size = new Size(40, 40);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button TIpBtn;
    }
}
