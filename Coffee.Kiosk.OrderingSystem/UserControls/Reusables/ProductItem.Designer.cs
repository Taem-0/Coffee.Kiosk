namespace Coffee.Kiosk.OrderingSystem.UserControls
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
            pictureBox1 = new PictureBox();
            productName = new Label();
            productPrice = new Label();
            guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            guna2ShadowPanel1.SuspendLayout();
            guna2Panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.default_icon;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(154, 141);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // productName
            // 
            productName.Font = new Font("Gill Sans Ultra Bold", 9F);
            productName.Location = new Point(13, 147);
            productName.Name = "productName";
            productName.Size = new Size(130, 25);
            productName.TabIndex = 1;
            productName.Text = "Product_Name";
            productName.TextAlign = ContentAlignment.MiddleLeft;
            productName.Click += productName_Click;
            // 
            // productPrice
            // 
            productPrice.AutoSize = true;
            productPrice.Location = new Point(13, 172);
            productPrice.Name = "productPrice";
            productPrice.Size = new Size(80, 15);
            productPrice.TabIndex = 2;
            productPrice.Text = "Product_Price";
            productPrice.Click += productPrice_Click;
            // 
            // guna2ShadowPanel1
            // 
            guna2ShadowPanel1.BackColor = Color.Transparent;
            guna2ShadowPanel1.Controls.Add(guna2Panel1);
            guna2ShadowPanel1.Dock = DockStyle.Fill;
            guna2ShadowPanel1.EdgeWidth = 2;
            guna2ShadowPanel1.FillColor = Color.WhiteSmoke;
            guna2ShadowPanel1.Location = new Point(0, 0);
            guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            guna2ShadowPanel1.Radius = 5;
            guna2ShadowPanel1.ShadowColor = Color.Black;
            guna2ShadowPanel1.Size = new Size(166, 198);
            guna2ShadowPanel1.TabIndex = 3;
            guna2ShadowPanel1.Click += guna2ShadowPanel1_Click;
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
            guna2Panel1.Size = new Size(160, 192);
            guna2Panel1.TabIndex = 0;
            guna2Panel1.UseTransparentBackground = true;
            guna2Panel1.Click += guna2Panel1_Click;
            // 
            // ProductItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(guna2ShadowPanel1);
            Name = "ProductItem";
            Size = new Size(166, 198);
            Load += ProductItem_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            guna2ShadowPanel1.ResumeLayout(false);
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Label productName;
        private Label productPrice;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
    }
}
