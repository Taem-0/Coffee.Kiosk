using Coffee.Kiosk.OrderingSystem.Helper;
using Coffee.Kiosk.OrderingSystem.UserControls.Reusables;
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
    public partial class ViewOrder : UserControl
    {
        internal event Action? OrderMoreClicked;
        internal event Action? StartOverClicked;

        private readonly Models.Orders _orders;



        decimal totalPriceAmount = 0;
        public ViewOrder(Models.Orders orders)
        {
            InitializeComponent();
            _orders = orders;
            LoadCurrentOrders();
        }


        public void LoadCurrentOrders()
        {
            flowLayoutPanel1.Visible = true;
            flowLayoutPanel1.Controls.Clear();
            foreach (var item in _orders.Items)
            {
                var orderItem = new OrderList(item);
                orderItem.AddQuantityClicked += OnAddQuantity;
                orderItem.SubtractQuantityClicked += OnSubtractQuantity;
                flowLayoutPanel1.Controls.Add(orderItem);
            }
            totalPriceAmount = _orders.Items.Sum(i => i.ProductPrice * i.Quantity);
            TotalPriceLbl.Text = $"PHP {totalPriceAmount}";
        }

        private void OnAddQuantity(Models.Orders.OrderItem item)
        {
            item.Quantity++;
            totalPriceAmount = _orders.Items.Sum(i => i.ProductPrice * i.Quantity);
            TotalPriceLbl.Text = $"PHP {totalPriceAmount:0.00}";
        }
        private void OnSubtractQuantity(Models.Orders.OrderItem item)
        {
            if (item.Quantity <= 1)
            {
                _orders.Items.Remove(item);
                LoadCurrentOrders();
            } else
            {
                item.Quantity--;
            }

        }


        private void OrderMoreBtn_Click(object sender, EventArgs e)
        {
            totalPriceAmount = _orders.Items.Sum(i => i.ProductPrice * i.Quantity);
            TotalPriceLbl.Text = $"PHP {totalPriceAmount:0.00}";
            OrderMoreClicked?.Invoke();
        }

        private void ViewOrder_Resize(object sender, EventArgs e)
        {
            ResizeFlowLayoutPanel();
        }

        private void ViewOrder_Load(object sender, EventArgs e)
        {
            ResizeFlowLayoutPanel();
        }

        private void ResizeFlowLayoutPanel()
        {
            if (this.Height > 1700)
            {
                guna2Panel1.Height = 1450;
            }
            else if (this.Height > 1200)
            {
                guna2Panel1.Height = 1000;
            }
            else if (this.Height > 1000)
            {
                guna2Panel1.Height = 800;
            }
            else
            {
                guna2Panel1.Height = 650;
            }

            UI_Handling.centerPanel(panel2, guna2Panel1);
        }

        private void StarvOverBtn_Click(object sender, EventArgs e)
        {
            StartOverClicked?.Invoke();
        }
    }
}
