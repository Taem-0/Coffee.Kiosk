using Coffee.Kiosk.CMS.Controllers;
using Coffee.Kiosk.CMS.DTOs;
using Coffee.Kiosk.CMS.Forms.SettingsTab.SettingsUserControls;
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

        private readonly KioskController _kioskController;
        private readonly AccountController _controller;
        private readonly Employee _currentEmployee;
        private readonly ShopController _themeController;
        private string? _selectedImagePath;
        private Cyotek.Windows.Forms.ColorPickerDialog colorPickerDialog1 = new Cyotek.Windows.Forms.ColorPickerDialog();


        public SettingsView(AccountController controller, ShopController themeController, KioskController kioskController, Employee currentEmployee)
        {
            InitializeComponent();

            bannerUpload1.Initialize(kioskController);

            _controller = controller ?? throw new ArgumentNullException(nameof(controller));
            _themeController = themeController ?? throw new ArgumentNullException(nameof(themeController));
            _kioskController = kioskController ?? throw new ArgumentNullException(nameof(kioskController));
            _currentEmployee = currentEmployee ?? throw new ArgumentNullException(nameof(currentEmployee));

            _selectedImagePath = currentEmployee.ProfilePicturePath;

            var uiTheme = UIhelp.ThemeManager.BuildUITheme(_themeController);
            UIhelp.ThemeManager.ApplyTheme(this, uiTheme);

            primaryColorButton.FillColor = uiTheme.Primary;
            primaryDarkColorButton.FillColor = uiTheme.DarkPrimary;
            secondaryColorButton.FillColor = uiTheme.Secondary;
            backgroundColorButton.FillColor = uiTheme.Background;
            accentColorButton.FillColor = uiTheme.Accent;
            UploadLogoContainer.FillColor = uiTheme.Background;

            selectThemeComboBox.Items.Clear();
            selectThemeComboBox.Items.Add("Default");
            selectThemeComboBox.Items.Add("Custom");

            var currentShop = _themeController.GetShopSettings();
            selectThemeComboBox.SelectedItem = currentShop.ThemeMode?.Equals("custom", StringComparison.OrdinalIgnoreCase) == true
                ? "Custom"
                : "Default";

            LoadCurrentEmployeeData();

            //KioskLoad:


            SwitchScreen(miniGetStartedScreen1);



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

                using var img = Image.FromFile(_selectedImagePath);
                guna2CirclePictureBox1.Image = new Bitmap(img);
                guna2CirclePictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
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

        private void saveButton_Click(object sender, EventArgs e)
        {
            var shop = _themeController.GetShopSettings();

            bool isCustom = selectThemeComboBox.SelectedItem?.ToString() == "Custom";
            shop.ThemeMode = isCustom ? "custom" : "default";

            if (isCustom)
            {
                shop.PrimaryColor = ColorTranslator.ToHtml(primaryColorButton.FillColor);
                shop.DarkPrimaryColor = ColorTranslator.ToHtml(primaryDarkColorButton.FillColor);
                shop.SecondaryColor = ColorTranslator.ToHtml(secondaryColorButton.FillColor);
                shop.BackgroundColor = ColorTranslator.ToHtml(backgroundColorButton.FillColor);
                shop.AccentColor = ColorTranslator.ToHtml(accentColorButton.FillColor);
            }
            else
            {
                shop.PrimaryColor = "#6F4D38";
                shop.DarkPrimaryColor = "#3D211A";
                shop.SecondaryColor = "#A07856";
                shop.BackgroundColor = "#F5F5DC";
                shop.AccentColor = "#CBB799";
            }

            _themeController.UpdateShopSettings(shop);

            var uiTheme = UIhelp.ThemeManager.BuildUITheme(_themeController);
            primaryColorButton.FillColor = uiTheme.Primary;
            primaryDarkColorButton.FillColor = uiTheme.DarkPrimary;
            secondaryColorButton.FillColor = uiTheme.Secondary;
            backgroundColorButton.FillColor = uiTheme.Background;
            accentColorButton.FillColor = uiTheme.Accent;

            UIhelp.ThemeManager.ApplyTheme(this, uiTheme);

            primaryColorButton.FillColor = uiTheme.Primary;
            primaryDarkColorButton.FillColor = uiTheme.DarkPrimary;
            secondaryColorButton.FillColor = uiTheme.Secondary;
            backgroundColorButton.FillColor = uiTheme.Background;
            accentColorButton.FillColor = uiTheme.Accent;
            UploadLogoContainer.FillColor = uiTheme.Background;
        }

        #endregion

        #region KIOSK TAB




        private void LeftSlideButton_Click(object sender, EventArgs e)
        {
            if (miniGetStartedScreen1.Visible) 
            {
                SwitchScreen(miniThankYouScreen1);
            }
            else if (miniDineInTakeOut1.Visible)
            {
                SwitchScreen(miniGetStartedScreen1);
            }
            else if (miniHomePage1.Visible)
            {
                SwitchScreen(miniDineInTakeOut1);
            }
            else if (miniKioskMenu1.Visible)
            {
                SwitchScreen(miniHomePage1);
            }
            else if (miniModalScreen1.Visible)
            {
                SwitchScreen(miniKioskMenu1);
            }
            else if (miniViewOrder1.Visible)
            {
                SwitchScreen(miniModalScreen1);
            }
            else if (miniThankYouScreen1.Visible)
            {
                SwitchScreen(miniViewOrder1);
            }
        }

        private void RightSlideButton_Click(object sender, EventArgs e)
        {
            if (miniGetStartedScreen1.Visible)
            {
                SwitchScreen(miniDineInTakeOut1);
            }
            else if (miniDineInTakeOut1.Visible)
            {
                SwitchScreen(miniHomePage1);
            }
            else if (miniHomePage1.Visible)
            {
                SwitchScreen(miniKioskMenu1);
            }
            else if (miniKioskMenu1.Visible) 
            {
                SwitchScreen(miniModalScreen1);
            }
            else if (miniModalScreen1.Visible) 
            {
                SwitchScreen(miniViewOrder1);
            }
            else if (miniViewOrder1.Visible)
            {
                SwitchScreen(miniThankYouScreen1);
            }
            else if (miniThankYouScreen1.Visible)
            {
                SwitchScreen(miniGetStartedScreen1);
            }
        }

        private void SwitchScreen(UserControl targetScreen)
        {
            UserControl[] allScreens = {
                miniGetStartedScreen1,
                miniDineInTakeOut1,
                miniHomePage1,
                miniKioskMenu1,
                miniModalScreen1,
                miniViewOrder1,
                miniThankYouScreen1
            };

            foreach (var screen in allScreens)
            {
                screen.Visible = (screen == targetScreen);
            }

            targetScreen.BringToFront();
        }

        #endregion

            targetScreen.BringToFront();
        }



        

        #endregion

    }
}