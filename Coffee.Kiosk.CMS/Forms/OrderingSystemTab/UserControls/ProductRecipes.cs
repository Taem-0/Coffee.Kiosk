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
    public partial class ProductRecipes : UserControl
    {
        private Models.OrderingSystem.ProductRecipe _model;
        public ProductRecipes(Models.OrderingSystem.ProductRecipe model)
        {
            InitializeComponent();
            _model = model;
        }

        private void DecreaseBtn_Click(object sender, EventArgs e)
        {

        }

        private void IncreaseBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
