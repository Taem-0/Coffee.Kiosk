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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label1 = new Label();
            TimeLineDropDown = new Guna.UI2.WinForms.Guna2ComboBox();
            TimeLineLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            DropDownContainer = new Guna.UI2.WinForms.Guna2ContainerControl();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            EmployeeView = new Guna.UI2.WinForms.Guna2DataGridView();
            EmpName = new DataGridViewTextBoxColumn();
            JobTitle = new DataGridViewTextBoxColumn();
            Shift = new DataGridViewTextBoxColumn();
            PhoneNumber = new DataGridViewTextBoxColumn();
            EmploymentType = new DataGridViewTextBoxColumn();
            AddEmployeeButton = new Guna.UI2.WinForms.Guna2Button();
            DropDownContainer.SuspendLayout();
            guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)EmployeeView).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.Location = new Point(17, 77);
            label1.Name = "label1";
            label1.Size = new Size(175, 48);
            label1.TabIndex = 5;
            label1.Text = "Accounts";
            // 
            // TimeLineDropDown
            // 
            TimeLineDropDown.AutoRoundedCorners = true;
            TimeLineDropDown.BackColor = Color.Brown;
            TimeLineDropDown.BorderColor = Color.Brown;
            TimeLineDropDown.BorderRadius = 17;
            TimeLineDropDown.BorderThickness = 0;
            TimeLineDropDown.CustomizableEdges = customizableEdges1;
            TimeLineDropDown.DrawMode = DrawMode.OwnerDrawFixed;
            TimeLineDropDown.DropDownStyle = ComboBoxStyle.DropDownList;
            TimeLineDropDown.FillColor = Color.Brown;
            TimeLineDropDown.FocusedColor = Color.FromArgb(94, 148, 255);
            TimeLineDropDown.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            TimeLineDropDown.FocusedState.FillColor = Color.Transparent;
            TimeLineDropDown.Font = new Font("Segoe UI", 10F);
            TimeLineDropDown.ForeColor = Color.White;
            TimeLineDropDown.HoverState.BorderColor = Color.Transparent;
            TimeLineDropDown.HoverState.FillColor = Color.Transparent;
            TimeLineDropDown.ItemHeight = 30;
            TimeLineDropDown.Items.AddRange(new object[] { "This day", "This month", "This year" });
            TimeLineDropDown.ItemsAppearance.SelectedFont = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TimeLineDropDown.Location = new Point(79, 5);
            TimeLineDropDown.Name = "TimeLineDropDown";
            TimeLineDropDown.ShadowDecoration.CustomizableEdges = customizableEdges2;
            TimeLineDropDown.Size = new Size(154, 36);
            TimeLineDropDown.StartIndex = 0;
            TimeLineDropDown.TabIndex = 2;
            // 
            // TimeLineLabel
            // 
            TimeLineLabel.BackColor = Color.Brown;
            TimeLineLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TimeLineLabel.ForeColor = Color.White;
            TimeLineLabel.Location = new Point(269, 90);
            TimeLineLabel.Name = "TimeLineLabel";
            TimeLineLabel.Size = new Size(54, 27);
            TimeLineLabel.TabIndex = 6;
            TimeLineLabel.Text = "Show:";
            // 
            // DropDownContainer
            // 
            DropDownContainer.AutoRoundedCorners = true;
            DropDownContainer.BackColor = SystemColors.Control;
            DropDownContainer.Controls.Add(TimeLineDropDown);
            DropDownContainer.CustomizableEdges = customizableEdges3;
            DropDownContainer.FillColor = Color.Brown;
            DropDownContainer.ForeColor = Color.Cornsilk;
            DropDownContainer.Location = new Point(250, 81);
            DropDownContainer.Name = "DropDownContainer";
            DropDownContainer.ShadowDecoration.CustomizableEdges = customizableEdges4;
            DropDownContainer.Size = new Size(251, 45);
            DropDownContainer.TabIndex = 7;
            DropDownContainer.Text = "DropDownContainer";
            // 
            // guna2Panel1
            // 
            guna2Panel1.Controls.Add(guna2TextBox1);
            guna2Panel1.CustomizableEdges = customizableEdges7;
            guna2Panel1.Dock = DockStyle.Top;
            guna2Panel1.Location = new Point(0, 0);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2Panel1.Size = new Size(1909, 74);
            guna2Panel1.TabIndex = 9;
            // 
            // guna2TextBox1
            // 
            guna2TextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            guna2TextBox1.AutoRoundedCorners = true;
            guna2TextBox1.CustomizableEdges = customizableEdges5;
            guna2TextBox1.DefaultText = "";
            guna2TextBox1.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            guna2TextBox1.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            guna2TextBox1.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox1.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox1.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox1.Font = new Font("Segoe UI", 9F);
            guna2TextBox1.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox1.Location = new Point(1604, 12);
            guna2TextBox1.Margin = new Padding(4, 5, 4, 5);
            guna2TextBox1.Name = "guna2TextBox1";
            guna2TextBox1.PlaceholderText = "Search";
            guna2TextBox1.SelectedText = "";
            guna2TextBox1.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2TextBox1.Size = new Size(289, 51);
            guna2TextBox1.TabIndex = 10;
            // 
            // EmployeeView
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            EmployeeView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            EmployeeView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            EmployeeView.ColumnHeadersHeight = 40;
            EmployeeView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            EmployeeView.Columns.AddRange(new DataGridViewColumn[] { EmpName, JobTitle, Shift, PhoneNumber, EmploymentType });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            EmployeeView.DefaultCellStyle = dataGridViewCellStyle3;
            EmployeeView.GridColor = Color.FromArgb(231, 229, 255);
            EmployeeView.Location = new Point(17, 158);
            EmployeeView.Name = "EmployeeView";
            EmployeeView.RowHeadersVisible = false;
            EmployeeView.RowHeadersWidth = 62;
            EmployeeView.Size = new Size(1876, 803);
            EmployeeView.TabIndex = 8;
            EmployeeView.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            EmployeeView.ThemeStyle.AlternatingRowsStyle.Font = null;
            EmployeeView.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            EmployeeView.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            EmployeeView.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            EmployeeView.ThemeStyle.BackColor = Color.White;
            EmployeeView.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            EmployeeView.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            EmployeeView.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            EmployeeView.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            EmployeeView.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            EmployeeView.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            EmployeeView.ThemeStyle.HeaderStyle.Height = 40;
            EmployeeView.ThemeStyle.ReadOnly = false;
            EmployeeView.ThemeStyle.RowsStyle.BackColor = Color.White;
            EmployeeView.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            EmployeeView.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            EmployeeView.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            EmployeeView.ThemeStyle.RowsStyle.Height = 33;
            EmployeeView.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            EmployeeView.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // EmpName
            // 
            EmpName.HeaderText = "Full Name";
            EmpName.MinimumWidth = 8;
            EmpName.Name = "EmpName";
            // 
            // JobTitle
            // 
            JobTitle.HeaderText = "Job Title";
            JobTitle.MinimumWidth = 8;
            JobTitle.Name = "JobTitle";
            // 
            // Shift
            // 
            Shift.HeaderText = "Shift";
            Shift.MinimumWidth = 8;
            Shift.Name = "Shift";
            // 
            // PhoneNumber
            // 
            PhoneNumber.HeaderText = "Phone";
            PhoneNumber.MinimumWidth = 8;
            PhoneNumber.Name = "PhoneNumber";
            // 
            // EmploymentType
            // 
            EmploymentType.HeaderText = "Employment Type";
            EmploymentType.MinimumWidth = 8;
            EmploymentType.Name = "EmploymentType";
            // 
            // AddEmployeeButton
            // 
            AddEmployeeButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            AddEmployeeButton.BorderRadius = 15;
            AddEmployeeButton.CustomizableEdges = customizableEdges9;
            AddEmployeeButton.DisabledState.BorderColor = Color.DarkGray;
            AddEmployeeButton.DisabledState.CustomBorderColor = Color.DarkGray;
            AddEmployeeButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            AddEmployeeButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            AddEmployeeButton.Font = new Font("Segoe UI", 9F);
            AddEmployeeButton.ForeColor = Color.White;
            AddEmployeeButton.Location = new Point(1642, 81);
            AddEmployeeButton.Name = "AddEmployeeButton";
            AddEmployeeButton.ShadowDecoration.CustomizableEdges = customizableEdges10;
            AddEmployeeButton.Size = new Size(251, 45);
            AddEmployeeButton.TabIndex = 10;
            AddEmployeeButton.Text = "Add Employee";
            AddEmployeeButton.Click += AddEmployeeButton_Click;
            // 
            // EmployeesControl
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(AddEmployeeButton);
            Controls.Add(EmployeeView);
            Controls.Add(guna2Panel1);
            Controls.Add(TimeLineLabel);
            Controls.Add(DropDownContainer);
            Controls.Add(label1);
            Name = "EmployeesControl";
            Size = new Size(1909, 1058);
            DropDownContainer.ResumeLayout(false);
            guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)EmployeeView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox TimeLineDropDown;
        private Guna.UI2.WinForms.Guna2HtmlLabel TimeLineLabel;
        private Guna.UI2.WinForms.Guna2ContainerControl DropDownContainer;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
        private Guna.UI2.WinForms.Guna2DataGridView EmployeeView;
        private DataGridViewTextBoxColumn EmpName;
        private DataGridViewTextBoxColumn JobTitle;
        private DataGridViewTextBoxColumn Shift;
        private DataGridViewTextBoxColumn PhoneNumber;
        private DataGridViewTextBoxColumn EmploymentType;
        private Guna.UI2.WinForms.Guna2Button AddEmployeeButton;
    }
}