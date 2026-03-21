using Coffee.Kiosk.CMS.Controllers;
using Coffee.Kiosk.CMS.Models;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.SettingsTab.SettingsUserControls
{
    public partial class BannerUpload : UserControl
    {
        private KioskController _kioskController;

        public BannerUpload()
        {
            InitializeComponent();
        }

        public void Initialize(KioskController controller)
        {
            _kioskController = controller;
            RefreshCards();
        }

        public void SetThemeColor(Color selectionColor)
        {
            foreach (Control c in bannersFlowLayout.Controls)
            {
                if (c is BannerSelectBase card)
                    card.SelectionColor = selectionColor;
            }
        }

        private void RefreshCards()
        {
            foreach (Control c in bannersFlowLayout.Controls)
            {
                if (c is BannerSelectBase card)
                    card.OnSelected -= ManagedSelection;
            }
            bannersFlowLayout.Controls.Clear();

            var banners = _kioskController.GetAllBanners();
            foreach (var banner in banners)
            {
                var card = CreateCard(banner);
                bannersFlowLayout.Controls.Add(card);
            }
        }

        private BannerSelectBase CreateCard(KioskBanner banner)
        {
            BannerSelectBase card = banner.Placement == "Starting Screen"
                ? new BannerSelectVertical()
                : new BannerSelectHorizontal();

            card.BannerID = banner.ID;
            card.Placement = banner.Placement;
            card.DisplayOrder = banner.DisplayOrder;
            card.OnSelected += ManagedSelection;
            card.SetImage(LoadImageNonLocking(banner.FilePath), banner.FilePath);
            return card;
        }

        private void ManagedSelection(object? sender, EventArgs e)
        {
            foreach (Control c in bannersFlowLayout.Controls)
            {
                if (c is BannerSelectBase card && card != sender)
                    card.IsSelected = false;
            }
        }

        private void UploadTileButton_Click_1(object sender, EventArgs e)
        {
            if (_kioskController == null) return;

            // Check if a card is selected — edit mode
            BannerSelectBase? selectedCard = null;
            foreach (Control c in bannersFlowLayout.Controls)
            {
                if (c is BannerSelectBase card && card.IsSelected)
                {
                    selectedCard = card;
                    break;
                }
            }

            // Build the existing banner if editing
            KioskBanner? existing = null;
            if (selectedCard != null)
            {
                existing = new KioskBanner
                {
                    ID = selectedCard.BannerID,
                    FilePath = selectedCard.CurrentImagePath ?? string.Empty,
                    Placement = selectedCard.Placement,
                    DisplayOrder = selectedCard.DisplayOrder
                };
            }

            // Open dialogue in correct mode
            using var dialogue = existing != null
                ? new AddBannerDialogoue(existing)
                : new AddBannerDialogoue();

            if (dialogue.ShowDialog() == DialogResult.OK)
            {
                if (dialogue.Result == null) return;

                try
                {
                    if (existing != null)
                        _kioskController.UpdateBanner(dialogue.Result);
                    else
                        _kioskController.AddBanner(dialogue.Result);

                    RefreshCards();
                    MessageBox.Show(
                        existing != null ? "Banner updated!" : "Banner added!",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to save: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
    }
}