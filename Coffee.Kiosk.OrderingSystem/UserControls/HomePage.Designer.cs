namespace Coffee.Kiosk.OrderingSystem.UserControls
{
    partial class HomePage
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
            HomeBanner2 = new PictureBox();
            HomeBanner1 = new PictureBox();
            panel3 = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            PanelContainer = new Panel();
            panel2 = new Panel();
            label1 = new Label();
            guna2vScrollBar1 = new Guna.UI2.WinForms.Guna2VScrollBar();
            ((System.ComponentModel.ISupportInitialize)HomeBanner2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)HomeBanner1).BeginInit();
            PanelContainer.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // HomeBanner2
            // 
            HomeBanner2.Dock = DockStyle.Top;
            HomeBanner2.Image = Properties.Resources.Desain__Banner;
            HomeBanner2.Location = new Point(0, 364);
            HomeBanner2.Name = "HomeBanner2";
            HomeBanner2.Padding = new Padding(17);
            HomeBanner2.Size = new Size(803, 300);
            HomeBanner2.SizeMode = PictureBoxSizeMode.StretchImage;
            HomeBanner2.TabIndex = 0;
            HomeBanner2.TabStop = false;
            // 
            // HomeBanner1
            // 
            HomeBanner1.Dock = DockStyle.Top;
            HomeBanner1.Image = Properties.Resources.download__29_;
            HomeBanner1.Location = new Point(0, 0);
            HomeBanner1.Name = "HomeBanner1";
            HomeBanner1.Padding = new Padding(17);
            HomeBanner1.Size = new Size(803, 300);
            HomeBanner1.SizeMode = PictureBoxSizeMode.StretchImage;
            HomeBanner1.TabIndex = 0;
            HomeBanner1.TabStop = false;
            // 
            // panel3
            // 
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 300);
            panel3.Name = "panel3";
            panel3.Size = new Size(803, 64);
            panel3.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel1.Location = new Point(0, 722);
            flowLayoutPanel1.MinimumSize = new Size(820, 160);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(820, 160);
            flowLayoutPanel1.TabIndex = 4;
            flowLayoutPanel1.ControlAdded += flowLayoutPanel1_ControlAdded;
            // 
            // PanelContainer
            // 
            PanelContainer.AutoScroll = true;
            PanelContainer.Controls.Add(flowLayoutPanel1);
            PanelContainer.Controls.Add(panel2);
            PanelContainer.Controls.Add(HomeBanner2);
            PanelContainer.Controls.Add(panel3);
            PanelContainer.Controls.Add(HomeBanner1);
            PanelContainer.Dock = DockStyle.Fill;
            PanelContainer.Location = new Point(0, 0);
            PanelContainer.Name = "PanelContainer";
            PanelContainer.Size = new Size(820, 848);
            PanelContainer.TabIndex = 4;
            // 
            // panel2
            // 
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 664);
            panel2.Name = "panel2";
            panel2.Size = new Size(803, 58);
            panel2.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DimGray;
            label1.Location = new Point(17, 12);
            label1.Name = "label1";
            label1.Size = new Size(154, 32);
            label1.TabIndex = 0;
            label1.Text = "All products";
            // 
            // guna2vScrollBar1
            // 
            guna2vScrollBar1.BindingContainer = PanelContainer;
            guna2vScrollBar1.InUpdate = false;
            guna2vScrollBar1.LargeChange = 10;
            guna2vScrollBar1.Location = new Point(802, 0);
            guna2vScrollBar1.Name = "guna2vScrollBar1";
            guna2vScrollBar1.ScrollbarSize = 18;
            guna2vScrollBar1.Size = new Size(18, 848);
            guna2vScrollBar1.TabIndex = 0;
            // 
            // HomePage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            Controls.Add(guna2vScrollBar1);
            Controls.Add(PanelContainer);
            Name = "HomePage";
            Size = new Size(820, 848);
            ((System.ComponentModel.ISupportInitialize)HomeBanner2).EndInit();
            ((System.ComponentModel.ISupportInitialize)HomeBanner1).EndInit();
            PanelContainer.ResumeLayout(false);
            PanelContainer.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox HomeBanner2;
        private PictureBox HomeBanner1;
        private Panel panel3;
        private Panel PanelContainer;
        private FlowLayoutPanel flowLayoutPanel1;
        private Guna.UI2.WinForms.Guna2VScrollBar guna2vScrollBar1;
        private Panel panel2;
        private Label label1;
    }
}
