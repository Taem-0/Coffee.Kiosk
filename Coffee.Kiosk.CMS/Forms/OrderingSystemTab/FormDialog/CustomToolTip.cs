using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.OrderingSystemTab.FormDialog
{
    public partial class CustomToolTip : Form
    {
        public CustomToolTip()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.BackColor = Color.LightYellow; // optional styling
            this.AutoSize = true; // adjusts automatically to content
        }

        public void ChangeToolTipText(string tipText)
        {
            label1.Text = tipText;
        }
    }
}
