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

            LoadImageAsync(iconPath);
            guna2Button1.Text = name;
        }

        public CategoryItem(int categoryId, string name, Image icon)
        {
            InitializeComponent();

            CategoryId = categoryId;

            guna2Button1.Text = name;
            guna2Button1.Image = icon;
        }


        private void LoadImageAsync(string path)
        {
            Task.Run(() =>
            {
                var img = UI_Images.loadImageFromFile(path);
                guna2Button1.Invoke(() =>
                {
                    guna2Button1.Image = img;
                });
            });
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            CategoryClicked?.Invoke(CategoryId);
        }
    }
}
