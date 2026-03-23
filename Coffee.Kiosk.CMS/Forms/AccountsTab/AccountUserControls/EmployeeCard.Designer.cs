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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeCard));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            employeeProfilePic = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            employeeName = new Label();
            jobTitle = new Label();
            department = new Label();
            history = new Label();
            status = new Guna.UI2.WinForms.Guna2Button();
            randoButton = new Guna.UI2.WinForms.Guna2ImageButton();
            ((System.ComponentModel.ISupportInitialize)employeeProfilePic).BeginInit();
            SuspendLayout();
            // 
            // employeeProfilePic
            // 
            employeeProfilePic.BackColor = SystemColors.ActiveCaption;
            employeeProfilePic.ImageRotate = 0F;
            employeeProfilePic.Location = new Point(30, 5);
            employeeProfilePic.Name = "employeeProfilePic";
            employeeProfilePic.ShadowDecoration.CustomizableEdges = customizableEdges5;
            employeeProfilePic.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            employeeProfilePic.Size = new Size(60, 60);
            employeeProfilePic.TabIndex = 0;
            employeeProfilePic.TabStop = false;
            // 
            // employeeName
            // 
            employeeName.AutoSize = true;
            employeeName.Font = new Font("Segoe UI", 9F);
            employeeName.Location = new Point(116, 5);
            employeeName.Name = "employeeName";
            employeeName.Size = new Size(90, 25);
            employeeName.TabIndex = 1;
            employeeName.Text = "Taeza, Rex";
            // 
            // jobTitle
            // 
            jobTitle.AutoSize = true;
            jobTitle.Font = new Font("Segoe UI", 9F);
            jobTitle.Location = new Point(490, 5);
            jobTitle.Name = "jobTitle";
            jobTitle.Size = new Size(60, 25);
            jobTitle.TabIndex = 3;
            jobTitle.Text = "Guard";
            // 
            // department
            // 
            department.AutoSize = true;
            department.Font = new Font("Segoe UI", 9F);
            department.Location = new Point(796, 5);
            department.Name = "department";
            department.Size = new Size(92, 25);
            department.TabIndex = 3;
            department.Text = "Rev. Army";
            // 
            // history
            // 
            history.AutoSize = true;
            history.Font = new Font("Segoe UI", 9F);
            history.Location = new Point(1102, 5);
            history.Name = "history";
            history.Size = new Size(106, 50);
            history.TabIndex = 4;
            history.Text = "Last shift In\r\n09/11/2006";
            // 
            // status
            // 
            status.BorderRadius = 20;
            status.CustomizableEdges = customizableEdges6;
            status.DisabledState.BorderColor = Color.DarkGray;
            status.DisabledState.CustomBorderColor = Color.DarkGray;
            status.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            status.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            status.FillColor = Color.GreenYellow;
            status.Font = new Font("Segoe UI", 9F);
            status.ForeColor = Color.White;
            status.Location = new Point(1397, 5);
            status.Name = "status";
            status.ShadowDecoration.CustomizableEdges = customizableEdges7;
            status.Size = new Size(235, 41);
            status.TabIndex = 5;
            status.Text = "Current Employee";
            // 
            // randoButton
            // 
            randoButton.CheckedState.ImageSize = new Size(64, 64);
            randoButton.HoverState.ImageSize = new Size(64, 64);
            randoButton.Image = (Image)resources.GetObject("randoButton.Image");
            randoButton.ImageOffset = new Point(0, 0);
            randoButton.ImageRotate = 0F;
            randoButton.Location = new Point(1727, 15);
            randoButton.Name = "randoButton";
            randoButton.PressedState.ImageSize = new Size(64, 64);
            randoButton.ShadowDecoration.CustomizableEdges = customizableEdges8;
            randoButton.Size = new Size(40, 40);
            randoButton.TabIndex = 6;
            // 
            // EmployeeCard
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(randoButton);
            Controls.Add(status);
            Controls.Add(history);
            Controls.Add(department);
            Controls.Add(jobTitle);
            Controls.Add(employeeName);
            Controls.Add(employeeProfilePic);
            Name = "EmployeeCard";
            Size = new Size(1845, 70);
            ((System.ComponentModel.ISupportInitialize)employeeProfilePic).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2CirclePictureBox employeeProfilePic;
        private Label employeeName;
        private Label jobTitle;
        private Label department;
        private Label history;
        private Guna.UI2.WinForms.Guna2Button status;
        private Guna.UI2.WinForms.Guna2ImageButton randoButton;
    }
}
