using Coffee.Kiosk.CMS.Forms.OrderingSystemTab.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.OrderingSystemTab.FormDialog
{
    public partial class EditModifierGroup : Form
    {

        //private OnHoverTipBox currentToolTip = new OnHoverTipBox();
        private CustomToolTip currentToolTip = new CustomToolTip();
        Models.OrderingSystem.ModifierGroup _model;

        public EditModifierGroup(Models.OrderingSystem.ModifierGroup model)
        {
            InitializeComponent();

            _model = model;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ShowToolTip(String tipText)
        {
            currentToolTip.ChangeToolTipText(tipText);

            currentToolTip.ChangeToolTipText(tipText);

            Point screenPos = Cursor.Position;
            currentToolTip.Location = new Point(screenPos.X + 10, screenPos.Y + 10);

            currentToolTip.Show();
        }
        private void HideToolTip()
        {
            currentToolTip.Hide();
        }

        // ------------------------------------------

        private void SelectionTypeToolTip_MouseEnter(object sender, EventArgs e)
        {
            ShowToolTip("""
                Select single or multiple options

                Single - Only allows one option to be selected.
                Multiple - Allows multiple option to be selected
                """);
        }

        private void SelectionTypeToolTip_MouseLeave(object sender, EventArgs e)
        {
            HideToolTip();
        }

        private void RequiredToolTip_MouseEnter(object sender, EventArgs e)
        {

        }

        private void RequiredToolTip_MouseLeave(object sender, EventArgs e)
        {

        }
    }
}
