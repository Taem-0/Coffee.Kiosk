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
    public partial class ModifierList : UserControl
    {
        public ModifierList(string groupName, string optName, decimal priceDelta = 0)
        {
            InitializeComponent();

            label1.Text = $"•{groupName}: {optName}";
            label2.Text = $"{(priceDelta == 0 ? "+PHP 0.00" : $"+PHP {priceDelta:0.00}")}";
        }
    }
}
