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
            panel1 = new Panel();
            guna2TextBox2 = new Guna.UI2.WinForms.Guna2TextBox();
            DisplayAsTableCheckBox = new Guna.UI2.WinForms.Guna2CheckBox();
            InventoryFlow = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(DisplayAsTableCheckBox);
            panel1.Controls.Add(guna2TextBox2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1008, 125);
            panel1.TabIndex = 0;
            // 
            // guna2TextBox2
            // 
            guna2TextBox2.CustomizableEdges = customizableEdges1;
            guna2TextBox2.DefaultText = "";
            guna2TextBox2.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            guna2TextBox2.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            guna2TextBox2.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox2.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox2.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox2.Font = new Font("Segoe UI", 13F);
            guna2TextBox2.ForeColor = Color.Black;
            guna2TextBox2.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox2.Location = new Point(33, 26);
            guna2TextBox2.Margin = new Padding(4, 6, 4, 6);
            guna2TextBox2.Name = "guna2TextBox2";
            guna2TextBox2.PlaceholderText = "Search";
            guna2TextBox2.SelectedText = "";
            guna2TextBox2.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2TextBox2.Size = new Size(400, 71);
            guna2TextBox2.TabIndex = 48;
            // 
            // DisplayAsTableCheckBox
            // 
            DisplayAsTableCheckBox.AutoSize = true;
            DisplayAsTableCheckBox.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
            DisplayAsTableCheckBox.CheckedState.BorderRadius = 0;
            DisplayAsTableCheckBox.CheckedState.BorderThickness = 0;
            DisplayAsTableCheckBox.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
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
            // 
            // InventoryFlow
            // 
            InventoryFlow.Dock = DockStyle.Fill;
            InventoryFlow.Location = new Point(0, 125);
            InventoryFlow.Name = "InventoryFlow";
            InventoryFlow.Size = new Size(1008, 532);
            InventoryFlow.TabIndex = 50;
            // 
            // InventoryScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(InventoryFlow);
            Controls.Add(panel1);
            Name = "InventoryScreen";
            Size = new Size(1008, 657);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Guna.UI2.WinForms.Guna2CheckBox DisplayAsTableCheckBox;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox2;
        private Panel InventoryFlow;
    }
}
