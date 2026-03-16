namespace Coffee.Kiosk.Cashier
{
    partial class UC_Receipt
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
            pnlReceipt = new Panel();
            lblAction = new Label();
            btnPrintReceipt = new Guna.UI2.WinForms.Guna2Button();
            btnNewOrder = new Guna.UI2.WinForms.Guna2Button();
            printDoc = new System.Drawing.Printing.PrintDocument();
            SuspendLayout();
            // 
            // pnlReceipt
            // 
            pnlReceipt.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            pnlReceipt.AutoScroll = true;
            pnlReceipt.BackColor = Color.White;
            pnlReceipt.BorderStyle = BorderStyle.FixedSingle;
            pnlReceipt.Location = new Point(493, 89);
            pnlReceipt.Name = "pnlReceipt";
            pnlReceipt.Size = new Size(473, 818);
            pnlReceipt.TabIndex = 0;
            pnlReceipt.Paint += pnlReceipt_Paint;
            // 
            // lblAction
            // 
            lblAction.AutoSize = true;
            lblAction.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAction.Location = new Point(1048, 111);
            lblAction.Name = "lblAction";
            lblAction.Size = new Size(115, 38);
            lblAction.TabIndex = 1;
            lblAction.Text = "Actions";
            // 
            // btnPrintReceipt
            // 
            btnPrintReceipt.BorderRadius = 10;
            btnPrintReceipt.CustomizableEdges = customizableEdges1;
            btnPrintReceipt.DisabledState.BorderColor = Color.DarkGray;
            btnPrintReceipt.DisabledState.CustomBorderColor = Color.DarkGray;
            btnPrintReceipt.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnPrintReceipt.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnPrintReceipt.FillColor = Color.FromArgb(107, 79, 58);
            btnPrintReceipt.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPrintReceipt.ForeColor = Color.White;
            btnPrintReceipt.Location = new Point(1059, 188);
            btnPrintReceipt.Name = "btnPrintReceipt";
            btnPrintReceipt.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnPrintReceipt.Size = new Size(305, 56);
            btnPrintReceipt.TabIndex = 2;
            btnPrintReceipt.Text = "Print Receipt";
            btnPrintReceipt.Click += btnPrintReceipt_Click;
            // 
            // btnNewOrder
            // 
            btnNewOrder.BorderColor = Color.FromArgb(212, 184, 150);
            btnNewOrder.BorderRadius = 10;
            btnNewOrder.BorderThickness = 8;
            btnNewOrder.CustomizableEdges = customizableEdges3;
            btnNewOrder.DisabledState.BorderColor = Color.DarkGray;
            btnNewOrder.DisabledState.CustomBorderColor = Color.DarkGray;
            btnNewOrder.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnNewOrder.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnNewOrder.FillColor = Color.Transparent;
            btnNewOrder.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNewOrder.ForeColor = Color.FromArgb(107, 79, 58);
            btnNewOrder.Location = new Point(1059, 279);
            btnNewOrder.Name = "btnNewOrder";
            btnNewOrder.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnNewOrder.Size = new Size(305, 56);
            btnNewOrder.TabIndex = 3;
            btnNewOrder.Text = "New Order";
            btnNewOrder.Click += btnNewOrder_Click;
            // 
            // UC_Receipt
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(250, 246, 243);
            Controls.Add(btnNewOrder);
            Controls.Add(btnPrintReceipt);
            Controls.Add(lblAction);
            Controls.Add(pnlReceipt);
            Name = "UC_Receipt";
            Padding = new Padding(20);
            Size = new Size(1920, 1001);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlReceipt;
        private Label lblAction;
        private Guna.UI2.WinForms.Guna2Button btnPrintReceipt;
        private Guna.UI2.WinForms.Guna2Button btnNewOrder;
        private System.Drawing.Printing.PrintDocument printDoc;
    }
}
