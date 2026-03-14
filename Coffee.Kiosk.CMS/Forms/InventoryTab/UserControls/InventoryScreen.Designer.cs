namespace Coffee.Kiosk.CMS.Forms.InventoryTab.UserControls
{
    partial class InventoryScreen
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
            panel1 = new Panel();
            panel2 = new Panel();
            AddMoreButton = new Guna.UI2.WinForms.Guna2Button();
            DisplayAsTableCheckBox = new Guna.UI2.WinForms.Guna2CheckBox();
            SearchTxtBox = new Guna.UI2.WinForms.Guna2TextBox();
            InventoryPanel = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(DisplayAsTableCheckBox);
            panel1.Controls.Add(SearchTxtBox);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1008, 125);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(AddMoreButton);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(882, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(126, 125);
            panel2.TabIndex = 51;
            // 
            // AddMoreButton
            // 
            AddMoreButton.CustomizableEdges = customizableEdges1;
            AddMoreButton.DisabledState.BorderColor = Color.DarkGray;
            AddMoreButton.DisabledState.CustomBorderColor = Color.DarkGray;
            AddMoreButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            AddMoreButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            AddMoreButton.FillColor = Color.Transparent;
            AddMoreButton.Font = new Font("Segoe UI", 9F);
            AddMoreButton.ForeColor = Color.White;
            AddMoreButton.Image = Properties.Resources.addMore;
            AddMoreButton.ImageSize = new Size(80, 80);
            AddMoreButton.Location = new Point(22, 26);
            AddMoreButton.Name = "AddMoreButton";
            AddMoreButton.ShadowDecoration.CustomizableEdges = customizableEdges2;
            AddMoreButton.Size = new Size(80, 80);
            AddMoreButton.TabIndex = 50;
            AddMoreButton.Click += AddMoreButton_Click;
            // 
            // DisplayAsTableCheckBox
            // 
            DisplayAsTableCheckBox.AutoSize = true;
            DisplayAsTableCheckBox.Checked = true;
            DisplayAsTableCheckBox.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
            DisplayAsTableCheckBox.CheckedState.BorderRadius = 0;
            DisplayAsTableCheckBox.CheckedState.BorderThickness = 0;
            DisplayAsTableCheckBox.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
            DisplayAsTableCheckBox.CheckState = CheckState.Checked;
            DisplayAsTableCheckBox.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            DisplayAsTableCheckBox.Location = new Point(466, 46);
            DisplayAsTableCheckBox.Name = "DisplayAsTableCheckBox";
            DisplayAsTableCheckBox.Size = new Size(193, 32);
            DisplayAsTableCheckBox.TabIndex = 49;
            DisplayAsTableCheckBox.Text = "Display as tables";
            DisplayAsTableCheckBox.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
            DisplayAsTableCheckBox.UncheckedState.BorderRadius = 0;
            DisplayAsTableCheckBox.UncheckedState.BorderThickness = 0;
            DisplayAsTableCheckBox.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
            DisplayAsTableCheckBox.CheckedChanged += DisplayAsTableCheckBox_CheckedChanged;
            // 
            // SearchTxtBox
            // 
            SearchTxtBox.CustomizableEdges = customizableEdges3;
            SearchTxtBox.DefaultText = "";
            SearchTxtBox.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            SearchTxtBox.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            SearchTxtBox.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            SearchTxtBox.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            SearchTxtBox.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            SearchTxtBox.Font = new Font("Segoe UI", 13F);
            SearchTxtBox.ForeColor = Color.Black;
            SearchTxtBox.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            SearchTxtBox.Location = new Point(33, 26);
            SearchTxtBox.Margin = new Padding(4, 6, 4, 6);
            SearchTxtBox.Name = "SearchTxtBox";
            SearchTxtBox.PlaceholderText = "Search";
            SearchTxtBox.SelectedText = "";
            SearchTxtBox.ShadowDecoration.CustomizableEdges = customizableEdges4;
            SearchTxtBox.Size = new Size(400, 71);
            SearchTxtBox.TabIndex = 48;
            SearchTxtBox.TextChanged += SearchTxtBox_TextChanged;
            // 
            // InventoryPanel
            // 
            InventoryPanel.Dock = DockStyle.Fill;
            InventoryPanel.Location = new Point(0, 125);
            InventoryPanel.Name = "InventoryPanel";
            InventoryPanel.Size = new Size(1008, 532);
            InventoryPanel.TabIndex = 50;
            // 
            // InventoryScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(InventoryPanel);
            Controls.Add(panel1);
            Name = "InventoryScreen";
            Size = new Size(1008, 657);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Guna.UI2.WinForms.Guna2CheckBox DisplayAsTableCheckBox;
        private Guna.UI2.WinForms.Guna2TextBox SearchTxtBox;
        private Panel InventoryPanel;
        private Panel panel2;
        private Guna.UI2.WinForms.Guna2Button AddMoreButton;
    }
}
