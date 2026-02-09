using Coffee.Kiosk.CMS.Controllers;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.DashBoardTab
{
    public partial class DashBoardControl : UserControl
    {
        public AdminControlForm? ParentFormReference { get; set; }
        private readonly AccountController _controller;

        // Coffee theme colors
        private Color _darkBrown = ColorTranslator.FromHtml("#3d211a");
        private Color _mediumBrown = ColorTranslator.FromHtml("#6f4d38");
        private Color _lightBrown = ColorTranslator.FromHtml("#a07856");
        private Color _beige = ColorTranslator.FromHtml("#cbb799");
        private Color _background = ColorTranslator.FromHtml("#f5f5dc");

        public DashBoardControl(AccountController accountController)
        {
            InitializeComponent();
            _controller = accountController ?? throw new ArgumentNullException(nameof(accountController));
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            // Set background colors
            this.BackColor = _background;
            this.ForeColor = _darkBrown;

            // Apply to header panel
            guna2Panel1.FillColor = _mediumBrown;
            guna2Panel1.BackColor = _mediumBrown;
            guna2Panel1.BorderColor = _darkBrown;
            guna2Panel1.BorderThickness = 1;

            // Apply to search textbox
            ApplyTextBoxTheme(guna2TextBox1);

            // Apply to title label
            label1.ForeColor = _darkBrown;
            label1.BackColor = Color.Transparent;

            // Apply to dropdown container
            DropDownContainer.FillColor = _mediumBrown;
            DropDownContainer.ForeColor = Color.White;

            // Apply to timeline label
            TimeLineLabel.BackColor = _mediumBrown;
            TimeLineLabel.ForeColor = Color.White;

            // Apply to dropdown
            ApplyComboBoxTheme(TimeLineDropDown);

            // Apply to data containers
            ApplyContainerTheme(guna2ContainerControl1);
            ApplyContainerTheme(guna2ContainerControl2);
            ApplyContainerTheme(guna2ContainerControl3);
            ApplyContainerTheme(guna2ContainerControl4);

            // Apply to table layouts
            tableLayoutPanel1.BackColor = _beige;
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.ForeColor = _darkBrown;
            tableLayoutPanel1.BorderStyle = BorderStyle.None;

            tableLayoutPanel2.BackColor = _beige;
            tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel2.ForeColor = _darkBrown;
            tableLayoutPanel2.BorderStyle = BorderStyle.None;

            tableLayoutPanel3.BackColor = Color.Transparent;

            // Add subtle borders to table panels for definition
            tableLayoutPanel1.Paint += (s, e) =>
            {
                using (Pen pen = new Pen(_mediumBrown, 2))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, tableLayoutPanel1.Width - 1, tableLayoutPanel1.Height - 1);
                }
            };

            tableLayoutPanel2.Paint += (s, e) =>
            {
                using (Pen pen = new Pen(_mediumBrown, 2))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, tableLayoutPanel2.Width - 1, tableLayoutPanel2.Height - 1);
                }
            };
        }

        private void ApplyTextBoxTheme(Guna.UI2.WinForms.Guna2TextBox textBox)
        {
            textBox.BorderColor = _mediumBrown;
            textBox.FocusedState.BorderColor = _lightBrown;
            textBox.HoverState.BorderColor = _lightBrown;
            textBox.FillColor = Color.White;
            textBox.ForeColor = _darkBrown;
            textBox.PlaceholderForeColor = Color.Gray;
            textBox.BorderRadius = 8;
        }

        private void ApplyComboBoxTheme(Guna.UI2.WinForms.Guna2ComboBox comboBox)
        {
            comboBox.FillColor = _mediumBrown;
            comboBox.BorderColor = _mediumBrown;
            comboBox.ForeColor = Color.White;
            comboBox.HoverState.BorderColor = _lightBrown;
            comboBox.HoverState.FillColor = _lightBrown;
            comboBox.FocusedState.BorderColor = _lightBrown;
            comboBox.BorderRadius = 17;

            // Style the dropdown items
            comboBox.ItemHeight = 30;
            comboBox.ItemsAppearance.BackColor = _beige;
            comboBox.ItemsAppearance.ForeColor = _darkBrown;
            comboBox.ItemsAppearance.SelectedBackColor = _lightBrown;
            comboBox.ItemsAppearance.SelectedForeColor = Color.White;
        }

        private void ApplyContainerTheme(Guna.UI2.WinForms.Guna2ContainerControl container)
        {
            container.BackColor = _beige;
            container.FillColor = _beige;
            container.BorderColor = _mediumBrown;
            container.BorderThickness = 2;
            container.BorderRadius = 25;
            container.ShadowDecoration.Enabled = true;
            container.ShadowDecoration.Color = Color.FromArgb(100, 0, 0, 0);
            container.ShadowDecoration.Shadow = new Padding(5);

            // Add a subtle inner shadow or gradient
            container.Paint += (s, e) =>
            {
                // Draw a subtle inner border
                using (Pen pen = new Pen(Color.FromArgb(50, _darkBrown), 1))
                {
                    e.Graphics.DrawRectangle(pen, 1, 1, container.Width - 3, container.Height - 3);
                }

                // Add a title area at the top
                using (Brush brush = new SolidBrush(_mediumBrown))
                {
                    e.Graphics.FillRectangle(brush, 0, 0, container.Width, 40);
                }
            };
        }

        private void DashBoardControl_Load(object sender, EventArgs e)
        {
            // Additional initialization if needed
            UpdateDashboardData();
        }

        private void UpdateDashboardData()
        {
            // This method would be called to update dashboard statistics
            // For now, we'll just set placeholder text

            // You could add labels or other controls to display data
            // For example:
            // AddEmployeeCount();
            // AddSalesData();
            // AddRecentActivity();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Optional: Add functionality if needed
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {
            // Optional: Add functionality if needed
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {
            // Optional: Add custom painting if needed
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            // Custom border painting is handled in ApplyTheme
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {
            // Optional: Add custom painting if needed
        }

        private void tableLayoutPanel3_Paint_1(object sender, PaintEventArgs e)
        {
            // Optional: Add custom painting if needed
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {
            // Optional: Add custom painting if needed
        }

        private void guna2ContainerControl4_Click(object sender, EventArgs e)
        {
            // Optional: Add functionality if needed
        }

        // Helper method to add a data card to containers
        private void AddDataCard(Guna.UI2.WinForms.Guna2ContainerControl container, string title, string value, Color valueColor)
        {
            container.Controls.Clear();

            var titleLabel = new Label
            {
                Text = title,
                Font = new Font("Segoe UI Semibold", 12, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                Location = new Point(20, 10),
                AutoSize = true
            };

            var valueLabel = new Label
            {
                Text = value,
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = valueColor,
                BackColor = Color.Transparent,
                Location = new Point(20, 50),
                AutoSize = true
            };

            container.Controls.Add(titleLabel);
            container.Controls.Add(valueLabel);
        }

        // You can call this in Load or when data updates
        private void InitializeDashboardCards()
        {
            // Example: Initialize the data cards
            AddDataCard(guna2ContainerControl1, "Total Employees", "0", _darkBrown);
            AddDataCard(guna2ContainerControl2, "Active Today", "0", Color.Green);
            AddDataCard(guna2ContainerControl3, "Pending Tasks", "0", Color.Orange);
            AddDataCard(guna2ContainerControl4, "Revenue", "$0.00", Color.Green);
        }
    }
}