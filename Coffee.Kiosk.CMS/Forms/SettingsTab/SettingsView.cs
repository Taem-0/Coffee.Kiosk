using Coffee.Kiosk.CMS.Controllers;
using Coffee.Kiosk.CMS.DTOs;
using Coffee.Kiosk.CMS.Models;
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

//shitty spaghetti code INCOMING !!
namespace Coffee.Kiosk.CMS.Forms.SettingsTab
{
    public partial class SettingsView : UserControl
    {
        private readonly AccountController _controller;
        private readonly Employee _currentEmployee;
        private string _selectedImagePath;

        public SettingsView(AccountController controller, Employee currentEmployee)
        {
            InitializeComponent();

            _controller = controller ?? throw new ArgumentNullException(nameof(controller));
            _currentEmployee = currentEmployee ?? throw new ArgumentNullException(nameof(currentEmployee));
            _selectedImagePath = currentEmployee.ProfilePicturePath;

            LoadCurrentEmployeeData();


            guna2CirclePictureBox1.MouseClick += ProfilePicture_MouseClick;
        }


        private void LoadCurrentEmployeeData()
        {
            LoadProfilePicture();

            fullNameLabel.Text = $"{_currentEmployee.FirstName} {_currentEmployee.LastName}";
            emailLabel.Text = _currentEmployee.Email;
            phoneLabel.Text = _currentEmployee.PhoneNumber;
        }

        private void LoadProfilePicture()
        {
            if (!string.IsNullOrWhiteSpace(_selectedImagePath) &&
                File.Exists(_selectedImagePath))
            {
                try
                {
                    using var img = Image.FromFile(_selectedImagePath);
                    guna2CirclePictureBox1.Image = new Bitmap(img);
                    guna2CirclePictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                catch
                {
                    SetDefaultProfileImage();
                }
            }
            else
            {
                SetDefaultProfileImage();
            }
        }

        private void SetDefaultProfileImage()
        {
            var bmp = new Bitmap(120, 120);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.LightGray);
                using (Pen pen = new Pen(Color.Gray, 2))
                {
                    g.DrawEllipse(pen, 5, 5, 110, 110);
                }

                string initials = GetInitials(_currentEmployee.FirstName, _currentEmployee.LastName);
                using (Font font = new Font("Arial", 24, FontStyle.Bold))
                using (Brush brush = new SolidBrush(Color.DarkGray))
                {
                    StringFormat format = new StringFormat();
                    format.Alignment = StringAlignment.Center;
                    format.LineAlignment = StringAlignment.Center;

                    g.DrawString(initials, font, brush,
                        new RectangleF(0, 0, bmp.Width, bmp.Height), format);
                }
            }
            guna2CirclePictureBox1.Image = bmp;
            guna2CirclePictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private string GetInitials(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
                return "??";

            return $"{firstName[0]}{lastName[0]}".ToUpper();
        }

        private void label11_Click(object sender, EventArgs e)
        {
        }

        private void pfpChangeButton_Click(object sender, EventArgs e)
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
                            guna2CirclePictureBox1.Image = new Bitmap(img);
                            guna2CirclePictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        }

                        UpdateEmployeeProfilePicture();

