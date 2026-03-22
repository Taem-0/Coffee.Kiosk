using Coffee.Kiosk.CMS.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.SettingsTab.SettingsUserControls
{
    public partial class AddBannerDialogoue : Form
    {
        public KioskBanner? Result { get; private set; }
        private string _selectedImagePath = string.Empty;
        private readonly KioskBanner? _existingBanner;
        private readonly List<KioskBanner> _allBanners;

        // Add mode
        public AddBannerDialogoue(List<KioskBanner> allBanners)
        {
            InitializeComponent();
            _allBanners = allBanners;
            SetupControls();
        }

        // Edit mode
        public AddBannerDialogoue(KioskBanner existing, List<KioskBanner> allBanners)
        {
            InitializeComponent();
            _existingBanner = existing;
            _allBanners = allBanners;
            SetupControls();
            PreFill(existing);
        }

        private void SetupControls()
        {

            for (int i = 1; i <= 20; i++)
                orderSelection.Items.Add(i);
            orderSelection.SelectedIndex = 0;

            // Refresh taken slots whenever placement changes
            placementSelection.SelectedIndexChanged += (s, e) => RefreshOrderOptions();

            bannerPictureBox.Click += PictureBox_Click;
            bannerPictureBox.Cursor = Cursors.Hand;

            cancelBannerButton.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
            clearPictureButton.Click += (s, e) =>
            {
                _selectedImagePath = string.Empty;
                bannerPictureBox.Image = null;
            };

            // Run once on load for the default placement
            RefreshOrderOptions();
        }

        private void RefreshOrderOptions()
        {
            string selectedPlacement = placementSelection.SelectedItem?.ToString() ?? string.Empty;

            // Get taken order numbers for this placement
            // If editing, exclude the current banner's own slot so it stays selectable
            var takenOrders = _allBanners
                .Where(b => b.Placement == selectedPlacement
                         && b.ID != (_existingBanner?.ID ?? -1))
                .Select(b => b.DisplayOrder)
                .ToHashSet();

            // Remember current selection
            int currentSelection = orderSelection.SelectedIndex >= 0
                ? Convert.ToInt32(orderSelection.SelectedItem)
                : 1;

            orderSelection.Items.Clear();
            int firstAvailable = -1;

            for (int i = 1; i <= 20; i++)
            {
                if (!takenOrders.Contains(i))
                {
                    orderSelection.Items.Add(i);
                    if (firstAvailable < 0) firstAvailable = i;
                }
            }

            // Try to restore previous selection, fallback to first available
            int restoreIndex = orderSelection.Items.IndexOf(currentSelection);
            orderSelection.SelectedIndex = restoreIndex >= 0 ? restoreIndex : 0;
        }

        private void PreFill(KioskBanner banner)
        {
            int placementIndex = placementSelection.Items.IndexOf(banner.Placement);
            if (placementIndex >= 0) placementSelection.SelectedIndex = placementIndex;

            // RefreshOrderOptions fires from SelectedIndexChanged above
            // so just restore the order after
            int orderIndex = orderSelection.Items.IndexOf(banner.DisplayOrder);
            if (orderIndex >= 0) orderSelection.SelectedIndex = orderIndex;

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