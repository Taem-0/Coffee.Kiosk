using Coffee.Kiosk.CMS.CoffeeKDB;
using Coffee.Kiosk.CMS.Forms.OrderingSystemTab.UserControls.Modifiers;
using Coffee.Kiosk.CMS.Helpers;

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

            modifierGroups = OrderingSystemDbManager.GetModifierGroups(_ProductId);

            foreach (var group in modifierGroups)
            {
                var groupControl = new ModifierGroup(group);
                flowLayoutPanel1.Controls.Add(groupControl);
            }

            addModifierGroupButton.AddModifierClicked -= AddModifier;
            addModifierGroupButton.AddModifierClicked += AddModifier;
            flowLayoutPanel1.Controls.Add(addModifierGroupButton);
        }

        private void AddModifier()
        {
            //var newGroup = new UnsavedModifierGroup()
            //{
            //    ProductId = _ProductId,
            //    ParentGroupId = null,
            //    Name = "New Modifier Group",
            //    SelectionType = Models.OrderingSystem.SelectionType.Single,
            //    Required = false
            //};

            //_unsavedModifierGroups.Add(newGroup);
            //var newGroupControl = new ModifierGroup(
            //    null,
            //    newGroup.ProductId,
            //    newGroup.ParentGroupId,
            //    newGroup.Name,
            //    newGroup.SelectionType,
            //    newGroup.Required
            //    );

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
            
            flowLayoutPanel1.Controls.Remove(addModifierGroupButton);
            flowLayoutPanel1.Controls.Add(newGroupControl);
            flowLayoutPanel1.Controls.Add(addModifierGroupButton);

            addModifierGroupButton.AddModifierClicked -= AddModifier;
            addModifierGroupButton.AddModifierClicked += AddModifier;

            flowLayoutPanel1.ScrollControlIntoView(addModifierGroupButton);

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
