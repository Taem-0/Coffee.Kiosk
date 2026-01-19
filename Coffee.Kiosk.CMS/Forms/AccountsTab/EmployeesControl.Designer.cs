namespace Coffee.Kiosk.CMS
{
    partial class EmployeesControl
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
            ListViewItem listViewItem1 = new ListViewItem("");
            EmployeeListView = new MaterialSkin.Controls.MaterialListView();
            FullName = new ColumnHeader();
            PhoneNumber = new ColumnHeader();
            EmailAddress = new ColumnHeader();
            EmergencyNumber = new ColumnHeader();
            JobTitle = new ColumnHeader();
            Salary = new ColumnHeader();
            AccountStatus = new ColumnHeader();
            addEmpButton = new Button();
            SuspendLayout();
            // 
            // EmployeeListView
            // 
            EmployeeListView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            EmployeeListView.AutoSizeTable = false;
            EmployeeListView.BackColor = Color.FromArgb(255, 255, 255);
            EmployeeListView.BorderStyle = BorderStyle.None;
            EmployeeListView.Columns.AddRange(new ColumnHeader[] { FullName, PhoneNumber, EmailAddress, EmergencyNumber, JobTitle, Salary, AccountStatus });
            EmployeeListView.Depth = 0;
            EmployeeListView.FullRowSelect = true;
            EmployeeListView.Items.AddRange(new ListViewItem[] { listViewItem1 });
            EmployeeListView.Location = new Point(0, 55);
            EmployeeListView.MinimumSize = new Size(200, 100);
            EmployeeListView.MouseLocation = new Point(-1, -1);
            EmployeeListView.MouseState = MaterialSkin.MouseState.OUT;
            EmployeeListView.Name = "EmployeeListView";
            EmployeeListView.OwnerDraw = true;
            EmployeeListView.Size = new Size(880, 427);
            EmployeeListView.TabIndex = 3;
            EmployeeListView.UseCompatibleStateImageBehavior = false;
            EmployeeListView.View = View.Details;
            EmployeeListView.Resize += EmployeeListView_Resize;
            // 
            // FullName
            // 
            FullName.Text = "Full Name";
            FullName.Width = 200;
            // 
            // PhoneNumber
            // 
            PhoneNumber.Text = "Phone Number";
            PhoneNumber.Width = 200;
            // 
            // EmailAddress
            // 
            EmailAddress.Text = "Email Address";
            EmailAddress.Width = 200;
            // 
            // EmergencyNumber
            // 
            EmergencyNumber.Text = "Emergency Contact";
            // 
            // JobTitle
            // 
            JobTitle.Text = "Job Title";
            // 
            // Salary
            // 
            Salary.Text = "Salary";
            // 
            // AccountStatus
            // 
            AccountStatus.Text = "Account Status";
            // 
            // addEmpButton
            // 
            addEmpButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addEmpButton.Location = new Point(718, 7);
            addEmpButton.Name = "addEmpButton";
            addEmpButton.Size = new Size(158, 35);
            addEmpButton.TabIndex = 2;
            addEmpButton.Text = "+ Add Employee";
            addEmpButton.UseVisualStyleBackColor = true;
            addEmpButton.Click += addEmpButton_Click;
            // 
            // EmployeesControl
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(EmployeeListView);
            Controls.Add(addEmpButton);
            Name = "EmployeesControl";
            Size = new Size(880, 482);
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialListView EmployeeListView;
        private Button addEmpButton;
        private ColumnHeader FullName;
        private ColumnHeader PhoneNumber;
        private ColumnHeader EmailAddress;
        private ColumnHeader EmergencyNumber;
        private ColumnHeader JobTitle;
        private ColumnHeader Salary;
        private ColumnHeader AccountStatus;
    }
}
