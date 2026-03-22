using Coffee.Kiosk.CMS.CoffeeKDB;
using Coffee.Kiosk.CMS.Models;
using System.Collections.Generic;

namespace Coffee.Kiosk.CMS.Services
{
    public class OrganizationService
    {
        private readonly OrganizationDBManager _dbManager;
        public OrganizationService(OrganizationDBManager dbManager) => _dbManager = dbManager;

        public List<OrganizationItem> GetJobTitles() => _dbManager.GetJobTitles();
        public List<OrganizationItem> GetDepartments() => _dbManager.GetDepartments();
        public void AddJobTitle(string title) => _dbManager.AddJobTitle(title);
        public void AddDepartment(string name) => _dbManager.AddDepartment(name);
        public void DeleteJobTitle(int id) => _dbManager.DeleteJobTitle(id);
        public void DeleteDepartment(int id) => _dbManager.DeleteDepartment(id);
    }
}