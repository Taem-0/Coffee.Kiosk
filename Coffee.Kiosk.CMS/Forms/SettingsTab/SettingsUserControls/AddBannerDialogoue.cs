using Coffee.Kiosk.CMS.Models;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.SettingsTab.SettingsUserControls
{
    public partial class AddBannerDialogoue : Form
    {
        public KioskBanner? Result { get; private set; }
        private string _selectedImagePath = string.Empty;
        private readonly KioskBanner? _existingBanner;

        // Default constructor — Add mode
        public AddBannerDialogoue()
        {
            InitializeComponent();
            SetupControls();
        }

        // Edit mode constructor
        public AddBannerDialogoue(KioskBanner existing)
        {
            InitializeComponent();
            _existingBanner = existing;
            SetupControls();
            PreFill(existing);
        }

        private void SetupControls()
        {
            placementSelection.Items.AddRange(new object[] { "Home Page", "Starting Screen", "Top Banner" });
            placementSelection.SelectedIndex = 0;

            for (int i = 1; i <= 20; i++)
                orderSelection.Items.Add(i);
            orderSelection.SelectedIndex = 0;

            bannerPictureBox.Click += PictureBox_Click;
            bannerPictureBox.Cursor = Cursors.Hand;

            cancelBannerButton.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
            clearPictureButton.Click += (s, e) =>
            {
                _selectedImagePath = string.Empty;
                bannerPictureBox.Image = null;
            };
        }

        private void PreFill(KioskBanner banner)
        {
            // Set placement
            int placementIndex = placementSelection.Items.IndexOf(banner.Placement);
            if (placementIndex >= 0) placementSelection.SelectedIndex = placementIndex;

            // Set order
            int orderIndex = orderSelection.Items.IndexOf(banner.DisplayOrder);
            if (orderIndex >= 0) orderSelection.SelectedIndex = orderIndex;

            // Load existing image
            if (!string.IsNullOrEmpty(banner.FilePath))
            {
                _selectedImagePath = banner.FilePath;
                bannerPictureBox.Image = LoadImageNonLocking(banner.FilePath);
                bannerPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void PictureBox_Click(object? sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.webp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _selectedImagePath = ofd.FileName;
                bannerPictureBox.Image = LoadImageNonLocking(_selectedImagePath);
                bannerPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (placementSelection.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a placement.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (orderSelection.SelectedIndex < 0)
            {
                MessageBox.Show("Please select an order number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Result = new KioskBanner
            {
                ID = _existingBanner?.ID ?? 0,
                FilePath = _selectedImagePath ?? string.Empty,
                Placement = placementSelection.SelectedItem?.ToString() ?? string.Empty,
                DisplayOrder = Convert.ToInt32(orderSelection.SelectedItem)
            };

            DialogResult = DialogResult.OK;
            Close();
        }

        private Image? LoadImageNonLocking(string path)
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
        private void AddBannerDialogoue_Load(object sender, EventArgs e) { }
    }
}