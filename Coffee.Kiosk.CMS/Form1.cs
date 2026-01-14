using MaterialSkin;
using MaterialSkin.Controls;
using Coffee.Kiosk.CMS.Helpers; 
namespace Coffee.Kiosk
{
    public partial class AdminControlForm : MaterialForm
    {
        public AdminControlForm()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            UIhelp.buttonNaRound(addEmpButton, 20);

        }


        private void materialListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
