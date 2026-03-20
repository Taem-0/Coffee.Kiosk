namespace Coffee.Kiosk.CMS.Forms.OrderingSystemTab.UserControls
{
    partial class RecipeItem
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
            InventoryItemBtn = new Guna.UI2.WinForms.Guna2Button();
            SuspendLayout();
            // 
            // InventoryItemBtn
            // 
            InventoryItemBtn.BorderColor = Color.DimGray;
            InventoryItemBtn.BorderRadius = 10;
            InventoryItemBtn.BorderThickness = 2;
            InventoryItemBtn.CustomizableEdges = customizableEdges1;
            InventoryItemBtn.DefaultAutoSize = true;
            InventoryItemBtn.DisabledState.BorderColor = Color.DarkGray;
            InventoryItemBtn.DisabledState.CustomBorderColor = Color.DarkGray;
            InventoryItemBtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            InventoryItemBtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            InventoryItemBtn.FillColor = Color.FromArgb(224, 224, 224);
            InventoryItemBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            InventoryItemBtn.ForeColor = Color.DimGray;
            InventoryItemBtn.Location = new Point(6, 8);
            InventoryItemBtn.MinimumSize = new Size(238, 49);
            InventoryItemBtn.Name = "InventoryItemBtn";
            InventoryItemBtn.ShadowDecoration.CustomizableEdges = customizableEdges2;
            InventoryItemBtn.Size = new Size(238, 49);
            InventoryItemBtn.TabIndex = 17;
            InventoryItemBtn.Text = "inventoryItem";
            InventoryItemBtn.Click += InventoryItemBtn_Click;
            // 
            // RecipeItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(InventoryItemBtn);
            Name = "RecipeItem";
            Padding = new Padding(3);
            Size = new Size(250, 69);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button InventoryItemBtn;
    }
}
