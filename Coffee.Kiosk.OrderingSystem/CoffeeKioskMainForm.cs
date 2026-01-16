using Coffee.Kiosk.OrderingSystem.Helper;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Drawing;



namespace Coffee.Kiosk.OrderingSystem
{
    public partial class CoffeeKioskMainForm : MaterialForm
    {
        public CoffeeKioskMainForm()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            UI_ColorScheme.initializeMaterialSkinThemes();
        }

        private void CoffeeKiosk_Load(object sender, EventArgs e)
        {
            showGetStartedScreen();
        }


        private void showGetStartedScreen()
        {
            var getStartedScreen = new GetStartedScreen();

            getStartedScreen.NextClicked += () =>
            {
                var dineInTakeOut = new DineInTakeOut();
                UI_Handling.loadUserControl(mainPanel, dineInTakeOut);
            };

            Helper.UI_Handling.loadUserControl(mainPanel, getStartedScreen, true);
        }

        internal void finishOrder()
        {
            showGetStartedScreen();
        }
    }
}
