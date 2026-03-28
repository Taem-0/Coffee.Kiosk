namespace Coffee.Kiosk.CMS.Forms.DashBoardTab.DashBoardUserControls
{
    partial class TopSellingProductContainer
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
            productRankNo = new Label();
            productName = new Label();
            productQt = new Label();
            itemPictureBox = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)itemPictureBox).BeginInit();
            SuspendLayout();
            // 
            // productRankNo
            // 
            productRankNo.AutoSize = true;
            productRankNo.Location = new Point(167, 26);
            productRankNo.Margin = new Padding(2, 0, 2, 0);
            productRankNo.Name = "productRankNo";
            productRankNo.Size = new Size(84, 20);
            productRankNo.TabIndex = 0;
            productRankNo.Text = "produ.Num";
            // 
            // productName
            // 
            productName.AutoSize = true;
            productName.Location = new Point(453, 26);
            productName.Margin = new Padding(2, 0, 2, 0);
            productName.Name = "productName";
            productName.Size = new Size(49, 20);
            productName.TabIndex = 1;
            productName.Text = "Name";
            // 
            // productQt
            // 
            productQt.AutoSize = true;
            productQt.Location = new Point(704, 26);
            productQt.Margin = new Padding(2, 0, 2, 0);
            productQt.Name = "productQt";
            productQt.Size = new Size(32, 20);
            productQt.TabIndex = 2;
            productQt.Text = "Qty";
            // 
            // itemPictureBox
            // 
            itemPictureBox.AutoRoundedCorners = true;
            itemPictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            itemPictureBox.CustomizableEdges = customizableEdges1;
            itemPictureBox.FillColor = Color.Transparent;
            itemPictureBox.ImageRotate = 0F;
            itemPictureBox.Location = new Point(45, 8);
            itemPictureBox.Margin = new Padding(2);
            itemPictureBox.Name = "itemPictureBox";
            itemPictureBox.ShadowDecoration.CustomizableEdges = customizableEdges2;
            itemPictureBox.Size = new Size(56, 56);
            itemPictureBox.TabIndex = 3;
            itemPictureBox.TabStop = false;
            itemPictureBox.Click += itemPictureBox_Click;
            // 
            // TopSellingProductContainer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(itemPictureBox);
            Controls.Add(productQt);
            Controls.Add(productName);
            Controls.Add(productRankNo);
            Margin = new Padding(2);
            Name = "TopSellingProductContainer";
            Size = new Size(840, 72);
            ((System.ComponentModel.ISupportInitialize)itemPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label productRankNo;
        private Label productName;
        private Label productQt;
        private Guna.UI2.WinForms.Guna2PictureBox itemPictureBox;
    }
}
