using Coffee.Kiosk.CMS.CoffeeKDB;
using Coffee.Kiosk.CMS.Controllers;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Coffee.Kiosk.CMS
{
    public partial class EmployeesControl : UserControl
    {
        private RegistrationController _controller;

        public AdminControlForm? ParentFormReference { get; set; }

        public EmployeesControl(RegistrationController controller)
        {
            InitializeComponent();

            _controller = controller ?? throw new ArgumentNullException(nameof(controller));

            UIhelp.buttonNaRound(addEmpButton, 20);
        }


        private void addEmpButton_Click(object sender, EventArgs e)
        {
            if (ParentFormReference == null) return;

            ParentFormReference.ShowInAccountsPanel(
                new RegisterControl(_controller)
                {
                    ParentFormReference = ParentFormReference
                }
            );
        }


        private void EmployeeListView_Resize(object sender, EventArgs e)
        {
 
            int totalWidth = EmployeeListView.ClientSize.Width;

            EmployeeListView.Columns[0].Width = (int)(totalWidth * 0.15); 
            EmployeeListView.Columns[1].Width = (int)(totalWidth * 0.15); 
            EmployeeListView.Columns[2].Width = (int)(totalWidth * 0.15);
            EmployeeListView.Columns[3].Width = (int)(totalWidth * 0.15); 
            EmployeeListView.Columns[4].Width = (int)(totalWidth * 0.15); 
            EmployeeListView.Columns[5].Width = (int)(totalWidth * 0.15); 
            EmployeeListView.Columns[6].Width = (int)(totalWidth * 0.10);

        }
    }

}
