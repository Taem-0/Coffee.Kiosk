namespace Coffee.Kiosk.OrderingSystem.UserControls
{
    partial class ViewOrder
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            TopPanel = new Panel();
            BottomPanel = new Panel();
            panel1 = new Panel();
            TotalPriceLbl = new Label();
            label5 = new Label();
            label3 = new Label();
            label2 = new Label();
            OrderMoreBtn = new Guna.UI2.WinForms.Guna2Button();
            checkOutBtn = new Guna.UI2.WinForms.Guna2Button();
            StarvOverBtn = new Guna.UI2.WinForms.Guna2Button();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel2 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            TopPanel.SuspendLayout();
            BottomPanel.SuspendLayout();
            panel1.SuspendLayout();
            guna2Panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.default_icon;
            pictureBox1.Location = new Point(22, 21);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(60, 60);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(88, 35);
            label1.Name = "label1";
            label1.Size = new Size(187, 37);
            label1.TabIndex = 1;
            label1.Text = "YOUR ORDER";
            // 
            // TopPanel
            // 
            TopPanel.Controls.Add(label1);
            TopPanel.Controls.Add(pictureBox1);
            TopPanel.Dock = DockStyle.Top;
            TopPanel.Location = new Point(0, 0);
            TopPanel.Name = "TopPanel";
            TopPanel.Size = new Size(673, 84);
            TopPanel.TabIndex = 2;
            // 
            // BottomPanel
            // 
            BottomPanel.BackColor = Color.SeaShell;
            BottomPanel.Controls.Add(panel1);
            BottomPanel.Controls.Add(StarvOverBtn);
            BottomPanel.Dock = DockStyle.Bottom;
            BottomPanel.Location = new Point(0, 595);
            BottomPanel.Name = "BottomPanel";
            BottomPanel.Size = new Size(673, 167);
            BottomPanel.TabIndex = 4;
            // 
            // panel1
            // 
            panel1.Controls.Add(TotalPriceLbl);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(OrderMoreBtn);
            panel1.Controls.Add(checkOutBtn);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(162, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(511, 167);
            panel1.TabIndex = 5;
            // 
            // TotalPriceLbl
            // 
            TotalPriceLbl.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TotalPriceLbl.Location = new Point(335, 34);
            TotalPriceLbl.Name = "TotalPriceLbl";
            TotalPriceLbl.RightToLeft = RightToLeft.Yes;
            TotalPriceLbl.Size = new Size(154, 20);
            TotalPriceLbl.TabIndex = 9;
            TotalPriceLbl.Text = "PHP 0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(418, 7);
            label5.Name = "label5";
            label5.Size = new Size(71, 20);
            label5.TabIndex = 8;
            label5.Text = "Sub Total";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(49, 34);
            label3.Name = "label3";
            label3.Size = new Size(44, 20);
            label3.TabIndex = 7;
            label3.Text = "Total";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(49, 7);
            label2.Name = "label2";
            label2.Size = new Size(71, 20);
            label2.TabIndex = 6;
            label2.Text = "Sub Total";
            // 
            // OrderMoreBtn
            // 
            OrderMoreBtn.Animated = true;
            OrderMoreBtn.BorderRadius = 17;
            OrderMoreBtn.CustomizableEdges = customizableEdges1;
            OrderMoreBtn.DisabledState.BorderColor = Color.DarkGray;
            OrderMoreBtn.DisabledState.CustomBorderColor = Color.DarkGray;
            OrderMoreBtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            OrderMoreBtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            OrderMoreBtn.FillColor = Color.FromArgb(99, 156, 92);
            OrderMoreBtn.Font = new Font("Segoe UI Semibold", 13.5F, FontStyle.Bold);
            OrderMoreBtn.ForeColor = Color.White;
            OrderMoreBtn.Location = new Point(39, 61);
            OrderMoreBtn.Margin = new Padding(50);
            OrderMoreBtn.Name = "OrderMoreBtn";
            OrderMoreBtn.ShadowDecoration.CustomizableEdges = customizableEdges2;
            OrderMoreBtn.Size = new Size(187, 56);
            OrderMoreBtn.TabIndex = 5;
            OrderMoreBtn.Text = "Order More";
            OrderMoreBtn.Click += OrderMoreBtn_Click;
            // 
            // checkOutBtn
            // 
            checkOutBtn.Animated = true;
            checkOutBtn.BorderRadius = 17;
            checkOutBtn.CustomizableEdges = customizableEdges3;
            checkOutBtn.DisabledState.BorderColor = Color.DarkGray;
            checkOutBtn.DisabledState.CustomBorderColor = Color.DarkGray;
            checkOutBtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            checkOutBtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            checkOutBtn.Enabled = false;
            checkOutBtn.FillColor = Color.Red;
            checkOutBtn.Font = new Font("Segoe UI Semibold", 13.5F, FontStyle.Bold);
            checkOutBtn.ForeColor = Color.White;
            checkOutBtn.Location = new Point(239, 61);
            checkOutBtn.Margin = new Padding(50);
            checkOutBtn.Name = "checkOutBtn";
            checkOutBtn.ShadowDecoration.CustomizableEdges = customizableEdges4;
            checkOutBtn.Size = new Size(250, 56);
            checkOutBtn.TabIndex = 4;
            checkOutBtn.Text = "Complete Order";
            checkOutBtn.Click += checkOutBtn_Click;
            // 
            // StarvOverBtn
            // 
            StarvOverBtn.BackColor = Color.Transparent;
            StarvOverBtn.BorderColor = Color.Transparent;
            StarvOverBtn.BorderRadius = 15;
            StarvOverBtn.BorderThickness = 1;
            StarvOverBtn.CustomizableEdges = customizableEdges5;
            StarvOverBtn.DisabledState.BorderColor = Color.DarkGray;
            StarvOverBtn.DisabledState.CustomBorderColor = Color.DarkGray;
            StarvOverBtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            StarvOverBtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            StarvOverBtn.FillColor = Color.WhiteSmoke;
            StarvOverBtn.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            StarvOverBtn.ForeColor = Color.Black;
            StarvOverBtn.HoverState.BorderColor = Color.Black;
            StarvOverBtn.HoverState.FillColor = Color.Transparent;
            StarvOverBtn.Location = new Point(0, 135);
            StarvOverBtn.Name = "StarvOverBtn";
            StarvOverBtn.ShadowDecoration.BorderRadius = 17;
            StarvOverBtn.ShadowDecoration.CustomizableEdges = customizableEdges6;
            StarvOverBtn.ShadowDecoration.Depth = 7;
            StarvOverBtn.ShadowDecoration.Enabled = true;
            StarvOverBtn.Size = new Size(116, 29);
            StarvOverBtn.TabIndex = 2;
            StarvOverBtn.Text = "< Start over";
            StarvOverBtn.Click += StarvOverBtn_Click;
            // 
            // guna2Panel1
            // 
            guna2Panel1.BackColor = Color.Transparent;
            guna2Panel1.BorderColor = Color.Silver;
            guna2Panel1.BorderRadius = 17;
            guna2Panel1.BorderThickness = 3;
            guna2Panel1.Controls.Add(flowLayoutPanel1);
            guna2Panel1.CustomizableEdges = customizableEdges7;
            guna2Panel1.FillColor = Color.White;
            guna2Panel1.Location = new Point(67, 56);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.Padding = new Padding(17, 7, 0, 7);
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2Panel1.Size = new Size(760, 518);
            guna2Panel1.TabIndex = 9;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(17, 7);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(743, 504);
            flowLayoutPanel1.TabIndex = 0;
            flowLayoutPanel1.WrapContents = false;
            // 
            // panel2
            // 
            panel2.AutoScroll = true;
            panel2.Controls.Add(guna2Panel1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 84);
            panel2.Name = "panel2";
            panel2.Size = new Size(673, 511);
            panel2.TabIndex = 10;
            // 
            // ViewOrder
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(228, 227, 210);
            Controls.Add(panel2);
            Controls.Add(BottomPanel);
            Controls.Add(TopPanel);
            Name = "ViewOrder";
            Size = new Size(673, 762);
            Load += ViewOrder_Load;
            Resize += ViewOrder_Resize;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            TopPanel.ResumeLayout(false);
            TopPanel.PerformLayout();
            BottomPanel.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            guna2Panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Panel TopPanel;
        private Panel BottomPanel;
        private Panel panel1;
        private Guna.UI2.WinForms.Guna2Button checkOutBtn;
        private Guna.UI2.WinForms.Guna2Button OrderMoreBtn;
        private Label label2;
        private Label TotalPriceLbl;
        private Label label5;
        private Label label3;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel2;
        private Guna.UI2.WinForms.Guna2Button StarvOverBtn;
    }
}
