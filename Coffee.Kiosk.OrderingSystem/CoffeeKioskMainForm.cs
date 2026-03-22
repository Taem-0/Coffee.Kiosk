using Coffee.Kiosk.OrderingSystem.Forms;
using Coffee.Kiosk.OrderingSystem.Helper;
using Coffee.Kiosk.OrderingSystem.IdleTimer;
using Coffee.Kiosk.OrderingSystem.Maintenance;
using Coffee.Kiosk.OrderingSystem.Sql;
using Coffee.Kiosk.OrderingSystem.UserControls;
using Coffee.Kiosk.OrderingSystem.UserControls.PayOption;
using Coffee.Kiosk.OrderingSystem.UserControls.Reusables;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Extensions.Configuration;
using QuestPDF.Fluent;
using System;
using System.Configuration;
using System.Drawing;
using System.Text;



namespace Coffee.Kiosk.OrderingSystem
{
    public partial class CoffeeKioskMainForm : Form
    {
        private const int IdleTimeoutSeconds = 60;


        public event Action<Models.Orders>? CartUpdated;

        private GetStartedScreen? getStartedScreen;
        private DineInTakeOut? dineInTakeOut;
        private KioskMenu? kioskMenu;
        private ViewOrder? viewOrder;
        private PayOptionScreen? payOptionScreen;
        private ReceiptScreen? receiptScreen;
        private ReceiptGcashScreen? receiptGcashScreen;
        private ModalScreen? modalScreen;

        private Models.Orders? currentOrder;

        private System.Windows.Forms.Timer _idleTimer = new();
        private int _idleSeconds;

        private Guna.UI2.WinForms.Guna2Panel? idleOverlay;
        private bool _idleWarningShown;
        private IdleWarningScreen? idleWarning = new IdleWarningScreen();


        private Guna.UI2.WinForms.Guna2Panel? maintenanceOverlay;
        private System.Windows.Forms.Timer _dbCheckTimer = new();
        private int _dbCountdownSeconds = 10;
        private bool _dbWarningShown = false;
        private MaintenanceWarningScreen? maintenanceWarning = new MaintenanceWarningScreen();

        private System.Windows.Forms.Timer _dbCountdownTimer = new();

        int screenHeight;
        Size modalScreenOriginalSize = new Size(720, 800);

        public CoffeeKioskMainForm()
        {
            InitializeComponent();

            //var materialSkinManager = MaterialSkinManager.Instance;
            //materialSkinManager.AddFormToManage(this);
            UI_ColorScheme.initializeMaterialSkinThemes();

            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            DBInitializer.Init(config);

            Models.Category.LoadFromDataBase();
            Models.Product.LoadFromDataBase();

            Models.Ads.LoadFromDatabase();

            Models.UiAssets.LoadFromDatabase();
            UI_Images.loadLogoImage();

            //Models.Category.LoadDummyData();
            //Models.Product.LoadDummyData();

            _idleTimer.Interval = 1000;
            _idleTimer.Tick += IdleTimer_Tick;

            Application.AddMessageFilter(new IdleMessageFilter(ResetIdleTimer));

            _dbCheckTimer.Interval = 2000; 
            _dbCheckTimer.Tick += DbCheckTimer_Tick;
            _dbCheckTimer.Start();

            _dbCountdownTimer.Interval = 1000;
            _dbCountdownTimer.Tick += DbCountdownTimer_Tick;
        }

        private void DbCheckTimer_Tick(object? sender, EventArgs e)
        {
            if (_dbWarningShown) return;

            if (Sql.Queries.CheckIfDatabaseChanged())
            {
                ShowMaintenanceWarning();
            }
        }
        private void DbCountdownTimer_Tick(object? sender, EventArgs e)
        {
            maintenanceWarning?.SetTimerNumber(_dbCountdownSeconds);
            _dbCountdownSeconds--;

            if (_dbCountdownSeconds < 0)
            {
                _dbCountdownTimer.Stop();
                ResetMaintenanceWarning();
                FinishOrder();
            }
        }

