using Coffee.Kiosk.CMS.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Coffee.Kiosk.CMS.Forms.DashBoardTab
{
    public partial class DashBoardControl : UserControl
    {

        public AdminControlForm? ParentFormReference { get; set; }

        private readonly AccountController _controller;


        public DashBoardControl(AccountController accountController)
        {
            InitializeComponent();
            _controller = accountController ?? throw new ArgumentNullException(nameof(accountController));
        }

        private void DashBoardControl_Load(object sender, EventArgs e)
        {
            DropDownContainer.FillColor = System.Drawing.ColorTranslator.FromHtml("#6F4D38");
            TimeLineLabel.BackColor = System.Drawing.ColorTranslator.FromHtml("#6F4D38");
            TimeLineDropDown.BackColor = System.Drawing.ColorTranslator.FromHtml("#6F4D38");
            TimeLineDropDown.FillColor = System.Drawing.ColorTranslator.FromHtml("#6F4D38");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void DashBoardControl_Resize(object sender, EventArgs e)
        {

            // Get the size of the entire form (including borders/title bar, which are accounted for by Windows when maximized)
            int formWidth = this.Size.Width;
            int formHeight = this.Size.Height;

            // Get the size of the client area (where controls are placed)
            int clientWidth = this.ClientSize.Width;
            int clientHeight = this.ClientSize.Height;

            // You can use these values, for example, to log them or resize controls
            System.Diagnostics.Debug.WriteLine($"Maximized Form Size: {formWidth}x{formHeight}");
            System.Diagnostics.Debug.WriteLine($"Maximized Client Size: {clientWidth}x{clientHeight}");

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
