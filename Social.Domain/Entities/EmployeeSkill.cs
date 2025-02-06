using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Social.Domain.Entities
{
    public class EmployeeSkill
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        [ValidateNever]
        public Employee Employee { get; set; }

        [ForeignKey("Skill")]
        public int SkillId { get; set; }
        [ValidateNever]
        public Skill Skill { get; set; }
    }
}
