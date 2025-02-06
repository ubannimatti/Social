using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Social.Domain.Entities
{
    public class FamilyMember
    {
        public int FamilyMemberId { get; set; }

        [MaxLength(30)]
        [DisplayName("Member Name")]
        public required string FamilyMemberName { get; set; }


        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        [ValidateNever]
        public Employee Employee { get; set; }


        [DisplayName("Relationship")]
        public string Relationship { get; set; }

        [Range(5, 60)]
        [DisplayName("Age")]
        public int Age { get; set; }

        [MaxLength(30)]
        [DisplayName("Education")]
        public string Education { get; set; }

        [MaxLength(30)]
        [DisplayName("Required Training")]
        public string RequiredTraining { get; set; }

    }
}
