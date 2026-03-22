namespace Coffee.Kiosk.OrderingSystem
{
    partial class GetStartedScreen
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
            guna2ShadowPanel2 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            panel1 = new Panel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            guna2ShadowPanel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // guna2ShadowPanel2
            // 
            guna2ShadowPanel2.BackColor = Color.Transparent;
            guna2ShadowPanel2.Controls.Add(panel1);
            guna2ShadowPanel2.Dock = DockStyle.Bottom;
            guna2ShadowPanel2.EdgeWidth = 40;
            guna2ShadowPanel2.FillColor = Color.FromArgb(58, 35, 29);
            guna2ShadowPanel2.Location = new Point(0, 443);
            guna2ShadowPanel2.Name = "guna2ShadowPanel2";
            guna2ShadowPanel2.Radius = 20;
            guna2ShadowPanel2.ShadowColor = Color.Black;
            guna2ShadowPanel2.ShadowDepth = 50;
            guna2ShadowPanel2.ShadowShift = 1;
            guna2ShadowPanel2.Size = new Size(675, 183);
            guna2ShadowPanel2.TabIndex = 1;
            guna2ShadowPanel2.Click += guna2ShadowPanel2_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(107, 42);
            panel1.Name = "panel1";
            panel1.Size = new Size(464, 141);
            panel1.TabIndex = 2;
            panel1.Click += panel1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(145, 53);
            label1.Name = "label1";
            label1.Size = new Size(302, 37);
            label1.TabIndex = 1;
            label1.Text = "TOUCH TO START";
            label1.Click += label1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.default_icon;
            pictureBox1.Location = new Point(0, 8);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(130, 130);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // GetStartedScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 12, 5);
            BackgroundImage = Properties.Resources.ADS1;
            BackgroundImageLayout = ImageLayout.Zoom;
            Controls.Add(guna2ShadowPanel2);
            Margin = new Padding(3, 2, 3, 2);
            Name = "GetStartedScreen";
            Size = new Size(675, 626);
            Load += GetStartedScreen_Load;
            Click += GetStartedScreen_Click;
            Resize += GetStartedScreen_Resize;
            guna2ShadowPanel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel2;
        private PictureBox pictureBox1;
        private Label label1;
        private Panel panel1;
    }
}
