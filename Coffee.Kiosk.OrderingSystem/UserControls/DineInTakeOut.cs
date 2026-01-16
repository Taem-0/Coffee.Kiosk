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

namespace Coffee.Kiosk.OrderingSystem
{
    public partial class DineInTakeOut : UserControl
    {

        bool isHoveredDineIn = false;
        bool isHoveredTakeOut = false;

        public DineInTakeOut()
        {
            InitializeComponent();
        }

        private void DineInTakeOut_Load(object sender, EventArgs e)
        {
            UI_Handling.centerPanel(panel1, DineInTakeOutLogo);
            UI_Handling.centerPanel(panel2, panel3, this.Size.Height < 800 ? 2 : 1);
            DineInTakeOutLogo.Image = Image.FromFile(UI_Images.logoImage());
        }

        private void DineInTakeOut_Resize(object sender, EventArgs e)
        {
            UI_Handling.centerPanel(panel1, DineInTakeOutLogo);
            UI_Handling.centerPanel(panel2, panel3, this.Size.Height < 800 ? 2 : 1);
        }


        private void DineIn_Button_MouseEnter(object sender, EventArgs e)
        {
            isHoveredDineIn = true;
            DineIn_Button.Invalidate();
        }

        private void DineIn_Button_MouseLeave(object sender, EventArgs e)
        {
            isHoveredDineIn = false;
            DineIn_Button.Invalidate();
        }

        private void DineIn_Button_Paint(object sender, PaintEventArgs e)
        {
            if (!isHoveredDineIn) return;
            UI_Handling.darkenOnHover(e, DineIn_Button.ClientRectangle);
        }

        private void TakeOut_Button_MouseEnter(object sender, EventArgs e)
        {
            isHoveredTakeOut = true;
            TakeOut_Button.Invalidate();
        }
        private void TakeOut_Button_MouseLeave(object sender, EventArgs e)
        {
            isHoveredTakeOut = false;
            TakeOut_Button.Invalidate();
        }
        private void TakeOut_Button_Paint(object sender, PaintEventArgs e)
        {
            if (!isHoveredTakeOut) return;
            UI_Handling.darkenOnHover(e, TakeOut_Button.ClientRectangle);

        }
    }
}
