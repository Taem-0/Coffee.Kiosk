namespace Coffee.Kiosk.Cashier
{
    partial class OrderCustomizer
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlHeader = new Panel();
            btnClose = new Button();
            lblCat = new Label();
            lblName = new Label();
            pnlFooter = new Panel();
            lblTotalPrice = new Label();
            btnAdd = new Guna.UI2.WinForms.Guna2Button();
            pnlBody = new Panel();
            pnlHeader.SuspendLayout();
            pnlFooter.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(59, 35, 20);
            pnlHeader.Controls.Add(btnClose);
            pnlHeader.Controls.Add(lblCat);
            pnlHeader.Controls.Add(lblName);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(562, 56);
            pnlHeader.TabIndex = 0;

            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Transparent;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(518, 14);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(32, 28);
            btnClose.TabIndex = 2;
            btnClose.Text = "X";
            btnClose.TextAlign = ContentAlignment.TopCenter;
            btnClose.UseVisualStyleBackColor = false;
            // 
            // lblCat
            // 
            lblCat.AutoSize = true;
            lblCat.Font = new Font("Segoe UI Semibold", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCat.ForeColor = Color.FromArgb(166, 124, 91);
            lblCat.Location = new Point(18, 32);
            lblCat.Name = "lblCat";
            lblCat.Size = new Size(62, 17);
            lblCat.TabIndex = 1;
            lblCat.Text = "category";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblName.ForeColor = Color.White;
            lblName.Location = new Point(18, 6);
            lblName.Name = "lblName";
            lblName.Size = new Size(68, 28);
            lblName.TabIndex = 0;
            lblName.Text = "Name";
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = Color.FromArgb(250, 246, 243);
            pnlFooter.Controls.Add(lblTotalPrice);
            pnlFooter.Controls.Add(btnAdd);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 580);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(562, 60);
            pnlFooter.TabIndex = 1;
            // 
            // lblTotalPrice
            // 
            lblTotalPrice.AutoSize = true;
            lblTotalPrice.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalPrice.ForeColor = Color.FromArgb(59, 35, 20);
            lblTotalPrice.Location = new Point(18, 19);
            lblTotalPrice.Name = "lblTotalPrice";
            lblTotalPrice.Size = new Size(67, 31);
            lblTotalPrice.TabIndex = 1;
            lblTotalPrice.Text = "Total";
            // 
            // btnAdd
            // 
            btnAdd.BorderRadius = 8;
            btnAdd.CustomizableEdges = customizableEdges1;
            btnAdd.DisabledState.BorderColor = Color.DarkGray;
            btnAdd.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAdd.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAdd.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAdd.FillColor = Color.FromArgb(107, 79, 58);
            btnAdd.Font = new Font("Segoe UI", 9F);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(380, 10);
            btnAdd.Name = "btnAdd";
            btnAdd.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnAdd.Size = new Size(160, 40);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Add to Order";
            // 
            // pnlBody
            // 
            pnlBody.AutoScroll = true;
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 56);
            pnlBody.Name = "pnlBody";
            pnlBody.Padding = new Padding(16, 12, 16, 12);
            pnlBody.Size = new Size(562, 524);
            pnlBody.TabIndex = 2;
            // 
            // OrderCustomizer
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(562, 640);
            Controls.Add(pnlBody);
            Controls.Add(pnlFooter);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "OrderCustomizer";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "OrderCustomizer";
            TopMost = true;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlFooter.ResumeLayout(false);
            pnlFooter.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblCat;
        private Label lblName;
        private Button btnClose;
        private Panel pnlFooter;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Label lblTotalPrice;
        private Panel pnlBody;
    }
}