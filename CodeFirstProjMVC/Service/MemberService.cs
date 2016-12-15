using CodeFirstProjMVC.DB.Models;
using CodeFirstProjMVC.Models;
using CodeFirstProjMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirstProjMVC.Service
{
    public class MemberService : IMemberService
    {
        public bool AddMember(Member vm)
        {
            try
            {
                using (var db = new Company())
                {
                    var Member = new Member { MemberId = vm.MemberId, MemberName = vm.MemberName, DepartmentId = vm.DepartmentId };

                    db.Members.Add(Member);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool EditMember(Member vm)
        {
            try
            {
                using (var db = new Company())
                {
                    var Member = db.Members.Where(x => x.MemberId.Equals(vm.MemberId)).FirstOrDefault();
                    Member.MemberName = vm.MemberName;
                    Member.DepartmentId = vm.DepartmentId;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteMember(string id)
        {
            try
            {
                using (var db = new Company())
                {
                    var Member = db.Members.Where(x => x.MemberId.Equals(id)).FirstOrDefault();
                    db.Members.Remove(Member);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Member GetMember(string id)
        {
            try
            {
                var result = new Member();
                using (var db = new Company())
                {
                    result = db.Members.Where(x => x.MemberId.Equals(id)).FirstOrDefault();
                }
                return result;
            }
            catch (Exception e)
            {
                return default(Member);
            }
        }

        public IEnumerable<MemberVM> GetAllMembers()
        {
            try
            {
                using (var db = new Company())
                {
                    var vms = new List<MemberVM>();
                    var linq = (from c in db.Members select c).ToList();
                    foreach (var item in linq)
                    {
                        vms.Add(new MemberVM
                        {
                            DepartmentId = item.DepartmentId,
                            MemberId = item.MemberId,
                            MemberName = item.MemberName,
                            DepartmentName = item.Department.DepartmentName
                        });
                    }
                    return vms;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}