using Coffee.Kiosk.CMS;
using Coffee.Kiosk.CMS.CoffeeKDB;
using Coffee.Kiosk.CMS.Helpers; 
using MaterialSkin;
using MaterialSkin.Controls;
namespace Coffee.Kiosk
{
    public partial class AdminControlForm : MaterialForm
    {

        private RegisterControl registerControl = new RegisterControl();
        private EmployeesControl employeesControl = new EmployeesControl();

        private void ShowEmployees() => UIhelp.CallControl(employeesControl, AccountsContentPanel);


        public AdminControlForm()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            registerControl = new RegisterControl();
            registerControl.ParentFormReference = this;

            employeesControl = new EmployeesControl();
            employeesControl.ParentFormReference = this;
    
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            ShowEmployees();

        }

        public void ShowInAccountsPanel(UserControl control)
        {
            UIhelp.CallControl(control, AccountsContentPanel);
        }

    }
}
