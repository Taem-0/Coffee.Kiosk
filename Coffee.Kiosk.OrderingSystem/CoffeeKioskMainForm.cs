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
            var getStartedScreen = new GetStartedScreen();

            getStartedScreen.NextClicked += () =>
            {
                UI_Handling.loadUserControl(mainPanel, new DineInTakeOut());
            };

            UI_Handling.loadUserControl(mainPanel, getStartedScreen);


        }
    }
}
