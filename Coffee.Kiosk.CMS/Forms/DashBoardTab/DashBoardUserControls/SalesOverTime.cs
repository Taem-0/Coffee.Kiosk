using Coffee.Kiosk.CMS.Helpers;
using Coffee.Kiosk.CMS.Models;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.DashBoardTab.DashBoardUserControls
{
    public partial class SalesOverTime : UserControl
    {
        private UIhelp.UITheme? _theme;

        public SalesOverTime()
        {
            InitializeComponent();
        }

        public void ApplyTheme(UIhelp.UITheme theme)
        {
            _theme = theme;
            this.BackColor = theme.Background;

            string bg = ColorTranslator.ToHtml(theme.Background);
            string primary = ColorTranslator.ToHtml(theme.Primary);
            string accent = ColorTranslator.ToHtml(theme.Accent);

            salesOTplot.BackColor = theme.Background;
            salesOTplot.Plot.FigureBackground.Color = ScottPlot.Color.FromHex(bg);
            salesOTplot.Plot.DataBackground.Color = ScottPlot.Color.FromHex(bg);
            salesOTplot.Plot.Grid.MajorLineColor = ScottPlot.Color.FromHex(accent);
            salesOTplot.Plot.Axes.Color(ScottPlot.Color.FromHex(primary));
            salesOTplot.Refresh();
        }

        public void LoadData(DashboardData data)
        {
            string bg = _theme != null ? ColorTranslator.ToHtml(_theme.Background) : "#F5F5DC";
            string primary = _theme != null ? ColorTranslator.ToHtml(_theme.Primary) : "#6F4D38";
            string accent = _theme != null ? ColorTranslator.ToHtml(_theme.Accent) : "#CBB799";

            salesOTplot.Plot.Clear();
            salesOTplot.BackColor = _theme?.Background ?? System.Drawing.Color.FromArgb(245, 245, 220);
            salesOTplot.Plot.FigureBackground.Color = ScottPlot.Color.FromHex(bg);
            salesOTplot.Plot.DataBackground.Color = ScottPlot.Color.FromHex(bg);
            salesOTplot.Plot.Grid.MajorLineColor = ScottPlot.Color.FromHex(accent);
            salesOTplot.Plot.Axes.Color(ScottPlot.Color.FromHex(primary));

            if (data.DailyRevenuePoints.Any())
            {
                double[] values = data.DailyRevenuePoints.Select(p => (double)p.Revenue).ToArray();
                double[] positions = Enumerable.Range(0, values.Length).Select(i => (double)i).ToArray();

                var scatter = salesOTplot.Plot.Add.Scatter(positions, values);
                scatter.Color = ScottPlot.Color.FromHex(primary);
                scatter.LineWidth = 2;
                scatter.MarkerSize = 5;

                salesOTplot.Plot.Axes.Bottom.TickGenerator =
                    new ScottPlot.TickGenerators.NumericManual(
                        positions,
                        data.DailyRevenuePoints.Select(p => p.Date.ToString("MM/dd")).ToArray());
            }

            salesOTplot.Plot.Title("Revenue Over Time");
            salesOTplot.Plot.YLabel("₱");
            salesOTplot.Refresh();
        }

        private void SalesOverTime_Load(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void salesOTplot_Load(object sender, EventArgs e) { }
    }
}