        private void ShowMaintenanceWarning()
        {
            if (_dbWarningShown) return;

            _dbWarningShown = true;
            _dbCountdownSeconds = 10;

            maintenanceOverlay = new Guna.UI2.WinForms.Guna2Panel
            {
                Dock = DockStyle.Fill,
                FillColor = Color.FromArgb(120, 0, 0, 0),
                UseTransparentBackground = true,
                Enabled = true
            };

            this.Controls.Add(maintenanceOverlay);
            maintenanceOverlay.BringToFront();

            maintenanceWarning ??= new MaintenanceWarningScreen();

            maintenanceWarning.TopLevel = false;

            this.Controls.Add(maintenanceWarning);
            maintenanceWarning.BringToFront();

            maintenanceWarning.Left = (this.ClientSize.Width - maintenanceWarning.Width) / 2;
            maintenanceWarning.Top = (this.ClientSize.Height - maintenanceWarning.Height) / 2;

            maintenanceWarning.Show();

            _dbCheckTimer.Stop();
            _dbCountdownTimer.Start();
        }
        private void ResetMaintenanceWarning()
        {
            if (!_dbWarningShown) return;

            maintenanceWarning?.Hide();

            if (maintenanceOverlay != null)
            {
                this.Controls.Remove(maintenanceOverlay);
                maintenanceOverlay.Dispose();
                maintenanceOverlay = null;
            }

            _dbWarningShown = false;
            _dbCountdownSeconds = 10;

            _dbCheckTimer.Start();
        }
        private void IdleTimer_Tick(object? sender, EventArgs e)
        {
            _idleSeconds--;

            if (_idleSeconds <= IdleTimeoutSeconds / 2 && !_idleWarningShown) ShowIdleWarning();
            //if (_idleSeconds <= IdleTimeoutSeconds && !_idleWarningShown) ShowIdleWarning();

            if (_idleWarningShown) idleWarning?.SetTimerNumber(_idleSeconds);

            if (_idleSeconds < 0)
            {
                _idleTimer.Stop();
                ResetIdleWarning();
                FinishOrder();
            }
        }

        private void ResetIdleTimer()
        {
            if (_idleWarningShown) return;

            _idleSeconds = IdleTimeoutSeconds;
            ResetIdleWarning();
        }

        private void ResetIdleWarning()
        {
            if (!_idleWarningShown) return;

            idleWarning!.Hide();
            idleOverlay!.Visible = false;

            _idleWarningShown = false;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
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

        private void LoadNecessary()
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
            currentOrder ??= new Models.Orders();
            if (viewOrder == null)
            {
                viewOrder = new ViewOrder(currentOrder);
                viewOrder.StartOverClicked += FinishOrder;
                viewOrder.OrderMoreClicked += ShowKioskMenuScreen;
                viewOrder.CompleteOrderClicked += ShowPayOptionScreen;
            }

            currentOrder ??= new Models.Orders();
            if (viewOrder == null)
            {
                viewOrder = new ViewOrder(currentOrder);
                viewOrder.StartOverClicked += FinishOrder;
                viewOrder.OrderMoreClicked += ShowKioskMenuScreen;
                viewOrder.CompleteOrderClicked += ShowPayOptionScreen;
            }
        }


        private void ShowGetStartedScreen()
        {
            Models.AuditLogs.currentDateTime = DateTime.Now;
            if (getStartedScreen == null)
            {
                getStartedScreen = new GetStartedScreen();
                getStartedScreen.NextClicked += ShowDineInTakeOutScreen;
            }
            LoadNecessary();
            _idleTimer.Stop();
            UI_Handling.loadUserControl(mainPanel, getStartedScreen);
        }

