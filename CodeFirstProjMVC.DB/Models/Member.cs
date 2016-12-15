using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirstProjMVC.DB.Models
{
    public class Member
    {
        public string MemberId { get; set; }
        public string MemberName { get; set; }

        public Guid DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}