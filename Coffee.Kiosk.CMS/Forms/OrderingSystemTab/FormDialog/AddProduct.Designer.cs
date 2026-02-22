namespace Coffee.Kiosk.CMS.Forms.OrderingSystemTab.FormDialog
{
    partial class AddProduct
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            ProductNameTxtBox = new Guna.UI2.WinForms.Guna2TextBox();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            PriceTxtBox = new Guna.UI2.WinForms.Guna2TextBox();
            SaveBtn = new Guna.UI2.WinForms.Guna2Button();
            CancelBtn = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // ProductNameTxtBox
            // 
            ProductNameTxtBox.CustomizableEdges = customizableEdges1;
            ProductNameTxtBox.DefaultText = "";
            ProductNameTxtBox.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            ProductNameTxtBox.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            ProductNameTxtBox.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            ProductNameTxtBox.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            ProductNameTxtBox.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            ProductNameTxtBox.Font = new Font("Segoe UI", 9F);
            ProductNameTxtBox.ForeColor = Color.Black;
            ProductNameTxtBox.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            ProductNameTxtBox.Location = new Point(12, 250);
            ProductNameTxtBox.Margin = new Padding(3, 4, 3, 4);
            ProductNameTxtBox.Name = "ProductNameTxtBox";
            ProductNameTxtBox.PlaceholderText = "ProductPlaceHolderName";
            ProductNameTxtBox.SelectedText = "";
            ProductNameTxtBox.ShadowDecoration.CustomizableEdges = customizableEdges2;
            ProductNameTxtBox.Size = new Size(392, 41);
            ProductNameTxtBox.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.default_icon;
            pictureBox1.Location = new Point(104, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(200, 200);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            pictureBox1.Paint += pictureBox1_Paint;
            pictureBox1.MouseEnter += pictureBox1_MouseEnter;
            pictureBox1.MouseLeave += pictureBox1_MouseLeave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlDarkDark;
            label1.Location = new Point(12, 215);
            label1.Name = "label1";
            label1.Size = new Size(77, 31);
            label1.TabIndex = 2;
            label1.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(12, 295);
            label2.Name = "label2";
            label2.Size = new Size(67, 31);
            label2.TabIndex = 4;
            label2.Text = "Price";
            // 
            // PriceTxtBox
            // 
            PriceTxtBox.CustomizableEdges = customizableEdges3;
            PriceTxtBox.DefaultText = "";
            PriceTxtBox.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            PriceTxtBox.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            PriceTxtBox.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            PriceTxtBox.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            PriceTxtBox.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            PriceTxtBox.Font = new Font("Segoe UI", 9F);
            PriceTxtBox.ForeColor = Color.Black;
            PriceTxtBox.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            PriceTxtBox.Location = new Point(12, 330);
            PriceTxtBox.Margin = new Padding(3, 4, 3, 4);
            PriceTxtBox.Name = "PriceTxtBox";
            PriceTxtBox.PlaceholderText = "100.00";
            PriceTxtBox.SelectedText = "";
            PriceTxtBox.ShadowDecoration.CustomizableEdges = customizableEdges4;
            PriceTxtBox.Size = new Size(392, 41);
            PriceTxtBox.TabIndex = 3;
            // 
            // SaveBtn
            // 
            SaveBtn.BorderRadius = 10;
            SaveBtn.CustomizableEdges = customizableEdges5;
            SaveBtn.DisabledState.BorderColor = Color.DarkGray;
            SaveBtn.DisabledState.CustomBorderColor = Color.DarkGray;
            SaveBtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            SaveBtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            SaveBtn.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SaveBtn.ForeColor = Color.White;
            SaveBtn.Location = new Point(277, 403);
            SaveBtn.Name = "SaveBtn";
            SaveBtn.ShadowDecoration.CustomizableEdges = customizableEdges6;
            SaveBtn.Size = new Size(127, 49);
            SaveBtn.TabIndex = 5;
            SaveBtn.Text = "Save";
            SaveBtn.Click += SaveBtn_Click;
            // 
            // CancelBtn
            // 
            CancelBtn.BorderRadius = 10;
            CancelBtn.CustomizableEdges = customizableEdges7;
            CancelBtn.DisabledState.BorderColor = Color.DarkGray;
            CancelBtn.DisabledState.CustomBorderColor = Color.DarkGray;
            CancelBtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            CancelBtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            CancelBtn.FillColor = Color.FromArgb(224, 224, 224);
            CancelBtn.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CancelBtn.ForeColor = Color.DimGray;
            CancelBtn.Location = new Point(144, 403);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.ShadowDecoration.CustomizableEdges = customizableEdges8;
            CancelBtn.Size = new Size(127, 49);
            CancelBtn.TabIndex = 6;
            CancelBtn.Text = "Cancel";
            CancelBtn.Click += CancelBtn_Click;
            // 
            // AddProduct
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(416, 464);
            Controls.Add(CancelBtn);
            Controls.Add(SaveBtn);
            Controls.Add(label2);
            Controls.Add(PriceTxtBox);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(ProductNameTxtBox);
            Name = "AddProduct";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add Product";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox ProductNameTxtBox;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Guna.UI2.WinForms.Guna2TextBox PriceTxtBox;
        private Guna.UI2.WinForms.Guna2Button SaveBtn;
        private Guna.UI2.WinForms.Guna2Button CancelBtn;
    }
}