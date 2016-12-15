using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeFirstProjMVC.Models;
using CodeFirstProjMVC.DB.Models;

namespace CodeFirstProjMVC.Service
{
    public class CompanyService : ICompanyService
    {
        public bool AddDepartment(DepartmentVM vm)
        {
            try
            {
                using (var db = new Company())
                {
                    var department = new Department { DepartmentId = vm.DepartmentId, DepartmentName = vm.DepartmentName };

                    db.Departments.Add(department);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool EditDepartment(DepartmentVM vm)
        {
            try
            {
                using (var db = new Company())
                {
                    var department = db.Departments.Where(x => x.DepartmentId.Equals(vm.DepartmentId)).FirstOrDefault();
                    department.DepartmentName = vm.DepartmentName;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteDepartment(string id)
        {
            try
            {
                using (var db = new Company())
                {
                    var depId = Guid.Parse(id);
                    var department = db.Departments.Where(x => x.DepartmentId.Equals(depId)).FirstOrDefault();
                    db.Departments.Remove(department);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public DepartmentVM GetDepartment(string id)
        {
            try
            {
                var result = new DepartmentVM();
                using (var db = new Company())
                {
                    var depId = Guid.Parse(id);
                    var department = db.Departments.Where(x => x.DepartmentId.Equals(depId)).FirstOrDefault();
                    result.DepartmentId = department.DepartmentId;
                    result.DepartmentName = department.DepartmentName;
                }
                return result;
            }
            catch (Exception e)
            {
                return default(DepartmentVM);
            }
        }

        public IEnumerable<DepartmentVM> GetAllDepartments()
        {
            try
            {
                List<DepartmentVM> result = new List<DepartmentVM>();
                using (var db = new Company())
                {
                    var linq = from c in db.Departments select c;
                    foreach (var item in linq)
                    {
                        result.Add(new DepartmentVM { DepartmentId = item.DepartmentId, DepartmentName = item.DepartmentName });
                    }
                }
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}