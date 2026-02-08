using Coffee.Kiosk.CMS.Controllers;
using Coffee.Kiosk.CMS.DTOs;
using Coffee.Kiosk.CMS.Models;
using Guna.UI2.AnimatorNS;
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
using static Coffee.Kiosk.CMS.Helpers.UIhelp;

namespace Coffee.Kiosk.CMS.Forms.AccountsTab
{
    public partial class NewUpdateEmployee : Form
    {
        private readonly DisplayDTO _employee;
        private readonly AccountController _controller;
        private string _selectedImagePath;

        public NewUpdateEmployee(DisplayDTO employee, AccountController controller)
        {
            InitializeComponent();

            _employee = employee ?? throw new ArgumentNullException(nameof(employee));
            _controller = controller ?? throw new ArgumentNullException(nameof(controller));
            _selectedImagePath = employee.ProfilePicturePath;


            DepartmentComboBox.DataSource =
             Enum.GetNames(typeof(Department))
                 .Select(EnumDisplayHelper.FormatEnum)
                 .ToList();

            EmployeeTypecomboBox.DataSource =
                Enum.GetNames(typeof(EmploymentType))
                    .Select(EnumDisplayHelper.FormatEnum)
                    .ToList();

            LoadEmployeeIntoForm();

            guna2vScrollBar1.Scroll += (s, e) =>
            {
                mainPanel.AutoScrollPosition = new Point(
                    0,
                    guna2vScrollBar1.Value
                );
            };

            mainPanel.Scroll += (s, e) =>
            {
                int scrollY = -mainPanel.AutoScrollPosition.Y;
                guna2vScrollBar1.Value = Math.Min(
                    guna2vScrollBar1.Maximum,
                    scrollY
                );
            };

            DeactivateButton.Enabled = _employee.Status != "DEACTIVATED" && _employee.Role != "Owner";
            DeactivateButton.Text = _employee.Status == "DEACTIVATED" ? "Deactivated" : "Deactivate";

        }

