using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirstProjMVC.DB.Models
{
    public class Department
    {
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public virtual ICollection<Member> Members { get; set; }
    }
}