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

namespace Coffee.Kiosk.OrderingSystem.UserControls.Reusables
{
    public partial class UnavailableProduct : UserControl
    {
        public UnavailableProduct(int productId, int categoryId, string name, string imagePath, decimal price)
        {
            InitializeComponent();

            pictureBox1.Image = UI_Images.loadImageFromFile(imagePath);
            productName.Text = name.ToString();
        }
    }
}
