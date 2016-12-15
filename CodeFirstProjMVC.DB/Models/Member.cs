using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirstProjMVC.DB.Models
{
    public class Member
    {
        [Display(Name = "員工ID")]
        [Required(ErrorMessage = "請輸入員工ID")]
        public string MemberId { get; set; }
        [Display(Name = "員工名稱")]
        [Required(ErrorMessage = "員工名稱")]
        public string MemberName { get; set; }

        [Display(Name = "員工部門")]
        [Required]
        public Guid DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}