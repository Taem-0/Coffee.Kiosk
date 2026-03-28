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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BannerUpload));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label20 = new Label();
            label1 = new Label();
            UploadTileButton = new Guna.UI2.WinForms.Guna2TileButton();
            saveButton = new Guna.UI2.WinForms.Guna2Button();
            bannersFlowLayout = new FlowLayoutPanel();
            suggestedDimensionTip = new Coffee.Kiosk.CMS.Forms.OrderingSystemTab.UserControls.TipButton();
            SuspendLayout();
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label20.Location = new Point(18, 17);
            label20.Margin = new Padding(2, 0, 2, 0);
            label20.Name = "label20";
            label20.Size = new Size(167, 30);
            label20.TabIndex = 7;
            label20.Text = "Banner Images";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label1.Location = new Point(18, 284);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(301, 30);
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
            UploadTileButton.CustomizableEdges = customizableEdges1;
            UploadTileButton.DisabledState.BorderColor = Color.DarkGray;
            UploadTileButton.DisabledState.CustomBorderColor = Color.DarkGray;
            UploadTileButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            UploadTileButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            UploadTileButton.Font = new Font("Segoe UI Semibold", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UploadTileButton.ForeColor = Color.White;
            UploadTileButton.Image = (Image)resources.GetObject("UploadTileButton.Image");
            UploadTileButton.ImageOffset = new Point(-85, 30);
            UploadTileButton.ImageSize = new Size(60, 60);
            UploadTileButton.Location = new Point(24, 334);
            UploadTileButton.Margin = new Padding(2);
            UploadTileButton.Name = "UploadTileButton";
            UploadTileButton.ShadowDecoration.CustomizableEdges = customizableEdges2;
            UploadTileButton.Size = new Size(1174, 96);
            UploadTileButton.TabIndex = 10;
            UploadTileButton.Text = "Upload your image";
            UploadTileButton.TextOffset = new Point(55, -30);
            UploadTileButton.Click += UploadTileButton_Click_1;
            // 
            // saveButton
            // 
            saveButton.BorderRadius = 10;
            saveButton.CustomizableEdges = customizableEdges3;
            saveButton.DisabledState.BorderColor = Color.DarkGray;
            saveButton.DisabledState.CustomBorderColor = Color.DarkGray;
            saveButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            saveButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            saveButton.Font = new Font("Segoe UI", 9F);
            saveButton.ForeColor = Color.White;
            saveButton.Location = new Point(1042, 502);
            saveButton.Margin = new Padding(2);
            saveButton.Name = "saveButton";
            saveButton.ShadowDecoration.CustomizableEdges = customizableEdges4;
            saveButton.Size = new Size(156, 54);
            saveButton.TabIndex = 11;
            saveButton.Text = "Save";
            // 
            // bannersFlowLayout
            // 
            bannersFlowLayout.AutoScroll = true;
            bannersFlowLayout.Location = new Point(24, 58);
            bannersFlowLayout.Margin = new Padding(2);
            bannersFlowLayout.Name = "bannersFlowLayout";
            bannersFlowLayout.Size = new Size(1174, 193);
            bannersFlowLayout.TabIndex = 12;
            bannersFlowLayout.WrapContents = false;
            // 
            // suggestedDimensionTip
            // 
            suggestedDimensionTip.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            suggestedDimensionTip.BackColor = Color.Transparent;
            suggestedDimensionTip.Location = new Point(323, 284);
            suggestedDimensionTip.Margin = new Padding(2);
            suggestedDimensionTip.Name = "suggestedDimensionTip";
            suggestedDimensionTip.Size = new Size(33, 32);
            suggestedDimensionTip.TabIndex = 13;
            suggestedDimensionTip.TipText = "Suggested Dimension: 16:9 \r\n(1280x720, 1600x900)";
            // 
            // BannerUpload
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(suggestedDimensionTip);
            Controls.Add(saveButton);
            Controls.Add(UploadTileButton);
            Controls.Add(label1);
            Controls.Add(label20);
            Controls.Add(bannersFlowLayout);
            Margin = new Padding(2);
            Name = "BannerUpload";
            Size = new Size(1221, 591);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label20;
        private Label label1;
        private Guna.UI2.WinForms.Guna2TileButton UploadTileButton;
        private Guna.UI2.WinForms.Guna2Button saveButton;
        private FlowLayoutPanel bannersFlowLayout;
        private OrderingSystemTab.UserControls.TipButton suggestedDimensionTip;
    }
}
