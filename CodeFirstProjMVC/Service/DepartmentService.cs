using CodeFirstProjMVC.DB.Models;
using CodeFirstProjMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirstProjMVC.Service
{
    public class DepartmentService : IDepartmentService
    {
        public bool AddDepartment(Department vm)
        {
            try
            {
                using (var db = new Company())
                {
                    var department = new DB.Models.Department { DepartmentId = vm.DepartmentId, DepartmentName = vm.DepartmentName };

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

        public bool EditDepartment(Department vm)
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

        public Department GetDepartment(string id)
        {
            try
            {
                var result = new Department();
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
                return default(Department);
            }
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            try
            {
                List<Department> result = new List<Department>();
                using (var db = new Company())
                {
                    var linq = from c in db.Departments select c;
                    foreach (var item in linq)
                    {
                        result.Add(new Department { DepartmentId = item.DepartmentId, DepartmentName = item.DepartmentName });
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