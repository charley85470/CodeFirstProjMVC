using CodeFirstProjMVC.DB.Models;
using CodeFirstProjMVC.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirstProjMVC.Controllers
{
    public class DepartmentController : Controller
    {
        IDepartmentService departmentService = new DepartmentService();
        // GET: Company
        public ActionResult Index()
        {
            var vms = departmentService.GetAllDepartments();
            return View(vms);
        }

        public ActionResult AddDepartment()
        {
            Department vm = new Department { DepartmentId = Guid.NewGuid() };
            return View(vm);
        }

        [HttpPost]
        public ActionResult AddDepartment(Department vm)
        {
            if (ModelState.IsValid)
            {
                var bl = departmentService.AddDepartment(vm);
                if (bl)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(vm);
        }

        public ActionResult EditDepartment(string id)
        {
            var vm = departmentService.GetDepartment(id);
            return View(vm);
        }

        [HttpPost]
        public ActionResult EditDepartment(Department vm)
        {
            if (ModelState.IsValid)
            {
                var bl = departmentService.EditDepartment(vm);
                if (bl)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(vm);
        }

        public ActionResult DeleteDepartment(string id)
        {
            var vm = departmentService.DeleteDepartment(id);
            return RedirectToAction("Index");
        }

    }
}