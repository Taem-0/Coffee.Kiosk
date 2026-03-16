namespace Coffee.Kiosk.Cashier
{
    partial class UC_Payment
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlPayRight = new Panel();
            btnBack = new Guna.UI2.WinForms.Guna2Button();
            btnConfirm = new Guna.UI2.WinForms.Guna2Button();
            lblChangeAmt = new Label();
            lblTotalAmt = new Label();
            pnlPayLeft = new Panel();
            guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            lblCashTend = new Label();
            lblQuick = new Label();
            guna2Button5 = new Guna.UI2.WinForms.Guna2Button();
            guna2Button4 = new Guna.UI2.WinForms.Guna2Button();
            guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            lblSummary = new Label();
            pnlSummary = new Panel();
            pnlPayRight.SuspendLayout();
            pnlPayLeft.SuspendLayout();
            SuspendLayout();
            // 
            // pnlPayRight
            // 
            pnlPayRight.BackColor = Color.White;
            pnlPayRight.Controls.Add(btnBack);
            pnlPayRight.Controls.Add(btnConfirm);
            pnlPayRight.Controls.Add(lblChangeAmt);
            pnlPayRight.Controls.Add(lblTotalAmt);
            pnlPayRight.Dock = DockStyle.Right;
            pnlPayRight.Location = new Point(1320, 0);
            pnlPayRight.Name = "pnlPayRight";
            pnlPayRight.Padding = new Padding(20);
            pnlPayRight.Size = new Size(600, 1001);
            pnlPayRight.TabIndex = 0;
            pnlPayRight.Paint += pnlPayRight_Paint;
            // 
            // btnBack
            // 
            btnBack.BorderRadius = 10;
            btnBack.CustomizableEdges = customizableEdges1;
            btnBack.DisabledState.BorderColor = Color.DarkGray;
            btnBack.DisabledState.CustomBorderColor = Color.DarkGray;
            btnBack.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnBack.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnBack.FillColor = Color.FromArgb(107, 77, 58);
            btnBack.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(86, 911);
            btnBack.Name = "btnBack";
            btnBack.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnBack.Size = new Size(326, 52);
            btnBack.TabIndex = 3;
            btnBack.Text = "⬅️ Back to Order";
            btnBack.Click += btnBack_Click;
            // 
            // btnConfirm
            // 
            btnConfirm.BorderRadius = 10;
            btnConfirm.CustomizableEdges = customizableEdges3;
            btnConfirm.DisabledState.BorderColor = Color.DarkGray;
            btnConfirm.DisabledState.CustomBorderColor = Color.DarkGray;
            btnConfirm.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnConfirm.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnConfirm.Enabled = false;
            btnConfirm.FillColor = Color.FromArgb(107, 77, 58);
            btnConfirm.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConfirm.ForeColor = Color.White;
            btnConfirm.Location = new Point(86, 819);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnConfirm.Size = new Size(326, 52);
            btnConfirm.TabIndex = 2;
            btnConfirm.Text = "Confirm Payment";
            btnConfirm.Click += btnConfirm_Click;
            // 
            // lblChangeAmt
            // 
            lblChangeAmt.AutoSize = true;
            lblChangeAmt.BackColor = Color.Transparent;
            lblChangeAmt.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold);
            lblChangeAmt.ForeColor = Color.FromArgb(111, 77, 56);
            lblChangeAmt.Location = new Point(46, 268);
            lblChangeAmt.Name = "lblChangeAmt";
            lblChangeAmt.Size = new Size(148, 46);
            lblChangeAmt.TabIndex = 1;
            lblChangeAmt.Text = "Change:";
            lblChangeAmt.Click += lblChangeAmt_Click;
            // 
            // lblTotalAmt
            // 
            lblTotalAmt.AutoSize = true;
            lblTotalAmt.BackColor = Color.Transparent;
            lblTotalAmt.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold);
            lblTotalAmt.ForeColor = Color.FromArgb(111, 77, 56);
            lblTotalAmt.Location = new Point(46, 46);
            lblTotalAmt.Name = "lblTotalAmt";
            lblTotalAmt.Size = new Size(181, 46);
            lblTotalAmt.TabIndex = 0;
            lblTotalAmt.Text = "Total Due:";
            lblTotalAmt.Click += lblTotalAmt_Click;
            // 
            // pnlPayLeft
            // 
            pnlPayLeft.Controls.Add(guna2TextBox1);
            pnlPayLeft.Controls.Add(lblCashTend);
            pnlPayLeft.Controls.Add(lblQuick);
            pnlPayLeft.Controls.Add(guna2Button5);
            pnlPayLeft.Controls.Add(guna2Button4);
            pnlPayLeft.Controls.Add(guna2Button3);
            pnlPayLeft.Controls.Add(guna2Button2);
            pnlPayLeft.Controls.Add(lblSummary);
            pnlPayLeft.Controls.Add(pnlSummary);
            pnlPayLeft.Dock = DockStyle.Fill;
            pnlPayLeft.Location = new Point(0, 0);
            pnlPayLeft.Name = "pnlPayLeft";
            pnlPayLeft.Size = new Size(1320, 1001);
            pnlPayLeft.TabIndex = 1;
            pnlPayLeft.Paint += pnlPayLeft_Paint;
            // 
            // guna2TextBox1
            // 
            guna2TextBox1.BorderColor = Color.FromArgb(212, 184, 150);
            guna2TextBox1.BorderRadius = 10;
            guna2TextBox1.BorderThickness = 3;
            guna2TextBox1.CustomizableEdges = customizableEdges5;
            guna2TextBox1.DefaultText = "";
            guna2TextBox1.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            guna2TextBox1.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            guna2TextBox1.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox1.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox1.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2TextBox1.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox1.Location = new Point(69, 702);
            guna2TextBox1.Margin = new Padding(4, 6, 4, 6);
            guna2TextBox1.Name = "guna2TextBox1";
            guna2TextBox1.PlaceholderText = "Enter Amount";
            guna2TextBox1.SelectedText = "";
            guna2TextBox1.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2TextBox1.Size = new Size(1182, 62);
            guna2TextBox1.TabIndex = 9;
            guna2TextBox1.TextChanged += guna2TextBox1_TextChanged;
            // 
            // lblCashTend
            // 
            lblCashTend.AutoSize = true;
            lblCashTend.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCashTend.ForeColor = Color.FromArgb(111, 77, 56);
            lblCashTend.Location = new Point(58, 634);
            lblCashTend.Name = "lblCashTend";
            lblCashTend.Size = new Size(206, 38);
            lblCashTend.TabIndex = 8;
            lblCashTend.Text = "Cash Tendered";
            lblCashTend.Click += lblCashTend_Click;
            // 
            // lblQuick
            // 
            lblQuick.AutoSize = true;
            lblQuick.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblQuick.ForeColor = Color.FromArgb(111, 77, 56);
            lblQuick.Location = new Point(58, 467);
            lblQuick.Name = "lblQuick";
            lblQuick.Size = new Size(161, 38);
            lblQuick.TabIndex = 7;
            lblQuick.Text = "Quick Cash";
            lblQuick.Click += lblQuick_Click;
            // 
            // guna2Button5
            // 
            guna2Button5.BorderColor = Color.FromArgb(212, 184, 150);
            guna2Button5.BorderRadius = 10;
            guna2Button5.BorderThickness = 3;
            guna2Button5.CustomizableEdges = customizableEdges7;
            guna2Button5.DisabledState.BorderColor = Color.DarkGray;
            guna2Button5.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button5.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button5.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button5.FillColor = Color.FromArgb(250, 246, 243);
            guna2Button5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2Button5.ForeColor = Color.FromArgb(107, 79, 58);
            guna2Button5.Location = new Point(979, 532);
            guna2Button5.Name = "guna2Button5";
            guna2Button5.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2Button5.Size = new Size(272, 52);
            guna2Button5.TabIndex = 6;
            guna2Button5.Text = "Exact";
            guna2Button5.Click += guna2Button5_Click;
            // 
            // guna2Button4
            // 
            guna2Button4.BorderColor = Color.FromArgb(212, 184, 150);
            guna2Button4.BorderRadius = 10;
            guna2Button4.BorderThickness = 3;
            guna2Button4.CustomizableEdges = customizableEdges9;
            guna2Button4.DisabledState.BorderColor = Color.DarkGray;
            guna2Button4.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button4.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button4.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button4.FillColor = Color.FromArgb(250, 246, 243);
            guna2Button4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2Button4.ForeColor = Color.FromArgb(107, 79, 58);
            guna2Button4.Location = new Point(669, 532);
            guna2Button4.Name = "guna2Button4";
            guna2Button4.ShadowDecoration.CustomizableEdges = customizableEdges10;
            guna2Button4.Size = new Size(272, 52);
            guna2Button4.TabIndex = 5;
            guna2Button4.Text = "1000";
            guna2Button4.Click += guna2Button4_Click;
            // 
            // guna2Button3
            // 
            guna2Button3.BorderColor = Color.FromArgb(212, 184, 150);
            guna2Button3.BorderRadius = 10;
            guna2Button3.BorderThickness = 3;
            guna2Button3.CustomizableEdges = customizableEdges11;
            guna2Button3.DisabledState.BorderColor = Color.DarkGray;
            guna2Button3.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button3.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button3.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button3.FillColor = Color.FromArgb(250, 246, 243);
            guna2Button3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2Button3.ForeColor = Color.FromArgb(107, 79, 58);
            guna2Button3.Location = new Point(365, 532);
            guna2Button3.Name = "guna2Button3";
            guna2Button3.ShadowDecoration.CustomizableEdges = customizableEdges12;
            guna2Button3.Size = new Size(272, 52);
            guna2Button3.TabIndex = 4;
            guna2Button3.Text = "500";
            guna2Button3.Click += guna2Button3_Click;
            // 
            // guna2Button2
            // 
            guna2Button2.BorderColor = Color.FromArgb(212, 184, 150);
            guna2Button2.BorderRadius = 10;
            guna2Button2.BorderThickness = 3;
            guna2Button2.CustomizableEdges = customizableEdges13;
            guna2Button2.DisabledState.BorderColor = Color.DarkGray;
            guna2Button2.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button2.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button2.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button2.FillColor = Color.FromArgb(250, 246, 243);
            guna2Button2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2Button2.ForeColor = Color.FromArgb(107, 79, 58);
            guna2Button2.Location = new Point(58, 532);
            guna2Button2.Name = "guna2Button2";
            guna2Button2.ShadowDecoration.CustomizableEdges = customizableEdges14;
            guna2Button2.Size = new Size(272, 52);
            guna2Button2.TabIndex = 3;
            guna2Button2.Text = "100";
            guna2Button2.Click += guna2Button2_Click;
            // 
            // lblSummary
            // 
            lblSummary.AutoSize = true;
            lblSummary.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSummary.ForeColor = Color.FromArgb(111, 77, 56);
            lblSummary.Location = new Point(47, 49);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(275, 46);
            lblSummary.TabIndex = 1;
            lblSummary.Text = "Order Summary";
            lblSummary.Click += lblSummary_Click;
            // 
            // pnlSummary
            // 
            pnlSummary.AutoScroll = true;
            pnlSummary.BorderStyle = BorderStyle.FixedSingle;
            pnlSummary.Location = new Point(58, 112);
            pnlSummary.Name = "pnlSummary";
            pnlSummary.Size = new Size(1193, 316);
            pnlSummary.TabIndex = 0;
            pnlSummary.Paint += pnlSummary_Paint;
            // 
            // UC_Payment
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(250, 246, 243);
            Controls.Add(pnlPayLeft);
            Controls.Add(pnlPayRight);
            Enabled = false;
            Name = "UC_Payment";
            Size = new Size(1920, 1001);
            pnlPayRight.ResumeLayout(false);
            pnlPayRight.PerformLayout();
            pnlPayLeft.ResumeLayout(false);
            pnlPayLeft.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlPayRight;
        private Label lblTotalAmt;
        private Label lblChangeAmt;
        private Guna.UI2.WinForms.Guna2Button btnConfirm;
        private Guna.UI2.WinForms.Guna2Button btnBack;
        private Panel pnlPayLeft;
        private Panel pnlSummary;
        private Label lblSummary;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
        private Label lblCashTend;
        private Label lblQuick;
        private Guna.UI2.WinForms.Guna2Button guna2Button5;
        private Guna.UI2.WinForms.Guna2Button guna2Button4;
        private Guna.UI2.WinForms.Guna2Button guna2Button3;
    }
}
