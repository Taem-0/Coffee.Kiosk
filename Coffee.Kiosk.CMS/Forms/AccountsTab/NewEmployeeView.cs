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
                Image? pfp = null;

                if (!string.IsNullOrEmpty(data.ProfilePicturePath) && File.Exists(data.ProfilePicturePath))
                {
                    using (var tempImg = Image.FromFile(data.ProfilePicturePath))
                    {
                        pfp = new Bitmap(tempImg);
                    }
                }

                employeeDataGrid.Rows.Add(
                    null,                   //Spacerrrrrr
                    pfp,                   // PFP 
                    data.FullName,
                    data.JobTitle,
                    data.Department,
                    "",                     // next time
                    data.Status
                );

                employeeDataGrid.Rows[employeeDataGrid.Rows.Count - 1].Tag = data;
            }

        }

        private void StabilizeGridRows(DataGridView grid, int height)
        {
            //Surrendered and used AI :< fuck winforms man wtf, give me console apps instead
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
            using (var step1 = new NewestRegisterView(_controller, draft))
            {
                step1.ShowDialog(this);
            }

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
    }
}
