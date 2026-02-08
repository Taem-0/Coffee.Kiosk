namespace Coffee.Kiosk.OrderingSystem.Forms.ViewDetail
{
    partial class ViewDetail
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            panel3 = new Panel();
            CloseBtn = new Guna.UI2.WinForms.Guna2Button();
            panel1 = new Panel();
            guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            pictureBox1 = new PictureBox();
            ProductNameLbl = new Label();
            panel2 = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            guna2ShadowPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.DragForm = false;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // panel3
            // 
            panel3.Controls.Add(CloseBtn);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 473);
            panel3.Name = "panel3";
            panel3.Size = new Size(500, 83);
            panel3.TabIndex = 6;
            // 
            // CloseBtn
            // 
            CloseBtn.BorderColor = Color.FromArgb(51, 79, 139);
            CloseBtn.BorderRadius = 13;
            CloseBtn.BorderThickness = 1;
            CloseBtn.CustomizableEdges = customizableEdges1;
            CloseBtn.DisabledState.BorderColor = Color.DarkGray;
            CloseBtn.DisabledState.CustomBorderColor = Color.DarkGray;
            CloseBtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            CloseBtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            CloseBtn.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CloseBtn.ForeColor = Color.White;
            CloseBtn.Location = new Point(371, 19);
            CloseBtn.Name = "CloseBtn";
            CloseBtn.ShadowDecoration.CustomizableEdges = customizableEdges2;
            CloseBtn.Size = new Size(107, 42);
            CloseBtn.TabIndex = 0;
            CloseBtn.Text = "Close";
            CloseBtn.Click += CloseBtn_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(guna2ShadowPanel1);
            panel1.Controls.Add(ProductNameLbl);
            panel1.Location = new Point(176, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(129, 156);
            panel1.TabIndex = 3;
            // 
            // guna2ShadowPanel1
            // 
            guna2ShadowPanel1.BackColor = Color.Transparent;
            guna2ShadowPanel1.Controls.Add(pictureBox1);
            guna2ShadowPanel1.Dock = DockStyle.Fill;
            guna2ShadowPanel1.EdgeWidth = 1;
            guna2ShadowPanel1.FillColor = Color.White;
            guna2ShadowPanel1.Location = new Point(0, 0);
            guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            guna2ShadowPanel1.Radius = 5;
            guna2ShadowPanel1.ShadowColor = Color.Black;
            guna2ShadowPanel1.Size = new Size(129, 122);
            guna2ShadowPanel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.default_icon;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(129, 122);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // ProductNameLbl
            // 
            ProductNameLbl.Dock = DockStyle.Bottom;
            ProductNameLbl.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ProductNameLbl.Location = new Point(0, 122);
            ProductNameLbl.Name = "ProductNameLbl";
            ProductNameLbl.Size = new Size(129, 34);
            ProductNameLbl.TabIndex = 2;
            ProductNameLbl.Text = "Product_Name";
            ProductNameLbl.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(500, 181);
            panel2.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(0, 181);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(500, 292);
            flowLayoutPanel1.TabIndex = 7;
            flowLayoutPanel1.WrapContents = false;
            // 
            // ViewDetail
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.White;
            ClientSize = new Size(500, 556);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(panel3);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.None;
            MaximumSize = new Size(500, 556);
            MinimumSize = new Size(500, 300);
            Name = "ViewDetail";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ViewDetail";
            Load += ViewDetail_Load;
            Resize += ViewDetail_Resize;
            panel3.ResumeLayout(false);
            panel1.ResumeLayout(false);
            guna2ShadowPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Panel panel3;
        private Guna.UI2.WinForms.Guna2Button CloseBtn;
        private Panel panel2;
        private Panel panel1;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private PictureBox pictureBox1;
        private Label ProductNameLbl;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}