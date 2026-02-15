using Coffee.Kiosk.OrderingSystem.Forms;
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
        internal event Action? CompleteOrderClicked;

        private readonly Models.Orders _orders;

        int currentCartCount = 0;
        decimal totalPriceAmount = 0;
        public ViewOrder(Models.Orders orders)
        {
            InitializeComponent();
            _orders = orders;
            LoadCurrentOrders();
            OnCartUpdate(orders);
            pictureBox1.Image = UI_Images.logoImage;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
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

        private void OnSubtractQuantity(Models.Orders.OrderItem item, bool remove)
        {
            if (item.Quantity <= 1 || remove)
            {
                using (var confirm = new ConfirmRemove($"Remove Item {item.ProductName}?"))
                {
                    var result = confirm.ShowDialog();
                    if (result == DialogResult.Yes)
                    {
                        _orders.Items.Remove(item);
                        LoadCurrentOrders();
                    }
                }
            }
            else
            {
                item.Quantity--;
            }
            totalPriceAmount = _orders.Items.Sum(i => i.ProductPrice * i.Quantity);
            TotalPriceLbl.Text = $"PHP {totalPriceAmount:0.00}";
            OnCartUpdate(_orders);
        }

        private void OrderMoreBtn_Click(object sender, EventArgs e)
        {
            totalPriceAmount = _orders.Items.Sum(i => i.ProductPrice * i.Quantity);
            TotalPriceLbl.Text = $"PHP {totalPriceAmount:0.00}";
            OrderMoreClicked?.Invoke();
        }

        public void OnCartUpdate(Models.Orders orders)
        {
            currentCartCount = orders.Items.Sum(i => i.Quantity);

            checkOutBtn.Enabled = currentCartCount > 0;
            totalPriceAmount = orders.Items.Sum(item => item.ProductPrice * item.Quantity);
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

            using (var confirm = new ConfirmRemove("Start Over?"))
            {
                var result = confirm.ShowDialog();
                if (result == DialogResult.Yes)
                {
                    StartOverClicked?.Invoke();
                }
            }
        }

        private void checkOutBtn_Click(object sender, EventArgs e)
        {
            CompleteOrderClicked?.Invoke();
        }
    }
}
