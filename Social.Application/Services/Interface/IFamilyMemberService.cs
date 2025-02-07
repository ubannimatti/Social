using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Social.Domain.Entities;

namespace Social.Application.Services.Interface
{
    public interface IFamilyMemberService
    {
        IEnumerable<FamilyMember> GetFamilyMembers(int employeeId);
        FamilyMember GetFamilyMemberById(int id);
        void CreateFamilyMember(FamilyMember familyMember);
        void UpdateFamilyMember(FamilyMember familyMember);
        bool DeleteFamilyMember(int id);
    }
}
