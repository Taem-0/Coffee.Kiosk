using Coffee.Kiosk.CMS.Controllers;
using Coffee.Kiosk.CMS.Forms.AccountsTab.AccountUserControls;
using Coffee.Kiosk.CMS.Helpers;
using System;
using System.Windows.Forms;
using static Coffee.Kiosk.CMS.Helpers.UIhelp;

namespace Coffee.Kiosk.CMS.Forms.AccountsTab
{
    public partial class NewEmployeeView : UserControl
    {
        public AdminControlForm? ParentFormReference { get; set; }
        private readonly AccountController _controller;
        private readonly ShopController _themeController;

        public NewEmployeeView(AccountController controller, ShopController themeController)
        {
            InitializeComponent();
            _controller = controller ?? throw new ArgumentNullException(nameof(controller));
            _themeController = themeController ?? throw new ArgumentNullException(nameof(themeController));

            var uiTheme = UIhelp.ThemeManager.BuildUITheme(_themeController);
            UIhelp.ThemeManager.ApplyTheme(this, uiTheme);

            employeeContainerContainer1.Initialize(_controller, _themeController);



            UIhelp.ThemeManager.ThemeChanged += OnThemeChanged;



        }

        private void OnThemeChanged(object? sender, UIhelp.UITheme theme)
        {
            if (InvokeRequired) { Invoke(() => OnThemeChanged(sender, theme)); return; }
            UIhelp.ThemeManager.ApplyTheme(this, theme);

        }

        private void NewEmployeeView_Load(object sender, EventArgs e) { }

        private void employeeContainerContainer1_Load(object sender, EventArgs e)
        {

        }
    }
}