namespace Coffee.Kiosk.CMS.Forms.OrderingSystemTab.UserControls
{
    partial class ProductRecipes
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            DecreaseBtn = new Button();
            IncreaseBtn = new Button();
            UnitLbl = new Label();
            InventoryItemNameLbl = new Label();
            guna2Panel1.SuspendLayout();
            SuspendLayout();
            // 
            // guna2Panel1
            // 
            guna2Panel1.BorderColor = Color.DimGray;
            guna2Panel1.BorderRadius = 17;
            guna2Panel1.BorderThickness = 2;
            guna2Panel1.Controls.Add(guna2TextBox1);
            guna2Panel1.Controls.Add(DecreaseBtn);
            guna2Panel1.Controls.Add(IncreaseBtn);
            guna2Panel1.Controls.Add(UnitLbl);
            guna2Panel1.Controls.Add(InventoryItemNameLbl);
            guna2Panel1.CustomizableEdges = customizableEdges7;
            guna2Panel1.Location = new Point(3, 3);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2Panel1.Size = new Size(639, 61);
            guna2Panel1.TabIndex = 0;
            // 
            // guna2TextBox1
            // 
            guna2TextBox1.CustomizableEdges = customizableEdges5;
            guna2TextBox1.DefaultText = "";
            guna2TextBox1.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            guna2TextBox1.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            guna2TextBox1.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox1.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox1.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox1.Font = new Font("Segoe UI", 9F);
            guna2TextBox1.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox1.Location = new Point(392, 13);
            guna2TextBox1.Margin = new Padding(3, 4, 3, 4);
            guna2TextBox1.Name = "guna2TextBox1";
            guna2TextBox1.PlaceholderText = "";
            guna2TextBox1.SelectedText = "";
            guna2TextBox1.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2TextBox1.Size = new Size(144, 31);
            guna2TextBox1.TabIndex = 7;
            guna2TextBox1.TextChanged += guna2TextBox1_TextChanged;
            // 
            // DecreaseBtn
            // 
            DecreaseBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DecreaseBtn.Location = new Point(318, 13);
            DecreaseBtn.Name = "DecreaseBtn";
            DecreaseBtn.Size = new Size(31, 31);
            DecreaseBtn.TabIndex = 6;
            DecreaseBtn.Text = "-";
            DecreaseBtn.UseVisualStyleBackColor = true;
            DecreaseBtn.Click += DecreaseBtn_Click;
            // 
            // IncreaseBtn
            // 
            IncreaseBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            IncreaseBtn.Location = new Point(355, 13);
            IncreaseBtn.Name = "IncreaseBtn";
            IncreaseBtn.Size = new Size(31, 31);
            IncreaseBtn.TabIndex = 5;
            IncreaseBtn.Text = "+";
            IncreaseBtn.UseVisualStyleBackColor = true;
            IncreaseBtn.Click += IncreaseBtn_Click;
            // 
            // UnitLbl
            // 
            UnitLbl.AutoSize = true;
            UnitLbl.BackColor = Color.White;
            UnitLbl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            UnitLbl.ForeColor = SystemColors.ControlDarkDark;
            UnitLbl.Location = new Point(542, 13);
            UnitLbl.Name = "UnitLbl";
            UnitLbl.RightToLeft = RightToLeft.Yes;
            UnitLbl.Size = new Size(49, 28);
            UnitLbl.TabIndex = 4;
            UnitLbl.Text = "Unit";
            // 
            // InventoryItemNameLbl
            // 
            InventoryItemNameLbl.AutoSize = true;
            InventoryItemNameLbl.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            InventoryItemNameLbl.ForeColor = SystemColors.ControlDarkDark;
            InventoryItemNameLbl.Location = new Point(18, 13);
            InventoryItemNameLbl.Name = "InventoryItemNameLbl";
            InventoryItemNameLbl.Size = new Size(77, 31);
            InventoryItemNameLbl.TabIndex = 3;
            InventoryItemNameLbl.Text = "Name";
            // 
            // ProductRecipes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(guna2Panel1);
            Name = "ProductRecipes";
            Size = new Size(645, 66);
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Label InventoryItemNameLbl;
        private Button DecreaseBtn;
        private Button IncreaseBtn;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
        private Label UnitLbl;
    }
}
