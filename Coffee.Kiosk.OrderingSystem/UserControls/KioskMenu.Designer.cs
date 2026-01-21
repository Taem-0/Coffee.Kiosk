namespace Coffee.Kiosk.OrderingSystem
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
            flowCategories = new FlowLayoutPanel();
            BottomPanel = new Panel();
            StartOver_Button = new Label();
            AdPanel = new Panel();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            ContentPanel = new Panel();
            BottomPanel.SuspendLayout();
            AdPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // flowCategories
            // 
            flowCategories.AutoScroll = true;
            flowCategories.Dock = DockStyle.Left;
            flowCategories.FlowDirection = FlowDirection.TopDown;
            flowCategories.Location = new Point(0, 56);
            flowCategories.Name = "flowCategories";
            flowCategories.Size = new Size(120, 491);
            flowCategories.TabIndex = 0;
            flowCategories.WrapContents = false;
            // 
            // BottomPanel
            // 
            BottomPanel.Controls.Add(StartOver_Button);
            BottomPanel.Dock = DockStyle.Bottom;
            BottomPanel.Location = new Point(0, 547);
            BottomPanel.Name = "BottomPanel";
            BottomPanel.Size = new Size(673, 78);
            BottomPanel.TabIndex = 1;
            // 
            // StartOver_Button
            // 
            StartOver_Button.AutoSize = true;
            StartOver_Button.Font = new Font("Segoe UI", 17F);
            StartOver_Button.Location = new Point(0, 47);
            StartOver_Button.Name = "StartOver_Button";
            StartOver_Button.Size = new Size(141, 31);
            StartOver_Button.TabIndex = 0;
            StartOver_Button.Text = "← Start Over";
            StartOver_Button.Click += StartOver_Button_Click;
            StartOver_Button.Paint += StartOver_Button_Paint;
            StartOver_Button.MouseEnter += StartOver_Button_MouseEnter;
            StartOver_Button.MouseLeave += StartOver_Button_MouseLeave;
            // 
            // AdPanel
            // 
            AdPanel.Controls.Add(label2);
            AdPanel.Controls.Add(pictureBox1);
            AdPanel.Dock = DockStyle.Top;
            AdPanel.Location = new Point(0, 0);
            AdPanel.Name = "AdPanel";
            AdPanel.Size = new Size(673, 56);
            AdPanel.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(266, 41);
            label2.Name = "label2";
            label2.Size = new Size(127, 15);
            label2.TabIndex = 0;
            label2.Text = "Dynamic Ad here  later";
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.Cafe_Brand_Web_Banner_Design;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Margin = new Padding(0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(673, 56);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // ContentPanel
            // 
            ContentPanel.Dock = DockStyle.Fill;
            ContentPanel.Location = new Point(120, 56);
            ContentPanel.Name = "ContentPanel";
            ContentPanel.Size = new Size(553, 491);
            ContentPanel.TabIndex = 3;
            // 
            // KioskMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(ContentPanel);
            Controls.Add(flowCategories);
            Controls.Add(BottomPanel);
            Controls.Add(AdPanel);
            Name = "KioskMenu";
            Size = new Size(673, 625);
            BottomPanel.ResumeLayout(false);
            BottomPanel.PerformLayout();
            AdPanel.ResumeLayout(false);
            AdPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowCategories;
        private Panel BottomPanel;
        private Label StartOver_Button;
        private Panel AdPanel;
        private Label label2;
        private PictureBox pictureBox1;
        private Panel ContentPanel;
    }
}
