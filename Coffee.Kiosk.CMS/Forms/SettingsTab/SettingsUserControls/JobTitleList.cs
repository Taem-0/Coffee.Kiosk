using Coffee.Kiosk.CMS.Controllers;
using Coffee.Kiosk.CMS.Models;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.SettingsTab.SettingsUserControls
{
    public partial class JobTitleList : UserControl
    {
        private OrganizationController? _controller;

        public JobTitleList()
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
            var items = _controller.GetJobTitles();
            RenderCards(items);
        }

        private void RenderCards(List<OrganizationItem> items)
        {
            this.Controls.Clear();
            int yOffset = 0;

            foreach (var item in items)
            {
                var card = new JobTitleCard();
                card.SetItem(item);
                card.Location = new System.Drawing.Point(0, yOffset);
                card.Width = this.Width;
                card.OnRemoveClicked += (s, id) =>
                {
                    _controller!.DeleteJobTitle(id);
                    Refresh();
                };
                this.Controls.Add(card);
                yOffset += card.Height + 2;
            }
        }
    }
}