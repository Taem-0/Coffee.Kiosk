using Coffee.Kiosk.CMS.Controllers;
using Coffee.Kiosk.CMS.DTOs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Forms.AccountsTab.AccountUserControls
{
    public partial class EmployeeCardContainercs : UserControl
    {
        public event EventHandler<DisplayDTO>? OnEmployeeClicked;

        private List<DisplayDTO> _currentData = new();
        private AccountController? _controller;
        private string _sortColumn = "Name";
        private bool _sortAscending = true;

        public EmployeeCardContainercs()
        {
            InitializeComponent();
            WireSortButtons();
        }

        private void WireSortButtons()
        {
            nameSortToggle.Click += (s, e) => SortBy("Name");
            jobSortToggle.Click += (s, e) => SortBy("JobTitle");
            departmentSortToggle.Click += (s, e) => SortBy("Department");
        }

        private void SortBy(string column)
        {
            if (_sortColumn == column)
                _sortAscending = !_sortAscending;
            else
            {
                _sortColumn = column;
                _sortAscending = true;
            }

            var sorted = _sortColumn switch
            {
                "Name" => _sortAscending ? _currentData.OrderBy(e => e.FullName).ToList() : _currentData.OrderByDescending(e => e.FullName).ToList(),
                "JobTitle" => _sortAscending ? _currentData.OrderBy(e => e.JobTitle).ToList() : _currentData.OrderByDescending(e => e.JobTitle).ToList(),
                "Department" => _sortAscending ? _currentData.OrderBy(e => e.Department).ToList() : _currentData.OrderByDescending(e => e.Department).ToList(),
                "Status" => _sortAscending ? _currentData.OrderBy(e => e.Status).ToList() : _currentData.OrderByDescending(e => e.Status).ToList(),
                _ => _currentData
            };

            RenderCards(sorted);
        }

        public void LoadEmployees(List<DisplayDTO> employees, AccountController controller)
        {
            _currentData = employees;
            _controller = controller;
            RenderCards(employees);
        }

        public void RenderCards(List<DisplayDTO> employees)
        {
            var toRemove = this.Controls.OfType<EmployeeCard>().ToList();
            foreach (var card in toRemove)
            {
                card.OnCardClicked -= Card_OnCardClicked;
                card.OnDeactivated -= Card_OnDeactivated;
                this.Controls.Remove(card);
                card.Dispose();
            }

            int yOffset = guna2Panel1.Bottom + 4;
            foreach (var emp in employees)
            {
                var card = new EmployeeCard();
                card.SetEmployee(emp, _controller!);
                card.Location = new Point(0, yOffset);
                card.Width = this.Width;
                card.OnCardClicked += Card_OnCardClicked;
                card.OnDeactivated += Card_OnDeactivated;
                this.Controls.Add(card);
                yOffset += card.Height + 2;
            }
        }

        private void Card_OnCardClicked(object? sender, DisplayDTO employee)
        {
            OnEmployeeClicked?.Invoke(this, employee);
        }

        private void Card_OnDeactivated(object? sender, EventArgs e)
        {
            // Reload current data to reflect status change
            LoadEmployees(_currentData, _controller!);
        }

        private void employeeCard1_Load(object sender, EventArgs e) { }
    }
}