using Coffee.Kiosk.OrderingSystem.Helper;
using Coffee.Kiosk.OrderingSystem.UserControls;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.ApplicationModel.Contacts;

namespace Coffee.Kiosk.OrderingSystem
{
    public partial class KioskMenu : UserControl
    {
        internal event Action? startOverClicked;

        private readonly Dictionary<int, UserControl> categoryPage = new();
        private UserControl? currentPage;

        private const int HOME_CATEGORY_ID = 0;
        private HomePage? homePage;

        public KioskMenu()
        {
            InitializeComponent();

            flowCategories.Dock = DockStyle.Left;
            flowCategories.FlowDirection = FlowDirection.TopDown;
            flowCategories.WrapContents = false;
            flowCategories.AutoScroll = true;

            LoadCategories();
            ShowHome();
        }
        private void StartOver_Button_Click(object sender, EventArgs e)
        {
            startOverClicked?.Invoke();
        }
        private void LoadCategories()
        {
            flowCategories.SuspendLayout();
            flowCategories.Controls.Clear();

            var homeItem = new CategoryItem(HOME_CATEGORY_ID, "Home", Properties.Resources.HOME);
            homeItem.CategoryClicked += OnCategoryClicked;
            flowCategories.Controls.Add(homeItem);

            for (int i = 0; i < Models.Category.categoryData.Count; i++)
            {
                var categoryItem = new CategoryItem(
                    Models.Category.categoryData[i].Id,
                    Models.Category.categoryData[i].Name,
                    UI_Images.loadImageFromFile(Models.Category.categoryData[i].IconPath)
                    );
                categoryItem.CategoryClicked += OnCategoryClicked;
                flowCategories.Controls.Add(categoryItem);
            }
            flowCategories.ResumeLayout();
        }

        private void OnCategoryClicked(int categoryId)
        {
            if (categoryId == HOME_CATEGORY_ID)
            {
                ShowHome();
            }
            else
            {
                ShowCategory(categoryId);
            }
        }

        private void ShowHome()
        {
            if (homePage == null)
            {
                homePage = new HomePage();
                categoryPage[HOME_CATEGORY_ID] = homePage;
            }
            ShowPage(homePage);
        }

        private void ShowCategory(int categoryId)
        {
            UserControl? page;
            if (!categoryPage.TryGetValue(categoryId, out page))
            {
                page = new CategoryPage(categoryId);
                categoryPage[categoryId] = page;
            }

            ShowPage(page);
        }

        private void ShowPage(UserControl page)
        {
            if (currentPage == page)
                return;

            UI_Handling.loadUserControl(ContentPanel, page);
            currentPage = page;
        }



        // --------------------------------------------------------------------------


        bool isHoveredStartOver = false;


        private void StartOver_Button_Paint(object sender, PaintEventArgs e)
        {
            if (!isHoveredStartOver) return;
            UI_Handling.darkenOnHover(e, StartOver_Button.ClientRectangle, UI_Handling.boxOrCircle.box);
        }

        private void StartOver_Button_MouseEnter(object sender, EventArgs e)
        {
            isHoveredStartOver = true;
            StartOver_Button.Invalidate();
        }

        private void StartOver_Button_MouseLeave(object sender, EventArgs e)
        {
            isHoveredStartOver = false;
            StartOver_Button.Invalidate();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void BottomPanel_Paint(object sender, PaintEventArgs e)
        {
            UI_Handling.drawBorderSides(e, BottomPanel.ClientRectangle, UI_Handling.borderSide.Top, Color.Black, 2);
        }
    }
}
