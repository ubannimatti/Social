using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Social.Domain.Entities;

namespace Social.Web.ViewModels
{
    public class EmployeeVM
    {
        public Employee? Employee { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem>? TalukList { get; set; }
    }
}
