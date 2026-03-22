using Coffee.Kiosk.CMS.Models;
using System;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.DashBoardTab.DashBoardUserControls
{
    public partial class DineInvsTakeout : UserControl
    {
        public DineInvsTakeout()
        {
            InitializeComponent();
        }

        public void LoadData(DashboardData data)
        {
            int total = data.DineInCount + data.TakeOutCount;
            dineInCount.Text = data.DineInCount.ToString();
            takeOutCount.Text = data.TakeOutCount.ToString();
            dineInPercentage.Text = total > 0 ? $"{Math.Round((double)data.DineInCount / total * 100, 1)}%" : "0%";
            takeOutPercentage.Text = total > 0 ? $"{Math.Round((double)data.TakeOutCount / total * 100, 1)}%" : "0%";

            // Chart-ready: for donut chart later:
            // new PieSeries { Title = "Dine In", Values = new[] { data.DineInCount } }
            // new PieSeries { Title = "Take Out", Values = new[] { data.TakeOutCount } }
        }
    }
}