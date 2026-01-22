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
            pictureBox1 = new PictureBox();
            productName = new Label();
            panel1 = new Panel();
            productPrice = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.default_icon;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(167, 154);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            pictureBox1.Paint += pictureBox1_Paint;
            pictureBox1.MouseEnter += pictureBox1_MouseEnter;
            pictureBox1.MouseLeave += pictureBox1_MouseLeave;
            // 
            // productName
            // 
            productName.Dock = DockStyle.Bottom;
            productName.Font = new Font("Gill Sans Ultra Bold", 9F);
            productName.Location = new Point(0, 154);
            productName.Name = "productName";
            productName.Size = new Size(167, 25);
            productName.TabIndex = 1;
            productName.Text = "Product_Name";
            productName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(productName);
            panel1.Controls.Add(productPrice);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(167, 194);
            panel1.TabIndex = 2;
            // 
            // productPrice
            // 
            productPrice.AutoSize = true;
            productPrice.Dock = DockStyle.Bottom;
            productPrice.Location = new Point(0, 179);
            productPrice.Name = "productPrice";
            productPrice.Size = new Size(80, 15);
            productPrice.TabIndex = 2;
            productPrice.Text = "Product_Price";
            // 
            // ProductItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "ProductItem";
            Size = new Size(167, 194);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Label productName;
        private Panel panel1;
        private Label productPrice;
    }
}
