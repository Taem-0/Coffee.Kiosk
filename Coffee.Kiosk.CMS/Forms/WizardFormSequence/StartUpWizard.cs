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

            // :3

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