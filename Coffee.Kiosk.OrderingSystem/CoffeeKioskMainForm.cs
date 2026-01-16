using Coffee.Kiosk.OrderingSystem.Helper;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Drawing;



namespace Coffee.Kiosk.OrderingSystem
{
    public partial class CoffeeKioskMainForm : MaterialForm
    {
        private GetStartedScreen? getStartedScreen;
        private DineInTakeOut? dineInTakeOut;

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
            //var getStartedScreen = new GetStartedScreen();
            //Helper.UI_Handling.loadUserControl(mainPanel, getStartedScreen, true);

            //getStartedScreen.NextClicked += () =>
            //{
            //    var dineInTakeOut = new DineInTakeOut();
            //    UI_Handling.loadUserControl(mainPanel, dineInTakeOut);

            //    dineInTakeOut.backButtonClicked += () =>
            //    {
            //        Helper.UI_Handling.loadUserControl(mainPanel, getStartedScreen);
            //    };
            //};
            // Rewriting this to avoid nesting


            if (getStartedScreen == null)
            {
                getStartedScreen = new GetStartedScreen();
                getStartedScreen.NextClicked += showDineInTakeOutScreen;
            }
            UI_Handling.loadUserControl(mainPanel, getStartedScreen);
        }

        private void showDineInTakeOutScreen()
        {
            if (dineInTakeOut == null)
            {
                dineInTakeOut = new DineInTakeOut();
                dineInTakeOut.backButtonClicked += () =>
                {
                    UI_Handling.loadUserControl(mainPanel, getStartedScreen!);
                };
            }
            UI_Handling.loadUserControl(mainPanel, dineInTakeOut);
        }

        internal void finishOrder()
        {
            getStartedScreen?.Dispose();
            dineInTakeOut?.Dispose();

            getStartedScreen = null;
            dineInTakeOut = null;
            
            showGetStartedScreen();
        }
    }
}
