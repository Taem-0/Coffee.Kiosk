using Coffee.Kiosk.CMS.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.SettingsTab.SettingsUserControls
{
    public partial class DepartmentCard : UserControl
    {
        public event EventHandler<int>? OnRemoveClicked;
        private OrganizationItem _item;

        public DepartmentCard()
        {
            InitializeComponent();
        }

        public void SetItem(OrganizationItem item)
        {
            _item = item;
            label1.Text = item.Name;

            if (item.IsDefault)
            {
                removeButton.Text = "default";
                removeButton.FillColor = Color.Gray;
                removeButton.Enabled = false;
            }
            else
            {
                removeButton.Text = "Remove";
                removeButton.FillColor = Color.Firebrick;
                removeButton.Enabled = true;
                removeButton.Click += (s, e) => OnRemoveClicked?.Invoke(this, _item.ID);
            }
        }
    }
}