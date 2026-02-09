using Coffee.Kiosk.CMS.Controllers;
using Coffee.Kiosk.CMS.DTOs;
using Coffee.Kiosk.CMS.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.AccountsTab
{
    public partial class NewEmployeeView : UserControl
    {
        private readonly AccountController _controller;
        private Color _darkBrown = ColorTranslator.FromHtml("#3d211a");
        private Color _mediumBrown = ColorTranslator.FromHtml("#6f4d38");
        private Color _lightBrown = ColorTranslator.FromHtml("#a07856");
        private Color _beige = ColorTranslator.FromHtml("#cbb799");
        private Color _background = ColorTranslator.FromHtml("#f5f5dc");

        public AdminControlForm? ParentFormReference { get; set; }

        public NewEmployeeView(AccountController controller)
        {
            InitializeComponent();
            _controller = controller ?? throw new ArgumentNullException(nameof(controller));
            ApplyTheme();
            LoadTable();
        }

        private void ApplyTheme()
        {
            // Set background colors
            this.BackColor = _background;
            this.ForeColor = _darkBrown;

            // Apply to main container
            guna2CustomGradientPanel1.BackColor = _beige;
            guna2CustomGradientPanel1.FillColor = _beige;
            guna2CustomGradientPanel1.FillColor2 = _beige;
            guna2CustomGradientPanel1.FillColor3 = _beige;
            guna2CustomGradientPanel1.FillColor4 = _beige;
            guna2CustomGradientPanel1.BorderColor = _mediumBrown;
            guna2CustomGradientPanel1.BorderThickness = 2;

            // Apply to panels
            guna2Panel1.FillColor = _mediumBrown;
            guna2Panel1.BackColor = _mediumBrown;

            // Apply to labels
            label1.ForeColor = _darkBrown;
            label1.BackColor = Color.Transparent;

            label2.ForeColor = _darkBrown;
            label2.BackColor = Color.Transparent;

            countLabel.ForeColor = _darkBrown;
            countLabel.BackColor = Color.Transparent;

            // Apply to buttons
            ConfigureButton(addEmpButton);
            ConfigureButton(guna2Button1);

            // Apply to search textbox
            searchTextBox.BorderColor = _mediumBrown;
            searchTextBox.FocusedState.BorderColor = _lightBrown;
            searchTextBox.HoverState.BorderColor = _lightBrown;
            searchTextBox.FillColor = Color.White;
            searchTextBox.ForeColor = _darkBrown;

            // Apply to datagrid
            ApplyDataGridTheme();
        }

        private void ConfigureButton(Guna.UI2.WinForms.Guna2Button button)
        {
            button.FillColor = _mediumBrown;
            button.ForeColor = Color.White;
            button.BorderColor = _darkBrown;
            button.BorderThickness = 1;
            button.HoverState.FillColor = _lightBrown;
            button.HoverState.BorderColor = _darkBrown;
            button.PressedColor = _darkBrown;
        }

        private void ApplyDataGridTheme()
        {
            // Configure DataGridView theme
            employeeDataGrid.BackgroundColor = _beige;
            employeeDataGrid.GridColor = _mediumBrown;

            // Header styling
            employeeDataGrid.ColumnHeadersDefaultCellStyle.BackColor = _mediumBrown;
            employeeDataGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            employeeDataGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            employeeDataGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            employeeDataGrid.ColumnHeadersHeight = 40;

            // Row styling
            employeeDataGrid.DefaultCellStyle.BackColor = Color.White;
            employeeDataGrid.DefaultCellStyle.ForeColor = _darkBrown;
            employeeDataGrid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(240, 240, 220);
            employeeDataGrid.DefaultCellStyle.SelectionForeColor = _darkBrown;
            employeeDataGrid.DefaultCellStyle.Font = new Font("Segoe UI", 9F);

            // Alternating rows
            employeeDataGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 240);
            employeeDataGrid.AlternatingRowsDefaultCellStyle.ForeColor = _darkBrown;

            // Border styling
            employeeDataGrid.BorderStyle = BorderStyle.None;
            employeeDataGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            employeeDataGrid.GridColor = _mediumBrown;

            // Row headers (if visible)
            employeeDataGrid.RowHeadersVisible = false;

            // Enable visual styles for better appearance
            employeeDataGrid.EnableHeadersVisualStyles = false;
        }

        private void NewEmployeeView_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            StabilizeGridRows(employeeDataGrid, 60);
            LoadTable();
        }

        private void LoadTable()
        {
            List<DisplayDTO> tableData = _controller.GetDisplayDTOs();

            employeeDataGrid.Rows.Clear();

            foreach (var data in tableData)
            {
                Image? pfp = null;

                if (!string.IsNullOrEmpty(data.ProfilePicturePath) && File.Exists(data.ProfilePicturePath))
                {
                    try
                    {
                        using var tempImg = Image.FromFile(data.ProfilePicturePath);
                        pfp = new Bitmap(tempImg, 40, 40); // Resize to consistent size
                    }
                    catch
                    {
                        pfp = CreateDefaultProfileImage(data.FirstName, data.LastName);
                    }
                }
                else
                {
                    pfp = CreateDefaultProfileImage(data.FirstName, data.LastName);
                }

                // Determine status color
                string status = data.Status;
                Color statusColor = GetStatusColor(status);

                employeeDataGrid.Rows.Add(
                    null,                   // Spacer
                    pfp,                    // PFP 
                    data.FullName,
                    data.JobTitle,
                    data.Department,
                    "",                     // Placeholder for History
                    status                  // Status text
                );

                // Apply status color to the status cell
                int rowIndex = employeeDataGrid.Rows.Count - 1;
                employeeDataGrid.Rows[rowIndex].Cells["StatusColumn"].Style.ForeColor = statusColor;
                employeeDataGrid.Rows[rowIndex].Cells["StatusColumn"].Style.Font = new Font("Segoe UI Semibold", 9F);

                employeeDataGrid.Rows[rowIndex].Tag = data;
            }

            // Update count label
            countLabel.Text = $"{tableData.Count} Employees";
        }

        private Image CreateDefaultProfileImage(string firstName, string lastName)
        {
            var bmp = new Bitmap(40, 40);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(240, 240, 240));
                using (Pen pen = new Pen(Color.FromArgb(200, 200, 200), 1))
                {
                    g.DrawEllipse(pen, 2, 2, 36, 36);
                }

                string initials = GetInitials(firstName, lastName);
                using (Font font = new Font("Arial", 10, FontStyle.Bold))
                using (Brush brush = new SolidBrush(Color.FromArgb(150, 150, 150)))
                {
                    StringFormat format = new StringFormat();
                    format.Alignment = StringAlignment.Center;
                    format.LineAlignment = StringAlignment.Center;

                    // Draw the text - newline will automatically make it vertical
                    g.DrawString(initials, font, brush,
                        new RectangleF(0, 0, bmp.Width, bmp.Height), format);
                }
            }
            return bmp;
        }

        private string GetInitials(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
                return "??";

            string firstInitial = string.IsNullOrEmpty(firstName) ? "" : firstName[0].ToString();
            string lastInitial = string.IsNullOrEmpty(lastName) ? "" : lastName[0].ToString();

            return $"{firstInitial}{lastInitial}".ToUpper();
        }

        private Color GetStatusColor(string status)
        {
            switch (status?.ToUpper())
            {
                case "ACTIVE":
                    return Color.Green;
                case "DEACTIVATED":
                    return Color.Red;
                case "PENDING":
                    return Color.Orange;
                case "ON LEAVE":
                    return Color.Blue;
                default:
                    return _darkBrown;
            }
        }

        private void StabilizeGridRows(DataGridView grid, int height)
        {
            grid.SuspendLayout();

            grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grid.EnableHeadersVisualStyles = false;
            grid.AllowUserToResizeRows = false;

            grid.RowTemplate.Height = height;

            foreach (DataGridViewRow row in grid.Rows)
                row.Height = height;

            grid.DataBindingComplete += (s, e) =>
            {
                foreach (DataGridViewRow row in grid.Rows)
                    row.Height = height;
            };

            grid.ResumeLayout();
        }

        private void employeeDataGrid_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                LoadTable();
            }
        }

        private void addEmpButton_Click(object sender, EventArgs e)
        {
            var draft = new DisplayDTO();
            using var step1 = new NewestRegisterView(_controller, draft);
            step1.ShowDialog(this);
        }

        private void employeeDataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var row = employeeDataGrid.Rows[e.RowIndex];

            if (row.Tag is not DisplayDTO selectedEmployee)
                return;

            using (var updateForm = new NewUpdateEmployee(selectedEmployee, _controller))
            {
                updateForm.ShowDialog(this);
            }

            LoadTable();
        }

       
        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            string searchTerm = searchTextBox.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchTerm))
            {
                LoadTable();
                return;
            }

            List<DisplayDTO> tableData = _controller.GetDisplayDTOs();
            var filteredData = tableData.Where(e =>
                e.FullName.ToLower().Contains(searchTerm) ||
                e.JobTitle.ToLower().Contains(searchTerm) ||
                e.Department.ToLower().Contains(searchTerm) ||
                e.Status.ToLower().Contains(searchTerm) ||
                e.Email.ToLower().Contains(searchTerm)
            ).ToList();

            employeeDataGrid.Rows.Clear();

            foreach (var data in filteredData)
            {
                Image? pfp = null;

                if (!string.IsNullOrEmpty(data.ProfilePicturePath) && File.Exists(data.ProfilePicturePath))
                {
                    try
                    {
                        using var tempImg = Image.FromFile(data.ProfilePicturePath);
                        pfp = new Bitmap(tempImg, 40, 40);
                    }
                    catch
                    {
                        pfp = CreateDefaultProfileImage(data.FirstName, data.LastName);
                    }
                }
                else
                {
                    pfp = CreateDefaultProfileImage(data.FirstName, data.LastName);
                }

                Color statusColor = GetStatusColor(data.Status);

                employeeDataGrid.Rows.Add(
                    null,
                    pfp,
                    data.FullName,
                    data.JobTitle,
                    data.Department,
                    "",
                    data.Status
                );

                int rowIndex = employeeDataGrid.Rows.Count - 1;
                employeeDataGrid.Rows[rowIndex].Cells["StatusColumn"].Style.ForeColor = statusColor;
                employeeDataGrid.Rows[rowIndex].Cells["StatusColumn"].Style.Font = new Font("Segoe UI Semibold", 9F);
                employeeDataGrid.Rows[rowIndex].Tag = data;
            }

            countLabel.Text = $"{filteredData.Count} Employees (Filtered)";
        }
    }
}