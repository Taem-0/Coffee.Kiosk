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
            guna2vScrollBar3 = new Guna.UI2.WinForms.Guna2VScrollBar();
            topSellingFlowLayout.SuspendLayout();
            SuspendLayout();
            // 
            // topSellingFlowLayout
            // 
            topSellingFlowLayout.AutoScroll = true;
            topSellingFlowLayout.Controls.Add(topSellingProductContainer1);
            topSellingFlowLayout.Dock = DockStyle.Fill;
            topSellingFlowLayout.FlowDirection = FlowDirection.TopDown;
            topSellingFlowLayout.Location = new Point(8, 8);
            topSellingFlowLayout.Margin = new Padding(2);
            topSellingFlowLayout.Name = "topSellingFlowLayout";
            topSellingFlowLayout.Padding = new Padding(2);
            topSellingFlowLayout.Size = new Size(869, 344);
            topSellingFlowLayout.TabIndex = 0;
            // 
            // topSellingProductContainer1
            // 
            topSellingProductContainer1.BorderStyle = BorderStyle.FixedSingle;
            topSellingProductContainer1.Location = new Point(4, 4);
            topSellingProductContainer1.Margin = new Padding(2);
            topSellingProductContainer1.Name = "topSellingProductContainer1";
            topSellingProductContainer1.Size = new Size(840, 72);
            topSellingProductContainer1.TabIndex = 0;
            // 
            // guna2vScrollBar3
            // 
            guna2vScrollBar3.BindingContainer = topSellingFlowLayout;
            guna2vScrollBar3.BorderRadius = 6;
            guna2vScrollBar3.FillOffset = new Padding(8, 8, 0, 8);
            guna2vScrollBar3.InUpdate = false;
            guna2vScrollBar3.LargeChange = 10;
            guna2vScrollBar3.Location = new Point(856, 8);
            guna2vScrollBar3.Margin = new Padding(2);
            guna2vScrollBar3.Name = "guna2vScrollBar3";
            guna2vScrollBar3.Padding = new Padding(8, 8, 0, 8);
            guna2vScrollBar3.ScrollbarSize = 13;
            guna2vScrollBar3.Size = new Size(21, 344);
            guna2vScrollBar3.TabIndex = 7;
            guna2vScrollBar3.Visible = false;
            // 
            // TopSellingProducts
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(guna2vScrollBar3);
            Controls.Add(topSellingFlowLayout);
            Margin = new Padding(2);
            Name = "TopSellingProducts";
            Padding = new Padding(8);
            Size = new Size(885, 360);
            Load += TopSellingProducts_Load;
            topSellingFlowLayout.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel topSellingFlowLayout;
        private Guna.UI2.WinForms.Guna2VScrollBar guna2vScrollBar3;
        private TopSellingProductContainer topSellingProductContainer1;
    }
}
