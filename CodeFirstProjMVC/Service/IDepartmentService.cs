using CodeFirstProjMVC.DB.Models;
using CodeFirstProjMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirstProjMVC.Service
{
    public interface IDepartmentService
    {
        bool AddDepartment(Department vm);
        bool EditDepartment(Department vm);
        bool DeleteDepartment(string id);
        Department GetDepartment(string id);
        IEnumerable<Department> GetAllDepartments();
    }
}