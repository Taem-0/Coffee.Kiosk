using Coffee.Kiosk.OrderingSystem.Forms;
using Coffee.Kiosk.OrderingSystem.Forms.ViewDetail;
using Coffee.Kiosk.OrderingSystem.Helper;
using Guna.UI2.WinForms;
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
        internal event Action<Models.Orders.OrderItem, bool>? SubtractQuantityClicked;

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
            SubtractQuantityClicked?.Invoke(_item, false);
            QuantityLbl.Text = $"{_item.Quantity}";
            itemCostLbl.Text = $"PHP {_item.ProductPrice * _item.Quantity}";
        }

        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            SubtractQuantityClicked?.Invoke(_item, true);
        }

        private void ViewDetailsBtn_Click(object sender, EventArgs e)
        {
            var parentForm = this.FindForm();

            Guna2Panel overlay = new Guna2Panel
            {
                Dock = DockStyle.Fill,
                FillColor = Color.FromArgb(67, 0, 0, 0),
                UseTransparentBackground = true,
            };
            parentForm.Controls.Add(overlay);
            overlay.BringToFront();

            var view = new ViewDetail(_item);
            view.TopLevel = false;
            parentForm.Controls.Add(view);
            view.BringToFront();

            view.Left = (parentForm.ClientSize.Width - view.Width) / 2;
            view.Top = (parentForm.ClientSize.Height - view.Height) / 2;


            view.Show();

            overlay.Click += (_, __) =>
            {
                view.Close();
                parentForm.Controls.Remove(overlay);
                overlay.Dispose();
            };

            view.FormClosed += (_, __) =>
            {
                parentForm.Controls.Remove(overlay);
                overlay.Dispose();
            };
        }

        private void QuantityLbl_Paint(object sender, PaintEventArgs e)
        {
            UI_Handling.drawBorder(e, QuantityLbl.ClientRectangle, UI_Handling.boxOrCircle.box, Color.Gray);
        }
    }
}
