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
            categoryItem1 = new Coffee.Kiosk.OrderingSystem.UserControls.CategoryItem();
            panel1 = new Panel();
            StartOver_Button = new Label();
            panel2 = new Panel();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            flowCategories.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // flowCategories
            // 
            flowCategories.AutoScroll = true;
            flowCategories.Controls.Add(categoryItem1);
            flowCategories.Dock = DockStyle.Left;
            flowCategories.FlowDirection = FlowDirection.TopDown;
            flowCategories.Location = new Point(0, 56);
            flowCategories.Name = "flowCategories";
            flowCategories.Size = new Size(120, 491);
            flowCategories.TabIndex = 0;
            flowCategories.WrapContents = false;
            // 
            // categoryItem1
            // 
            categoryItem1.Location = new Point(3, 3);
            categoryItem1.Name = "categoryItem1";
            categoryItem1.Size = new Size(110, 131);
            categoryItem1.TabIndex = 3;
            // 
            // panel1
            // 
            panel1.Controls.Add(StartOver_Button);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 547);
            panel1.Name = "panel1";
            panel1.Size = new Size(673, 78);
            panel1.TabIndex = 1;
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
            // panel2
            // 
            panel2.Controls.Add(label2);
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(673, 56);
            panel2.TabIndex = 2;
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
            pictureBox1.Image = Properties.Resources.Tux;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Margin = new Padding(0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(673, 56);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // KioskMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(flowCategories);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Name = "KioskMenu";
            Size = new Size(673, 625);
            flowCategories.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowCategories;
        private Panel panel1;
        private Label StartOver_Button;
        private Panel panel2;
        private Label label2;
        private PictureBox pictureBox1;
        private UserControls.CategoryItem categoryItem1;
    }
}
