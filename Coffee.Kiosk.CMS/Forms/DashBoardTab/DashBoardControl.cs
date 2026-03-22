using Coffee.Kiosk.CMS.Controllers;
using Coffee.Kiosk.CMS.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.DashBoardTab
{
    public partial class DashBoardControl : UserControl
    {
        public AdminControlForm? ParentFormReference { get; set; }
        private readonly AccountController _controller;
        private DashboardController? _dashboardController;

        private Color _darkBrown = ColorTranslator.FromHtml("#3d211a");
        private Color _mediumBrown = ColorTranslator.FromHtml("#6f4d38");
        private Color _lightBrown = ColorTranslator.FromHtml("#a07856");
        private Color _beige = ColorTranslator.FromHtml("#cbb799");
        private Color _background = ColorTranslator.FromHtml("#f5f5dc");

        public DashBoardControl(AccountController accountController)
        {
            InitializeComponent();
            _controller = accountController ?? throw new ArgumentNullException(nameof(accountController));

            guna2PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            guna2PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            guna2PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            guna2PictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;

            TimeLineDropDown.Items.Clear();
            TimeLineDropDown.Items.Add("This day");
            TimeLineDropDown.Items.Add("This month");
            TimeLineDropDown.Items.Add("This year");
            TimeLineDropDown.SelectedIndex = 0;

            ApplyTheme();
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

            salesOverTime1.LoadData(data);
            ordersOverTime1.LoadData(data);
            dineInvsTakeout1.LoadData(data);
            peakHours1.LoadData(data);
            topSellingProducts1.LoadData(data);
        }

        private void ApplyTheme()
        {
            this.BackColor = _background;
            this.ForeColor = _darkBrown;

            guna2Panel1.FillColor = _mediumBrown;
            guna2Panel1.BackColor = _mediumBrown;
            guna2Panel1.BorderColor = _darkBrown;
            guna2Panel1.BorderThickness = 1;

            ApplyTextBoxTheme(guna2TextBox1);

            label1.ForeColor = _darkBrown;
            label1.BackColor = Color.Transparent;

            DropDownContainer.FillColor = _mediumBrown;
            DropDownContainer.ForeColor = Color.White;

            TimeLineLabel.BackColor = _mediumBrown;
            TimeLineLabel.ForeColor = Color.White;

            ApplyComboBoxTheme(TimeLineDropDown);

            ApplyContainerTheme(guna2ContainerControl1);
            ApplyContainerTheme(guna2ContainerControl2);
            ApplyContainerTheme(guna2ContainerControl3);
            ApplyContainerTheme(guna2ContainerControl4);

            tableLayoutPanel3.BackColor = Color.Transparent;
        }

        private void ApplyTextBoxTheme(Guna.UI2.WinForms.Guna2TextBox textBox)
        {
            textBox.BorderColor = _mediumBrown;
            textBox.FocusedState.BorderColor = _lightBrown;
            textBox.HoverState.BorderColor = _lightBrown;
            textBox.FillColor = Color.White;
            textBox.ForeColor = _darkBrown;
            textBox.PlaceholderForeColor = Color.Gray;
            textBox.BorderRadius = 8;
        }

        private void ApplyComboBoxTheme(Guna.UI2.WinForms.Guna2ComboBox comboBox)
        {
            comboBox.FillColor = _mediumBrown;
            comboBox.BorderColor = _mediumBrown;
            comboBox.ForeColor = Color.White;
            comboBox.HoverState.BorderColor = _lightBrown;
            comboBox.HoverState.FillColor = _lightBrown;
            comboBox.FocusedState.BorderColor = _lightBrown;
            comboBox.BorderRadius = 17;
            comboBox.ItemHeight = 30;

            comboBox.ItemsAppearance.BackColor = _beige;
            comboBox.ItemsAppearance.ForeColor = _darkBrown;
            comboBox.ItemsAppearance.SelectedBackColor = _lightBrown;
            comboBox.ItemsAppearance.SelectedForeColor = Color.White;
        }

        private void ApplyContainerTheme(Guna.UI2.WinForms.Guna2ContainerControl container)
        {
            container.BorderColor = _mediumBrown;
            container.BorderThickness = 2;
            container.BorderRadius = 25;
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