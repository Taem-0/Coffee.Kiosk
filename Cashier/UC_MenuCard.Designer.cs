namespace Coffee.Kiosk.Cashier
{
    partial class UC_MenuCard
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
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            label1 = new Label();
            lblCategory = new Label();
            lblItemName = new Label();
            picItem = new PictureBox();
            guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picItem).BeginInit();
            SuspendLayout();
            // 
            // guna2Panel1
            // 
            guna2Panel1.BorderColor = Color.FromArgb(212, 184, 150);
            guna2Panel1.BorderRadius = 10;
            guna2Panel1.BorderThickness = 1;
            guna2Panel1.Controls.Add(label1);
            guna2Panel1.Controls.Add(lblCategory);
            guna2Panel1.Controls.Add(lblItemName);
            guna2Panel1.Controls.Add(picItem);
            guna2Panel1.Cursor = Cursors.Hand;
            guna2Panel1.CustomizableEdges = customizableEdges1;
            guna2Panel1.Dock = DockStyle.Fill;
            guna2Panel1.FillColor = Color.White;
            guna2Panel1.Location = new Point(0, 0);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Panel1.Size = new Size(150, 140);
            guna2Panel1.TabIndex = 0;
            guna2Panel1.Paint += guna2Panel1_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 110);
            label1.Name = "label1";
            label1.Padding = new Padding(6, 0, 6, 4);
            label1.Size = new Size(61, 27);
            label1.TabIndex = 3;
            label1.Text = "Price";
            label1.Click += label1_Click;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Segoe UI Semibold", 7.20000029F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCategory.ForeColor = Color.FromArgb(44, 34, 24);
            lblCategory.Location = new Point(3, 87);
            lblCategory.Name = "lblCategory";
            lblCategory.Padding = new Padding(6, 0, 6, 0);
            lblCategory.Size = new Size(76, 17);
            lblCategory.TabIndex = 2;
            lblCategory.Text = "Category";
            lblCategory.Click += lblCategory_Click;
            // 
            // lblItemName
            // 
            lblItemName.AutoSize = true;
            lblItemName.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblItemName.ForeColor = Color.FromArgb(44, 34, 24);
            lblItemName.Location = new Point(3, 63);
            lblItemName.Name = "lblItemName";
            lblItemName.Padding = new Padding(6, 4, 6, 0);
            lblItemName.Size = new Size(107, 24);
            lblItemName.TabIndex = 1;
            lblItemName.Text = "Order Name";
            lblItemName.Click += lblItemName_Click;
            // 
            // picItem
            // 
            picItem.BackColor = Color.Linen;
            picItem.BackgroundImageLayout = ImageLayout.None;
            picItem.Dock = DockStyle.Top;
            picItem.Location = new Point(0, 0);
            picItem.Name = "picItem";
            picItem.Size = new Size(150, 60);
            picItem.SizeMode = PictureBoxSizeMode.Zoom;
            picItem.TabIndex = 0;
            picItem.TabStop = false;
            picItem.Click += picItem_Click;
            // 
            // UC_MenuCard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(guna2Panel1);
            Name = "UC_MenuCard";
            Size = new Size(150, 140);
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picItem).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private PictureBox picItem;
        private Label lblCategory;
        private Label lblItemName;
        private Label label1;
    }
}
