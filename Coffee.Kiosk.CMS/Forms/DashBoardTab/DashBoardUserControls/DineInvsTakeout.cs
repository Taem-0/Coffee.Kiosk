using Coffee.Kiosk.CMS.Helpers;
using Coffee.Kiosk.CMS.Models;
using ScottPlot.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.DashBoardTab.DashBoardUserControls
{
    public partial class DineInvsTakeout : UserControl
    {
        private FormsPlot _chart = new FormsPlot();
        private UIhelp.UITheme? _theme;

        public DineInvsTakeout()
        {
            InitializeComponent();
            _chart.Dock = DockStyle.Fill;
            this.Controls.Add(_chart);
        }

        public void ApplyTheme(UIhelp.UITheme theme)
        {
            _theme = theme;
            this.BackColor = theme.Background;
            _chart.BackColor = theme.Background;

            string bg = ColorTranslator.ToHtml(theme.Background);
            _chart.Plot.FigureBackground.Color = ScottPlot.Color.FromHex(bg);
            _chart.Plot.DataBackground.Color = ScottPlot.Color.FromHex(bg);
            _chart.Plot.Axes.Frameless();
            _chart.Plot.HideGrid();
            _chart.Refresh();
        }

        public void LoadData(DashboardData data)
        {
            string bg = _theme != null ? ColorTranslator.ToHtml(_theme.Background) : "#F5F5DC";
            string primary = _theme != null ? ColorTranslator.ToHtml(_theme.Primary) : "#6F4D38";
            string accent = _theme != null ? ColorTranslator.ToHtml(_theme.Accent) : "#CBB799";

            int total = data.DineInCount + data.TakeOutCount;

            _chart.BackColor = _theme?.Background ?? Color.FromArgb(245, 245, 220);
            this.BackColor = _theme?.Background ?? Color.FromArgb(245, 245, 220);
            _chart.Plot.Clear();
            _chart.Plot.FigureBackground.Color = ScottPlot.Color.FromHex(bg);
            _chart.Plot.DataBackground.Color = ScottPlot.Color.FromHex(bg);
            _chart.Plot.Axes.Frameless();
            _chart.Plot.HideGrid();

            if (total > 0)
            {
                double dineInPct = Math.Round((double)data.DineInCount / total * 100, 1);
                double takeOutPct = Math.Round((double)data.TakeOutCount / total * 100, 1);

                var pie = _chart.Plot.Add.Pie(new double[] { data.DineInCount, data.TakeOutCount });
                pie.Slices[0].Label = $"Dine In ({dineInPct}%)";
                pie.Slices[0].FillColor = ScottPlot.Color.FromHex(primary);
                pie.Slices[1].Label = $"Take Out ({takeOutPct}%)";
                pie.Slices[1].FillColor = ScottPlot.Color.FromHex(accent);
                pie.DonutFraction = 0.5;
            }
            else
            {
                var pie = _chart.Plot.Add.Pie(new double[] { 1 });
                pie.Slices[0].Label = "No data";
                pie.Slices[0].FillColor = ScottPlot.Color.FromHex("#DDDDDD");
                pie.DonutFraction = 0.5;
            }

            _chart.Plot.ShowLegend();
            _chart.Refresh();
        }
    }
}