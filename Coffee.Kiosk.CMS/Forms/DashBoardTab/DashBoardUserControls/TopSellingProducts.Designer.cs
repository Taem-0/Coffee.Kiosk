namespace Coffee.Kiosk.CMS.Forms.DashBoardTab.DashBoardUserControls
{
    partial class TopSellingProducts
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
            topSellingFlowLayout = new FlowLayoutPanel();
            topSellingProductContainer1 = new TopSellingProductContainer();
            topSellingFlowLayout.SuspendLayout();
            SuspendLayout();
            // 
            // topSellingFlowLayout
            // 
            topSellingFlowLayout.Controls.Add(topSellingProductContainer1);
            topSellingFlowLayout.Dock = DockStyle.Fill;
            topSellingFlowLayout.Location = new Point(10, 10);
            topSellingFlowLayout.Name = "topSellingFlowLayout";
            topSellingFlowLayout.Padding = new Padding(2);
            topSellingFlowLayout.Size = new Size(830, 250);
            topSellingFlowLayout.TabIndex = 0;
            // 
            // topSellingProductContainer1
            // 
            topSellingProductContainer1.Location = new Point(5, 5);
            topSellingProductContainer1.Name = "topSellingProductContainer1";
            topSellingProductContainer1.Size = new Size(822, 90);
            topSellingProductContainer1.TabIndex = 0;
            // 
            // TopSellingProducts
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(topSellingFlowLayout);
            Name = "TopSellingProducts";
            Padding = new Padding(10);
            Size = new Size(850, 270);
            Load += TopSellingProducts_Load;
            topSellingFlowLayout.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel topSellingFlowLayout;
        private TopSellingProductContainer topSellingProductContainer1;
    }
}
