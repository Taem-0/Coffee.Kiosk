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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            label1 = new Label();
            guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            employeeDataGrid = new Guna.UI2.WinForms.Guna2DataGridView();
            CarbonSpacer = new DataGridViewTextBoxColumn();
            Profile = new DataGridViewImageColumn();
            NameColumn = new DataGridViewTextBoxColumn();
            JobTitleColumn = new DataGridViewTextBoxColumn();
            DepartmentColumn = new DataGridViewTextBoxColumn();
            HistoryColumn = new DataGridViewTextBoxColumn();
            StatusColumn = new DataGridViewTextBoxColumn();
            tableLayoutPanel3 = new TableLayoutPanel();
            addEmpButton = new Guna.UI2.WinForms.Guna2Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            label2 = new Label();
            searchTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            countLabel = new Label();
            guna2CustomGradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)employeeDataGrid).BeginInit();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // guna2Panel1
            // 
            guna2Panel1.CustomizableEdges = customizableEdges1;
            guna2Panel1.Dock = DockStyle.Top;
            guna2Panel1.Location = new Point(0, 0);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Panel1.Size = new Size(1909, 74);
            guna2Panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.Location = new Point(17, 79);
            label1.Name = "label1";
            label1.Size = new Size(175, 48);
            label1.TabIndex = 2;
            label1.Text = "Accounts";
            // 
            // guna2CustomGradientPanel1
            // 
            guna2CustomGradientPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            guna2CustomGradientPanel1.BorderColor = Color.Black;
            guna2CustomGradientPanel1.BorderRadius = 10;
            guna2CustomGradientPanel1.BorderThickness = 2;
            guna2CustomGradientPanel1.Controls.Add(employeeDataGrid);
            guna2CustomGradientPanel1.Controls.Add(tableLayoutPanel3);
            guna2CustomGradientPanel1.Controls.Add(tableLayoutPanel2);
            guna2CustomGradientPanel1.Controls.Add(tableLayoutPanel1);
            guna2CustomGradientPanel1.CustomizableEdges = customizableEdges9;
            guna2CustomGradientPanel1.Location = new Point(17, 159);
            guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            guna2CustomGradientPanel1.Padding = new Padding(5);
            guna2CustomGradientPanel1.ShadowDecoration.CustomizableEdges = customizableEdges10;
            guna2CustomGradientPanel1.Size = new Size(1876, 849);
            guna2CustomGradientPanel1.TabIndex = 3;
            // 
            // employeeDataGrid
            // 
            employeeDataGrid.AllowUserToAddRows = false;
            employeeDataGrid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            employeeDataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            employeeDataGrid.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            employeeDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            employeeDataGrid.ColumnHeadersHeight = 60;
            employeeDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            employeeDataGrid.Columns.AddRange(new DataGridViewColumn[] { CarbonSpacer, Profile, NameColumn, JobTitleColumn, DepartmentColumn, HistoryColumn, StatusColumn });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            employeeDataGrid.DefaultCellStyle = dataGridViewCellStyle3;
            employeeDataGrid.GridColor = Color.FromArgb(231, 229, 255);
            employeeDataGrid.Location = new Point(16, 261);
            employeeDataGrid.Name = "employeeDataGrid";
            employeeDataGrid.ReadOnly = true;
            employeeDataGrid.RowHeadersVisible = false;
            employeeDataGrid.RowHeadersWidth = 62;
            employeeDataGrid.RowTemplate.Height = 50;
            employeeDataGrid.Size = new Size(1845, 573);
            employeeDataGrid.TabIndex = 2;
            employeeDataGrid.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            employeeDataGrid.ThemeStyle.AlternatingRowsStyle.Font = null;
            employeeDataGrid.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            employeeDataGrid.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            employeeDataGrid.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            employeeDataGrid.ThemeStyle.BackColor = Color.White;
            employeeDataGrid.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            employeeDataGrid.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            employeeDataGrid.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            employeeDataGrid.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            employeeDataGrid.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            employeeDataGrid.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            employeeDataGrid.ThemeStyle.HeaderStyle.Height = 60;
            employeeDataGrid.ThemeStyle.ReadOnly = true;
            employeeDataGrid.ThemeStyle.RowsStyle.BackColor = Color.White;
            employeeDataGrid.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            employeeDataGrid.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            employeeDataGrid.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            employeeDataGrid.ThemeStyle.RowsStyle.Height = 50;
            employeeDataGrid.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            employeeDataGrid.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            employeeDataGrid.CellDoubleClick += employeeDataGrid_CellDoubleClick;
            employeeDataGrid.VisibleChanged += employeeDataGrid_VisibleChanged;
            // 
            // CarbonSpacer
            // 
            CarbonSpacer.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            CarbonSpacer.HeaderText = "";
            CarbonSpacer.MinimumWidth = 8;
            CarbonSpacer.Name = "CarbonSpacer";
            CarbonSpacer.ReadOnly = true;
            CarbonSpacer.Width = 10;
            // 
            // Profile
            // 
            Profile.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Profile.FillWeight = 144.578308F;
            Profile.HeaderText = "";
            Profile.ImageLayout = DataGridViewImageCellLayout.Zoom;
            Profile.MinimumWidth = 8;
            Profile.Name = "Profile";
            Profile.ReadOnly = true;
            Profile.Width = 40;
            // 
            // NameColumn
            // 
            NameColumn.FillWeight = 91.0843353F;
            NameColumn.HeaderText = "Name";
            NameColumn.MinimumWidth = 8;
            NameColumn.Name = "NameColumn";
            NameColumn.ReadOnly = true;
            // 
            // JobTitleColumn
            // 
            JobTitleColumn.FillWeight = 91.0843353F;
            JobTitleColumn.HeaderText = "Job Title";
            JobTitleColumn.MinimumWidth = 8;
            JobTitleColumn.Name = "JobTitleColumn";
            JobTitleColumn.ReadOnly = true;
            // 
            // DepartmentColumn
            // 
            DepartmentColumn.FillWeight = 91.0843353F;
            DepartmentColumn.HeaderText = "Department";
            DepartmentColumn.MinimumWidth = 8;
            DepartmentColumn.Name = "DepartmentColumn";
            DepartmentColumn.ReadOnly = true;
            // 
            // HistoryColumn
            // 
            HistoryColumn.FillWeight = 91.0843353F;
            HistoryColumn.HeaderText = "History";
            HistoryColumn.MinimumWidth = 8;
            HistoryColumn.Name = "HistoryColumn";
            HistoryColumn.ReadOnly = true;
            // 
            // StatusColumn
            // 
            StatusColumn.FillWeight = 91.0843353F;
            StatusColumn.HeaderText = "Status";
            StatusColumn.MinimumWidth = 8;
            StatusColumn.Name = "StatusColumn";
            StatusColumn.ReadOnly = true;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.BackColor = Color.Transparent;
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.9936008F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 88.0064F));
            tableLayoutPanel3.Controls.Add(addEmpButton, 0, 1);
            tableLayoutPanel3.Dock = DockStyle.Top;
            tableLayoutPanel3.Location = new Point(5, 130);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 3;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 18.26923F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 81.73077F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 39F));
            tableLayoutPanel3.Size = new Size(1866, 119);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // addEmpButton
            // 
            addEmpButton.Anchor = AnchorStyles.None;
            addEmpButton.AutoRoundedCorners = true;
            addEmpButton.CustomizableEdges = customizableEdges3;
            addEmpButton.DisabledState.BorderColor = Color.DarkGray;
            addEmpButton.DisabledState.CustomBorderColor = Color.DarkGray;
            addEmpButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            addEmpButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            addEmpButton.Font = new Font("Segoe UI", 9F);
            addEmpButton.ForeColor = Color.White;
            addEmpButton.Location = new Point(28, 19);
            addEmpButton.Name = "addEmpButton";
            addEmpButton.ShadowDecoration.CustomizableEdges = customizableEdges4;
            addEmpButton.Size = new Size(167, 54);
            addEmpButton.TabIndex = 0;
            addEmpButton.Text = "Add Employee";
            addEmpButton.Click += addEmpButton_Click;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = Color.Transparent;
            tableLayoutPanel2.ColumnCount = 4;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.15565F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.4008522F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.08742F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 57.3560753F));
            tableLayoutPanel2.Controls.Add(label2, 0, 0);
            tableLayoutPanel2.Controls.Add(searchTextBox, 1, 0);
            tableLayoutPanel2.Controls.Add(guna2Button1, 2, 0);
            tableLayoutPanel2.Dock = DockStyle.Top;
            tableLayoutPanel2.Location = new Point(5, 82);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(1866, 48);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(11, 11);
            label2.Name = "label2";
            label2.Size = new Size(130, 25);
            label2.TabIndex = 0;
            label2.Text = "Refine results:";
            // 
            // searchTextBox
            // 
            searchTextBox.CustomizableEdges = customizableEdges5;
            searchTextBox.DefaultText = "";
            searchTextBox.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            searchTextBox.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            searchTextBox.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            searchTextBox.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            searchTextBox.Dock = DockStyle.Fill;
            searchTextBox.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            searchTextBox.Font = new Font("Segoe UI", 9F);
            searchTextBox.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            searchTextBox.Location = new Point(156, 5);
            searchTextBox.Margin = new Padding(4, 5, 4, 5);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.PlaceholderText = "";
            searchTextBox.SelectedText = "";
            searchTextBox.ShadowDecoration.CustomizableEdges = customizableEdges6;
            searchTextBox.Size = new Size(428, 38);
            searchTextBox.TabIndex = 1;
            // 
            // guna2Button1
            // 
            guna2Button1.Anchor = AnchorStyles.Left;
            guna2Button1.AutoRoundedCorners = true;
            guna2Button1.CustomizableEdges = customizableEdges7;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.Font = new Font("Segoe UI", 9F);
            guna2Button1.ForeColor = Color.White;
            guna2Button1.Location = new Point(591, 3);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2Button1.Size = new Size(150, 42);
            guna2Button1.TabIndex = 2;
            guna2Button1.Text = "Search";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Controls.Add(countLabel, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(5, 5);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1866, 77);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // countLabel
            // 
            countLabel.Anchor = AnchorStyles.None;
            countLabel.AutoSize = true;
            countLabel.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            countLabel.Location = new Point(862, 15);
            countLabel.Name = "countLabel";
            countLabel.Size = new Size(139, 46);
            countLabel.TabIndex = 0;
            countLabel.Text = "COUNT";
            // 
            // NewEmployeeView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(guna2CustomGradientPanel1);
            Controls.Add(label1);
            Controls.Add(guna2Panel1);
            Name = "NewEmployeeView";
            Size = new Size(1909, 1058);
            Load += NewEmployeeView_Load;
            guna2CustomGradientPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)employeeDataGrid).EndInit();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Label label1;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel1;
        private Label countLabel;
        private Label label2;
        private Guna.UI2.WinForms.Guna2TextBox searchTextBox;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private TableLayoutPanel tableLayoutPanel3;
        private Guna.UI2.WinForms.Guna2Button addEmpButton;
        private Guna.UI2.WinForms.Guna2DataGridView employeeDataGrid;
        private DataGridViewTextBoxColumn CarbonSpacer;
        private DataGridViewImageColumn Profile;
        private DataGridViewTextBoxColumn NameColumn;
        private DataGridViewTextBoxColumn JobTitleColumn;
        private DataGridViewTextBoxColumn DepartmentColumn;
        private DataGridViewTextBoxColumn HistoryColumn;
        private DataGridViewTextBoxColumn StatusColumn;
    }
}
