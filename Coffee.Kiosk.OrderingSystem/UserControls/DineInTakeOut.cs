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


        internal event Action? backButtonClicked;
        internal event Action? hasPickedAChoice;

        bool isHoveredBackButton = false;
        bool isHoveredDineIn = false;
        bool isHoveredTakeOut = false;

        internal Models.Orders.TypeOfOrder lastChoice;

        public DineInTakeOut()
        {
            InitializeComponent();
            UI_Handling.fixVisualShifts(this);
        }

        private void DineInTakeOut_Load(object sender, EventArgs e)
        {
            UI_Handling.centerPanel(panel1, DineInTakeOutLogo);
            UI_Handling.centerPanel(panel2, panel3);
            DineInTakeOutLogo.Image = Image.FromFile(UI_Images.logoImage());
        }

        private void DineInTakeOut_Resize(object sender, EventArgs e)
        {
            UI_Handling.centerPanel(panel1, DineInTakeOutLogo);
            UI_Handling.centerPanel(panel2, panel3);
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            backButtonClicked?.Invoke();
        }


        private void DineIn_Button_Click(object sender, EventArgs e)
        {
            hasPickedAChoice?.Invoke();
            lastChoice = Models.Orders.TypeOfOrder.DineIn;
        }

        private void TakeOut_Button_Click(object sender, EventArgs e)
        {
            hasPickedAChoice?.Invoke();
            lastChoice = Models.Orders.TypeOfOrder.TakeOut;
        }






        // --------------------------------------------------------------------------

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
            UI_Handling.darkenOnHover(e, DineIn_Button.ClientRectangle, UI_Handling.boxOrCircle.box);
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
            UI_Handling.darkenOnHover(e, TakeOut_Button.ClientRectangle, UI_Handling.boxOrCircle.circle);
        }

        private void BackButton_MouseEnter(object sender, EventArgs e)
        {
            isHoveredBackButton = true;
            TakeOut_Button.Invalidate();
        }

        private void BackButton_MouseLeave(object sender, EventArgs e)
        {
            isHoveredBackButton = false;
            TakeOut_Button.Invalidate();
        }

        private void BackButton_Paint(object sender, PaintEventArgs e)
        {
            if (!isHoveredBackButton) return;
            UI_Handling.darkenOnHover(e, BackButton.ClientRectangle, UI_Handling.boxOrCircle.circle);
        }

    }
}
