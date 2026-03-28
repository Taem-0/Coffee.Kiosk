using Coffee.Kiosk.CMS.Controllers;
using Coffee.Kiosk.CMS.DTOs;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.AccountsTab.AccountUserControls
{
    public partial class EmployeeCard : UserControl
    {
        public event EventHandler<DisplayDTO>? OnCardClicked;
        public event EventHandler? OnDeactivated;

        private DisplayDTO _employee;
        private AccountController _controller;

        public EmployeeCard()
        {
            InitializeComponent();
        }

        public void SetEmployee(DisplayDTO employee, AccountController controller)
        {
            _employee = employee;
            _controller = controller;

            employeeName.Text = employee.FullName;
            jobTitle.Text = employee.JobTitle;
            department.Text = employee.Department;
            status.Text = employee.Status?.ToUpper() == "ACTIVE" ? "Current Employee" : "Inactive Employee";
            status.FillColor = employee.Status?.ToUpper() == "ACTIVE"
                ? Color.GreenYellow
                : Color.FromArgb(50, 50, 50);
            status.ForeColor = Color.White;

            quickDeactButton.Visible = employee.Role != "Owner";
            quickDeactButton.Click += QuickDeactButton_Click;

            LoadProfilePicture(employee.ProfilePicturePath);

            this.Click += Card_Click;
            foreach (Control c in this.Controls)
            {
                if (c != quickDeactButton)
                    c.Click += Card_Click;
            }
        }

        private void Card_Click(object? sender, EventArgs e)
        {
            OnCardClicked?.Invoke(this, _employee);
        }

        private void QuickDeactButton_Click(object? sender, EventArgs e)
        {
            bool isDeactivated = _employee.Status?.ToUpper() == "DEACTIVATED";

            using var dialogue = new Coffee.Kiosk.CMS.Forms.QuickDialogues.DeactivateDialogue();
            dialogue.StartPosition = FormStartPosition.CenterParent;
            dialogue.ShowDialog(this);

            if (!dialogue.Confirmed) return;

            try
            {
                if (isDeactivated)
                    _controller.ReactivateAccount(_employee);
                else
                    _controller.DeactivateAccount(_employee);

                OnDeactivated?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProfilePicture(string? path)
        {
            if (!string.IsNullOrEmpty(path) && File.Exists(path))
            {
                try
                {
                    using var img = Image.FromFile(path);
                    profileBox.Image = new Bitmap(img, 48, 48);
                    return;
                }
                catch { }
            }
            profileBox.Image = new Bitmap(Properties.Resources.person_972_1024, 48, 48);
        }
    }
}