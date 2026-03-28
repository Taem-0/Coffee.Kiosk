using Coffee.Kiosk.CMS.Controllers;
using Coffee.Kiosk.CMS.DTOs;
using Coffee.Kiosk.CMS.Forms.SettingsTab.SettingsUserControls;
using Coffee.Kiosk.CMS.Helpers;
using Coffee.Kiosk.CMS.Models;
using Guna.UI2.WinForms;
using System.IO;


namespace Coffee.Kiosk.CMS.Forms.SettingsTab
{
    public partial class SettingsView : UserControl
    {

        private readonly KioskController _kioskController;
        private readonly AccountController _controller;
        private readonly Employee _currentEmployee;
        private readonly ShopController _themeController;
        private readonly OrganizationController _orgController;
        private string? _selectedImagePath;
        private Cyotek.Windows.Forms.ColorPickerDialog colorPickerDialog1 = new Cyotek.Windows.Forms.ColorPickerDialog();


        public SettingsView(AccountController controller, ShopController themeController, KioskController kioskController, OrganizationController orgController, Employee currentEmployee)
        {
            InitializeComponent();


            _controller = controller ?? throw new ArgumentNullException(nameof(controller));
            _themeController = themeController ?? throw new ArgumentNullException(nameof(themeController));
            _kioskController = kioskController ?? throw new ArgumentNullException(nameof(kioskController));
            _currentEmployee = currentEmployee ?? throw new ArgumentNullException(nameof(currentEmployee));

            _selectedImagePath = currentEmployee.ProfilePicturePath;


            var uiTheme = UIhelp.ThemeManager.BuildUITheme(_themeController);
            UIhelp.ThemeManager.ApplyTheme(this, uiTheme);

            RightSlideButton.BackColor = Color.Transparent;
            LeftSlideButton.BackColor = Color.Transparent;


            shopPreferences1.Initialize(themeController);
            //jobTitles1.Initialize(orgController);
            LoadCurrentEmployeeData();


            //KioskLoad:

            RightSlideButton.BackColor = Color.Transparent;
            LeftSlideButton.BackColor = Color.Transparent;
            bannerUpload1.Initialize(kioskController);
            RefreshPreviews();
            SwitchScreen(miniGetStartedScreen1);
            bannerUpload1.BannersChanged += (s, e) => RefreshPreviews();
            RightSlideButton.BackColor = uiTheme.Background;
            LeftSlideButton.BackColor = uiTheme.Background;


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

        #region KIOSK TAB


        private void LeftSlideButton_Click(object sender, EventArgs e)
        {
            if (miniGetStartedScreen1.Visible)
                SwitchScreen(miniKioskMenu1);
            else if (miniKioskMenu1.Visible)
                SwitchScreen(miniGetStartedScreen1);
        }

        private void RightSlideButton_Click(object sender, EventArgs e)
        {
            if (miniGetStartedScreen1.Visible)
                SwitchScreen(miniKioskMenu1);
            else if (miniKioskMenu1.Visible)
                SwitchScreen(miniGetStartedScreen1);
        }

        private void SwitchScreen(UserControl targetScreen)
        {
            UserControl[] allScreens = {
                miniGetStartedScreen1,
                miniKioskMenu1
            };

            foreach (var screen in allScreens)
                screen.Visible = (screen == targetScreen);

            targetScreen.BringToFront();
        }

        private void RefreshPreviews()
        {


            var banners = _kioskController.GetAllBanners();

            var startingBanner = banners
                .Where(b => b.Placement == "Starting Screen")
                .OrderBy(b => b.DisplayOrder)
                .FirstOrDefault();

            var topBanner = banners
                .Where(b => b.Placement == "Top Banner")
                .OrderBy(b => b.DisplayOrder)
                .FirstOrDefault();

            var homeBanner1 = banners
                .Where(b => b.Placement == "Home Page Banner 1")
                .OrderBy(b => b.DisplayOrder)
                .FirstOrDefault();

            var homeBanner2 = banners
                .Where(b => b.Placement == "Home Page Banner 2")
                .OrderBy(b => b.DisplayOrder)
                .FirstOrDefault();


            miniGetStartedScreen1.SetBanner(LoadPreviewImage(startingBanner?.FilePath));
            miniKioskMenu1.SetTopBanner(LoadPreviewImage(topBanner?.FilePath));
            miniKioskMenu1.SetPromoBanner1(LoadPreviewImage(homeBanner1?.FilePath));
            miniKioskMenu1.SetPromoBanner2(LoadPreviewImage(homeBanner2?.FilePath));


        }

        #endregion

        private Image? LoadPreviewImage(string? path)
        {
            if (string.IsNullOrEmpty(path) || !File.Exists(path)) return null;
            try
            {
                using var fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                return Image.FromStream(fs);
            }
            catch { return null; }
        }


    }







}