using Coffee.Kiosk.OrderingSystem.Helper;
using Coffee.Kiosk.OrderingSystem.Sql;
using Coffee.Kiosk.OrderingSystem.UserControls;
using Coffee.Kiosk.OrderingSystem.UserControls.Reusables;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Extensions.Configuration;
using System;
using System.Configuration;
using System.Drawing;
using System.Text;



namespace Coffee.Kiosk.OrderingSystem
{
    public partial class CoffeeKioskMainForm : Form
    {
        public event Action<Models.Orders>? CartUpdated;

        private GetStartedScreen? getStartedScreen;
        private DineInTakeOut? dineInTakeOut;
        private KioskMenu? kioskMenu;
        private ViewOrder? viewOrder;
        private PayOptionScreen? payOptionScreen;

        private ModalScreen? modalScreen;

        private Models.Orders? currentOrder;

        int screenHeight;
        Size modalScreenOriginalSize = new Size(720, 800);

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

            //Models.Category.LoadFromDataBase();
            //Models.Product.LoadFromDataBase();

            Models.Category.LoadDummyData();
            Models.Product.LoadDummyData();

        }

        private void CoffeeKiosk_Load(object sender, EventArgs e)
        {
            screenHeight = this.ClientSize.Height;

            ShowGetStartedScreen();
            modalOverlayPanel.FillColor = Color.FromArgb(67, 0, 0, 0);
            UI_Handling.centerPanel(modalOverlayPanel, modalMainScreen);

            screenHeight = this.ClientSize.Height;
            if (screenHeight > 1000)
            {
                modalMainScreen.Height = 1000;

            } else
            {
                modalMainScreen.Size = modalScreenOriginalSize;
            }
        }



        private void ShowGetStartedScreen()
        {
            //Models.Category.LoadFromDataBase();
            //Models.Product.LoadFromDataBase();
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
                    if (currentOrder == null)
                    {
                        currentOrder = new Models.Orders();
                    }
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
                currentOrder ??= new Models.Orders();
                kioskMenu = new KioskMenu(currentOrder.Type == Models.Orders.TypeOfOrder.DineIn ? "Dine In" : "Take Out");

                kioskMenu.StartOverClicked += FinishOrder;
                kioskMenu.ProductSelected += ShowModalCustomizeScreen;
                kioskMenu.ViewOrderClicked += ShowViewOrder;
                this.CartUpdated += kioskMenu.OnCartUpdated;
            }
            UI_Handling.loadUserControl(mainPanel, kioskMenu);
        }

        private void ShowViewOrder()
        {
            currentOrder ??= new Models.Orders();
            if (viewOrder == null)
            {
                viewOrder = new ViewOrder(currentOrder);
                viewOrder.StartOverClicked += FinishOrder;
                viewOrder.OrderMoreClicked += ShowKioskMenuScreen;
                viewOrder.CompleteOrderClicked += ShowPayOptionScreen;
            }
            viewOrder.OnCartUpdate(currentOrder);
            viewOrder.LoadCurrentOrders();
            UI_Handling.loadUserControl(mainPanel, viewOrder);
        }

        private void ShowPayOptionScreen()
        {
            if (payOptionScreen == null)
            {
                payOptionScreen = new PayOptionScreen();
                payOptionScreen.BackButtonClicked += ShowViewOrder;
            }
            UI_Handling.loadUserControl(mainPanel, payOptionScreen);
        }


        private void ShowModalCustomizeScreen(int productId = 0)
        {
            if (modalScreen == null)
            {
                modalScreen = new ModalScreen(productId);
                modalScreen.BackButtonClicked += HideModalScreen;
                modalScreen.AddToCartClicked += item =>
                {
                    if (currentOrder == null)
                        return;

                    currentOrder.AddOrMergeItem(item);
                    CartUpdated?.Invoke(currentOrder);

                    var modifiers = new StringBuilder();
                    foreach (var modifier in item.SelectedModifiersName)
                    {
                        modifiers.AppendLine($"{modifier.Key}: {string.Join(",", modifier.Value)}");
                    }

                    //MessageBox.Show($"""
                    //    {item.ProductId.ToString()}: {item.ProductName.ToString()}
                    //    Quantity: {item.Quantity.ToString()}
                    //    {modifiers}
                    //    """);
                    HideModalScreen();
                };

            }
            else
            {
                modalScreen.ReloadModalScreen(productId);
            }
            modalScreen.productId = productId;
            modalOverlayPanel.Visible = true;
            UI_Handling.centerPanel(modalOverlayPanel, modalMainScreen);
            UI_Handling.loadUserControl(modalMainScreen, modalScreen);
        }

        private void HideModalScreen()
        {
            modalOverlayPanel.Visible = false;
            //modalScreen?.Dispose();
            //modalScreen = null;

            kioskMenu?.KioskScrollPosFix();
        }



        internal void FinishOrder()
        {
            getStartedScreen?.Dispose();
            dineInTakeOut?.Dispose();
            if (kioskMenu != null)
            {
                this.CartUpdated -= kioskMenu.OnCartUpdated;
                kioskMenu?.Dispose();
                kioskMenu = null;
            }
            modalScreen?.Dispose();
            viewOrder?.Dispose();

            getStartedScreen = null;
            dineInTakeOut = null;
            modalScreen = null;
            viewOrder = null;

            currentOrder = null;

            ShowGetStartedScreen();
        }


        private void CoffeeKioskMainForm_Resize(object sender, EventArgs e)
        {
            screenHeight = this.ClientSize.Height;
            if (screenHeight > 1300)
            {
                modalMainScreen.Height = 1200;
            }
            else if (screenHeight > 1000)
            {
                modalMainScreen.Height = 1000;
            }
            else
            {
                modalMainScreen.Size = modalScreenOriginalSize;
            }

            UI_Handling.centerPanel(modalOverlayPanel, modalMainScreen);
        }
    }
}
