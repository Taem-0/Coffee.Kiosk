using Coffee.Kiosk.OrderingSystem.Helper;
using Coffee.Kiosk.OrderingSystem.Sql;
using Coffee.Kiosk.OrderingSystem.UserControls;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Extensions.Configuration;
using System;
using System.Configuration;
using System.Drawing;



namespace Coffee.Kiosk.OrderingSystem
{
    public partial class CoffeeKioskMainForm : Form
    {

        private GetStartedScreen? getStartedScreen;
        private DineInTakeOut? dineInTakeOut;
        private KioskMenu? kioskMenu;

        private ModalScreen? modalScreen;

        private Models.Orders? currentOrder;

        public CoffeeKioskMainForm()
        {
            InitializeComponent();

            //var materialSkinManager = MaterialSkinManager.Instance;
            //materialSkinManager.AddFormToManage(this);
            UI_ColorScheme.initializeMaterialSkinThemes();
            UI_Images.loadLogoImage();

            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            DBInitializer.Init(config);

            Models.Category.LoadFromDataBase();

            // remove after connecting to database
            //Models.Category.LoadDummyData();
            Models.Product.LoadDummyData();
        }

        private void CoffeeKiosk_Load(object sender, EventArgs e)
        {
            ShowGetStartedScreen();
            modalOverlayPanel.FillColor = Color.FromArgb(67, 0, 0, 0);
            UI_Handling.centerPanel(modalOverlayPanel, modalMainScreen);
        }

        private void loadEverything()
        {
            if (getStartedScreen == null)
            {
                getStartedScreen = new GetStartedScreen();
                getStartedScreen.NextClicked += ShowDineInTakeOutScreen;
            }
            if (dineInTakeOut == null)
            {
                dineInTakeOut = new DineInTakeOut();

                dineInTakeOut.backButtonClicked += () =>
                {
                    UI_Handling.loadUserControl(mainPanel, getStartedScreen);
                };

                dineInTakeOut.hasPickedAChoice += () =>
                {
                    currentOrder = new Models.Orders();
                    currentOrder.Type = dineInTakeOut.lastChoice;
                    ShowKioskMenuScreen();
                };
            }
            if (kioskMenu == null)
            {
                kioskMenu = new KioskMenu();
                kioskMenu.startOverClicked += FinishOrder;
                kioskMenu.ProductSelected += ShowModalScreen;
            }
        }


        private void ShowGetStartedScreen()
        {
            Models.Category.LoadFromDataBase();
            loadEverything();
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
                kioskMenu.ProductSelected += ShowModalScreen;
            }
            UI_Handling.loadUserControl(mainPanel, kioskMenu);
        }

        private void ShowModalScreen(int productId = 0)
        {
            if (modalScreen == null)
            {
                modalScreen = new ModalScreen(productId);
                modalScreen.BackButtonClicked += HideModalScreen;
            }
            modalScreen.productId = productId;
            modalOverlayPanel.Visible = true;
            UI_Handling.centerPanel(modalOverlayPanel, modalMainScreen);
            UI_Handling.loadUserControl(modalMainScreen, modalScreen);
        }

        private void HideModalScreen()
        {
            modalOverlayPanel.Visible = false;
            modalScreen?.Dispose();
            modalScreen = null;
        }

        internal void FinishOrder()
        {
            //getStartedScreen?.Dispose();
            //dineInTakeOut?.Dispose();
            //kioskMenu?.Dispose();

            //getStartedScreen = null;
            //dineInTakeOut = null;
            //kioskMenu = null;

            currentOrder = null;

            ShowGetStartedScreen();
        }
        private void CoffeeKioskMainForm_Resize(object sender, EventArgs e)
        {
            UI_Handling.centerPanel(modalOverlayPanel, modalMainScreen);
        }
    }
}
