using CodeFirstProjMVC.Models;
using CodeFirstProjMVC.Service;
using CodeFirstProjMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirstProjMVC.Controllers
{
    public class MemberController : Controller
    {
        IDepartmentService departmentService = new DepartmentService();
        IMemberService memberService = new MemberService();
        // GET: Member
        public ActionResult Index()
        {
            var vm = memberService.GetAllMembers();
            return View(vm);
        }

        public ActionResult AddMember()
        {
            AddMemberVM vm = new AddMemberVM();
            vm.departmentSelectItems = GetDepartmentSelectItems();
            return View(vm);
        }

        [HttpPost]
        public ActionResult AddMember(AddMemberVM vm)
        {
            if (ModelState.IsValid)
            {
                var bl = memberService.AddMember(vm.member);
                if (bl)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(vm);
        }

        public ActionResult EditMember(string id)
        {
            EditMemberVM vm = new EditMemberVM();
            vm.member = memberService.GetMember(id);
            vm.departmentSelectItems = GetDepartmentSelectItems();
            return View(vm);
        }

        [HttpPost]
        public ActionResult EditMember(EditMemberVM vm)
        {
            if (ModelState.IsValid)
            {
                var bl = memberService.EditMember(vm.member);
                if (bl)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(vm);
        }
        
        public ActionResult DeleteMember(string id)
        {
            var bl = memberService.DeleteMember(id);
            if (bl)
            {

            }
            return RedirectToAction("Index");
        }


        #region  SelectListItems
        private List<SelectListItem> GetDepartmentSelectItems()
        {
            var deps = departmentService.GetAllDepartments();
            List<SelectListItem> slis = new List<SelectListItem>();
            foreach (var item in deps)
            {
                slis.Add(new SelectListItem { Value = item.DepartmentId.ToString(), Text = item.DepartmentName });
            }
            return slis;
        }
        #endregion
    }
}