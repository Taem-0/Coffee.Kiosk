using Coffee.Kiosk.CMS.Helpers;
using System;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.WizardWoopWoop
{
    public partial class StartUpWizard : Form
    {
        public IServiceProvider ServiceProvider { get; set; }

        public StartUpWizard()
        {
            InitializeComponent();


        }

        private void StartUpWizard_Load(object sender, EventArgs e)
        {
            guna2PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            // :3 Manual, causeeeeeee.....!

            Color darkBrown = ColorTranslator.FromHtml("#3d211a");
            Color mediumBrown = ColorTranslator.FromHtml("#6f4d38");
            Color lightBrown = ColorTranslator.FromHtml("#a07856");
            Color beige = ColorTranslator.FromHtml("#cbb799");
            Color background = ColorTranslator.FromHtml("#f5f5dc");

            this.BackColor = background;
            this.ForeColor = darkBrown; 

            BannerPanel.BackColor = mediumBrown; 
            panel1.BackColor = background; 
            panel1.ForeColor = darkBrown; 

            label1.ForeColor = darkBrown;

            guna2Button1.FillColor = mediumBrown;
            guna2Button1.ForeColor = Color.White;
            guna2Button1.BorderColor = darkBrown;

            guna2Button2.FillColor = mediumBrown;
            guna2Button2.ForeColor = Color.White;
            guna2Button2.BorderColor = darkBrown;

            guna2Separator1.FillColor = darkBrown;

            guna2Button1.MouseEnter += (s, args) => guna2Button1.FillColor = lightBrown;
            guna2Button1.MouseLeave += (s, args) => guna2Button1.FillColor = mediumBrown;

            guna2Button2.MouseEnter += (s, args) => guna2Button2.FillColor = lightBrown;
            guna2Button2.MouseLeave += (s, args) => guna2Button2.FillColor = mediumBrown;
        }


        private void guna2Button2_Click(object sender, EventArgs e)
        {
            var ownerRegistration = new WizardFormSequence.OwnerRegistration();
            ownerRegistration.ServiceProvider = ServiceProvider;

            this.Hide();
            var result = ownerRegistration.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                this.Show();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}