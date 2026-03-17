using Cashier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee.Kiosk.Cashier
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
            lblCashier.Text = $"Cashier Staff — {SessionManager.CurrentUser.Username}";
            lblClock.Text = DateTime.Now.ToString("hh:mm tt");
            tmrClock.Start();
            LoadControl(new UC_Cashier());
        }

        public void LoadControl(UserControl uc)
        {
            pnlContainer.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(uc);
        }

        private void tmrClock_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("hh:mm tt");
        }

        private void lblCashier_Click(object sender, EventArgs e) { }
        private void lblClock_Click(object sender, EventArgs e) { }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                new LogIn().Show();
                this.Close();
            }
        }
    }
}