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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            flowCategories = new FlowLayoutPanel();
            BottomPanel = new Panel();
            StartOverBtn = new Guna.UI2.WinForms.Guna2Button();
            pictureBox2 = new PictureBox();
            AdPanel = new Panel();
            pictureBox1 = new PictureBox();
            ContentPanel = new Guna.UI2.WinForms.Guna2Panel();
            BottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            AdPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // flowCategories
            // 
            flowCategories.AutoScroll = true;
            flowCategories.BackColor = Color.SeaShell;
            flowCategories.Dock = DockStyle.Left;
            flowCategories.FlowDirection = FlowDirection.TopDown;
            flowCategories.Location = new Point(0, 95);
            flowCategories.Name = "flowCategories";
            flowCategories.Size = new Size(125, 418);
            flowCategories.TabIndex = 0;
            flowCategories.WrapContents = false;
            // 
            // BottomPanel
            // 
            BottomPanel.BackColor = Color.SeaShell;
            BottomPanel.Controls.Add(StartOverBtn);
            BottomPanel.Controls.Add(pictureBox2);
            BottomPanel.Dock = DockStyle.Bottom;
            BottomPanel.Location = new Point(0, 513);
            BottomPanel.Name = "BottomPanel";
            BottomPanel.Size = new Size(673, 112);
            BottomPanel.TabIndex = 1;
            BottomPanel.Paint += BottomPanel_Paint;
            // 
            // StartOverBtn
            // 
            StartOverBtn.Animated = true;
            StartOverBtn.BorderColor = Color.DimGray;
            StartOverBtn.BorderRadius = 15;
            StartOverBtn.BorderThickness = 1;
            StartOverBtn.CustomizableEdges = customizableEdges1;
            StartOverBtn.DisabledState.BorderColor = Color.DarkGray;
            StartOverBtn.DisabledState.CustomBorderColor = Color.DarkGray;
            StartOverBtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            StartOverBtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            StartOverBtn.FillColor = Color.DarkKhaki;
            StartOverBtn.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            StartOverBtn.ForeColor = Color.Black;
            StartOverBtn.HoverState.BorderColor = Color.Black;
            StartOverBtn.HoverState.FillColor = Color.FromArgb(138, 133, 78);
            StartOverBtn.Location = new Point(9, 80);
            StartOverBtn.Name = "StartOverBtn";
            StartOverBtn.ShadowDecoration.CustomizableEdges = customizableEdges2;
            StartOverBtn.Size = new Size(116, 29);
            StartOverBtn.TabIndex = 2;
            StartOverBtn.Text = "< Start over";
            StartOverBtn.Click += guna2Button1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.CART__1__1_;
            pictureBox2.Location = new Point(36, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(80, 70);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // AdPanel
            // 
            AdPanel.Controls.Add(pictureBox1);
            AdPanel.Dock = DockStyle.Top;
            AdPanel.Location = new Point(0, 0);
            AdPanel.Name = "AdPanel";
            AdPanel.Size = new Size(673, 95);
            AdPanel.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Sienna;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Margin = new Padding(0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(673, 95);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // ContentPanel
            // 
            ContentPanel.BackColor = Color.SeaShell;
            ContentPanel.CustomizableEdges = customizableEdges3;
            ContentPanel.Dock = DockStyle.Fill;
            ContentPanel.Location = new Point(125, 95);
            ContentPanel.Name = "ContentPanel";
            ContentPanel.Padding = new Padding(3);
            ContentPanel.ShadowDecoration.CustomizableEdges = customizableEdges4;
            ContentPanel.Size = new Size(548, 418);
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
            Margin = new Padding(0);
            Name = "KioskMenu";
            Size = new Size(673, 625);
            BottomPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            AdPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowCategories;
        private Panel BottomPanel;
        private Label StartOver_Button;
        private Panel AdPanel;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Guna.UI2.WinForms.Guna2Panel ContentPanel;
        private Guna.UI2.WinForms.Guna2Button StartOverBtn;
    }
}