                        MessageBox.Show("Profile picture updated successfully!",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading image: {ex.Message}",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        _selectedImagePath = _currentEmployee.ProfilePicturePath;
                        LoadProfilePicture();
                    }
                }
            }
        }

        private void UpdateEmployeeProfilePicture()
        {
            try
            {
                var displayDTO = GetCurrentDisplayDTO();
                displayDTO.ProfilePicturePath = _selectedImagePath;

                var result = _controller.Update(displayDTO);

                if (!result.IsValid)
                {
                    MessageBox.Show(
                        string.Join(Environment.NewLine, result.Errors.Values),
                        "Update Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                _currentEmployee.ProfilePicturePath = _selectedImagePath;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating profile picture: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private DisplayDTO GetCurrentDisplayDTO()
        {
            return new DisplayDTO
            {
                PrimaryID = _currentEmployee.Id.ToString(),
                FirstName = _currentEmployee.FirstName,
                MiddleName = _currentEmployee.MiddleName,
                LastName = _currentEmployee.LastName,
                PhoneNumber = _currentEmployee.PhoneNumber,
                Email = _currentEmployee.Email,
                EmergencyFirstName = _currentEmployee.EmergencyFirstName,
                EmergencyLastName = _currentEmployee.EmergencyLastName,
                EmergencyNumber = _currentEmployee.EmergencyNumber,
                JobTitle = _currentEmployee.JobTitle,
                Salary = _currentEmployee.Salary.ToString("F2"),
                Role = _currentEmployee.Role.ToString(),
                Department = _currentEmployee.Department.ToString(),
                EmploymentType = _currentEmployee.EmploymentType.ToString(),
                Status = _currentEmployee.Status.ToString(),
                ProfilePicturePath = _currentEmployee.ProfilePicturePath
            };
        }

        private void pfpChangeButton_Click_1(object sender, EventArgs e)
        {
            pfpChangeButton_Click(sender, e);
        }

        private void requestResetButton_Click(object sender, EventArgs e)
        {
            if (_currentEmployee.Role == AccountRole.OWNER)
            {
                ShowChangePasswordDialog();
            }
            else if (_currentEmployee.IsFirstLogin)
            {
                ShowChangePasswordDialog();
            }
            else
            {
                RequestPasswordReset();
            }
        }

        private void ShowChangePasswordDialog()
        {
            bool isFirstLogin = _currentEmployee.IsFirstLogin && _currentEmployee.Role != AccountRole.OWNER;

            using (var dialog = new Coffee.Kiosk.CMS.Forms.Small_Dialogues.passwordChangeDialogue(
                _controller,
                _currentEmployee,
                isFirstLogin))
            {
                dialog.PasswordChanged += (s, e) =>
                {
                    if (isFirstLogin)
                    {
                        _currentEmployee.IsFirstLogin = false;
                    }
                };

                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.ShowDialog();
            }
        }

        private void RequestPasswordReset()
        {
            var result = MessageBox.Show(
                "Request a password reset? An administrator will need to approve this.",
                "Request Password Reset",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool success = _controller.RequestPasswordReset(_currentEmployee.Id);

                    if (success)
                    {
                        MessageBox.Show(
                            "Password reset request submitted to administrator.",
                            "Request Sent",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                    else
                    {
                        MessageBox.Show(
                            "You already have a pending password reset request.",
                            "Information",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void changeNameButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new Form())
            {
                dialog.Text = "Change Name";
                dialog.Size = new Size(400, 200);
                dialog.FormBorderStyle = FormBorderStyle.FixedDialog;
                dialog.StartPosition = FormStartPosition.CenterParent;

                var firstNameLabel = new Label { Text = "First Name:", Location = new Point(20, 20) };
                var firstNameBox = new TextBox
                {
                    Text = _currentEmployee.FirstName,
                    Location = new Point(120, 20),
                    Width = 250
                };

                var lastNameLabel = new Label { Text = "Last Name:", Location = new Point(20, 60) };
                var lastNameBox = new TextBox
                {
                    Text = _currentEmployee.LastName,
                    Location = new Point(120, 60),
                    Width = 250
                };

                var saveButton = new Button
                {
                    Text = "Save",
                    DialogResult = DialogResult.OK,
                    Location = new Point(120, 110)
                };

                dialog.Controls.AddRange(new Control[]
                {
                    firstNameLabel, firstNameBox,
                    lastNameLabel, lastNameBox,
                    saveButton
                });

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var newFirstName = firstNameBox.Text.Trim();
                    var newLastName = lastNameBox.Text.Trim();

                    if (UpdateEmployeeName(newFirstName, newLastName))
                    {
                        fullNameLabel.Text = $"{newFirstName} {newLastName}";
                        MessageBox.Show("Name updated successfully!",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private bool UpdateEmployeeName(string firstName, string lastName)
        {
            try
            {
                var displayDTO = GetCurrentDisplayDTO();
                displayDTO.FirstName = firstName;
                displayDTO.LastName = lastName;

                var result = _controller.Update(displayDTO);

                if (!result.IsValid)
                {
                    MessageBox.Show(
                        string.Join(Environment.NewLine, result.Errors.Values),
                        "Update Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return false;
                }

                _currentEmployee.FirstName = firstName;
                _currentEmployee.LastName = lastName;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating name: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void changePhoneButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new Form())
            {
                dialog.Text = "Change Phone Number";
                dialog.Size = new Size(400, 150);
                dialog.FormBorderStyle = FormBorderStyle.FixedDialog;
                dialog.StartPosition = FormStartPosition.CenterParent;

                var phoneLabel = new Label { Text = "Phone Number:", Location = new Point(20, 20) };
                var phoneBox = new TextBox
                {
                    Text = _currentEmployee.PhoneNumber,
                    Location = new Point(150, 20),
                    Width = 200
                };

                var saveButton = new Button
                {
                    Text = "Save",
                    DialogResult = DialogResult.OK,
                    Location = new Point(150, 70)
                };

                dialog.Controls.AddRange(new Control[] { phoneLabel, phoneBox, saveButton });

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var newPhone = phoneBox.Text.Trim();

                    if (UpdateEmployeePhone(newPhone))
                    {
                        phoneLabel.Text = newPhone;
                        MessageBox.Show("Phone number updated successfully!",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private bool UpdateEmployeePhone(string phoneNumber)
        {
            try
            {
                var displayDTO = GetCurrentDisplayDTO();
                displayDTO.PhoneNumber = phoneNumber;

                var result = _controller.Update(displayDTO);

                if (!result.IsValid)
                {
                    MessageBox.Show(
                        string.Join(Environment.NewLine, result.Errors.Values),
                        "Update Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return false;
                }

                _currentEmployee.PhoneNumber = phoneNumber;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating phone number: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void ProfilePicture_MouseClick(object sender, MouseEventArgs e)
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
                        SetDefaultProfileImage();

                        UpdateEmployeeProfilePicture();

                        MessageBox.Show("Profile picture removed successfully!",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                };

                var viewItem = new ToolStripMenuItem("View Full Size");
                viewItem.Click += (s, args) =>
                {
                    if (guna2CirclePictureBox1.Image != null)
                    {
                        using (var viewForm = new Form())
                        {
                            viewForm.Text = "Profile Picture";
                            viewForm.Size = new Size(500, 500);
                            viewForm.StartPosition = FormStartPosition.CenterParent;

                            var pictureBox = new PictureBox
                            {
                                Image = guna2CirclePictureBox1.Image,
                                SizeMode = PictureBoxSizeMode.StretchImage,
                                Dock = DockStyle.Fill
                            };

                            viewForm.Controls.Add(pictureBox);
                            viewForm.ShowDialog();
                        }
                    }
                };

                contextMenu.Items.Add(viewItem);
                contextMenu.Items.Add(removeItem);
                contextMenu.Show(guna2CirclePictureBox1, e.Location);
            }
        }
    }
}