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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            InventoryItemNameLbl = new Label();
            label1 = new Label();
            IncreaseBtn = new Button();
            DecreaseBtn = new Button();
            guna2Panel1.SuspendLayout();
            SuspendLayout();
            // 
            // guna2Panel1
            // 
            guna2Panel1.BorderColor = Color.DimGray;
            guna2Panel1.BorderRadius = 17;
            guna2Panel1.BorderThickness = 2;
            guna2Panel1.Controls.Add(DecreaseBtn);
            guna2Panel1.Controls.Add(IncreaseBtn);
            guna2Panel1.Controls.Add(label1);
            guna2Panel1.Controls.Add(InventoryItemNameLbl);
            guna2Panel1.CustomizableEdges = customizableEdges1;
            guna2Panel1.Location = new Point(3, 3);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Panel1.Size = new Size(639, 61);
            guna2Panel1.TabIndex = 0;
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
            // label1
            // 
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlDarkDark;
            label1.Location = new Point(382, 13);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.Yes;
            label1.Size = new Size(154, 31);
            label1.TabIndex = 4;
            label1.Text = "00.00";
            // 
            // IncreaseBtn
            // 
            IncreaseBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            IncreaseBtn.Location = new Point(542, 13);
            IncreaseBtn.Name = "IncreaseBtn";
            IncreaseBtn.Size = new Size(31, 31);
            IncreaseBtn.TabIndex = 5;
            IncreaseBtn.Text = "+";
            IncreaseBtn.UseVisualStyleBackColor = true;
            IncreaseBtn.Click += IncreaseBtn_Click;
            // 
            // DecreaseBtn
            // 
            DecreaseBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DecreaseBtn.Location = new Point(579, 13);
            DecreaseBtn.Name = "DecreaseBtn";
            DecreaseBtn.Size = new Size(31, 31);
            DecreaseBtn.TabIndex = 6;
            DecreaseBtn.Text = "-";
            DecreaseBtn.UseVisualStyleBackColor = true;
            DecreaseBtn.Click += DecreaseBtn_Click;
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
        private Label label1;
        private Label InventoryItemNameLbl;
        private Button DecreaseBtn;
        private Button IncreaseBtn;
    }
}
