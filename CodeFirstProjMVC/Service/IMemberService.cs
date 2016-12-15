using CodeFirstProjMVC.DB.Models;
using CodeFirstProjMVC.Models;
using CodeFirstProjMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirstProjMVC.Service
{
    public interface IMemberService
    {
        bool AddMember(Member vm);
        bool EditMember(Member vm);
        bool DeleteMember(string id);
        Member GetMember(string id);
        IEnumerable<MemberVM> GetAllMembers();
    }
}