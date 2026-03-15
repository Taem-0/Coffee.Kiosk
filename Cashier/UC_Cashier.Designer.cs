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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlRight = new Panel();
            pnlLeft = new Panel();
            pnlOrderFooter = new Panel();
            pnlOrderItems = new Panel();
            btnClear = new Guna.UI2.WinForms.Guna2Button();
            btnPay = new Guna.UI2.WinForms.Guna2Button();
            txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            flpCategories = new FlowLayoutPanel();
            flpMenuGrid = new FlowLayoutPanel();
            pnlRight.SuspendLayout();
            pnlLeft.SuspendLayout();
            pnlOrderFooter.SuspendLayout();
            SuspendLayout();
            // 
            // pnlRight
            // 
            pnlRight.BackColor = Color.FromArgb(107, 77, 58);
            pnlRight.Controls.Add(pnlOrderItems);
            pnlRight.Controls.Add(pnlOrderFooter);
            pnlRight.Dock = DockStyle.Right;
            pnlRight.Location = new Point(1428, 0);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(493, 1002);
            pnlRight.TabIndex = 0;
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
            // pnlOrderFooter
            // 
            pnlOrderFooter.BackColor = Color.FromArgb(59, 35, 20);
            pnlOrderFooter.Controls.Add(btnPay);
            pnlOrderFooter.Controls.Add(btnClear);
            pnlOrderFooter.Dock = DockStyle.Bottom;
            pnlOrderFooter.Location = new Point(0, 659);
            pnlOrderFooter.Name = "pnlOrderFooter";
            pnlOrderFooter.Padding = new Padding(10);
            pnlOrderFooter.Size = new Size(493, 343);
            pnlOrderFooter.TabIndex = 0;
            // 
            // pnlOrderItems
            // 
            pnlOrderItems.AutoScroll = true;
            pnlOrderItems.Dock = DockStyle.Fill;
            pnlOrderItems.Location = new Point(0, 0);
            pnlOrderItems.Name = "pnlOrderItems";
            pnlOrderItems.Padding = new Padding(6);
            pnlOrderItems.Size = new Size(493, 659);
            pnlOrderItems.TabIndex = 1;
            // 
            // btnClear
            // 
            btnClear.BorderRadius = 10;
            btnClear.CustomizableEdges = customizableEdges7;
            btnClear.DisabledState.BorderColor = Color.DarkGray;
            btnClear.DisabledState.CustomBorderColor = Color.DarkGray;
            btnClear.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnClear.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnClear.FillColor = Color.FromArgb(111, 77, 56);
            btnClear.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(33, 267);
            btnClear.Name = "btnClear";
            btnClear.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnClear.Size = new Size(175, 50);
            btnClear.TabIndex = 0;
            btnClear.Text = "Clear";
            // 
            // btnPay
            // 
            btnPay.BorderRadius = 10;
            btnPay.CustomizableEdges = customizableEdges9;
            btnPay.DisabledState.BorderColor = Color.DarkGray;
            btnPay.DisabledState.CustomBorderColor = Color.DarkGray;
            btnPay.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnPay.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnPay.FillColor = Color.FromArgb(111, 77, 56);
            btnPay.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPay.ForeColor = Color.White;
            btnPay.Location = new Point(238, 267);
            btnPay.Name = "btnPay";
            btnPay.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnPay.Size = new Size(226, 50);
            btnPay.TabIndex = 1;
            btnPay.Text = "Proceed to Payment";
            // 
            // txtSearch
            // 
            txtSearch.BorderColor = Color.FromArgb(212, 184, 150);
            txtSearch.BorderRadius = 8;
            txtSearch.BorderThickness = 3;
            txtSearch.CustomizableEdges = customizableEdges11;
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
            txtSearch.ShadowDecoration.CustomizableEdges = customizableEdges12;
            txtSearch.Size = new Size(1382, 67);
            txtSearch.TabIndex = 0;
            // 
            // flpCategories
            // 
            flpCategories.BackColor = Color.Transparent;
            flpCategories.Location = new Point(21, 105);
            flpCategories.Name = "flpCategories";
            flpCategories.Size = new Size(1382, 65);
            flpCategories.TabIndex = 1;
            flpCategories.WrapContents = false;
            flpCategories.Paint += flpCategories_Paint;
            // 
            // flpMenuGrid
            // 
            flpMenuGrid.AutoScroll = true;
            flpMenuGrid.BackColor = Color.Transparent;
            flpMenuGrid.Location = new Point(21, 187);
            flpMenuGrid.Name = "flpMenuGrid";
            flpMenuGrid.Size = new Size(1382, 789);
            flpMenuGrid.TabIndex = 2;
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
            pnlLeft.ResumeLayout(false);
            pnlOrderFooter.ResumeLayout(false);
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
    }
}
