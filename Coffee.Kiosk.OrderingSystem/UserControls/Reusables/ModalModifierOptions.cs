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
    public partial class ModalModifierOptions : UserControl
    {
        bool isSelected = false;
        public int OptionId;
        public event Action<ModalModifierOptions>? SelectChanged;
        public string OptionName = String.Empty;
        public bool TriggersChild;
        public ModalModifierOptions(Models.Product.ModifierOption modifierOption)
        {
            InitializeComponent();

            OptionId = modifierOption.Id; 
            OptionName = modifierOption.Name;
            TriggersChild = modifierOption.TriggersChild;

            guna2Button1.Text = OptionName;

            if (!TriggersChild)
            {
                isSelected = true;
                guna2Button1.FillColor = Color.Gray;
            }
        }



        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (isSelected)
            {
                Deselect();
            }else
            {
                isSelected = true;
                guna2Button1.FillColor = Color.Gray;
            }
            SelectChanged?.Invoke(this);
        }

        public void Deselect()
        {
            isSelected = false;
            guna2Button1.FillColor = Color.White;
        }
    }
}
