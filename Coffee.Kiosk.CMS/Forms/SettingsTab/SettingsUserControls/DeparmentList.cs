using Coffee.Kiosk.CMS.Controllers;
using Coffee.Kiosk.CMS.Models;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.SettingsTab.SettingsUserControls
{
    public partial class DeparmentList : UserControl
    {
        private OrganizationController? _controller;

        public DeparmentList()
        {
            InitializeComponent();
        }

        public void Initialize(OrganizationController controller)
        {
            _controller = controller;
            Refresh();
        }

        public void Refresh()
        {
            if (_controller == null) return;
            var items = _controller.GetDepartments();
            RenderCards(items);
        }

        private void RenderCards(List<OrganizationItem> items)
        {
            this.Controls.Clear();
            int yOffset = 0;

            foreach (var item in items)
            {
                var card = new DepartmentCard();
                card.SetItem(item);
                card.Location = new System.Drawing.Point(0, yOffset);
                card.Width = this.Width;
                card.OnRemoveClicked += (s, id) =>
                {
                    _controller!.DeleteDepartment(id);
                    Refresh();
                };
                this.Controls.Add(card);
                yOffset += card.Height + 2;
            }
        }
    }
}