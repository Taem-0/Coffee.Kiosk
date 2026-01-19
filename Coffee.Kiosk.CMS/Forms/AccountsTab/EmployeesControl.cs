using Coffee.Kiosk.CMS.CoffeeKDB;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Coffee.Kiosk.CMS
{
    public partial class EmployeesControl : UserControl
    {
        private AccountController _controller;

        public AdminControlForm? ParentFormReference { get; set; }

        public EmployeesControl(AccountController controller)
        {
            InitializeComponent();

            _controller = controller ?? throw new ArgumentNullException(nameof(controller));

            UIhelp.buttonNaRound(addEmpButton, 20);

            List<DisplayDTO> tableData = _controller.GetDisplayDTOs();

            EmployeeListView.Columns.Add("Full Name", 200, HorizontalAlignment.Left);
            EmployeeListView.Columns.Add("Phone", 200, HorizontalAlignment.Left);
            EmployeeListView.Columns.Add("Email", 200, HorizontalAlignment.Left);
            EmployeeListView.Columns.Add("Emergency Number", 200, HorizontalAlignment.Left);
            EmployeeListView.Columns.Add("Job Title", 200, HorizontalAlignment.Left);
            EmployeeListView.Columns.Add("Salary", 200, HorizontalAlignment.Left);
            EmployeeListView.Columns.Add("Status", 200, HorizontalAlignment.Left);

            foreach (var data in tableData)
            {
                ListViewItem item = new ListViewItem(data.FullName);
                item.SubItems.Add(data.PhoneNumber);
                item.SubItems.Add(data.Email);
                item.SubItems.Add(data.EmergencyNumber);
                item.SubItems.Add(data.JobTitle);
                item.SubItems.Add(data.Salary);
                item.SubItems.Add(data.Status);

                EmployeeListView.Items.Add(item);    

            }

        }


        private void addEmpButton_Click(object sender, EventArgs e)
        {
            //From here
            if (ParentFormReference == null) return;

            ParentFormReference.ShowInAccountsPanel(
                new RegisterControl(_controller)
                {
                    ParentFormReference = ParentFormReference
                }
            );
            //To here is how we call a user control for navigationnnn
        }


        private void EmployeeListView_Resize(object sender, EventArgs e)
        {

            int totalWidth = EmployeeListView.ClientSize.Width;

            EmployeeListView.Columns[0].Width = (int)(totalWidth * 0.15);
            EmployeeListView.Columns[1].Width = (int)(totalWidth * 0.15);
            EmployeeListView.Columns[2].Width = (int)(totalWidth * 0.15);
            EmployeeListView.Columns[3].Width = (int)(totalWidth * 0.15);
            EmployeeListView.Columns[4].Width = (int)(totalWidth * 0.15);
            EmployeeListView.Columns[5].Width = (int)(totalWidth * 0.15);
            EmployeeListView.Columns[6].Width = (int)(totalWidth * 0.10);

        }


    }

}
