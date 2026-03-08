namespace Coffee.Kiosk.CMS.Forms.InventoryTab.UserControls
{
    partial class InventoryItem
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
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            InventoryUnit = new Label();
            pictureBox1 = new PictureBox();
            InventoryName = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            EditName = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            Cancel = new ToolStripMenuItem();
            InventoryIdLbl = new Label();
            guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // guna2Panel1
            // 
            guna2Panel1.BackColor = Color.Transparent;
            guna2Panel1.BorderColor = Color.FromArgb(105, 86, 69);
            guna2Panel1.BorderRadius = 15;
            guna2Panel1.BorderThickness = 3;
            guna2Panel1.Controls.Add(InventoryIdLbl);
            guna2Panel1.Controls.Add(guna2Button1);
            guna2Panel1.Controls.Add(InventoryUnit);
            guna2Panel1.Controls.Add(pictureBox1);
            guna2Panel1.Controls.Add(InventoryName);
            guna2Panel1.CustomizableEdges = customizableEdges3;
            guna2Panel1.Location = new Point(3, 0);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.BorderRadius = 15;
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Panel1.Size = new Size(203, 270);
            guna2Panel1.TabIndex = 2;
            guna2Panel1.UseTransparentBackground = true;
            // 
            // guna2Button1
            // 
            guna2Button1.BorderRadius = 7;
            guna2Button1.CustomizableEdges = customizableEdges1;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.FillColor = Color.Transparent;
            guna2Button1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2Button1.ForeColor = Color.Black;
            guna2Button1.Image = Properties.Resources._3_dots;
            guna2Button1.ImageSize = new Size(30, 30);
            guna2Button1.Location = new Point(157, 3);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Button1.Size = new Size(43, 22);
            guna2Button1.TabIndex = 5;
            guna2Button1.Tile = true;
            guna2Button1.Click += guna2Button1_Click;
            // 
            // InventoryUnit
            // 
            InventoryUnit.AutoSize = true;
            InventoryUnit.Location = new Point(6, 241);
            InventoryUnit.Name = "InventoryUnit";
            InventoryUnit.Size = new Size(51, 20);
            InventoryUnit.TabIndex = 2;
            InventoryUnit.Text = "67 pcs";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.default_icon;
            pictureBox1.Location = new Point(12, 31);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(178, 185);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // InventoryName
            // 
            InventoryName.Font = new Font("Gill Sans Ultra Bold", 9F);
            InventoryName.Location = new Point(6, 216);
            InventoryName.Name = "InventoryName";
            InventoryName.Size = new Size(178, 25);
            InventoryName.TabIndex = 1;
            InventoryName.Text = "Inventory_Name";
            InventoryName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Font = new Font("Segoe UI Semibold", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { EditName, deleteToolStripMenuItem, Cancel });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(157, 112);
            // 
            // EditName
            // 
            EditName.Name = "EditName";
            EditName.Size = new Size(156, 36);
            EditName.Text = "Edit";
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(156, 36);
            deleteToolStripMenuItem.Text = "Delete";
            // 
            // Cancel
            // 
            Cancel.Name = "Cancel";
            Cancel.Size = new Size(156, 36);
            Cancel.Text = "Cancel";
            // 
            // InventoryIdLbl
            // 
            InventoryIdLbl.AutoSize = true;
            InventoryIdLbl.Location = new Point(12, 3);
            InventoryIdLbl.Name = "InventoryIdLbl";
            InventoryIdLbl.Size = new Size(47, 20);
            InventoryIdLbl.TabIndex = 6;
            InventoryIdLbl.Text = "ID: 67";
            // 
            // InventoryItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(guna2Panel1);
            Name = "InventoryItem";
            Size = new Size(209, 273);
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Label InventoryUnit;
        private PictureBox pictureBox1;
        private Label InventoryName;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem EditName;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem Cancel;
        private Label InventoryIdLbl;
    }
}
