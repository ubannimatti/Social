using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Social.Domain.Entities;

namespace Social.Web.ViewModels
{
    public class FamilyMemberListVM
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public IEnumerable<FamilyMember> FamilyMembers { get; set; }
    }
}
