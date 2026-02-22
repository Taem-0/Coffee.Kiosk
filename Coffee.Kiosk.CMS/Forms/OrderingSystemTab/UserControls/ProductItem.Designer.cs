namespace Coffee.Kiosk.CMS.Forms.OrderingSystemTab.UserControls
{
    partial class ProductItem
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
            productPrice = new Label();
            pictureBox1 = new PictureBox();
            productName = new Label();
            guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // guna2Panel1
            // 
            guna2Panel1.BackColor = Color.Transparent;
            guna2Panel1.BorderColor = Color.FromArgb(64, 64, 64);
            guna2Panel1.BorderRadius = 15;
            guna2Panel1.BorderThickness = 1;
            guna2Panel1.Controls.Add(productPrice);
            guna2Panel1.Controls.Add(pictureBox1);
            guna2Panel1.Controls.Add(productName);
            guna2Panel1.CustomizableEdges = customizableEdges1;
            guna2Panel1.Location = new Point(3, 3);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.BorderRadius = 15;
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Panel1.Size = new Size(203, 237);
            guna2Panel1.TabIndex = 1;
            guna2Panel1.UseTransparentBackground = true;
            // 
            // productPrice
            // 
            productPrice.AutoSize = true;
            productPrice.Location = new Point(13, 212);
            productPrice.Name = "productPrice";
            productPrice.Size = new Size(98, 20);
            productPrice.TabIndex = 2;
            productPrice.Text = "Product_Price";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.default_icon;
            pictureBox1.Location = new Point(6, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(194, 185);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // productName
            // 
            productName.Font = new Font("Gill Sans Ultra Bold", 9F);
            productName.Location = new Point(13, 187);
            productName.Name = "productName";
            productName.Size = new Size(178, 25);
            productName.TabIndex = 1;
            productName.Text = "Product_Name";
            productName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ProductItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(guna2Panel1);
            Name = "ProductItem";
            Size = new Size(209, 243);
            Load += ProductItem_Load;
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Label productPrice;
        private PictureBox pictureBox1;
        private Label productName;
    }
}
