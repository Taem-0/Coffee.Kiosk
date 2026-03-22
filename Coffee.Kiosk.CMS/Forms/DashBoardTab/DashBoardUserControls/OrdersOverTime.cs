using Coffee.Kiosk.CMS.Models;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.DashBoardTab.DashBoardUserControls
{
    public partial class OrdersOverTime : UserControl
    {
        public OrdersOverTime()
        {
            InitializeComponent();
        }

        public void LoadData(DashboardData data)
        {
            todayOrders.Text = data.TodayOrders.ToString();
            weekOrders.Text = data.WeekOrders.ToString();
            monthOrders.Text = data.YearOrders.ToString();
        }
    }
}