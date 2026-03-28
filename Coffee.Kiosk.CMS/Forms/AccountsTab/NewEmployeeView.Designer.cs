using Coffee.Kiosk.CMS.Helpers;

namespace Coffee.Kiosk.CMS.Forms.AccountsTab
{
    partial class NewEmployeeView
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
                UIhelp.ThemeManager.ThemeChanged -= OnThemeChanged;
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
            label1 = new Label();
            employeeContainerContainer1 = new Coffee.Kiosk.CMS.Forms.AccountsTab.AccountUserControls.EmployeeContainerContainer();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.Location = new Point(14, 13);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(316, 41);
            label1.TabIndex = 2;
            label1.Text = "Employee Dashboard";
            // 
            // employeeContainerContainer1
            // 
            employeeContainerContainer1.Location = new Point(2, 56);
            employeeContainerContainer1.Margin = new Padding(2);
            employeeContainerContainer1.Name = "employeeContainerContainer1";
            employeeContainerContainer1.Size = new Size(1920, 974);
            employeeContainerContainer1.TabIndex = 3;
            employeeContainerContainer1.Load += employeeContainerContainer1_Load;
            // 
            // NewEmployeeView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(employeeContainerContainer1);
            Controls.Add(label1);
            Margin = new Padding(2);
            Name = "NewEmployeeView";
            Size = new Size(1920, 1080);
            Load += NewEmployeeView_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private AccountUserControls.EmployeeContainerContainer employeeContainerContainer1;
    }
}
