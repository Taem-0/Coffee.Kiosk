namespace Coffee.Kiosk.CMS.Forms.SettingsTab.SettingsUserControls
{
    partial class BannerUpload
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label20 = new Label();
            label1 = new Label();
            UploadTileButton = new Guna.UI2.WinForms.Guna2TileButton();
            saveButton = new Guna.UI2.WinForms.Guna2Button();
            bannersFlowLayout = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label20.Location = new Point(23, 21);
            label20.Name = "label20";
            label20.Size = new Size(196, 36);
            label20.TabIndex = 7;
            label20.Text = "Banner Images";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label1.Location = new Point(23, 355);
            label1.Name = "label1";
            label1.Size = new Size(354, 36);
            label1.TabIndex = 9;
            label1.Text = "Upload New Banner Images";
            // 
            // UploadTileButton
            // 
            UploadTileButton.BackColor = Color.Transparent;
            UploadTileButton.BorderColor = Color.LightGray;
            UploadTileButton.BorderRadius = 30;
            UploadTileButton.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            UploadTileButton.BorderThickness = 2;
            UploadTileButton.CustomizableEdges = customizableEdges5;
            UploadTileButton.DisabledState.BorderColor = Color.DarkGray;
            UploadTileButton.DisabledState.CustomBorderColor = Color.DarkGray;
            UploadTileButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            UploadTileButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            UploadTileButton.Font = new Font("Segoe UI", 9F);
            UploadTileButton.ForeColor = Color.White;
            UploadTileButton.Location = new Point(30, 417);
            UploadTileButton.Name = "UploadTileButton";
            UploadTileButton.ShadowDecoration.CustomizableEdges = customizableEdges6;
            UploadTileButton.Size = new Size(1467, 120);
            UploadTileButton.TabIndex = 10;
            UploadTileButton.Click += UploadTileButton_Click_1;
            // 
            // saveButton
            // 
            saveButton.BorderRadius = 10;
            saveButton.CustomizableEdges = customizableEdges7;
            saveButton.DisabledState.BorderColor = Color.DarkGray;
            saveButton.DisabledState.CustomBorderColor = Color.DarkGray;
            saveButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            saveButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            saveButton.Font = new Font("Segoe UI", 9F);
            saveButton.ForeColor = Color.White;
            saveButton.Location = new Point(1302, 628);
            saveButton.Name = "saveButton";
            saveButton.ShadowDecoration.CustomizableEdges = customizableEdges8;
            saveButton.Size = new Size(195, 68);
            saveButton.TabIndex = 11;
            saveButton.Text = "Save";
            // 
            // bannersFlowLayout
            // 
            bannersFlowLayout.AutoScroll = true;
            bannersFlowLayout.Location = new Point(30, 73);
            bannersFlowLayout.Name = "bannersFlowLayout";
            bannersFlowLayout.Size = new Size(1467, 241);
            bannersFlowLayout.TabIndex = 12;
            bannersFlowLayout.WrapContents = false;
            // 
            // BannerUpload
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(saveButton);
            Controls.Add(UploadTileButton);
            Controls.Add(label1);
            Controls.Add(label20);
            Controls.Add(bannersFlowLayout);
            Name = "BannerUpload";
            Size = new Size(1526, 739);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label20;
        private Label label1;
        private Guna.UI2.WinForms.Guna2TileButton UploadTileButton;
        private Guna.UI2.WinForms.Guna2Button saveButton;
        private FlowLayoutPanel bannersFlowLayout;
    }
}
