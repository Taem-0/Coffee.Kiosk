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
        public Models.Product.ModifierOption Option { get; }
        public bool IsSelected { get; private set; }

        public event Action<ModalModifierOptions>? SelectionChanged;

        public ModalModifierOptions(Models.Product.ModifierOption option)
        {
            InitializeComponent();
            Option = option;

            guna2Button1.Text = option.Name;
            IsSelected = false;
            //if (!option.TriggersChild)
            //{
            //    IsSelected = true;
            //}

            UpdateVisual();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            IsSelected = !IsSelected;
            UpdateVisual();
            SelectionChanged?.Invoke(this);
        }

        public void Deselect()
        {
            IsSelected = false;
            UpdateVisual();
        }

        private void UpdateVisual()
        {
            guna2Button1.FillColor = IsSelected ? Color.Gray : Color.White;
        }
    }
}
