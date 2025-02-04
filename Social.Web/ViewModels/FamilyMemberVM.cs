using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Social.Domain.Entities;

namespace Social.Web.ViewModels
{
    public class FamilyMemberVM
    {
        public FamilyMember? FamilyMember { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem>? EmployeeList { get; set; }
        public IEnumerable<SelectListItem>? RelationList { get; set; }
    }
}
