using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.QuickDialogues
{
    public partial class DeactivateDialogue : Form
    {
        public bool Confirmed { get; private set; } = false;

        public DeactivateDialogue()
        {
            InitializeComponent();
            saveButton.Click += (s, e) => { Confirmed = true; this.Close(); };
            cancelBannerButton.Click += (s, e) => { Confirmed = false; this.Close(); };
        }
    }
}
