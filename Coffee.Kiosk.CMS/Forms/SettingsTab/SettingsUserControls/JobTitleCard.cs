using Coffee.Kiosk.CMS.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.SettingsTab.SettingsUserControls
{
    public partial class JobTitleCard : UserControl
    {
        public event EventHandler<int>? OnRemoveClicked;
        private OrganizationItem _item;

        public JobTitleCard()
        {
            InitializeComponent();
        }

        public void SetItem(OrganizationItem item)
        {
            _item = item;
            label1.Text = item.Name;

            if (item.IsDefault)
            {
                guna2Button1.Text = "default";
                guna2Button1.FillColor = Color.Gray;
                guna2Button1.Enabled = false;
            }
            else
            {
                guna2Button1.Text = "Remove";
                guna2Button1.FillColor = Color.Firebrick;
                guna2Button1.Enabled = true;
                guna2Button1.Click += (s, e) => OnRemoveClicked?.Invoke(this, _item.ID);
            }
        }
    }
}