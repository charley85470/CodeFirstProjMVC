using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirstProjMVC.Models
{
    public class DepartmentVM
    {
        [Display(Name = "部門ID")]
        public Guid DepartmentId { get; set; }
        [Display(Name = "部門名稱")]
        public string DepartmentName { get; set; }
    }

    public class MemberVM
    {
        [Display(Name = "員工ID")]
        public string MemberId { get; set; }
        [Display(Name = "員工姓名")]
        public string MemberName { get; set; }
    }
}