using Coffee.Kiosk.CMS.Controllers;
using Coffee.Kiosk.CMS.Helpers;
using Coffee.Kiosk.CMS.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.DashBoardTab
{
    public partial class DashBoardControl : UserControl
    {
        public AdminControlForm? ParentFormReference { get; set; }
        private readonly AccountController _controller;
        private DashboardController? _dashboardController;
        private readonly ShopController _themeController;

        public DashBoardControl(AccountController accountController, ShopController themeController)
        {
            InitializeComponent();
            _controller = accountController ?? throw new ArgumentNullException(nameof(accountController));
            _themeController = themeController ?? throw new ArgumentNullException(nameof(themeController));

            guna2PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            guna2PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            guna2PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            guna2PictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;

            TimeLineDropDown.Items.Clear();
            TimeLineDropDown.Items.Add("This day");
            TimeLineDropDown.Items.Add("This month");
            TimeLineDropDown.Items.Add("This year");
            TimeLineDropDown.SelectedIndex = 0;

            var uiTheme = UIhelp.ThemeManager.BuildUITheme(_themeController);
            ApplyFullTheme(uiTheme);

            UIhelp.ThemeManager.ThemeChanged += OnThemeChanged;
        }



        private void OnThemeChanged(object? sender, UIhelp.UITheme theme)
        {
            if (InvokeRequired)
            {
                Invoke(() => OnThemeChanged(sender, theme));
                return;
            }
            ApplyFullTheme(theme);
            this.Refresh();
        }

        private void ApplyFullTheme(UIhelp.UITheme theme)
        {
            UIhelp.ThemeManager.ApplyTheme(this, theme);

            salesOverTime1.ApplyTheme(theme);
            ordersOverTime1.ApplyTheme(theme);
            dineInvsTakeout1.ApplyTheme(theme);
            peakHours1.ApplyTheme(theme);

            guna2Panel1.FillColor = theme.Primary;
            guna2Panel1.BackColor = theme.Primary;
            guna2Panel1.BorderColor = theme.DarkPrimary;
            guna2Panel1.BorderThickness = 1;

            tableLayoutPanel3.BackColor = Color.Transparent;

            TimeLineDropDown.FillColor = theme.Background;
            TimeLineDropDown.BorderColor = theme.Background;
            TimeLineDropDown.ForeColor = Color.White;
            TimeLineDropDown.HoverState.FillColor = theme.Primary;
            TimeLineDropDown.HoverState.BorderColor = theme.Primary;
            TimeLineDropDown.FocusedState.FillColor = theme.Primary;

            ApplyComboBoxTheme(TimeLineDropDown, theme);
            ApplyContainerTheme(guna2ContainerControl1, theme);
            ApplyContainerTheme(guna2ContainerControl2, theme);
            ApplyContainerTheme(guna2ContainerControl3, theme);
            ApplyContainerTheme(guna2ContainerControl4, theme);
        }



        private void ApplyComboBoxTheme(Guna.UI2.WinForms.Guna2ComboBox comboBox, UIhelp.UITheme theme)
        {
            comboBox.FillColor = theme.Primary;
            comboBox.BorderColor = theme.Primary;
            comboBox.ForeColor = Color.White;
            comboBox.HoverState.BorderColor = theme.Primary;
            comboBox.HoverState.FillColor = theme.Primary;
            comboBox.FocusedState.BorderColor = theme.Primary;
            comboBox.FocusedState.FillColor = theme.Primary; 
            comboBox.BorderRadius = 17;
            comboBox.ItemHeight = 30;
            comboBox.ItemsAppearance.BackColor = theme.Accent;
            comboBox.ItemsAppearance.ForeColor = theme.DarkPrimary;
            comboBox.ItemsAppearance.SelectedBackColor = theme.Secondary;
            comboBox.ItemsAppearance.SelectedForeColor = Color.White;
        }

        private void ApplyContainerTheme(Guna.UI2.WinForms.Guna2ContainerControl container, UIhelp.UITheme theme)
        {
            container.BorderColor = theme.Primary;
            container.BorderThickness = 2;
            container.BorderRadius = 25;
        }

        public void Initialize(DashboardController dashboardController)
        {
            _dashboardController = dashboardController;
            RefreshDashboard();
        }

        private void RefreshDashboard()
        {
            if (_dashboardController == null) return;

            string filter = TimeLineDropDown.SelectedItem?.ToString() switch
            {
                "This month" => "month",
                "This year" => "year",
                _ => "day"
            };

            var data = _dashboardController.GetDashboardData(filter);

            transactionsNum.Text = data.TodayOrders.ToString();
            totalQTYNum.Text = data.TopProducts.Sum(p => p.Quantity).ToString();
            totalRevenueNum.Text = $"₱{data.TodayRevenue:N2}";
            totalProfitNum.Text = $"₱{data.TodayRevenue:N2}";

            salesOverTime1.LoadData(data);
            ordersOverTime1.LoadData(data);
            dineInvsTakeout1.LoadData(data);
            peakHours1.LoadData(data);
            topSellingProducts1.LoadData(data);
        }

        private void DashBoardControl_Load(object sender, EventArgs e)
        {
            RefreshDashboard();
        }

        private void TimeLineDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshDashboard();
        }

        private void AddDataCard(Guna.UI2.WinForms.Guna2ContainerControl container, string title, string value, Color valueColor)
        {
            container.Controls.Clear();

            var titleLabel = new Label
            {
                Text = title,
                Font = new Font("Segoe UI Semibold", 12, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                Location = new Point(20, 10),
                AutoSize = true
            };

            var valueLabel = new Label
            {
                Text = value,
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = valueColor,
                BackColor = Color.Transparent,
                Location = new Point(20, 50),
                AutoSize = true
            };

            container.Controls.Add(titleLabel);
            container.Controls.Add(valueLabel);
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void guna2HtmlLabel1_Click(object sender, EventArgs e) { }
        private void guna2Panel2_Paint(object sender, PaintEventArgs e) { }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e) { }
        private void tableLayoutPanel3_Paint_1(object sender, PaintEventArgs e) { }
        private void guna2Panel1_Paint(object sender, PaintEventArgs e) { }
        private void guna2ContainerControl4_Click(object sender, EventArgs e) { }
    }
}