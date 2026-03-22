namespace Coffee.Kiosk.CMS.Forms.SettingsTab.SettingsUserControls
{
    partial class AddBannerDialogoue
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
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label19 = new Label();
            label1 = new Label();
            placementSelection = new Guna.UI2.WinForms.Guna2ComboBox();
            orderSelection = new Guna.UI2.WinForms.Guna2ComboBox();
            label2 = new Label();
            saveButton = new Guna.UI2.WinForms.Guna2Button();
            bannerPictureBox = new Guna.UI2.WinForms.Guna2PictureBox();
            cancelBannerButton = new Guna.UI2.WinForms.Guna2Button();
            clearPictureButton = new Guna.UI2.WinForms.Guna2Button();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            ((System.ComponentModel.ISupportInitialize)bannerPictureBox).BeginInit();
            SuspendLayout();
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label19.Location = new Point(33, 18);
            label19.Name = "label19";
            label19.Size = new Size(296, 41);
            label19.TabIndex = 6;
            label19.Text = "Custom Banner Slot";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            label1.Location = new Point(36, 339);
            label1.Name = "label1";
            label1.Size = new Size(138, 36);
            label1.TabIndex = 7;
            label1.Text = "Placement";
            label1.Click += label1_Click;
            // 
            // placementSelection
            // 
            placementSelection.BackColor = Color.Transparent;
            placementSelection.CustomizableEdges = customizableEdges1;
            placementSelection.DrawMode = DrawMode.OwnerDrawFixed;
            placementSelection.DropDownStyle = ComboBoxStyle.DropDownList;
            placementSelection.FocusedColor = Color.FromArgb(94, 148, 255);
            placementSelection.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            placementSelection.Font = new Font("Segoe UI", 10F);
            placementSelection.ForeColor = Color.FromArgb(68, 88, 112);
            placementSelection.ItemHeight = 30;
            placementSelection.Items.AddRange(new object[] { "Starting Screen", "Top Banner", "Home Page Banner 1", "Home Page Banner 2" });
            placementSelection.Location = new Point(42, 383);
            placementSelection.Name = "placementSelection";
            placementSelection.ShadowDecoration.CustomizableEdges = customizableEdges2;
            placementSelection.Size = new Size(471, 36);
            placementSelection.TabIndex = 8;
            placementSelection.SelectedIndexChanged += guna2ComboBox1_SelectedIndexChanged;
            // 
            // orderSelection
            // 
            orderSelection.BackColor = Color.Transparent;
            orderSelection.CustomizableEdges = customizableEdges3;
            orderSelection.DrawMode = DrawMode.OwnerDrawFixed;
            orderSelection.DropDownStyle = ComboBoxStyle.DropDownList;
            orderSelection.FocusedColor = Color.FromArgb(94, 148, 255);
            orderSelection.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            orderSelection.Font = new Font("Segoe UI", 10F);
            orderSelection.ForeColor = Color.FromArgb(68, 88, 112);
            orderSelection.ItemHeight = 30;
            orderSelection.Location = new Point(42, 486);
            orderSelection.Name = "orderSelection";
            orderSelection.ShadowDecoration.CustomizableEdges = customizableEdges4;
            orderSelection.Size = new Size(471, 36);
            orderSelection.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            label2.Location = new Point(36, 442);
            label2.Name = "label2";
            label2.Size = new Size(190, 36);
            label2.TabIndex = 9;
            label2.Text = "Order Number";
            // 
            // saveButton
            // 
            saveButton.BorderRadius = 10;
            saveButton.CustomizableEdges = customizableEdges5;
            saveButton.DisabledState.BorderColor = Color.DarkGray;
            saveButton.DisabledState.CustomBorderColor = Color.DarkGray;
            saveButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            saveButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            saveButton.Font = new Font("Segoe UI", 9F);
            saveButton.ForeColor = Color.White;
            saveButton.Location = new Point(372, 563);
            saveButton.Name = "saveButton";
            saveButton.ShadowDecoration.CustomizableEdges = customizableEdges6;
            saveButton.Size = new Size(141, 52);
            saveButton.TabIndex = 11;
            saveButton.Text = "Save";
            saveButton.Click += saveButton_Click;
            // 
            // bannerPictureBox
            // 
            bannerPictureBox.BackColor = Color.Transparent;
            bannerPictureBox.BackgroundImageLayout = ImageLayout.Zoom;
            bannerPictureBox.CustomizableEdges = customizableEdges7;
            bannerPictureBox.ImageRotate = 0F;
            bannerPictureBox.Location = new Point(30, 87);
            bannerPictureBox.Name = "bannerPictureBox";
            bannerPictureBox.ShadowDecoration.CustomizableEdges = customizableEdges8;
            bannerPictureBox.Size = new Size(470, 220);
            bannerPictureBox.TabIndex = 12;
            bannerPictureBox.TabStop = false;
            // 
            // cancelBannerButton
            // 
            cancelBannerButton.BorderRadius = 10;
            cancelBannerButton.CustomizableEdges = customizableEdges9;
            cancelBannerButton.DisabledState.BorderColor = Color.DarkGray;
            cancelBannerButton.DisabledState.CustomBorderColor = Color.DarkGray;
            cancelBannerButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            cancelBannerButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            cancelBannerButton.FillColor = Color.Red;
            cancelBannerButton.Font = new Font("Segoe UI", 9F);
            cancelBannerButton.ForeColor = Color.White;
            cancelBannerButton.Location = new Point(215, 563);
            cancelBannerButton.Name = "cancelBannerButton";
            cancelBannerButton.ShadowDecoration.CustomizableEdges = customizableEdges10;
            cancelBannerButton.Size = new Size(141, 52);
            cancelBannerButton.TabIndex = 13;
            cancelBannerButton.Text = "Cancel";
            // 
            // clearPictureButton
            // 
            clearPictureButton.BorderRadius = 15;
            clearPictureButton.CustomizableEdges = customizableEdges11;
            clearPictureButton.DisabledState.BorderColor = Color.DarkGray;
            clearPictureButton.DisabledState.CustomBorderColor = Color.DarkGray;
            clearPictureButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            clearPictureButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            clearPictureButton.FillColor = Color.Red;
            clearPictureButton.Font = new Font("Segoe UI", 9F);
            clearPictureButton.ForeColor = Color.White;
            clearPictureButton.Location = new Point(411, 259);
            clearPictureButton.Name = "clearPictureButton";
            clearPictureButton.ShadowDecoration.CustomizableEdges = customizableEdges12;
            clearPictureButton.Size = new Size(89, 48);
            clearPictureButton.TabIndex = 15;
            clearPictureButton.Text = "Clear";
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.BorderRadius = 30;
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.ResizeForm = false;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // AddBannerDialogoue
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(542, 636);
            Controls.Add(clearPictureButton);
            Controls.Add(cancelBannerButton);
            Controls.Add(bannerPictureBox);
            Controls.Add(saveButton);
            Controls.Add(orderSelection);
            Controls.Add(label2);
            Controls.Add(placementSelection);
            Controls.Add(label1);
            Controls.Add(label19);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AddBannerDialogoue";
            Load += AddBannerDialogoue_Load;
            ((System.ComponentModel.ISupportInitialize)bannerPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label19;
        private Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox placementSelection;
        private Guna.UI2.WinForms.Guna2ComboBox orderSelection;
        private Label label2;
        private Guna.UI2.WinForms.Guna2Button saveButton;
        private Guna.UI2.WinForms.Guna2PictureBox bannerPictureBox;
        private Guna.UI2.WinForms.Guna2Button cancelBannerButton;
        private Guna.UI2.WinForms.Guna2Button clearPictureButton;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
    }
}
