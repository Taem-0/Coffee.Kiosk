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
using Windows.Graphics.Printing;

namespace Coffee.Kiosk.OrderingSystem.UserControls.Reusables
{
    public partial class OrderList : UserControl
    {
        private readonly Models.Orders.OrderItem _item;
        internal event Action<Models.Orders.OrderItem>? AddQuantityClicked;
        internal event Action<Models.Orders.OrderItem>? SubtractQuantityClicked;

        public OrderList(Models.Orders.OrderItem item)
        {
            InitializeComponent();
            _item = item;

            pictureBox1.Image = UI_Images.loadImageFromFile(item.ImagePath);
            ItemLbl.Text = item.ProductName;
            QuantityLbl.Text = _item.Quantity.ToString();
            itemCostLbl.Text = $"PHP {_item.ProductPrice * _item.Quantity}";
        }

        private void AddQuantityBtn_Click(object sender, EventArgs e)
        {
            AddQuantityClicked?.Invoke(_item);
            QuantityLbl.Text = $"{_item.Quantity}";
            itemCostLbl.Text = $"PHP {_item.ProductPrice * _item.Quantity}";
        }

        private void SubtractQuantityBtn_Click(object sender, EventArgs e)
        {
            SubtractQuantityClicked?.Invoke(_item);
            QuantityLbl.Text = $"{_item.Quantity}";
            itemCostLbl.Text = $"PHP {_item.ProductPrice * _item.Quantity}";
        }

        private void RemoveBtn_Click(object sender, EventArgs e)
        {

        }

        private void ViewDetailsBtn_Click(object sender, EventArgs e)
        {

        }

        private void QuantityLbl_Paint(object sender, PaintEventArgs e)
        {
            UI_Handling.drawBorder(e, QuantityLbl.ClientRectangle, UI_Handling.boxOrCircle.box, Color.Gray);
        }
    }
}
