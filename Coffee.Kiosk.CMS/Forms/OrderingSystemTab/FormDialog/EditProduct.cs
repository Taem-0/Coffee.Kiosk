using Coffee.Kiosk.CMS.CoffeeKDB;
using Coffee.Kiosk.CMS.Forms.OrderingSystemTab.UserControls.Modifiers;
using Coffee.Kiosk.CMS.Helpers;
using MySqlX.XDevAPI.Common;

namespace Coffee.Kiosk.CMS.Forms.OrderingSystemTab.FormDialog
{
    public partial class EditProduct : Form
    {

        private AddModifierGroupButton addModifierGroupButton = new AddModifierGroupButton();

        //public class UnsavedModifierGroup
        //{
        //    public int ProductId { get; set; }
        //    public int? ParentGroupId { get; set; }
        //    public string Name { get; set; } = string.Empty;
        //    public Models.OrderingSystem.SelectionType SelectionType { get; set; }
        //    public bool Required { get; set; }
        //}

        //private List<UnsavedModifierGroup> _unsavedModifierGroups = new List<UnsavedModifierGroup>();
        private List<Models.OrderingSystem.ModifierGroup> modifierGroups = new ();

        int _ProductId;
        string _ProductName = String.Empty;
        decimal _ProductPrice;
        string _ImagePath = String.Empty;


        public EditProduct(int productId, string productName, decimal productPrice, string imagePath)
        {
            InitializeComponent();


            _ProductId = productId;
            _ProductName = productName;
            _ProductPrice = productPrice;
            _ImagePath = imagePath;


            ProductNameTxtBox.Text = productName;
            PriceTxtBox.Text = productPrice.ToString();
            pictureBox1.Image = UIhelp.loadImageFromFile(imagePath);

            LoadModifierGroups();
        }

        private void LoadModifierGroups()
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.SuspendLayout();

            modifierGroups = OrderingSystemDbManager.GetModifierGroups(_ProductId);

            //var modifierGroupWithoutParentId = modifierGroups.Where(g => g.ParentGroupId == null).ToList();
            //var modifierGroupWithParentId = modifierGroups.Where(g => g.ParentGroupId != null).ToList();

            //foreach (var parent in modifierGroupWithoutParentId)
            //{
            //    var groupControl = new ModifierGroup(parent);
            //    groupControl.EditClicked += EditModifierGroup;
            //    groupControl.DeleteClicked += DeleteModifierGroup;

            //    flowLayoutPanel1.Controls.Add(groupControl);
            //    foreach(var child in modifierGroupWithParentId.Where(g => g.ParentGroupId == parent.Id))
            //    {
            //        var childControl = new ModifierGroup(child);
            //        childControl.EditClicked += EditModifierGroup;
            //        childControl.DeleteClicked += DeleteModifierGroup;

            //        flowLayoutPanel1.Controls.Add(childControl);
            //    }
            //}

            RecursivelyAddGroups(null);

            addModifierGroupButton.AddModifierClicked -= AddModifier;
            addModifierGroupButton.AddModifierClicked += AddModifier;
            flowLayoutPanel1.Controls.Add(addModifierGroupButton);

            flowLayoutPanel1.ResumeLayout();
        }

        private void RecursivelyAddGroups(int? parentId)
        {
            foreach (var group in modifierGroups.Where(g => g.ParentGroupId == parentId))
            {
                var groupControl = new ModifierGroup(group);
                groupControl.EditClicked += EditModifierGroup;
                groupControl.DeleteClicked += DeleteModifierGroup;

                flowLayoutPanel1.Controls.Add(groupControl);

                RecursivelyAddGroups(group.Id);
            }
        }

        private void AddModifier()
        {
            int newGroup = OrderingSystemDbManager.AddModifierGroup(
                _ProductId,
                null,
                "New Modifier Group",
                Models.OrderingSystem.SelectionType.Single,
                false
                );

            modifierGroups.Add(new Models.OrderingSystem.ModifierGroup(
                newGroup,
                _ProductId,
                null,
                "New Modifier Group",
                Models.OrderingSystem.SelectionType.Single,
                false
                ));

            var newGroupControl = new ModifierGroup(modifierGroups.Last());
                newGroupControl.EditClicked += EditModifierGroup;
                newGroupControl.DeleteClicked += DeleteModifierGroup;
            
            flowLayoutPanel1.Controls.Remove(addModifierGroupButton);
            flowLayoutPanel1.Controls.Add(newGroupControl);
            flowLayoutPanel1.Controls.Add(addModifierGroupButton);

            addModifierGroupButton.AddModifierClicked -= AddModifier;
            addModifierGroupButton.AddModifierClicked += AddModifier;

            flowLayoutPanel1.ScrollControlIntoView(addModifierGroupButton);
        }

        private void EditModifierGroup(Models.OrderingSystem.ModifierGroup model)
        {
            using var dialog = new EditModifierGroup(model, modifierGroups);
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                LoadModifierGroups();
            }
        }
        private void DeleteModifierGroup(int GroupId)
        {
            using var dialog = new ConfirmDelete("Are you sure you want to delete this Modifier Group?");
            if (dialog.ShowDialog() != DialogResult.OK) return;

            OrderingSystemDbManager.DeleteModifierGroup(GroupId);
            LoadModifierGroups();
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

            _ImagePath = dialog.FileName;
            pictureBox1.Image = UIhelp.loadImageFromFile(_ImagePath);
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            string name = ProductNameTxtBox.Text.Trim();
            string priceText = PriceTxtBox.Text.Trim();

            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(name)) errors.Add("Product name cannot be empty.");
            if (!decimal.TryParse(priceText, out decimal parsedPrice)) errors.Add("Price must be a valid number (e.g., 123.12).");
            if (parsedPrice < 0) errors.Add("Price cannot be negative.");

            if (errors.Count > 0)
            {
                MessageBox.Show(string.Join("\n", errors));
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }



        //---------------------------------------------

        bool isHoveredPicture = false;

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
            if (!isHoveredPicture) return;
            UIhelp.darkenOnHover(e, pictureBox1.ClientRectangle, UIhelp.boxOrCircle.box);
        }
    }
}
