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

        public CategoryItem(int categoryId, string name, string iconPath = "C:/Images/default_icon.png")
        {
            InitializeComponent();

            CategoryId = categoryId;
            label1.Text = name;

            pictureBox1.Image = UI_Images.loadImageFromFile(iconPath);

        }

        public CategoryItem(int categoryId, string name, Image icon)
        {
            InitializeComponent();

            CategoryId = categoryId;
            label1.Text = name;

            pictureBox1.Image = icon;
        }

        private void CategoryItem_Load(object sender, EventArgs e)
        {
        }

        private void CategoryItem_Resize(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            CategoryClicked?.Invoke(CategoryId);

        }
        private void CategoryItem_Click(object sender, EventArgs e)
        {
            CategoryClicked?.Invoke(CategoryId);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }



        // --------------------------------------------------------------------------

        bool isHovered = false;
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            isHovered = true;
            pictureBox1.Invalidate();
            label1.Invalidate();
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            isHovered = false;
            pictureBox1.Invalidate();
            label1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (!isHovered) return;
            UI_Handling.darkenOnHover(e, pictureBox1.ClientRectangle, UI_Handling.boxOrCircle.box);
        }

        private void label1_Paint(object sender, PaintEventArgs e)
        {
            if (!isHovered) return;
            UI_Handling.darkenOnHover(e, label1.ClientRectangle, UI_Handling.boxOrCircle.box);
        }
    }
}
