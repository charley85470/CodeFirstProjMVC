using CodeFirstProjMVC.Models;
using CodeFirstProjMVC.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirstProjMVC.Controllers
{
    public class CompanyController : Controller
    {
        ICompanyService companyService = new CompanyService();
        // GET: Company
        public ActionResult Index()
        {
            var vms = companyService.GetAllDepartments();
            return View(vms);
        }

        public ActionResult AddDepartment()
        {
            DepartmentVM vm = new DepartmentVM { DepartmentId = Guid.NewGuid() };
            return View(vm);
        }

        [HttpPost]
        public ActionResult AddDepartment(DepartmentVM vm)
        {
            if (ModelState.IsValid)
            {
                var bl = companyService.AddDepartment(vm);
                if (bl)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(vm);
        }

        public ActionResult EditDepartment(string id)
        {
            var vm = companyService.GetDepartment(id);
            return View(vm);
        }

        [HttpPost]
        public ActionResult EditDepartment(DepartmentVM vm)
        {
            if (ModelState.IsValid)
            {
                var bl = companyService.EditDepartment(vm);
                if (bl)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(vm);
        }

        public ActionResult DeleteDepartment(string id)
        {
            var vm = companyService.DeleteDepartment(id);
            return RedirectToAction("Index");
        }
    }
}