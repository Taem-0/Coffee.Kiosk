using Coffee.Kiosk.CMS.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.OrderingSystemTab.UserControls
{
    public partial class CategoryItem : UserControl
    {
        internal int CategoryId { get; }
        internal bool IsDraft { get; }

        internal event Action<int>? doubleClicked;
        internal event Action<int, string>? IconEditRequest;
        internal event Action<int>? NameEditRequest;
        internal event Action<int>? DeleteRequest;
        internal event Action<int, bool>? IsDraftEditRequest;

        public CategoryItem(
            int categoryId = 0,
            string categoryName = "category_name",
            string iconPath = "C:/Images/default_icon.png",
            bool isDraft = true
            )
        {
            InitializeComponent();

            CategoryIdLabel.Text = $"{categoryId}.";
            CategoryName.Text = categoryName;
            pictureBox1.Image = UIhelp.loadImageFromFile(iconPath);

            CategoryId = categoryId;
            materialSwitch1.Checked = isDraft;

            this.SetStyle(ControlStyles.Selectable, true);
            this.TabStop = true;


            //if (isDraft) this.BackColor = Color.Gray;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Title = "Select category icon",
                Filter = "Image Files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg",
                Multiselect = false
            };
            if (dialog.ShowDialog() != DialogResult.OK) return;

            var selectedPath = dialog.FileName;
            pictureBox1.Image = UIhelp.loadImageFromFile(selectedPath);
            IconEditRequest?.Invoke(CategoryId, selectedPath);
        }


        private void CategoryItem_DoubleClick(object sender, EventArgs e)
        {
            doubleClicked?.Invoke(CategoryId);
        }
        private void materialSwitch1_Click(object sender, EventArgs e)
        {
            IsDraftEditRequest?.Invoke(CategoryId, materialSwitch1.Checked);

        }
        private void EditName_Click(object sender, EventArgs e)
        {
            NameEditRequest?.Invoke(CategoryId);
        }

        private void CategoryName_Click(object sender, EventArgs e)
        {
            NameEditRequest?.Invoke(CategoryId);
        }
        private void ChangeImage_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Title = "Select category icon",
                Filter = "Image Files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg",
                Multiselect = false
            };
            if (dialog.ShowDialog() != DialogResult.OK) return;

            var selectedPath = dialog.FileName;
            pictureBox1.Image = UIhelp.loadImageFromFile(selectedPath);
            IconEditRequest?.Invoke(CategoryId, selectedPath);
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteRequest?.Invoke(CategoryId);
        }

        internal void UpdateCategoryName(string newName)
        {
            CategoryName.Text = newName;
        }

        private void CategoryItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (isHovered && (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back))
            {
                DeleteRequest?.Invoke(CategoryId);
                e.Handled = true;
            }
        }

        // ----------------------------------------------------------

        bool isHovered = false;
        bool isHoveredName = false;
        bool isHoveredPicture = false;

        private void CategoryItem_Paint(object sender, PaintEventArgs e)
        {
            UIhelp.drawBorder(e, this.ClientRectangle, UIhelp.boxOrCircle.box, Color.Black);
            if (!isHovered) return;
            UIhelp.darkenOnHover(e, this.ClientRectangle, UIhelp.boxOrCircle.box);
        }

        private void CategoryItem_MouseEnter(object sender, EventArgs e)
        {
            isHovered = true;
            this.Invalidate();
            CategoryName.Invalidate();
        }

        private void CategoryItem_MouseLeave(object sender, EventArgs e)
        {
            isHovered = false;
            this.Invalidate();
            CategoryName.Invalidate();
        }

        private void CategoryName_Paint(object sender, PaintEventArgs e)
        {
            if (isHovered || isHoveredName)
            {
                UIhelp.darkenOnHover(e, CategoryName.ClientRectangle, UIhelp.boxOrCircle.box);
            }
        }

        private void CategoryName_MouseEnter(object sender, EventArgs e)
        {
            isHoveredName = true;
            this.Invalidate();
            CategoryName.Invalidate();
        }

        private void CategoryName_MouseLeave(object sender, EventArgs e)
        {
            isHoveredName = false;
            this.Invalidate();
            CategoryName.Invalidate();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            isHoveredPicture = true;
            pictureBox1.Invalidate();
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            isHoveredPicture = false;
            pictureBox1.Invalidate();

        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            UIhelp.drawBorder(e, pictureBox1.ClientRectangle, UIhelp.boxOrCircle.box, Color.Black);
            if (!isHoveredPicture) return;
            UIhelp.darkenOnHover(e, pictureBox1.ClientRectangle, UIhelp.boxOrCircle.box);
        }
    }
}
