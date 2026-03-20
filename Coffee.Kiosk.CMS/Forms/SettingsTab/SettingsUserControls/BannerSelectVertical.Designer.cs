namespace Coffee.Kiosk.CMS.Forms.SettingsTab.SettingsUserControls
{
    partial class BannerSelectVertical
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BannerSelectVertical));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            AddPfpButton = new Guna.UI2.WinForms.Guna2CircleButton();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
            SuspendLayout();
            // 
            // guna2PictureBox1
            // 
            guna2PictureBox1.BackColor = SystemColors.ControlDark;
            guna2PictureBox1.CustomizableEdges = customizableEdges1;
            guna2PictureBox1.ImageRotate = 0F;
            guna2PictureBox1.Location = new Point(106, 9);
            guna2PictureBox1.Name = "guna2PictureBox1";
            guna2PictureBox1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2PictureBox1.Size = new Size(88, 175);
            guna2PictureBox1.TabIndex = 1;
            guna2PictureBox1.TabStop = false;
            // 
            // AddPfpButton
            // 
            AddPfpButton.BackColor = Color.Transparent;
            AddPfpButton.DisabledState.BorderColor = Color.DarkGray;
            AddPfpButton.DisabledState.CustomBorderColor = Color.DarkGray;
            AddPfpButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            AddPfpButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            AddPfpButton.Font = new Font("Segoe UI", 15F);
            AddPfpButton.ForeColor = Color.Transparent;
            AddPfpButton.Image = (Image)resources.GetObject("AddPfpButton.Image");
            AddPfpButton.ImageSize = new Size(50, 50);
            AddPfpButton.Location = new Point(242, 8);
            AddPfpButton.Name = "AddPfpButton";
            AddPfpButton.ShadowDecoration.CustomizableEdges = customizableEdges3;
            AddPfpButton.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            AddPfpButton.Size = new Size(50, 50);
            AddPfpButton.TabIndex = 4;
            AddPfpButton.TextAlign = HorizontalAlignment.Left;
            AddPfpButton.UseTransparentBackground = true;
            // 
            // BannerSelectVertical
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(AddPfpButton);
            Controls.Add(guna2PictureBox1);
            Name = "BannerSelectVertical";
            Size = new Size(300, 193);
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2CircleButton AddPfpButton;
    }
}
