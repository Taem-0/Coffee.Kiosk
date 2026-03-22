using Coffee.Kiosk.CMS.Models;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.DashBoardTab.DashBoardUserControls
{
    public partial class PeakHours : UserControl
    {
        public PeakHours()
        {
            InitializeComponent();
        }

        public void LoadData(DashboardData data)
        {
            peakHourNum.Text = data.BusiestHour;
            slowestHourNum.Text = data.SlowestHour;
        }
    }
}