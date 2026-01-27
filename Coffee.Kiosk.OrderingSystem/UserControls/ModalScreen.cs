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
    public partial class ModalScreen : UserControl
    {
        internal event Action? BackButtonClicked;

        internal int productId;
        public ModalScreen(int productId)
        {
            InitializeComponent();
            label1.Text = "Product ID:" + productId.ToString();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            BackButtonClicked?.Invoke();
        }
    }
}
