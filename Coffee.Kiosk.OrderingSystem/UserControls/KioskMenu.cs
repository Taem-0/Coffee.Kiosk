using Coffee.Kiosk.OrderingSystem.Helper;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee.Kiosk.OrderingSystem
{
    public partial class KioskMenu : UserControl
    {

        internal event Action? startOverClicked;

        public KioskMenu()
        {
            InitializeComponent();
        }
        private void StartOver_Button_Click(object sender, EventArgs e)
        {
            startOverClicked?.Invoke();
        }



        // --------------------------------------------------------------------------


        bool isHoveredStartOver = false;


        private void StartOver_Button_Paint(object sender, PaintEventArgs e)
        {
            if (!isHoveredStartOver) return;
            UI_Handling.darkenOnHover(e, StartOver_Button.ClientRectangle, UI_Handling.boxOrCircle.box);
        }

        private void StartOver_Button_MouseEnter(object sender, EventArgs e)
        {
            isHoveredStartOver = true;
            StartOver_Button.Invalidate();
        }

        private void StartOver_Button_MouseLeave(object sender, EventArgs e)
        {
            isHoveredStartOver = false;
            StartOver_Button.Invalidate();
        }
    }
}
