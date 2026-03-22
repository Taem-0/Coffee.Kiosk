namespace Coffee.Kiosk.CMS.Forms.SettingsTab.SettingsUserControls
{
    partial class DepartmentCard
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
            removeButton = new Guna.UI2.WinForms.Guna2Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // removeButton
            // 
            removeButton.BorderRadius = 15;
            removeButton.CustomizableEdges = customizableEdges1;
            removeButton.DisabledState.BorderColor = Color.DarkGray;
            removeButton.DisabledState.CustomBorderColor = Color.DarkGray;
            removeButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            removeButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            removeButton.Font = new Font("Segoe UI", 9F);
            removeButton.ForeColor = Color.White;
            removeButton.Location = new Point(678, 10);
            removeButton.Name = "removeButton";
            removeButton.ShadowDecoration.CustomizableEdges = customizableEdges2;
            removeButton.Size = new Size(113, 38);
            removeButton.TabIndex = 3;
            removeButton.Text = "default";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(17, 15);
            label1.Name = "label1";
            label1.Size = new Size(109, 28);
            label1.TabIndex = 2;
            label1.Text = "Operations";
            // 
            // DepartmentCard
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(removeButton);
            Controls.Add(label1);
            Name = "DepartmentCard";
            Size = new Size(802, 58);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button removeButton;
        private Label label1;
    }
}
