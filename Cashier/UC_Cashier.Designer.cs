namespace Coffee.Kiosk.Cashier
{
    partial class UC_Cashier
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
            pnlRight = new Panel();
            label1 = new Label();
            lblOrderNum = new Label();
            pnlOrderItems = new Panel();
            pnlOrderFooter = new Panel();
            label2 = new Label();
            lblTax = new Label();
            lblSubtotal = new Label();
            btnPay = new Guna.UI2.WinForms.Guna2Button();
            btnClear = new Guna.UI2.WinForms.Guna2Button();
            pnlLeft = new Panel();
            flpMenuGrid = new FlowLayoutPanel();
            flpCategories = new FlowLayoutPanel();
            txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            pnlRight.SuspendLayout();
            pnlOrderFooter.SuspendLayout();
            pnlLeft.SuspendLayout();
            SuspendLayout();
            // 
            // pnlRight
            // 
            pnlRight.BackColor = Color.FromArgb(107, 77, 58);
            pnlRight.Controls.Add(label1);
            pnlRight.Controls.Add(lblOrderNum);
            pnlRight.Controls.Add(pnlOrderItems);
            pnlRight.Controls.Add(pnlOrderFooter);
            pnlRight.Dock = DockStyle.Right;
            pnlRight.Location = new Point(1428, 0);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(493, 1002);
            pnlRight.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(22, 16);
            label1.Name = "label1";
            label1.Size = new Size(176, 28);
            label1.TabIndex = 0;
            label1.Text = "Customer's Order";
            // 
            // lblOrderNum
            // 
            lblOrderNum.AutoSize = true;
            lblOrderNum.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblOrderNum.ForeColor = Color.FromArgb(166, 124, 91);
            lblOrderNum.Location = new Point(358, 16);
            lblOrderNum.Name = "lblOrderNum";
            lblOrderNum.Size = new Size(118, 28);
            lblOrderNum.TabIndex = 1;
            lblOrderNum.Text = "Order Num";
            lblOrderNum.Click += lblOrderNum_Click;
            // 
            // pnlOrderItems
            // 
            pnlOrderItems.AutoScroll = true;
            pnlOrderItems.Location = new Point(0, 58);
            pnlOrderItems.Name = "pnlOrderItems";
            pnlOrderItems.Padding = new Padding(6);
            pnlOrderItems.Size = new Size(493, 601);
            pnlOrderItems.TabIndex = 1;
            pnlOrderItems.Paint += pnlOrderItems_Paint;
            // 
            // pnlOrderFooter
            // 
            pnlOrderFooter.BackColor = Color.FromArgb(59, 35, 20);
            pnlOrderFooter.Controls.Add(label2);
            pnlOrderFooter.Controls.Add(lblTax);
            pnlOrderFooter.Controls.Add(lblSubtotal);
            pnlOrderFooter.Controls.Add(btnPay);
            pnlOrderFooter.Controls.Add(btnClear);
            pnlOrderFooter.Dock = DockStyle.Bottom;
            pnlOrderFooter.Location = new Point(0, 659);
            pnlOrderFooter.Name = "pnlOrderFooter";
            pnlOrderFooter.Padding = new Padding(10);
            pnlOrderFooter.Size = new Size(493, 343);
            pnlOrderFooter.TabIndex = 0;
            pnlOrderFooter.Paint += pnlOrderFooter_Paint;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(212, 184, 150);
            label2.Location = new Point(20, 119);
            label2.Name = "label2";
            label2.Size = new Size(82, 37);
            label2.TabIndex = 4;
            label2.Text = "Total";
            label2.Click += label2_Click;
            // 
            // lblTax
            // 
            lblTax.AutoSize = true;
            lblTax.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTax.ForeColor = Color.FromArgb(212, 184, 150);
            lblTax.Location = new Point(20, 71);
            lblTax.Name = "lblTax";
            lblTax.Size = new Size(93, 28);
            lblTax.TabIndex = 3;
            lblTax.Text = "Tax (0%)";
            lblTax.Click += lblTax_Click;
            // 
            // lblSubtotal
            // 
            lblSubtotal.AutoSize = true;
            lblSubtotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblSubtotal.ForeColor = Color.FromArgb(212, 184, 150);
            lblSubtotal.Location = new Point(20, 25);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new Size(92, 28);
            lblSubtotal.TabIndex = 2;
            lblSubtotal.Text = "Subtotal";
            lblSubtotal.Click += lblSubtotal_Click;
            // 
            // btnPay
            // 
            btnPay.BorderRadius = 10;
            btnPay.CustomizableEdges = customizableEdges1;
            btnPay.DisabledState.BorderColor = Color.DarkGray;
            btnPay.DisabledState.CustomBorderColor = Color.DarkGray;
            btnPay.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnPay.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnPay.FillColor = Color.FromArgb(111, 77, 56);
            btnPay.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPay.ForeColor = Color.White;
            btnPay.Location = new Point(238, 267);
            btnPay.Name = "btnPay";
            btnPay.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnPay.Size = new Size(226, 50);
            btnPay.TabIndex = 1;
            btnPay.Text = "Proceed to Payment";
            btnPay.Click += btnPay_Click;
            // 
            // btnClear
            // 
            btnClear.BorderRadius = 10;
            btnClear.CustomizableEdges = customizableEdges3;
            btnClear.DisabledState.BorderColor = Color.DarkGray;
            btnClear.DisabledState.CustomBorderColor = Color.DarkGray;
            btnClear.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnClear.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnClear.FillColor = Color.FromArgb(111, 77, 56);
            btnClear.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(33, 267);
            btnClear.Name = "btnClear";
            btnClear.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnClear.Size = new Size(175, 50);
            btnClear.TabIndex = 0;
            btnClear.Text = "Clear";
            btnClear.Click += btnClear_Click;
            // 
            // pnlLeft
            // 
            pnlLeft.Controls.Add(flpMenuGrid);
            pnlLeft.Controls.Add(flpCategories);
            pnlLeft.Controls.Add(txtSearch);
            pnlLeft.Dock = DockStyle.Fill;
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(1428, 1002);
            pnlLeft.TabIndex = 1;
            // 
            // flpMenuGrid
            // 
            flpMenuGrid.AutoScroll = true;
            flpMenuGrid.BackColor = Color.Transparent;
            flpMenuGrid.Location = new Point(21, 187);
            flpMenuGrid.Name = "flpMenuGrid";
            flpMenuGrid.Size = new Size(1382, 789);
            flpMenuGrid.TabIndex = 2;
            flpMenuGrid.Paint += flpMenuGrid_Paint;
            // 
            // flpCategories
            // 
            flpCategories.AutoScroll = true;
            flpCategories.BackColor = Color.Transparent;
            flpCategories.Location = new Point(21, 105);
            flpCategories.Name = "flpCategories";
            flpCategories.Size = new Size(1382, 65);
            flpCategories.TabIndex = 1;
            flpCategories.WrapContents = false;
            flpCategories.Paint += flpCategories_Paint;
            // 
            // txtSearch
            // 
            txtSearch.BorderColor = Color.FromArgb(212, 184, 150);
            txtSearch.BorderRadius = 8;
            txtSearch.BorderThickness = 3;
            txtSearch.CustomizableEdges = customizableEdges5;
            txtSearch.DefaultText = "";
            txtSearch.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtSearch.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtSearch.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtSearch.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtSearch.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearch.Location = new Point(21, 23);
            txtSearch.Margin = new Padding(4, 6, 4, 6);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search";
            txtSearch.SelectedText = "";
            txtSearch.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtSearch.Size = new Size(1382, 67);
            txtSearch.TabIndex = 0;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // UC_Cashier
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlLeft);
            Controls.Add(pnlRight);
            Name = "UC_Cashier";
            Size = new Size(1921, 1002);
            pnlRight.ResumeLayout(false);
            pnlRight.PerformLayout();
            pnlOrderFooter.ResumeLayout(false);
            pnlOrderFooter.PerformLayout();
            pnlLeft.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlRight;
        private Panel pnlLeft;
        private Panel pnlOrderItems;
        private Panel pnlOrderFooter;
        private Guna.UI2.WinForms.Guna2Button btnClear;
        private Guna.UI2.WinForms.Guna2Button btnPay;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private FlowLayoutPanel flpCategories;
        private FlowLayoutPanel flpMenuGrid;
        private Label label1;
        private Label lblOrderNum;
        private Label label2;
        private Label lblTax;
        private Label lblSubtotal;
    }
}
