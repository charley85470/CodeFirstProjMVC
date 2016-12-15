using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirstProjMVC.DB.Models
{
    public class Department
    {
        [Display(Name = "部門ID")]
        [Required(ErrorMessage = "請輸入部門ID")]
        public Guid DepartmentId { get; set; }
        [Display(Name = "部門名稱")]
        [Required(ErrorMessage = "請輸入部門名稱")]
        public string DepartmentName { get; set; }

        public virtual ICollection<Member> Members { get; set; }
    }
}