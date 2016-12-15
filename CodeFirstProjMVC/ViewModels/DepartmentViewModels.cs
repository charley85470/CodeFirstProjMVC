using CodeFirstProjMVC.DB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirstProjMVC.ViewModels
{
    public class AddMemberVM
    {
        public Member member { get; set; }
        public List<SelectListItem> departmentSelectItems { get; set; }
    }

    public class EditMemberVM
    {
        public Member member { get; set; }
        public List<SelectListItem> departmentSelectItems { get; set; }
    }

    public class MemberVM
    {
        [Display(Name = "員工ID")]
        public string MemberId { get; set; }
        [Display(Name = "員工名稱")]
        public string MemberName { get; set; }
        [Display(Name = "員工部門")]
        public Guid DepartmentId { get; set; }
        [Display(Name = "員工部門")]
        public string DepartmentName { get; set; }
    }
}