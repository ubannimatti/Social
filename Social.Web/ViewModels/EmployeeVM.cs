using System.ComponentModel.DataAnnotations;
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
        [Display(Name = "Skills Selected")]
        public List<int> SelectedSkills { get; set; } = new List<int>();
        public IEnumerable<SelectListItem>? SkillList { get; set; }
    }
}
