namespace Coffee.Kiosk.OrderingSystem.UserControls
{
    partial class CategoryPage
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
            flowProducts = new FlowLayoutPanel();
            panel1 = new Panel();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowProducts
            // 
            flowProducts.AutoScroll = true;
            flowProducts.Dock = DockStyle.Fill;
            flowProducts.Location = new Point(0, 31);
            flowProducts.Name = "flowProducts";
            flowProducts.Padding = new Padding(0, 25, 0, 0);
            flowProducts.Size = new Size(495, 542);
            flowProducts.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(495, 31);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(495, 31);
            label1.TabIndex = 0;
            label1.Text = "Menu";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // CategoryPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(flowProducts);
            Controls.Add(panel1);
            Name = "CategoryPage";
            Size = new Size(495, 573);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowProducts;
        private Panel panel1;
        private Label label1;
    }
}
