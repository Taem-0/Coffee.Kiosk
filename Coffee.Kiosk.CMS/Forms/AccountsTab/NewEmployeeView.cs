using Coffee.Kiosk.CMS.Controllers;
using Coffee.Kiosk.CMS.DTOs;
using Coffee.Kiosk.CMS.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.AccountsTab
{
    public partial class NewEmployeeView : UserControl
    {

        private AccountController _controller;

        public AdminControlForm? ParentFormReference { get; set; }

        public NewEmployeeView(AccountController controller)
        {
            InitializeComponent();

            _controller = controller ?? throw new ArgumentNullException(nameof(controller));

            LoadTable();


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
                employeeDataGrid.Rows.Add(
                    null,
                    null,
                    data.FullName,
                    data.JobTitle,
                    data.Department,
                    "",                   //Next timeee
                    data.Status
                );

                employeeDataGrid.Rows[employeeDataGrid.Rows.Count - 1].Tag = data;
            }
        }

        private void StabilizeGridRows(DataGridView grid, int height)
        {
            //Surrendered and used AI :< fuck winforms man wtf, give me console apps instead
            grid.SuspendLayout();

            // Kill all autosizing paths
            grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grid.EnableHeadersVisualStyles = false;
            grid.AllowUserToResizeRows = false;

            // Lock the template
            grid.RowTemplate.Height = height;

            // Enforce on existing rows
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
            using (var step1 = new NewestRegisterView(_controller, draft))
            {
                step1.ShowDialog(this);
            }

        }
    }
}
