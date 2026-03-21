namespace Coffee.Kiosk.CMS.Forms.SettingsTab.SettingsUserControls
{
    partial class MiniGetStartedScreen
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
            getStartedMiniPic = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)getStartedMiniPic).BeginInit();
            SuspendLayout();
            // 
            // getStartedMiniPic
            // 
            getStartedMiniPic.CustomizableEdges = customizableEdges1;
            getStartedMiniPic.Dock = DockStyle.Fill;
            getStartedMiniPic.ImageRotate = 0F;
            getStartedMiniPic.Location = new Point(0, 0);
            getStartedMiniPic.Name = "getStartedMiniPic";
            getStartedMiniPic.ShadowDecoration.CustomizableEdges = customizableEdges2;
            getStartedMiniPic.Size = new Size(352, 626);
            getStartedMiniPic.TabIndex = 1;
            getStartedMiniPic.TabStop = false;
            // 
            // MiniGetStartedScreen
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(getStartedMiniPic);
            Name = "MiniGetStartedScreen";
            Size = new Size(352, 626);
            ((System.ComponentModel.ISupportInitialize)getStartedMiniPic).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox getStartedMiniPic;
    }
}
