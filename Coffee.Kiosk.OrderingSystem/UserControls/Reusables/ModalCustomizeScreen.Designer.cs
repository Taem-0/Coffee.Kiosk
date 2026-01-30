namespace Coffee.Kiosk.OrderingSystem.UserControls.Reusables
{
    partial class ModalCustomizeScreen
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
            topPanel = new Panel();
            guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            pictureBox1 = new PictureBox();
            ProductNameLbl = new Label();
            panel2 = new Panel();
            AmountLbl = new Label();
            SubtractAmountButton = new Guna.UI2.WinForms.Guna2Button();
            AddAmountBtn = new Guna.UI2.WinForms.Guna2Button();
            button1 = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            topPanel.SuspendLayout();
            guna2ShadowPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // topPanel
            // 
            topPanel.Controls.Add(guna2ShadowPanel1);
            topPanel.Controls.Add(button1);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(0, 0);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(517, 179);
            topPanel.TabIndex = 0;
            // 
            // guna2ShadowPanel1
            // 
            guna2ShadowPanel1.BackColor = Color.Transparent;
            guna2ShadowPanel1.Controls.Add(pictureBox1);
            guna2ShadowPanel1.Controls.Add(ProductNameLbl);
            guna2ShadowPanel1.Controls.Add(panel2);
            guna2ShadowPanel1.FillColor = Color.White;
            guna2ShadowPanel1.Location = new Point(185, 19);
            guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            guna2ShadowPanel1.Radius = 5;
            guna2ShadowPanel1.ShadowColor = Color.Black;
            guna2ShadowPanel1.Size = new Size(138, 146);
            guna2ShadowPanel1.TabIndex = 4;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.default_icon;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(138, 96);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // ProductNameLbl
            // 
            ProductNameLbl.Dock = DockStyle.Bottom;
            ProductNameLbl.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ProductNameLbl.Location = new Point(0, 96);
            ProductNameLbl.Name = "ProductNameLbl";
            ProductNameLbl.Size = new Size(138, 22);
            ProductNameLbl.TabIndex = 1;
            ProductNameLbl.Text = "Product_Name";
            ProductNameLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.Controls.Add(AmountLbl);
            panel2.Controls.Add(SubtractAmountButton);
            panel2.Controls.Add(AddAmountBtn);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 118);
            panel2.Name = "panel2";
            panel2.Size = new Size(138, 28);
            panel2.TabIndex = 3;
            // 
            // AmountLbl
            // 
            AmountLbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AmountLbl.Location = new Point(48, 0);
            AmountLbl.Name = "AmountLbl";
            AmountLbl.Size = new Size(42, 25);
            AmountLbl.TabIndex = 3;
            AmountLbl.Text = "13";
            AmountLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SubtractAmountButton
            // 
            SubtractAmountButton.BorderRadius = 10;
            customizableEdges1.BottomRight = false;
            customizableEdges1.TopLeft = false;
            customizableEdges1.TopRight = false;
            SubtractAmountButton.CustomizableEdges = customizableEdges1;
            SubtractAmountButton.DisabledState.BorderColor = Color.DarkGray;
            SubtractAmountButton.DisabledState.CustomBorderColor = Color.DarkGray;
            SubtractAmountButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            SubtractAmountButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            SubtractAmountButton.FillColor = Color.IndianRed;
            SubtractAmountButton.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SubtractAmountButton.ForeColor = Color.White;
            SubtractAmountButton.Location = new Point(3, 0);
            SubtractAmountButton.Name = "SubtractAmountButton";
            SubtractAmountButton.ShadowDecoration.CustomizableEdges = customizableEdges2;
            SubtractAmountButton.Size = new Size(45, 25);
            SubtractAmountButton.TabIndex = 3;
            SubtractAmountButton.Text = "+";
            SubtractAmountButton.Click += SubtractAmountButton_Click;
            // 
            // AddAmountBtn
            // 
            AddAmountBtn.BorderRadius = 10;
            customizableEdges3.BottomLeft = false;
            customizableEdges3.TopLeft = false;
            customizableEdges3.TopRight = false;
            AddAmountBtn.CustomizableEdges = customizableEdges3;
            AddAmountBtn.DisabledState.BorderColor = Color.DarkGray;
            AddAmountBtn.DisabledState.CustomBorderColor = Color.DarkGray;
            AddAmountBtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            AddAmountBtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            AddAmountBtn.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddAmountBtn.ForeColor = Color.White;
            AddAmountBtn.Location = new Point(90, 0);
            AddAmountBtn.Name = "AddAmountBtn";
            AddAmountBtn.PressedDepth = 0;
            AddAmountBtn.ShadowDecoration.CustomizableEdges = customizableEdges4;
            AddAmountBtn.Size = new Size(45, 25);
            AddAmountBtn.TabIndex = 2;
            AddAmountBtn.Text = "+";
            AddAmountBtn.Click += AddAmountBtn_Click;
            // 
            // button1
            // 
            button1.Location = new Point(391, 91);
            button1.Name = "button1";
            button1.Size = new Size(75, 47);
            button1.TabIndex = 3;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(0, 179);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(517, 438);
            flowLayoutPanel1.TabIndex = 1;
            flowLayoutPanel1.WrapContents = false;
            // 
            // ModalCustomizeScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(flowLayoutPanel1);
            Controls.Add(topPanel);
            Name = "ModalCustomizeScreen";
            Size = new Size(517, 617);
            Load += ModalCustomizeScreen_Load;
            Resize += ModalCustomizeScreen_Resize;
            topPanel.ResumeLayout(false);
            guna2ShadowPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel topPanel;
        private PictureBox pictureBox1;
        private Label ProductNameLbl;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label AmountLbl;
        private Guna.UI2.WinForms.Guna2Button AddAmountBtn;
        private Panel panel2;
        private Guna.UI2.WinForms.Guna2Button SubtractAmountButton;
        private Button button1;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
    }
}
