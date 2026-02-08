using Coffee.Kiosk.OrderingSystem.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee.Kiosk.OrderingSystem.UserControls
{
    public partial class ReceiptScreen : UserControl
    {
        public event Action? ResetRequested;
        private System.Windows.Forms.Timer _timer = new();
        private int _seconds;

        int _orderNumber;
        public ReceiptScreen()
        {
            InitializeComponent();
            CompanyLogo.Image = UI_Images.logoImage;
        }

        public void SetOrderNumber(int orderNumber)
        {
            OrderNumberLbl.Text = orderNumber.ToString();
        }

        public void StartResetCountdown(int seconds)
        {
            OrderNumberLbl.Visible = true;
            _seconds = seconds;
            UpdateLabel();

            _timer.Interval = 1000;
            _timer.Tick -= Timer_Tick;
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            _seconds--;
            UpdateLabel();

            if (_seconds <= 0)
            {
                _timer.Stop();
                ResetRequested?.Invoke();
            }
        }

        private void UpdateLabel()
        {
            label4.Text = $"Resetting in {_seconds}...";
        }
        private void ReceiptScreen_Load(object sender, EventArgs e)
        {
            UI_Handling.centerPanel(panel2, panel4, 4);
            UI_Handling.centerPanel(panel3, panel8);
        }

        private void ReceiptScreen_Resize(object sender, EventArgs e)
        {
            UI_Handling.centerPanel(panel2, panel4, 4);
            UI_Handling.centerPanel(panel3, panel8);
        }
    }
}
