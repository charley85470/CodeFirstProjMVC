using CodeFirstProjMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirstProjMVC.Service
{
    public interface ICompanyService
    {
        bool AddDepartment(DepartmentVM vm);
        bool EditDepartment(DepartmentVM vm);
        bool DeleteDepartment(string id);
        DepartmentVM GetDepartment(string id);
        IEnumerable<DepartmentVM> GetAllDepartments(); 
    }
}