        private void ShowDineInTakeOutScreen()
        {
            Models.Category.LoadFromDataBase();
            Models.Product.LoadFromDataBase();

            Models.Ads.LoadFromDatabase();

            Models.UiAssets.LoadFromDatabase();
            UI_Images.loadLogoImage();

            if (dineInTakeOut == null)
            {
                dineInTakeOut = new DineInTakeOut();


                dineInTakeOut.backButtonClicked += () =>
                {
                    ShowGetStartedScreen();
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
            ResetIdleTimer();
            _idleTimer.Start();
        }

        private void ShowKioskMenuScreen()
        {
            mainPanel.SuspendLayout();
            if (kioskMenu == null)
            {
                currentOrder ??= new Models.Orders();
                kioskMenu = new KioskMenu(currentOrder.Type == Models.Orders.TypeOfOrder.DineIn ? "Dine In" : "Take Out");

                kioskMenu.StartOverClicked += FinishOrder;
                kioskMenu.ProductSelected += ShowModalCustomizeScreen;
                kioskMenu.ViewOrderClicked += ShowViewOrder;
                this.CartUpdated += kioskMenu.OnCartUpdated;
            }
            currentOrder ??= new Models.Orders();
            if (viewOrder == null)
            {
                viewOrder = new ViewOrder(currentOrder);
                viewOrder.StartOverClicked += FinishOrder;
                viewOrder.OrderMoreClicked += ShowKioskMenuScreen;
                viewOrder.CompleteOrderClicked += ShowPayOptionScreen;
            }
            UI_Handling.loadUserControl(mainPanel, kioskMenu);
            mainPanel.ResumeLayout();
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
                payOptionScreen.PaymentChoiceClicked += () =>
                {
                    currentOrder ??= new Models.Orders();
                    currentOrder.paymentType = payOptionScreen.paymentChoice;
                    ShowReceiptScreen(currentOrder.paymentType);
                };
            }
            UI_Handling.loadUserControl(mainPanel, payOptionScreen);
        }

        private async void ShowReceiptScreen(Models.Orders.TypeOfPayment typeOfPayment)
        {
            if (currentOrder == null) return;

            int customerId = Sql.Queries.AddCustomerOrder(currentOrder);
            bool success = Sql.Queries.AddCustomerOrderItem(currentOrder, customerId);

            if (!success) MessageBox.Show("uhh something went wrong");

            int countdown = 10;
            _idleTimer.Stop();
            if (typeOfPayment == Models.Orders.TypeOfPayment.Cash)
            {
                if (receiptScreen == null)
                {
                    receiptScreen = new ReceiptScreen(customerId);
                    receiptScreen.ResetRequested += ShowThankYouScreen;
                }
                UI_Handling.loadUserControl(mainPanel, receiptScreen);
                await Task.Delay(3000);
                receiptScreen.StartResetCountdown(countdown);
            }
            else
            {
                if (receiptGcashScreen == null)
                {
                    receiptGcashScreen = new ReceiptGcashScreen(customerId);
                    receiptGcashScreen.ResetRequested += ShowThankYouScreen;
                }
                UI_Handling.loadUserControl(mainPanel, receiptGcashScreen);
                await Task.Delay(3000);
                receiptGcashScreen.StartResetCountdown(20);
            }

            QPdfGen.GenerateReceiptPdf(currentOrder, "Kiosk_Receipt.pdf", customerId);
        }

        private void ShowThankYouScreen()
        {
            //TODO
            FinishOrder();
        }


        private void ShowModalCustomizeScreen(int productId = 0)
        {
            modalMainScreen.SuspendLayout();
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
            modalMainScreen.ResumeLayout();
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
            modalScreen?.Dispose();
            modalScreen = null;

            kioskMenu?.KioskScrollPosFix();
        }


        private void ShowIdleWarning()
        {
            if (_idleWarningShown) return;

            _idleWarningShown = true;

            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm != this && openForm.Modal)
                {
                    openForm.Close();
                }
            }

            idleOverlay = new Guna.UI2.WinForms.Guna2Panel
            {
                Dock = DockStyle.Fill,
                FillColor = Color.FromArgb(67, 0, 0, 0),
                UseTransparentBackground = true,
            };

            this.Controls.Add(idleOverlay);
            idleOverlay.BringToFront();

            idleWarning = new IdleWarningScreen
            {
                TopLevel = false
            };

            this.Controls.Add(idleWarning);
            idleWarning.BringToFront();

            idleWarning.Left = (this.ClientSize.Width - idleWarning.Width) / 2;
            idleWarning.Top = (this.ClientSize.Height - idleWarning.Height) / 2;

            idleWarning.Show();

            idleOverlay.Click += (_, __) =>
            {
                this.Controls.Remove(idleOverlay);
                idleWarning.Close();
                _idleWarningShown = false;
                
            };
            idleWarning.FormClosed += (_, __) =>
            {
                this.Controls.Remove(idleOverlay);
                _idleWarningShown = false;
            };
        }



        internal void FinishOrder()
        {
            HideModalScreen();

            foreach (Form f in Application.OpenForms)
            {
                if (f is ConfirmRemove) f.Close();
            }

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
            payOptionScreen?.Dispose();
            receiptScreen?.Dispose();
            receiptGcashScreen?.Dispose();


            getStartedScreen = null;
            dineInTakeOut = null;
            modalScreen = null;
            viewOrder = null;
            payOptionScreen = null;
            receiptScreen = null;
            receiptGcashScreen = null;

            currentOrder = null;

            _idleTimer.Stop();
            ResetIdleWarning();

            Models.Category.LoadFromDataBase();
            Models.Product.LoadFromDataBase();

            Models.Ads.LoadFromDatabase();

            Models.UiAssets.LoadFromDatabase();
            UI_Images.loadLogoImage();

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
