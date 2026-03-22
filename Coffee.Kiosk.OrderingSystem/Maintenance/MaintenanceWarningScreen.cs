using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee.Kiosk.OrderingSystem.Maintenance
{
    public partial class MaintenanceWarningScreen : Form
    {
        public MaintenanceWarningScreen()
        {
            InitializeComponent();
        }


        public void SetTimerNumber(int timerNumber)
        {
            var time = TimeSpan.FromSeconds(timerNumber);
            label2.Text = time.ToString(@"m\:ss");
        }
    }
}
