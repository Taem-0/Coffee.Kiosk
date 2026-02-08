using Coffee.Kiosk.OrderingSystem.Forms.ViewDetail;
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

namespace Coffee.Kiosk.OrderingSystem.Forms.ViewDetail
{
    public partial class ViewDetail : Form
    {
        public ViewDetail(Models.Orders.OrderItem item)
        {
            InitializeComponent();
            this.Deactivate += (_, __) => this.Close();

            ProductNameLbl.Text = item.ProductName;
            pictureBox1.Image = UI_Images.loadImageFromFile(item.ImagePath);
            LoadModifierList(item);


        }


        private void LoadModifierList(Models.Orders.OrderItem item)
        {
            flowLayoutPanel1.Controls.Clear();

            var selections =
                from groupEntry in item.SelectedModifierOptions
                join g in Models.Product.modifierGroups
                    on groupEntry.Key equals g.Id
                from optionId in groupEntry.Value
                join o in Models.Product.modifierOption
                    on optionId equals o.Id
                select new
                {
                    GroupName = g.Name,
                    OptionName = o.Name,
                    PriceDelta = o.PriceDelta,
                };

            foreach (var s in selections)
            {
                var ctrl = new ModifierList(
                    s.GroupName,
                    s.OptionName,
                    s.PriceDelta
                );

                flowLayoutPanel1.Controls.Add(ctrl);
            }
        }

        private void ViewDetail_Load(object sender, EventArgs e)
        {
            UI_Handling.centerPanel(panel2, panel1);
        }

        private void ViewDetail_Resize(object sender, EventArgs e)
        {
            UI_Handling.centerPanel(panel2, panel1);
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

    }
}
