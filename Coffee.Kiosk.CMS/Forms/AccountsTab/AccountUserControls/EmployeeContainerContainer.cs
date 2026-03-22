using Coffee.Kiosk.CMS.Controllers;
using Coffee.Kiosk.CMS.DTOs;
using Coffee.Kiosk.CMS.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.AccountsTab.AccountUserControls
{
    public partial class EmployeeContainerContainer : UserControl
    {
        private AccountController? _controller;
        private ShopController? _themeController;
        private List<DisplayDTO> _allEmployees = new();
        private string _activeFilter = "Current";

        public EmployeeContainerContainer()
        {
            InitializeComponent();
        }

        public void Initialize(AccountController controller, ShopController themeController)
        {
            _controller = controller;
            _themeController = themeController;

            employeeCardContainercs1.OnEmployeeClicked += OnEmployeeClicked;
            currentEmployeeFilter.Click += (s, e) => ApplyFilter("Current");
            inactiveEmployeeFilter.Click += (s, e) => ApplyFilter("Inactive");
            allEmployeeFilter.Click += (s, e) => ApplyFilter("All");
            addNewEmployeeButton.Click += AddNewEmployeeButton_Click;
            searchButton.Click += SearchButton_Click;

            LoadData();
        }

        private void LoadData()
        {
            if (_controller == null) return;
            _allEmployees = _controller.GetAllEmployees();
            UpdateFilterCounts();
            ApplyFilter(_activeFilter);
        }

        private void UpdateFilterCounts()
        {
            int active = _allEmployees.Count(e => e.Status?.ToUpper() == "ACTIVE");
            int inactive = _allEmployees.Count(e => e.Status?.ToUpper() == "DEACTIVATED");
            currentEmployeeFilter.Text = $"Current Employees ({active})";
            inactiveEmployeeFilter.Text = $"Inactive Employees ({inactive})";
            allEmployeeFilter.Text = $"All Employees ({_allEmployees.Count})";
            employeeCount.Text = $"{_allEmployees.Count} Employees";
        }

        private void ApplyFilter(string filter)
        {
            _activeFilter = filter;
            var filtered = filter switch
            {
                "Current" => _allEmployees.Where(e => e.Status?.ToUpper() == "ACTIVE").ToList(),
                "Inactive" => _allEmployees.Where(e => e.Status?.ToUpper() == "DEACTIVATED").ToList(),
                _ => _allEmployees
            };
            employeeCardContainercs1.LoadEmployees(filtered, _controller!);
        }

        private void SearchButton_Click(object? sender, EventArgs e)
        {
            string term = searchTextBox.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(term)) { ApplyFilter(_activeFilter); return; }

            var filtered = _allEmployees.Where(e =>
                (e.FullName?.ToLower().Contains(term) ?? false) ||
                (e.JobTitle?.ToLower().Contains(term) ?? false) ||
                (e.Department?.ToLower().Contains(term) ?? false) ||
                (e.Status?.ToLower().Contains(term) ?? false) ||
                (e.Email?.ToLower().Contains(term) ?? false)
            ).ToList();

            employeeCardContainercs1.LoadEmployees(filtered, _controller!);
            employeeCount.Text = $"{filtered.Count} Employees (Filtered)";
        }

        private void AddNewEmployeeButton_Click(object? sender, EventArgs e)
        {
            var draft = new DisplayDTO();
            using var step1 = new NewestRegisterView(_controller!, draft, _themeController!);
            step1.ShowDialog(this);
            LoadData();
        }

        private void OnEmployeeClicked(object? sender, DisplayDTO employee)
        {
            using var updateForm = new NewUpdateEmployee(employee, _controller!, _themeController!);
            updateForm.ShowDialog(this);
            LoadData();
        }

        private void guna2Button5_Click(object sender, EventArgs e) => SearchButton_Click(sender, e);
    }
}