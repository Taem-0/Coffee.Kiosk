using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.OrderingSystemTab.UserControls
{
    public partial class TipButton : UserControl
    {

        private FormDialog.CustomToolTip currentToolTip = new FormDialog.CustomToolTip();
        public TipButton()
        {
            InitializeComponent();
        }

        private string tipText = "";

        [Category("Tip"), Description("Text to display when hovering")]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        public string TipText
        {
            get => tipText;
            set => tipText = value;
        }


        public void ShowToolTip(String tipText)
        {
            currentToolTip.ChangeToolTipText(tipText);

            currentToolTip.ChangeToolTipText(tipText);

            Point screenPos = Cursor.Position;
            currentToolTip.Location = new Point(screenPos.X + 10, screenPos.Y + 10);

            currentToolTip.Show();
        }
        public void ShowToolTip()
        {
            currentToolTip.ChangeToolTipText(tipText);
            Point screenPos = Cursor.Position;
            currentToolTip.Location = new Point(screenPos.X + 10, screenPos.Y + 10);
            currentToolTip.Show();
        }

        public void HideToolTip()
        {
            currentToolTip.Hide();
        }

        private void TIpBtn_MouseEnter(object sender, EventArgs e)
        {
            ShowToolTip();
        }

        private void TIpBtn_MouseLeave(object sender, EventArgs e)
        {
            HideToolTip();
        }
    }
}