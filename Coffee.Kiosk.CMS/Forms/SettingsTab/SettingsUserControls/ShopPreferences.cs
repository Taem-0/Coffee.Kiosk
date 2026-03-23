using Coffee.Kiosk.CMS.Controllers;
using Coffee.Kiosk.CMS.Helpers;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.SettingsTab.SettingsUserControls
{
    public partial class ShopPreferences : UserControl
    {
        private ShopController _themeController;
        private Cyotek.Windows.Forms.ColorPickerDialog colorPickerDialog1 = new Cyotek.Windows.Forms.ColorPickerDialog();

        public ShopPreferences()
        {
            InitializeComponent();
            saveButton.Click += saveButton_Click;
            uploadLogoButton.Click += uploadLogoButton_Click;
            selectThemeComboBox.SelectedIndexChanged += selectThemeComboBox_SelectedIndexChanged;
            primaryColorButton.Click += (s, e) => PickColor(primaryColorButton);
            primaryDarkColorButton.Click += (s, e) => PickColor(primaryDarkColorButton);
            secondaryColorButton.Click += (s, e) => PickColor(secondaryColorButton);
            backgroundColorButton.Click += (s, e) => PickColor(backgroundColorButton);
            accentColorButton.Click += (s, e) => PickColor(accentColorButton);
        }

        public void Initialize(ShopController themeController)
        {
            _themeController = themeController ?? throw new ArgumentNullException(nameof(themeController));

            selectThemeComboBox.Items.Clear();
            selectThemeComboBox.Items.Add("Default");
            selectThemeComboBox.Items.Add("Custom");

            var currentShop = _themeController.GetShopSettings();

            selectThemeComboBox.SelectedItem = currentShop.ThemeMode?.Equals("custom", StringComparison.OrdinalIgnoreCase) == true
                ? "Custom"
                : "Default";

            shopNameTextBox.Text = currentShop.ShopName;

            RestoreColorButtons();
            SetColorEditing(selectThemeComboBox.SelectedItem?.ToString() == "Custom");
            LoadLogoImage(currentShop.LogoPath);

            UIhelp.ThemeManager.ThemeChanged += (s, theme) =>
            {
                if (InvokeRequired) { Invoke(() => RestoreColorButtons()); return; }
                RestoreColorButtons();
            };
        }

        private void RestoreColorButtons()
        {
            var uiTheme = UIhelp.ThemeManager.BuildUITheme(_themeController);
            primaryColorButton.FillColor = uiTheme.Primary;
            primaryDarkColorButton.FillColor = uiTheme.DarkPrimary;
            secondaryColorButton.FillColor = uiTheme.Secondary;
            backgroundColorButton.FillColor = uiTheme.Background;
            accentColorButton.FillColor = uiTheme.Accent;
            UploadLogoContainer.FillColor = uiTheme.Background;
        }

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
            SetColorEditing(selectThemeComboBox.SelectedItem?.ToString() == "Custom");
        }

        private void PickColor(Guna.UI2.WinForms.Guna2Button button)
        {
            colorPickerDialog1.Color = button.FillColor;
            if (colorPickerDialog1.ShowDialog() == DialogResult.OK)
                button.FillColor = colorPickerDialog1.Color;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var shop = _themeController.GetShopSettings();

            shop.ShopName = shopNameTextBox.Text.Trim();

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

            UIhelp.ThemeManager.ApplyTheme(this.ParentForm, uiTheme);
            UIhelp.ThemeManager.NotifyThemeChanged(uiTheme);

            // Restore color buttons AFTER ApplyTheme paints over them
            RestoreColorButtons();

            MessageBox.Show("Settings saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void uploadLogoButton_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.webp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var shop = _themeController.GetShopSettings();
                    shop.LogoPath = ofd.FileName;
                    _themeController.UpdateShopSettings(shop);
                    LoadLogoImage(ofd.FileName);
                    MessageBox.Show("Logo updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to save logo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadLogoImage(string? path)
        {
            if (string.IsNullOrEmpty(path) || !File.Exists(path)) return;
            try
            {
                using var fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                LogoPictureBox.Image = System.Drawing.Image.FromStream(fs);
                LogoPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch { }
        }
    }
}