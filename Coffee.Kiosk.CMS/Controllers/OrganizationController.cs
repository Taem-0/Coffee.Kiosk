using Coffee.Kiosk.CMS.Models;
using Coffee.Kiosk.CMS.Services;
using System.Collections.Generic;

namespace Coffee.Kiosk.CMS.Controllers
{
    public class OrganizationController
    {
        private readonly OrganizationService _service;
        public OrganizationController(OrganizationService service) => _service = service;

        public List<OrganizationItem> GetJobTitles() => _service.GetJobTitles();
        public List<OrganizationItem> GetDepartments() => _service.GetDepartments();
        public void AddJobTitle(string title) => _service.AddJobTitle(title);
        public void AddDepartment(string name) => _service.AddDepartment(name);
        public void DeleteJobTitle(int id) => _service.DeleteJobTitle(id);
        public void DeleteDepartment(int id) => _service.DeleteDepartment(id);
    }
}