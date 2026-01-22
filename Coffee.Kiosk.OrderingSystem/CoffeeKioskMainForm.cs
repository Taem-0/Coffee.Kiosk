using Coffee.Kiosk.OrderingSystem.Helper;
using Coffee.Kiosk.OrderingSystem.Sql;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Extensions.Configuration;
using System;
using System.Configuration;
using System.Drawing;



namespace Coffee.Kiosk.OrderingSystem
{
    public partial class CoffeeKioskMainForm : MaterialForm
    {

        public event EventHandler? bruh;
        
        private GetStartedScreen? getStartedScreen;
        private DineInTakeOut? dineInTakeOut;
        private KioskMenu? kioskMenu;

        private Models.Orders? currentOrder;

        public CoffeeKioskMainForm()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            UI_ColorScheme.initializeMaterialSkinThemes();
            UI_Images.loadLogoImage();

            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            DBInitializer.Init(config);


            // remove after connecting to database
            Models.Category.LoadDummyData();
            Models.Product.LoadDummyData();
        }

        private void CoffeeKiosk_Load(object sender, EventArgs e)
        {
            ShowGetStartedScreen();
        }


        private void ShowGetStartedScreen()
        {
            if (getStartedScreen == null)
            {
                getStartedScreen = new GetStartedScreen();
                getStartedScreen.NextClicked += ShowDineInTakeOutScreen;
            }
            UI_Handling.loadUserControl(mainPanel, getStartedScreen);
        }

        private void ShowDineInTakeOutScreen()
        {
            if (dineInTakeOut == null)
            {
                dineInTakeOut = new DineInTakeOut();

                dineInTakeOut.backButtonClicked += () =>
                {
                    UI_Handling.loadUserControl(mainPanel, getStartedScreen!);
                };

                dineInTakeOut.hasPickedAChoice += () =>
                {
                    currentOrder = new Models.Orders();
                    currentOrder.Type = dineInTakeOut.lastChoice;
                    ShowKioskMenuScreen();
                };

            }
            UI_Handling.loadUserControl(mainPanel, dineInTakeOut);
        }

        private void ShowKioskMenuScreen()
        {
            if (kioskMenu == null)
            {
                kioskMenu = new KioskMenu();

                kioskMenu.startOverClicked += FinishOrder;
            }
            UI_Handling.loadUserControl(mainPanel, kioskMenu);
        }

        internal void FinishOrder()
        {
            getStartedScreen?.Dispose();
            dineInTakeOut?.Dispose();
            kioskMenu?.Dispose();

            getStartedScreen = null;
            dineInTakeOut = null;
            kioskMenu = null;

            currentOrder = null;
            
            ShowGetStartedScreen();
        }
    }
}
