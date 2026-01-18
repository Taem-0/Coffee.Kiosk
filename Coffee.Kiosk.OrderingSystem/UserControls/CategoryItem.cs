using Coffee.Kiosk.OrderingSystem.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee.Kiosk.OrderingSystem.UserControls
{
    public partial class CategoryItem : UserControl
    {
        internal int CategoryId { get; private set; }
        internal event Action<int>? CategoryClicked;

        bool isHovered = false;
        public CategoryItem()
        {
            InitializeComponent();

        }

        private void CategoryItem_Load(object sender, EventArgs e)
        {
        }

        private void CategoryItem_Resize(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }



        // --------------------------------------------------------------------------
        private void CategoryItem_MouseEnter(object sender, EventArgs e)
        {

        }

    }
}
