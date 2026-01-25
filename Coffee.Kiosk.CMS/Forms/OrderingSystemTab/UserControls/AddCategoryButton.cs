using Coffee.Kiosk.CMS.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.OrderingSystemTab.UserControls
{
    public partial class AddCategoryButton : UserControl
    {

        internal event Action? addMoreClicked;

        public AddCategoryButton()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            addMoreClicked?.Invoke();
        }



        // -----------------------------------------------

        bool isHovered = false;

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            isHovered = true;
            pictureBox1.Invalidate();
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            isHovered = false;
            pictureBox1.Invalidate();

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            UIhelp.drawBorder(e, pictureBox1.ClientRectangle, UIhelp.boxOrCircle.box, Color.Gray);
            if (!isHovered) return;
            UIhelp.darkenOnHover(e, pictureBox1.ClientRectangle, UIhelp.boxOrCircle.box);
        }
    }
}
