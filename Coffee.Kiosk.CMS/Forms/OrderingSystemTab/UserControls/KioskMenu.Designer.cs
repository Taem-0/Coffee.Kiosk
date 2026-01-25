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
            label1 = new Label();
            label2 = new Label();
            panel1.SuspendLayout();
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
            flowProduct.Dock = DockStyle.Fill;
            flowProduct.FlowDirection = FlowDirection.TopDown;
            flowProduct.Location = new Point(511, 65);
            flowProduct.Name = "flowProduct";
            flowProduct.Size = new Size(551, 611);
            flowProduct.TabIndex = 1;
            flowProduct.WrapContents = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1062, 65);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Left;
            label1.Font = new Font("Tahoma", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(511, 65);
            label1.TabIndex = 0;
            label1.Text = "Categories";
            label1.TextAlign = ContentAlignment.BottomCenter;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Tahoma", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(511, 0);
            label2.Name = "label2";
            label2.Size = new Size(551, 65);
            label2.TabIndex = 1;
            label2.Text = "Products";
            label2.TextAlign = ContentAlignment.BottomCenter;
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
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowCategory;
        private FlowLayoutPanel flowProduct;
        private Panel panel1;
        private Label label1;
        private Label label2;
    }
}
