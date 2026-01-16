using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS
{
    public partial class RegisterControl : UserControl
    {

        public AdminControlForm? ParentFormReference { get; set; }

        public RegisterControl()
        {
            InitializeComponent();
        }

        private void RegisterControl_Load(object sender, EventArgs e)
        {

        }
    }
}