        private void LoadEmployeeIntoForm()
        {
            if (!string.IsNullOrWhiteSpace(_employee.ProfilePicturePath) &&
                File.Exists(_employee.ProfilePicturePath))
            {
                try
                {
                    using var img = Image.FromFile(_employee.ProfilePicturePath);
                    PictureBox.Image = new Bitmap(img);
                    PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                catch
                {
                    // If image loading fails, set to default
                    PictureBox.Image = CreateDefaultProfileImage();
                    PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            else
            {
                PictureBox.Image = CreateDefaultProfileImage();
                PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            FirstNameTextBox.Text = _employee.FirstName;
            MiddleNameTextBox.Text = _employee.MiddleName;
            LastNameTextBox.Text = _employee.LastName;

            EmailTextBox.Text = _employee.Email;
            PhoneTextBox.Text = _employee.PhoneNumber;

            EmergencyFirstNameTextBox.Text = _employee.EmergencyFirstName;
            EmergencyLastNameTextBox.Text = _employee.EmergencyLastName;
            EmergencyPhoneTextBox.Text = _employee.EmergencyNumber;

            JobTitleTextBox.Text = _employee.JobTitle;
            SalaryTextBox1.Text = _employee.Salary;

            DepartmentComboBox.SelectedItem = _employee.Department;
            EmployeeTypecomboBox.SelectedItem = _employee.EmploymentType;

            switch (_employee.Role)
            {
                case "Owner":
                    AdminRadioButton.Checked = true;
                    break;
                case "Manager":
                    ManagerRadioButton.Checked = true;
                    break;
                default:
                    employeeRadioButton.Checked = true;
                    break;
            }

            if (_employee.Role == "Owner")
            {
                AdminRadioButton.Enabled = false;
                ManagerRadioButton.Enabled = false;
                employeeRadioButton.Enabled = false;

                DeactivateButton.Enabled = false;
                DeactivateButton.Text = "Cannot Deactivate Owner";
            }
        }

        private void InputCollection()
        {
            _employee.FirstName = FirstNameTextBox.Text.Trim();
            _employee.MiddleName = MiddleNameTextBox.Text.Trim();
            _employee.LastName = LastNameTextBox.Text.Trim();

            _employee.Email = EmailTextBox.Text.Trim();
            _employee.PhoneNumber = PhoneTextBox.Text.Trim();

            _employee.EmergencyFirstName = EmergencyFirstNameTextBox.Text.Trim();
            _employee.EmergencyLastName = EmergencyLastNameTextBox.Text.Trim();
            _employee.EmergencyNumber = EmergencyPhoneTextBox.Text.Trim();

            _employee.Department = DepartmentComboBox.SelectedItem?.ToString() ?? "";
            _employee.EmploymentType = EmployeeTypecomboBox.SelectedItem?.ToString() ?? "";

            EmployeeTypecomboBox.Text = _employee.EmploymentType;

            if (decimal.TryParse(SalaryTextBox1.Text, out var salary))
            {
                _employee.Salary = salary.ToString();
            }

            _employee.ProfilePicturePath = _selectedImagePath;

            if (_employee.Role != "Owner")
            {
                if (AdminRadioButton.Checked)
                    _employee.Role = "Owner";
                else if (ManagerRadioButton.Checked)
                    _employee.Role = "Manager";
                else
                    _employee.Role = "Employee";
            }

            var result = _controller.Update(_employee);

            if (!result.IsValid)
            {
                MessageBox.Show(
                    string.Join(Environment.NewLine, result.Errors.Values),
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            MessageBox.Show(
                "Employee updated successfully!",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            this.Close();
        }

        private void SubmitButton_Click_1(object sender, EventArgs e)
        {
            InputCollection();
            this.Close();
        }

        private void DeactivateButton_Click(object sender, EventArgs e)
        {
            if (_employee.Role == "Owner")
            {
                MessageBox.Show(
                    "Owner accounts cannot be deactivated.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            var result = MessageBox.Show(
                $"Are you sure you want to deactivate {_employee.FirstName} {_employee.LastName}?",
                "Confirm Deactivation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result != DialogResult.Yes)
                return;

            try
            {
                _controller.DeactivateAccount(_employee);

                _employee.Status = "DEACTIVATED";

                MessageBox.Show(
                    "Employee deactivated successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error deactivating employee: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void AddPfpButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Title = "Select Profile Picture";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _selectedImagePath = openFileDialog.FileName;

                        using (var img = Image.FromFile(_selectedImagePath))
                        {
                            PictureBox.Image = new Bitmap(img);
                            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        }

                        // Optional: Show success message
                        // MessageBox.Show("Profile picture updated!", "Success", 
                        //     MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading image: {ex.Message}",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        _selectedImagePath = _employee.ProfilePicturePath; // Revert to original
                    }
                }
            }
        }

        private Image CreateDefaultProfileImage()
        {
            var bmp = new Bitmap(200, 200);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(240, 240, 240));
                using (Pen pen = new Pen(Color.FromArgb(200, 200, 200), 2))
                {
                    g.DrawEllipse(pen, 10, 10, 180, 180);
                }

                string initials = GetInitials(_employee.FirstName, _employee.LastName);
                using (Font font = new Font("Arial", 48, FontStyle.Bold))
                using (Brush brush = new SolidBrush(Color.FromArgb(150, 150, 150)))
                {
                    StringFormat format = new StringFormat();
                    format.Alignment = StringAlignment.Center;
                    format.LineAlignment = StringAlignment.Center;

                    g.DrawString(initials, font, brush,
                        new RectangleF(0, 0, bmp.Width, bmp.Height), format);
                }
            }
            return bmp;
        }

        private string GetInitials(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
                return "??";

            return $"{firstName[0]}{lastName[0]}".ToUpper();
        }

        private void PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var contextMenu = new ContextMenuStrip();
                var removeItem = new ToolStripMenuItem("Remove Profile Picture");
                removeItem.Click += (s, args) =>
                {
                    var result = MessageBox.Show(
                        "Remove profile picture?",
                        "Confirm",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (result == DialogResult.Yes)
                    {
                        _selectedImagePath = null;
                        PictureBox.Image = CreateDefaultProfileImage();
                        PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                };
                contextMenu.Items.Add(removeItem);
                contextMenu.Show(PictureBox, e.Location);
            }
        }


    }
}