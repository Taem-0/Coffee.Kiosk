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
            history.Text = "";

            status.Text = employee.Status?.ToUpper() == "ACTIVE" ? "Current Employee" : "Inactive Employee";
            status.FillColor = employee.Status?.ToUpper() == "ACTIVE"
                ? Color.GreenYellow
                : Color.FromArgb(50, 50, 50);
            status.ForeColor = employee.Status?.ToUpper() == "ACTIVE"
                ? Color.White
                : Color.White;

            LoadProfilePicture(employee.ProfilePicturePath, employee.FirstName, employee.LastName);

            this.Click += Card_Click;
            foreach (Control c in this.Controls)
                c.Click += Card_Click;
        }

        private void Card_Click(object? sender, EventArgs e)
        {
            OnCardClicked?.Invoke(this, _employee);
        }

        private void LoadProfilePicture(string? path, string firstName, string lastName)
        {
            if (!string.IsNullOrEmpty(path) && File.Exists(path))
            {
                try
                {
                    using var img = Image.FromFile(path);
                    employeeProfilePic.Image = new Bitmap(img, 60, 60);
                    return;
                }
                catch { }
            }
            employeeProfilePic.Image = CreateDefaultProfileImage(firstName, lastName);
        }

        private Image CreateDefaultProfileImage(string firstName, string lastName)
        {
            var bmp = new Bitmap(60, 60);
            using var g = Graphics.FromImage(bmp);
            g.Clear(Color.FromArgb(240, 240, 240));
            using var pen = new Pen(Color.FromArgb(200, 200, 200), 1);
            g.DrawEllipse(pen, 2, 2, 56, 56);
            string initials = GetInitials(firstName, lastName);
            using var font = new Font("Arial", 14, FontStyle.Bold);
            using var brush = new SolidBrush(Color.FromArgb(150, 150, 150));
            var format = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            g.DrawString(initials, font, brush, new RectangleF(0, 0, 60, 60), format);
            return bmp;
        }

        private string GetInitials(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName)) return "??";
            string f = string.IsNullOrEmpty(firstName) ? "" : firstName[0].ToString();
            string l = string.IsNullOrEmpty(lastName) ? "" : lastName[0].ToString();
            return $"{f}{l}".ToUpper();
        }

        private void guna2Button2_Click(object sender, EventArgs e) { }
    }
}