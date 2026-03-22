using Coffee.Kiosk.CMS.Models;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.DashBoardTab.DashBoardUserControls
{
    public partial class SalesOverTime : UserControl
    {
        public SalesOverTime()
        {
            InitializeComponent();
        }

        public void LoadData(DashboardData data)
        {
            todayRevenue.Text = $"₱{data.TodayRevenue:N2}";
            weekRevenue.Text = $"₱{data.WeekRevenue:N2}";
            monthRevenue.Text = $"₱{data.YearRevenue:N2}";
        }


        private void SalesOverTime_Load(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
    }
}