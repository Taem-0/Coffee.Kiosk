using Coffee.Kiosk.CMS.CoffeeKDB;
using Coffee.Kiosk.CMS.Helpers;
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
    public partial class EmployeesControl : UserControl
    {

        private RegisterControl registerControl = new RegisterControl();

        public AdminControlForm? ParentFormReference { get; set; }


        public EmployeesControl()
        {
            InitializeComponent();

            UIhelp.buttonNaRound(addEmpButton, 20);
        }

        private void addEmpButton_Click(object sender, EventArgs e)
        {
            if (ParentFormReference == null) return;

            registerControl.ParentFormReference = ParentFormReference;

            ParentFormReference.ShowInAccountsPanel(registerControl);
        }


    }
}
