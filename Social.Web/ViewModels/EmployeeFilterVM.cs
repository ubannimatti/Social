using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Social.Domain.Entities;

namespace Social.Web.ViewModels
{
    public class EmployeeFilterVM
    {
        public bool? HasOwnHouse { get; set; }

        public bool? HasSite { get; set; }
        public bool? HasToilet { get; set; }
        public bool? HasElectricity { get; set; }
        public bool? HasWaterConnection { get; set; }
        public bool? HasAadharCard { get; set; }
        public bool? HasAayushmannBharatCard { get; set; }
        public bool? HasHealthInsurance { get; set; }
        public bool? HasRationCard { get; set; }
        public bool? HasNaregaJobCard { get; set; }
        public List<SelectListItem> TalukList { get; set; }
        public List<SelectListItem> SkillList { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();  // List of filtered employees
    }
}
