namespace Coffee.Kiosk.CMS.Forms.AccountsTab.AccountUserControls
{
    partial class EmployeeCard
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
            employeeProfilePic = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            employeeName = new Label();
            jobTitle = new Label();
            department = new Label();
            status = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)employeeProfilePic).BeginInit();
            SuspendLayout();
            // 
            // employeeProfilePic
            // 
            employeeProfilePic.BackColor = SystemColors.ActiveCaption;
            employeeProfilePic.ImageRotate = 0F;
            employeeProfilePic.Location = new Point(24, 4);
            employeeProfilePic.Margin = new Padding(2);
            employeeProfilePic.Name = "employeeProfilePic";
            employeeProfilePic.ShadowDecoration.CustomizableEdges = customizableEdges1;
            employeeProfilePic.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            employeeProfilePic.Size = new Size(48, 48);
            employeeProfilePic.TabIndex = 0;
            employeeProfilePic.TabStop = false;
            // 
            // employeeName
            // 
            employeeName.AutoSize = true;
            employeeName.Font = new Font("Segoe UI", 9F);
            employeeName.Location = new Point(93, 4);
            employeeName.Margin = new Padding(2, 0, 2, 0);
            employeeName.Name = "employeeName";
            employeeName.Size = new Size(77, 20);
            employeeName.TabIndex = 1;
            employeeName.Text = "Taeza, Rex";
            // 
            // jobTitle
            // 
            jobTitle.AutoSize = true;
            jobTitle.Font = new Font("Segoe UI", 9F);
            jobTitle.Location = new Point(569, 4);
            jobTitle.Margin = new Padding(2, 0, 2, 0);
            jobTitle.Name = "jobTitle";
            jobTitle.Size = new Size(49, 20);
            jobTitle.TabIndex = 3;
            jobTitle.Text = "Guard";
            // 
            // department
            // 
            department.AutoSize = true;
            department.Font = new Font("Segoe UI", 9F);
            department.Location = new Point(922, 4);
            department.Margin = new Padding(2, 0, 2, 0);
            department.Name = "department";
            department.Size = new Size(75, 20);
            department.TabIndex = 3;
            department.Text = "Rev. Army";
            // 
            // status
            // 
            status.BorderRadius = 20;
            status.CustomizableEdges = customizableEdges2;
            status.DisabledState.BorderColor = Color.DarkGray;
            status.DisabledState.CustomBorderColor = Color.DarkGray;
            status.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            status.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            status.FillColor = Color.GreenYellow;
            status.Font = new Font("Segoe UI", 9F);
            status.ForeColor = Color.White;
            status.Location = new Point(1513, 4);
            status.Margin = new Padding(2);
            status.Name = "status";
            status.ShadowDecoration.CustomizableEdges = customizableEdges3;
            status.Size = new Size(188, 33);
            status.TabIndex = 5;
            status.Text = "Current Employee";
            // 
            // EmployeeCard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(status);
            Controls.Add(department);
            Controls.Add(jobTitle);
            Controls.Add(employeeName);
            Controls.Add(employeeProfilePic);
            Margin = new Padding(2);
            Name = "EmployeeCard";
            Size = new Size(1920, 56);
            ((System.ComponentModel.ISupportInitialize)employeeProfilePic).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2CirclePictureBox employeeProfilePic;
        private Label employeeName;
        private Label jobTitle;
        private Label department;
        private Guna.UI2.WinForms.Guna2Button status;
    }
}
