namespace Coffee.Kiosk.CMS.Forms.SettingsTab.SettingsUserControls
{
    public partial class BannerSelectVertical : BannerSelectBase
    {
        public BannerSelectVertical()
        {
            InitializeComponent();
            HookClicks();
        }

        protected override Guna.UI2.WinForms.Guna2PictureBox GetPictureBox() => guna2PictureBox1;
    }
}