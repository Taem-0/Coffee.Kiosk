namespace Coffee.Kiosk.Cashier
{
    partial class UC_OrderRow
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
            btnMinus = new Guna.UI2.WinForms.Guna2Button();
            lblItemName = new Label();
            lblQty = new Label();
            btnPlus = new Guna.UI2.WinForms.Guna2Button();
            lblSubtotal = new Label();
            SuspendLayout();
            // 
            // btnMinus
            // 
            btnMinus.BackColor = Color.Transparent;
            btnMinus.BorderRadius = 4;
            btnMinus.CustomizableEdges = customizableEdges1;
            btnMinus.DisabledState.BorderColor = Color.DarkGray;
            btnMinus.DisabledState.CustomBorderColor = Color.DarkGray;
            btnMinus.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnMinus.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnMinus.FillColor = Color.FromArgb(107, 79, 58);
            btnMinus.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMinus.ForeColor = Color.White;
            btnMinus.Location = new Point(192, 6);
            btnMinus.Name = "btnMinus";
            btnMinus.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnMinus.Size = new Size(22, 22);
            btnMinus.TabIndex = 0;
            btnMinus.Text = "-";
            // 
            // lblItemName
            // 
            lblItemName.AutoSize = true;
            lblItemName.Location = new Point(6, 7);
            lblItemName.Name = "lblItemName";
            lblItemName.Size = new Size(39, 20);
            lblItemName.TabIndex = 1;
            lblItemName.Text = "Item";
            // 
            // lblQty
            // 
            lblQty.AutoSize = true;
            lblQty.Location = new Point(224, 7);
            lblQty.Name = "lblQty";
            lblQty.Size = new Size(32, 20);
            lblQty.TabIndex = 2;
            lblQty.Text = "Qty";
            // 
            // btnPlus
            // 
            btnPlus.BackColor = Color.Transparent;
            btnPlus.BorderRadius = 4;
            btnPlus.CustomizableEdges = customizableEdges3;
            btnPlus.DisabledState.BorderColor = Color.DarkGray;
            btnPlus.DisabledState.CustomBorderColor = Color.DarkGray;
            btnPlus.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnPlus.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnPlus.FillColor = Color.FromArgb(107, 79, 58);
            btnPlus.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPlus.ForeColor = Color.White;
            btnPlus.Location = new Point(265, 6);
            btnPlus.Name = "btnPlus";
            btnPlus.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnPlus.Size = new Size(22, 22);
            btnPlus.TabIndex = 3;
            btnPlus.Text = "+";
            btnPlus.Click += guna2Button1_Click;
            // 
            // lblSubtotal
            // 
            lblSubtotal.AutoSize = true;
            lblSubtotal.Location = new Point(304, 7);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new Size(41, 20);
            lblSubtotal.TabIndex = 4;
            lblSubtotal.Text = "Price";
            // 
            // UC_OrderRow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(lblSubtotal);
            Controls.Add(btnPlus);
            Controls.Add(lblQty);
            Controls.Add(lblItemName);
            Controls.Add(btnMinus);
            Name = "UC_OrderRow";
            Size = new Size(372, 34);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnMinus;
        private Label lblItemName;
        private Label lblQty;
        private Guna.UI2.WinForms.Guna2Button btnPlus;
        private Label lblSubtotal;
    }
}
