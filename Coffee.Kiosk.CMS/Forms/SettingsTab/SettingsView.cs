using Coffee.Kiosk.CMS.Controllers;
using Coffee.Kiosk.CMS.DTOs;
using Coffee.Kiosk.CMS.Helpers;
using Coffee.Kiosk.CMS.Models;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.SettingsTab
{
    public partial class SettingsView : UserControl
    {
        private readonly AccountController _controller;
        private readonly Employee _currentEmployee;
        private readonly ThemeController _themeController;
        private string? _selectedImagePath;
        private Cyotek.Windows.Forms.ColorPickerDialog colorPickerDialog1 = new Cyotek.Windows.Forms.ColorPickerDialog();


        public SettingsView(AccountController controller, ThemeController themeController, Employee currentEmployee)
        {
            InitializeComponent();

            _controller = controller ?? throw new ArgumentNullException(nameof(controller));
            _themeController = themeController ?? throw new ArgumentNullException(nameof(themeController));
            _currentEmployee = currentEmployee ?? throw new ArgumentNullException(nameof(currentEmployee));
            _selectedImagePath = currentEmployee.ProfilePicturePath;

            var uiTheme = UIhelp.ThemeManager.BuildUITheme(_themeController, false);

            UIhelp.ThemeManager.ApplyTheme(this, uiTheme);

            primaryColorButton.FillColor = uiTheme.Primary;
            primaryDarkColorButton.FillColor = uiTheme.DarkPrimary;
            secondaryColorButton.FillColor = uiTheme.Secondary;
            backgroundColorButton.FillColor = uiTheme.Background;
            accentColorButton.FillColor = uiTheme.Accent;
            UploadLogoContainer.FillColor = uiTheme.Background;

            LoadCurrentEmployeeData();
            SetColorEditing(false);

        }

        #region ACCOUNT TAB
        private void LoadCurrentEmployeeData()
        {
            LoadProfilePicture();
            fullNameLabel.Text = $"{_currentEmployee.FirstName} {_currentEmployee.LastName}";
            emailLabel.Text = _currentEmployee.Email;
            phoneLabel.Text = _currentEmployee.PhoneNumber;
        }

        private void LoadProfilePicture()
        {
            if (!string.IsNullOrWhiteSpace(_selectedImagePath) && File.Exists(_selectedImagePath))
            {
                try
                {
                    using var img = Image.FromFile(_selectedImagePath);
                    guna2CirclePictureBox1.Image = new Bitmap(img);
                    guna2CirclePictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                catch
                {
                    //SetDefaultProfileImage();
                }
            }
            else
            {
                //SetDefaultProfileImage();
            }
        }



        private DisplayDTO GetCurrentDisplayDTO() => new()
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
            Role = _currentEmployee.Role.ToString(),
            Department = _currentEmployee.Department.ToString(),
            EmploymentType = _currentEmployee.EmploymentType.ToString(),
            Status = _currentEmployee.Status.ToString(),
            ProfilePicturePath = _currentEmployee.ProfilePicturePath
        };

        private bool TryUpdate(DisplayDTO dto, out string error)
        {
            error = null!;
            var result = _controller.Update(dto);
            if (!result.IsValid)
                error = string.Join(Environment.NewLine, result.Errors.Values);
            return result.IsValid;
        }

        private void pfpChangeButton_Click(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif",
                Title = "Select Profile Picture",
                Multiselect = false
            };

            if (dialog.ShowDialog() != DialogResult.OK) return;

            try
            {
                _selectedImagePath = dialog.FileName;
                using (var img = Image.FromFile(_selectedImagePath))
                {
                    guna2CirclePictureBox1.Image = new Bitmap(img);
                    guna2CirclePictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }

                var dto = GetCurrentDisplayDTO();
                dto.ProfilePicturePath = _selectedImagePath;

                if (!TryUpdate(dto, out var error))
                {
                    MessageBox.Show(error, "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _currentEmployee.ProfilePicturePath = _selectedImagePath;
                MessageBox.Show("Profile picture updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _selectedImagePath = _currentEmployee.ProfilePicturePath;
                LoadProfilePicture();
            }
        }

        private void pfpChangeButton_Click_1(object sender, EventArgs e) => pfpChangeButton_Click(sender, e);

        private void requestResetButton_Click(object sender, EventArgs e)
        {
            if (_currentEmployee.Role == AccountRole.OWNER || _currentEmployee.IsFirstLogin)
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

            using var dialog = new Coffee.Kiosk.CMS.Forms.Small_Dialogues.passwordChangeDialogue(
                _controller, _currentEmployee, isFirstLogin);

            dialog.PasswordChanged += (s, e) =>
            {
                if (isFirstLogin) _currentEmployee.IsFirstLogin = false;
            };

            dialog.StartPosition = FormStartPosition.CenterParent;
            dialog.ShowDialog();
        }

        private void RequestPasswordReset()
        {
            if (MessageBox.Show(
                "Request a password reset? An administrator will need to approve this.",
                "Request Password Reset",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                bool success = _controller.RequestPasswordReset(_currentEmployee.Id);
                MessageBox.Show(
                    success
                        ? "Password reset request submitted to administrator."
                        : "You already have a pending password reset request.",
                    success ? "Request Sent" : "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region ORGANIZATION TAB

        private void SetColorEditing(bool enabled)
        {
            primaryColorButton.Enabled = enabled;
            primaryDarkColorButton.Enabled = enabled;
            secondaryColorButton.Enabled = enabled;
            backgroundColorButton.Enabled = enabled;
            accentColorButton.Enabled = enabled;
        }

        private void SetButtonState(Guna.UI2.WinForms.Guna2Button button, bool enabled)
        {
            button.Enabled = enabled;

            if (enabled)
                button.FillColor = Color.FromArgb(255, button.FillColor);   
            else
                button.FillColor = Color.FromArgb(120, button.FillColor);  
        }

        private void selectThemeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isCustom = selectThemeComboBox.SelectedItem?.ToString() == "Custom";
            SetColorEditing(isCustom);
        }

        private void PickColor(Guna.UI2.WinForms.Guna2Button button)
        {
            colorPickerDialog1.Color = button.FillColor;

            if (colorPickerDialog1.ShowDialog() == DialogResult.OK)
            {
                button.FillColor = colorPickerDialog1.Color;
            }
        }

        private void primaryColorButton_Click(object sender, EventArgs e)
        {
            PickColor(primaryColorButton);
        }

        private void primaryDarkColorButton_Click(object sender, EventArgs e)
        {
            PickColor(primaryDarkColorButton);
        }

        private void secondaryColorButton_Click(object sender, EventArgs e)
        {
            PickColor(secondaryColorButton);
        }

        private void backgroundColorButton_Click(object sender, EventArgs e)
        {
            PickColor(backgroundColorButton);
        }

        private void accentColorButton_Click(object sender, EventArgs e)
        {
            PickColor(accentColorButton);
        }


        #endregion


    }
}