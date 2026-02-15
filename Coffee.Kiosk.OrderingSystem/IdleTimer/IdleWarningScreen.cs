using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee.Kiosk.OrderingSystem.IdleTimer
{
    public partial class IdleWarningScreen : Form
    {
        public IdleWarningScreen()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void IdleWarningScreen_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void SetTimerNumber(long timerNumber)
        {
            var time = TimeSpan.FromSeconds(timerNumber);
            label2.Text = time.ToString(@"m\:ss");
        }
    }
}
