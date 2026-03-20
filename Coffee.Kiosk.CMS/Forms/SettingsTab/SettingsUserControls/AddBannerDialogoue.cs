using Coffee.Kiosk.CMS.Models;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.SettingsTab.SettingsUserControls
{
    public partial class AddBannerDialogoue : Form
    {
        public KioskBanner Result { get; private set; }

        private string _selectedImagePath = string.Empty;

        public AddBannerDialogoue()
        {
            InitializeComponent();

            // Populate placement options
            guna2ComboBox1.Items.AddRange(new object[] { "Home Page", "Starting Screen", "Top Banner" });
            guna2ComboBox1.SelectedIndex = 0;

            // Populate order numbers
            for (int i = 1; i <= 20; i++)
                guna2ComboBox2.Items.Add(i);
            guna2ComboBox2.SelectedIndex = 0;

            // Make picture box clickable
            guna2PictureBox1.Click += PictureBox_Click;
            guna2PictureBox1.Cursor = Cursors.Hand;

            saveButton.Click += SaveButton_Click;
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.webp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _selectedImagePath = ofd.FileName;
                guna2PictureBox1.Image = LoadImageNonLocking(_selectedImagePath);
                guna2PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

            if (guna2ComboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a placement.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (guna2ComboBox2.SelectedIndex < 0)
            {
                MessageBox.Show("Please select an order number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Result = new KioskBanner
            {
                FilePath = _selectedImagePath,
                Placement = guna2ComboBox1.SelectedItem.ToString(),
                DisplayOrder = (int)guna2ComboBox2.SelectedItem
            };

            DialogResult = DialogResult.OK;
            Close();
        }

        private Image LoadImageNonLocking(string path)
        {
            if (string.IsNullOrEmpty(path) || !File.Exists(path)) return null;
            try
            {
                using var fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                return Image.FromStream(fs);
            }
            catch { return null; }
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
    }
}