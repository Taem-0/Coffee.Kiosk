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
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            ProductNameLbl = new Label();
            panel2 = new Panel();
            AmountLbl = new Label();
            SubtractAmountButton = new Guna.UI2.WinForms.Guna2Button();
            AddAmountBtn = new Guna.UI2.WinForms.Guna2Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            button1 = new Button();
            topPanel.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // topPanel
            // 
            topPanel.Controls.Add(button1);
            topPanel.Controls.Add(panel1);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(0, 0);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(517, 173);
            topPanel.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(ProductNameLbl);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(191, 23);
            panel1.Name = "panel1";
            panel1.Size = new Size(130, 144);
            panel1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.default_icon;
            pictureBox1.Location = new Point(0, 31);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(130, 82);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // ProductNameLbl
            // 
            ProductNameLbl.Dock = DockStyle.Top;
            ProductNameLbl.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ProductNameLbl.Location = new Point(0, 0);
            ProductNameLbl.Name = "ProductNameLbl";
            ProductNameLbl.Size = new Size(130, 31);
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
            panel2.Location = new Point(0, 113);
            panel2.Name = "panel2";
            panel2.Size = new Size(130, 31);
            panel2.TabIndex = 3;
            // 
            // AmountLbl
            // 
            AmountLbl.Dock = DockStyle.Fill;
            AmountLbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AmountLbl.Location = new Point(48, 0);
            AmountLbl.Name = "AmountLbl";
            AmountLbl.Size = new Size(34, 31);
            AmountLbl.TabIndex = 3;
            AmountLbl.Text = "13";
            AmountLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SubtractAmountButton
            // 
            SubtractAmountButton.CustomizableEdges = customizableEdges1;
            SubtractAmountButton.DisabledState.BorderColor = Color.DarkGray;
            SubtractAmountButton.DisabledState.CustomBorderColor = Color.DarkGray;
            SubtractAmountButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            SubtractAmountButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            SubtractAmountButton.Dock = DockStyle.Left;
            SubtractAmountButton.FillColor = Color.IndianRed;
            SubtractAmountButton.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SubtractAmountButton.ForeColor = Color.White;
            SubtractAmountButton.Location = new Point(0, 0);
            SubtractAmountButton.Name = "SubtractAmountButton";
            SubtractAmountButton.ShadowDecoration.CustomizableEdges = customizableEdges2;
            SubtractAmountButton.Size = new Size(48, 31);
            SubtractAmountButton.TabIndex = 3;
            SubtractAmountButton.Text = "+";
            SubtractAmountButton.Click += SubtractAmountButton_Click;
            // 
            // AddAmountBtn
            // 
            AddAmountBtn.CustomizableEdges = customizableEdges3;
            AddAmountBtn.DisabledState.BorderColor = Color.DarkGray;
            AddAmountBtn.DisabledState.CustomBorderColor = Color.DarkGray;
            AddAmountBtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            AddAmountBtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            AddAmountBtn.Dock = DockStyle.Right;
            AddAmountBtn.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddAmountBtn.ForeColor = Color.White;
            AddAmountBtn.Location = new Point(82, 0);
            AddAmountBtn.Name = "AddAmountBtn";
            AddAmountBtn.ShadowDecoration.CustomizableEdges = customizableEdges4;
            AddAmountBtn.Size = new Size(48, 31);
            AddAmountBtn.TabIndex = 2;
            AddAmountBtn.Text = "+";
            AddAmountBtn.Click += AddAmountBtn_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 173);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(517, 444);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(392, 100);
            button1.Name = "button1";
            button1.Size = new Size(75, 47);
            button1.TabIndex = 3;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
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
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel topPanel;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label ProductNameLbl;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label AmountLbl;
        private Guna.UI2.WinForms.Guna2Button AddAmountBtn;
        private Panel panel2;
        private Guna.UI2.WinForms.Guna2Button SubtractAmountButton;
        private Button button1;
    }
}
