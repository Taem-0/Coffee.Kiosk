using Coffee.Kiosk.CMS.Controllers;
using Coffee.Kiosk.CMS.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.AccountsTab
{
    public partial class NewestRegisterView : Form
    {

        private readonly AccountController _controller;
        private readonly DisplayDTO _draft;

        public NewestRegisterView(AccountController controller, DisplayDTO draft)
        {
            InitializeComponent();
            _controller = controller ?? throw new ArgumentNullException(nameof(controller));
            _draft = draft ?? throw new ArgumentNullException(nameof(draft));

            LoadDraftValues();
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
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            _draft.FirstName = FirstNameTextBox.Text.Trim();
            _draft.MiddleName = MiddleNameTextBox.Text.Trim();
            _draft.LastName = LastNameTextBox.Text.Trim();
            _draft.PhoneNumber = PhoneTextBox.Text.Trim();
            _draft.Email = EmailTextBox.Text.Trim();
            _draft.EmergencyFirstName = EmergencyFirstNameTextBox.Text.Trim();
            _draft.EmergencyLastName = EmergencyLastNameTextBox.Text.Trim();
            _draft.EmergencyNumber = EmergencyPhoneTextBox.Text.Trim();

            using (var step2 = new SecondNewestRegisterView(_controller, _draft))
            {
                var result = step2.ShowDialog(this);
                if (result == DialogResult.Cancel)
                {
                    this.Close();
                }
                else if (result == DialogResult.OK)
                {
                    this.Close();
                }
                else if (result == DialogResult.Retry)
                {
                }
            }
        }

        private void CancelButton_Click_1(object sender, EventArgs e)
        {

            this.Close();
        }

        private void AddPfpButton_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Title = "Select Profile Picture";
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                ofd.Multiselect = false;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _draft.ProfilePicturePath = ofd.FileName;

                    PictureBox.Image = Image.FromFile(ofd.FileName);
                }
            }

            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {

        }
    }
}
