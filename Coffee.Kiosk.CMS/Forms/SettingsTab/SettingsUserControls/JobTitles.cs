using Coffee.Kiosk.CMS.Controllers;
using System;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.SettingsTab.SettingsUserControls
{
    public partial class JobTitles : UserControl
    {
        private OrganizationController? _controller;

        public JobTitles()
        {
            InitializeComponent();
            guna2Button1.Click += AddJobTitle_Click;
            guna2Button2.Click += AddDepartment_Click;
        }

        public void Initialize(OrganizationController controller)
        {
            _controller = controller;
            jobTitleList1.Initialize(controller);
            //deparmentList1.Initialize(controller);
        }

        private void AddJobTitle_Click(object? sender, EventArgs e)
        {
            string title = guna2TextBox1.Text.Trim();
            if (string.IsNullOrEmpty(title)) return;

            try
            {
                _controller!.AddJobTitle(title);
                guna2TextBox1.Text = string.Empty;
                jobTitleList1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to add: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddDepartment_Click(object? sender, EventArgs e)
        {
            string name = guna2TextBox2.Text.Trim();
            if (string.IsNullOrEmpty(name)) return;

            try
            {
                _controller!.AddDepartment(name);
                guna2TextBox2.Text = string.Empty;
                //deparmentList1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to add: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void JobTitles_Load(object sender, EventArgs e) { }
    }
}