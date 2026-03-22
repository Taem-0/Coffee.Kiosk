using Coffee.Kiosk.CMS.Helpers;
using Coffee.Kiosk.CMS.Models;
using ScottPlot.WinForms;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.DashBoardTab.DashBoardUserControls
{
    public partial class PeakHours : UserControl
    {
        private FormsPlot _chart = new FormsPlot();
        private UIhelp.UITheme? _theme;

        public PeakHours()
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
            string primary = ColorTranslator.ToHtml(theme.Primary);
            string accent = ColorTranslator.ToHtml(theme.Accent);

            _chart.Plot.FigureBackground.Color = ScottPlot.Color.FromHex(bg);
            _chart.Plot.DataBackground.Color = ScottPlot.Color.FromHex(bg);
            _chart.Plot.Grid.MajorLineColor = ScottPlot.Color.FromHex(accent);
            _chart.Plot.Axes.Color(ScottPlot.Color.FromHex(primary));
            _chart.Refresh();
        }

        public void LoadData(DashboardData data)
        {
            string bg = _theme != null ? ColorTranslator.ToHtml(_theme.Background) : "#F5F5DC";
            string primary = _theme != null ? ColorTranslator.ToHtml(_theme.Primary) : "#6F4D38";
            string accent = _theme != null ? ColorTranslator.ToHtml(_theme.Accent) : "#CBB799";

            _chart.BackColor = _theme?.Background ?? Color.FromArgb(245, 245, 220);
            this.BackColor = _theme?.Background ?? Color.FromArgb(245, 245, 220);
            _chart.Plot.Clear();
            _chart.Plot.FigureBackground.Color = ScottPlot.Color.FromHex(bg);
            _chart.Plot.DataBackground.Color = ScottPlot.Color.FromHex(bg);
            _chart.Plot.Grid.MajorLineColor = ScottPlot.Color.FromHex(accent);
            _chart.Plot.Axes.Color(ScottPlot.Color.FromHex(primary));

            if (data.HourlyOrderPoints.Any())
            {
                double[] values = data.HourlyOrderPoints.Select(p => (double)p.OrderCount).ToArray();
                double[] positions = data.HourlyOrderPoints.Select(p => (double)p.Hour).ToArray();

                var bars = _chart.Plot.Add.Bars(positions, values);
                foreach (var bar in bars.Bars)
                    bar.FillColor = ScottPlot.Color.FromHex(primary);

                _chart.Plot.Axes.Bottom.TickGenerator =
                    new ScottPlot.TickGenerators.NumericManual(
                        positions,
                        data.HourlyOrderPoints.Select(p => p.HourLabel).ToArray());
            }

            _chart.Plot.YLabel("Orders");
            _chart.Refresh();
        }
    }
}