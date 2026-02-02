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
        public event Action<int>? CartUpdated;

        private GetStartedScreen? getStartedScreen;
        private DineInTakeOut? dineInTakeOut;
        private KioskMenu? kioskMenu;

        private ModalScreen? modalScreen;

        public Models.Orders? currentOrder;

        int screenHeight;
        Size modalScreenOriginalSize = new Size(676, 800);

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

            // remove after connecting to database
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

        //private void loadEverything()
        //{
        //    if (getStartedScreen == null)
        //    {
        //        getStartedScreen = new GetStartedScreen();
        //        getStartedScreen.NextClicked += ShowDineInTakeOutScreen;
        //    }
        //    if (dineInTakeOut == null)
        //    {
        //        dineInTakeOut = new DineInTakeOut();

        //        dineInTakeOut.backButtonClicked += () =>
        //        {
        //            UI_Handling.loadUserControl(mainPanel, getStartedScreen);
        //        };

        //        dineInTakeOut.hasPickedAChoice += () =>
        //        {
        //            if (currentOrder == null)
        //            {
        //                currentOrder = new Models.Orders();
        //            }
        //            currentOrder.Type = dineInTakeOut.lastChoice;
        //            ShowKioskMenuScreen();
        //        };
        //    }
        //    if (kioskMenu == null)
        //    {
        //        kioskMenu = new KioskMenu();
        //        kioskMenu.startOverClicked += FinishOrder;
        //        kioskMenu.ProductSelected += ShowModalScreen;

        //        this.CartUpdated += kioskMenu.OnCartUpdated;
        //    }
        //}


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
                kioskMenu = new KioskMenu(currentOrder?.Type == Models.Orders.TypeOfOrder.DineIn ? "Dine In" : "Take Out");

                kioskMenu.startOverClicked += FinishOrder;
                kioskMenu.ProductSelected += ShowModalScreen;

                this.CartUpdated += kioskMenu.OnCartUpdated;
            }
            UI_Handling.loadUserControl(mainPanel, kioskMenu);
        }

        private void ShowModalScreen(int productId = 0)
        {
            if (modalScreen == null)
            {
                modalScreen = new ModalScreen(productId);
                modalScreen.BackButtonClicked += HideModalScreen;
                modalScreen.AddToCartClicked += item =>
                {
                    if (currentOrder == null)
                        return;

                    currentOrder.Items.Add(item);

                    CartUpdated?.Invoke(currentOrder.Items.Count());

                    var modifiers = new StringBuilder();
                    foreach (var modifier in item.SelectedModifiersName)
                    {
                        modifiers.AppendLine($"{modifier.Key}: {string.Join(",", modifier.Value)}");
                    }

                    MessageBox.Show($"""
                        {item.ProductId.ToString()}: {item.ProductName.ToString()}
                        Quantity: {item.Quantity.ToString()}
                        {modifiers}
                        """);
                    HideModalScreen();
                };

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
            getStartedScreen?.Dispose();
            dineInTakeOut?.Dispose();
            kioskMenu?.Dispose();
            modalScreen?.Dispose();

            getStartedScreen = null;
            dineInTakeOut = null;
            kioskMenu = null;
            modalScreen = null;

            currentOrder = null;

            ShowGetStartedScreen();
        }


        private void CoffeeKioskMainForm_Resize(object sender, EventArgs e)
        {
            screenHeight = this.ClientSize.Height;
            if (screenHeight > 1000)
            {
                modalMainScreen.Height = 1000;

            } else
            {
                modalMainScreen.Size = modalScreenOriginalSize;
            }

                UI_Handling.centerPanel(modalOverlayPanel, modalMainScreen);
        }
    }
}
