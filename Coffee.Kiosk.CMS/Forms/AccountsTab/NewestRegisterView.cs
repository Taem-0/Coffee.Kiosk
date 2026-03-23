using Coffee.Kiosk.CMS.Controllers;
using Coffee.Kiosk.CMS.DTOs;
using Coffee.Kiosk.CMS.Helpers;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.AccountsTab
{
    public partial class NewestRegisterView : Form
    {
        private readonly AccountController _controller;
        private readonly DisplayDTO _draft;
        private readonly ShopController _themeController;
        private Color _darkBrown;
        private Color _mediumBrown;
        private Color _lightBrown;
        private Color _beige;
        private Color _background;

        public NewestRegisterView(AccountController controller, DisplayDTO draft, ShopController themeController)
        {
            InitializeComponent();
            _controller = controller ?? throw new ArgumentNullException(nameof(controller));
            _draft = draft ?? throw new ArgumentNullException(nameof(draft));
            _themeController = themeController ?? throw new ArgumentNullException(nameof(themeController));

            var uiTheme = UIhelp.ThemeManager.BuildUITheme(_themeController);
            _darkBrown = uiTheme.DarkPrimary;
            _mediumBrown = uiTheme.Primary;
            _lightBrown = uiTheme.Secondary;
            _beige = uiTheme.Accent;
            _background = uiTheme.Background;

            ApplyTheme();
            WireUpEvents();
            LoadDraftValues();

            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void ApplyTheme()
        {
            this.BackColor = _background;
            this.ForeColor = _darkBrown;
            this.Padding = new Padding(20);

            guna2Panel1.FillColor = _mediumBrown;
            guna2Panel1.BackColor = _mediumBrown;
            guna2Panel1.BorderColor = _darkBrown;
            guna2Panel1.BorderThickness = 1;

            tableLayoutPanel1.BackColor = _beige;

            label1.ForeColor = _darkBrown; label1.BackColor = Color.Transparent;
            label2.ForeColor = _darkBrown; label2.BackColor = Color.Transparent;
            label3.ForeColor = _darkBrown; label3.BackColor = Color.Transparent;
            label4.ForeColor = _darkBrown; label4.BackColor = Color.Transparent;
            label5.ForeColor = _darkBrown; label5.BackColor = Color.Transparent;
            label6.ForeColor = _darkBrown; label6.BackColor = Color.Transparent;
            label7.ForeColor = _darkBrown; label7.BackColor = Color.Transparent;
            label8.ForeColor = _darkBrown; label8.BackColor = Color.Transparent;
            label9.ForeColor = _darkBrown; label9.BackColor = Color.Transparent;
            label10.ForeColor = _darkBrown; label10.BackColor = Color.Transparent;
            label17.ForeColor = Color.White; label17.BackColor = Color.Transparent;

            ConfigureButton(NextButton);
            ConfigureButton(CancelButton);
            ConfigureCircleButton(AddPfpButton);

            ApplyTextBoxTheme(FirstNameTextBox);
            ApplyTextBoxTheme(MiddleNameTextBox);
            ApplyTextBoxTheme(LastNameTextBox);
            ApplyTextBoxTheme(PhoneTextBox);
            ApplyTextBoxTheme(EmailTextBox);
            ApplyTextBoxTheme(EmergencyFirstNameTextBox);
            ApplyTextBoxTheme(EmergencyLastNameTextBox);
            ApplyTextBoxTheme(EmergencyPhoneTextBox);

            PictureBox.FillColor = Color.White;
        }

        private void ConfigureButton(Guna.UI2.WinForms.Guna2Button button)
        {
            button.FillColor = _mediumBrown;
            button.ForeColor = Color.White;
            button.BorderColor = _darkBrown;
            button.BorderThickness = 1;
            button.HoverState.FillColor = _lightBrown;
            button.HoverState.BorderColor = _darkBrown;
            button.PressedColor = _darkBrown;
            button.BorderRadius = 15;
        }

        private void ConfigureCircleButton(Guna.UI2.WinForms.Guna2CircleButton button)
        {
            button.FillColor = _mediumBrown;
            button.ForeColor = Color.White;
            button.BorderColor = _darkBrown;
            button.BorderThickness = 1;
            button.HoverState.FillColor = _lightBrown;
            button.HoverState.BorderColor = _darkBrown;
            button.PressedColor = _darkBrown;
        }

        private void ApplyTextBoxTheme(Guna.UI2.WinForms.Guna2TextBox textBox)
        {
            textBox.BorderColor = _mediumBrown;
            textBox.FocusedState.BorderColor = _lightBrown;
            textBox.HoverState.BorderColor = _lightBrown;
            textBox.FillColor = Color.White;
            textBox.ForeColor = _darkBrown;
            textBox.PlaceholderForeColor = Color.Gray;
            textBox.BorderRadius = 8;
        }

        private void WireUpEvents()
        {
            FirstNameTextBox.TextChanged += (s, e) => ClearError(FirstNameTextBox);
            MiddleNameTextBox.TextChanged += (s, e) => ClearError(MiddleNameTextBox);
            LastNameTextBox.TextChanged += (s, e) => ClearError(LastNameTextBox);
            PhoneTextBox.TextChanged += (s, e) => ClearError(PhoneTextBox);
            EmailTextBox.TextChanged += (s, e) => ClearError(EmailTextBox);
            EmergencyFirstNameTextBox.TextChanged += (s, e) => ClearError(EmergencyFirstNameTextBox);
            EmergencyLastNameTextBox.TextChanged += (s, e) => ClearError(EmergencyLastNameTextBox);
            EmergencyPhoneTextBox.TextChanged += (s, e) => ClearError(EmergencyPhoneTextBox);
            PictureBox.MouseClick += PictureBox_MouseClick;
        }

        private void LoadDraftValues()
        {
            FirstNameTextBox.Text = _draft.FirstName;
            MiddleNameTextBox.Text = _draft.MiddleName;
            LastNameTextBox.Text = _draft.LastName;
            PhoneTextBox.Text = _draft.PhoneNumber;
            EmailTextBox.Text = _draft.Email;
            EmergencyFirstNameTextBox.Text = _draft.EmergencyFirstName;
            EmergencyLastNameTextBox.Text = _draft.EmergencyLastName;
            EmergencyPhoneTextBox.Text = _draft.EmergencyNumber;

            if (!string.IsNullOrEmpty(_draft.ProfilePicturePath) && File.Exists(_draft.ProfilePicturePath))
            {
                try { PictureBox.Image = Image.FromFile(_draft.ProfilePicturePath); }
                catch { PictureBox.Image = null; }
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (!ValidateAllFields()) return;

            _draft.FirstName = FirstNameTextBox.Text.Trim();
            _draft.MiddleName = MiddleNameTextBox.Text.Trim();
            _draft.LastName = LastNameTextBox.Text.Trim();
            _draft.PhoneNumber = PhoneTextBox.Text.Trim();
            _draft.Email = EmailTextBox.Text.Trim();
            _draft.EmergencyFirstName = EmergencyFirstNameTextBox.Text.Trim();
            _draft.EmergencyLastName = EmergencyLastNameTextBox.Text.Trim();
            _draft.EmergencyNumber = EmergencyPhoneTextBox.Text.Trim();

            using var step2 = new SecondNewestRegisterView(_controller, _draft, _themeController);
            var result = step2.ShowDialog(this);
            if (result == DialogResult.Cancel || result == DialogResult.OK)
                this.Close();
        }

        private void CancelButton_Click_1(object sender, EventArgs e) => this.Close();

        private void AddPfpButton_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Title = "Select Profile Picture",
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif",
                Multiselect = false
            };

            if (ofd.ShowDialog() != DialogResult.OK) return;

            _draft.ProfilePicturePath = ofd.FileName;
            try { PictureBox.Image = Image.FromFile(ofd.FileName); }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowError(Guna.UI2.WinForms.Guna2TextBox textBox, string errorMessage, bool clearInput = false)
        {
            textBox.BorderColor = UIhelp.ThemeColors.ErrorColor;
            textBox.FocusedState.BorderColor = UIhelp.ThemeColors.ErrorColor;
            textBox.HoverState.BorderColor = UIhelp.ThemeColors.ErrorColor;
            textBox.PlaceholderText = errorMessage;
            textBox.PlaceholderForeColor = UIhelp.ThemeColors.ErrorColor;
            if (clearInput) textBox.Text = "";
        }

        private void ClearError(Guna.UI2.WinForms.Guna2TextBox textBox)
        {
            textBox.BorderColor = _mediumBrown;
            textBox.FocusedState.BorderColor = _lightBrown;
            textBox.HoverState.BorderColor = _lightBrown;
            textBox.PlaceholderText = "";
            textBox.PlaceholderForeColor = Color.Gray;
        }

        private void ClearAllErrors()
        {
            ClearError(FirstNameTextBox);
            ClearError(MiddleNameTextBox);
            ClearError(LastNameTextBox);
            ClearError(PhoneTextBox);
            ClearError(EmailTextBox);
            ClearError(EmergencyFirstNameTextBox);
            ClearError(EmergencyLastNameTextBox);
            ClearError(EmergencyPhoneTextBox);
        }

        private bool ValidateAllFields()
        {
            ClearAllErrors();
            bool isValid = true;
            bool firstErrorFocused = false;

            void Flag(Guna.UI2.WinForms.Guna2TextBox tb, string msg)
            {
                ShowError(tb, msg, true);
                isValid = false;
                if (!firstErrorFocused) { tb.Focus(); firstErrorFocused = true; }
            }

            if (string.IsNullOrWhiteSpace(FirstNameTextBox.Text))
                Flag(FirstNameTextBox, "First name is required");

            if (string.IsNullOrWhiteSpace(LastNameTextBox.Text))
                Flag(LastNameTextBox, "Last name is required");

            if (string.IsNullOrWhiteSpace(EmailTextBox.Text))
                Flag(EmailTextBox, "Email is required");
            else if (!IsValidEmail(EmailTextBox.Text))
                Flag(EmailTextBox, "Please enter a valid email address");

            if (string.IsNullOrWhiteSpace(PhoneTextBox.Text))
                Flag(PhoneTextBox, "Phone number is required");

            return isValid;
        }

        private bool IsValidEmail(string email)
        {
            try { var a = new System.Net.Mail.MailAddress(email); return a.Address == email; }
            catch { return false; }
        }

        private void PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right || PictureBox.Image == null) return;
            if (MessageBox.Show("Remove profile picture?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _draft.ProfilePicturePath = null;
                PictureBox.Image = null;
                PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void PictureBox_Click(object sender, EventArgs e) { }
    }
}