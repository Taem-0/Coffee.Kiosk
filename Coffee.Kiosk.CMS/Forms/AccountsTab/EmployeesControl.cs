using Coffee.Kiosk.CMS.Controllers;
using Coffee.Kiosk.CMS.DTOs;
using Coffee.Kiosk.CMS.Forms.AccountsTab;
using Coffee.Kiosk.CMS.Helpers;


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

            EmployeeListView.Columns.Add("Full Name", 200, HorizontalAlignment.Left);
            EmployeeListView.Columns.Add("Phone", 200, HorizontalAlignment.Left);
            EmployeeListView.Columns.Add("Email", 200, HorizontalAlignment.Left);
            EmployeeListView.Columns.Add("Emergency Number", 200, HorizontalAlignment.Left);
            EmployeeListView.Columns.Add("Job Title", 200, HorizontalAlignment.Left);
            EmployeeListView.Columns.Add("Salary", 200, HorizontalAlignment.Left);
            EmployeeListView.Columns.Add("Status", 200, HorizontalAlignment.Left);

            LoadTable();
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);

            if (Visible)
            {
                LoadTable();
            }
        }


        private void LoadTable()
        {

            EmployeeListView.BeginUpdate();
            EmployeeListView.Items.Clear();

            List<DisplayDTO> tableData = _controller.GetDisplayDTOs();


            foreach (var data in tableData)
            {
                ListViewItem item = new ListViewItem(data.FullName);
                item.SubItems.Add(data.PhoneNumber);
                item.SubItems.Add(data.Email);
                item.SubItems.Add(data.EmergencyNumber);
                item.SubItems.Add(data.JobTitle);
                item.SubItems.Add(data.Salary);
                item.SubItems.Add(data.Status);

                item.Tag = data;

                EmployeeListView.Items.Add(item);

            }

            EmployeeListView.EndUpdate();

        }

        private void addEmpButton_Click(object sender, EventArgs e)
        {

            //From here
            if (ParentFormReference == null) return;

            ParentFormReference?.ShowRegister();
            //To here is how we call a user control for navigationnnn


        }


        private void EmployeeListView_Resize(object sender, EventArgs e)
        {

            int totalWidth = EmployeeListView.ClientSize.Width;

            // ayaw mag run sakin eh, uncomment mo nalang
            //EmployeeListView.Columns[0].Width = (int)(totalWidth * 0.15);
            //EmployeeListView.Columns[1].Width = (int)(totalWidth * 0.15);
            //EmployeeListView.Columns[2].Width = (int)(totalWidth * 0.15);
            //EmployeeListView.Columns[3].Width = (int)(totalWidth * 0.15);
            //EmployeeListView.Columns[4].Width = (int)(totalWidth * 0.15);
            //EmployeeListView.Columns[5].Width = (int)(totalWidth * 0.15);
            //EmployeeListView.Columns[6].Width = (int)(totalWidth * 0.10);

        }

        private void EmployeeListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (EmployeeListView.SelectedItems.Count != 1)
                return;

            var selectedAccount = EmployeeListView.SelectedItems[0].Tag as DisplayDTO;
            if (selectedAccount == null)
                return;

            ParentFormReference?.ShowUpdate(selectedAccount);
        }


    }

}
