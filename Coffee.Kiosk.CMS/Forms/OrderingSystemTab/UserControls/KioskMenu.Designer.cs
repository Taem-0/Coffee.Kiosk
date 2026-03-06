namespace Coffee.Kiosk.CMS.Forms.OrderingSystemTab.UserControls
{
    partial class KioskMenu
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
            flowCategory = new FlowLayoutPanel();
            flowProduct = new FlowLayoutPanel();
            panel1 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            tipButton2 = new TipButton();
            label2 = new Label();
            panel2 = new Panel();
            tipButton1 = new TipButton();
            label3 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // flowCategory
            // 
            flowCategory.AutoScroll = true;
            flowCategory.Dock = DockStyle.Left;
            flowCategory.FlowDirection = FlowDirection.TopDown;
            flowCategory.Location = new Point(0, 65);
            flowCategory.Name = "flowCategory";
            flowCategory.Size = new Size(511, 611);
            flowCategory.TabIndex = 0;
            flowCategory.WrapContents = false;
            flowCategory.Paint += flowCategory_Paint;
            // 
            // flowProduct
            // 
            flowProduct.AutoScroll = true;
            flowProduct.Dock = DockStyle.Fill;
            flowProduct.Location = new Point(511, 65);
            flowProduct.Name = "flowProduct";
            flowProduct.Size = new Size(551, 611);
            flowProduct.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1062, 65);
            panel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(panel4);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(511, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(551, 65);
            panel3.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.Controls.Add(tipButton2);
            panel4.Controls.Add(label2);
            panel4.Location = new Point(184, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(204, 62);
            panel4.TabIndex = 3;
            // 
            // tipButton2
            // 
            tipButton2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tipButton2.Location = new Point(163, 27);
            tipButton2.Name = "tipButton2";
            tipButton2.Size = new Size(36, 34);
            tipButton2.TabIndex = 2;
            tipButton2.TipText = "Product\r\nThis is where you find products for selected category.";
            // 
            // label2
            // 
            label2.Font = new Font("Tahoma", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(0, 27);
            label2.Name = "label2";
            label2.Size = new Size(157, 38);
            label2.TabIndex = 1;
            label2.Text = "Products";
            label2.TextAlign = ContentAlignment.BottomCenter;
            // 
            // panel2
            // 
            panel2.Controls.Add(tipButton1);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(511, 65);
            panel2.TabIndex = 0;
            // 
            // tipButton1
            // 
            tipButton1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tipButton1.Location = new Point(301, 31);
            tipButton1.Name = "tipButton1";
            tipButton1.Size = new Size(36, 34);
            tipButton1.TabIndex = 0;
            tipButton1.TipText = "Category\r\nThis is where you group your products.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(301, 23);
            label3.TabIndex = 0;
            label3.Text = "Tip: Hover over \"?\" to read description";
            // 
            // label1
            // 
            label1.Font = new Font("Tahoma", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(124, 24);
            label1.Name = "label1";
            label1.Size = new Size(184, 41);
            label1.TabIndex = 0;
            label1.Text = "Categories";
            label1.TextAlign = ContentAlignment.BottomCenter;
            // 
            // KioskMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(flowProduct);
            Controls.Add(flowCategory);
            Controls.Add(panel1);
            Name = "KioskMenu";
            Size = new Size(1062, 676);
            Load += KioskMenu_Load;
            Resize += KioskMenu_Resize;
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowCategory;
        private FlowLayoutPanel flowProduct;
        private Panel panel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private TipButton tipButton1;
        private Panel panel3;
        private Panel panel4;
        private TipButton tipButton2;
        private Panel panel2;
    }
}
