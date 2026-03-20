using Coffee.Kiosk.CMS.Models;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.SettingsTab.SettingsUserControls
{
    public class BannerSelectBase : UserControl
    {
        public int BannerID { get; set; }
        public string CurrentImagePath { get; private set; }
        public event EventHandler OnSelected;
        public Color SelectionColor { get; set; } = Color.DodgerBlue;

        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                UpdateSelectionVisual();
            }
        }

        protected void HookClicks()
        {
            this.Click += Card_Click;
            foreach (Control child in this.Controls)
                child.Click += Card_Click;
        }

        private void Card_Click(object sender, EventArgs e)
        {
            if (_isSelected)
                IsSelected = false;
            else
            {
                IsSelected = true;
                OnSelected?.Invoke(this, EventArgs.Empty);
            }
        }

        private void UpdateSelectionVisual()
        {
            this.BackColor = _isSelected ? SelectionColor : Color.Transparent;
            this.Padding = _isSelected ? new Padding(3) : new Padding(0);
            this.Refresh();
        }

        public void SetImage(Image img, string path)
        {
            var pb = GetPictureBox();
            if (pb == null) return;

            if (pb.Image != null)
                pb.Image.Dispose();

            pb.Image = img;
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            CurrentImagePath = path;
            pb.Invalidate();
        }

        // Each subclass tells the base where its picture box is
        protected virtual Guna.UI2.WinForms.Guna2PictureBox GetPictureBox() => null;
    }
}