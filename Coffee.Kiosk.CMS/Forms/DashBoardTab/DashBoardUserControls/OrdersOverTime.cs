using Coffee.Kiosk.CMS.Helpers;
using Coffee.Kiosk.CMS.Models;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.DashBoardTab.DashBoardUserControls
{
    public partial class OrdersOverTime : UserControl
    {
        private UIhelp.UITheme? _theme;

        public OrdersOverTime()
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

            ordersOTplot.BackColor = theme.Background;
            ordersOTplot.Plot.FigureBackground.Color = ScottPlot.Color.FromHex(bg);
            ordersOTplot.Plot.DataBackground.Color = ScottPlot.Color.FromHex(bg);
            ordersOTplot.Plot.Grid.MajorLineColor = ScottPlot.Color.FromHex(accent);
            ordersOTplot.Plot.Axes.Color(ScottPlot.Color.FromHex(primary));
            ordersOTplot.Refresh();
        }

        public void LoadData(DashboardData data)
        {
            string bg = _theme != null ? ColorTranslator.ToHtml(_theme.Background) : "#F5F5DC";
            string primary = _theme != null ? ColorTranslator.ToHtml(_theme.Primary) : "#6F4D38";
            string secondary = _theme != null ? ColorTranslator.ToHtml(_theme.Secondary) : "#A07856";
            string accent = _theme != null ? ColorTranslator.ToHtml(_theme.Accent) : "#CBB799";

            ordersOTplot.Plot.Clear();
            ordersOTplot.BackColor = _theme?.Background ?? System.Drawing.Color.FromArgb(245, 245, 220);
            ordersOTplot.Plot.FigureBackground.Color = ScottPlot.Color.FromHex(bg);
            ordersOTplot.Plot.DataBackground.Color = ScottPlot.Color.FromHex(bg);
            ordersOTplot.Plot.Grid.MajorLineColor = ScottPlot.Color.FromHex(accent);
            ordersOTplot.Plot.Axes.Color(ScottPlot.Color.FromHex(primary));

            if (data.HourlyOrderPoints.Any())
            {
                double[] values = data.HourlyOrderPoints.Select(p => (double)p.OrderCount).ToArray();
                double[] positions = Enumerable.Range(0, values.Length).Select(i => (double)i).ToArray();

                var scatter = ordersOTplot.Plot.Add.Scatter(positions, values);
                scatter.Color = ScottPlot.Color.FromHex(secondary);
                scatter.LineWidth = 2;
                scatter.MarkerSize = 5;

                ordersOTplot.Plot.Axes.Bottom.TickGenerator =
                    new ScottPlot.TickGenerators.NumericManual(
                        positions,
                        data.HourlyOrderPoints.Select(p => p.HourLabel).ToArray());
            }

            ordersOTplot.Plot.Title("Orders Over Time");
            ordersOTplot.Plot.YLabel("Orders");
            ordersOTplot.Refresh();
        }

        private void label4_Click(object sender, EventArgs e) { }
        private void ordersOTplot_Load(object sender, EventArgs e) { }
    }
}