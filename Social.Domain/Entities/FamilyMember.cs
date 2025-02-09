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
        [DisplayName("ಕುಟುಂಬದ ಸದಸ್ಯರ ಹೆಸರು")]
        public required string FamilyMemberName { get; set; }


        [DisplayName("ಮ್ಯಾನ್ಯುಯಲ್ ಸ್ಕ್ಯಾವೆಂಜರ್ಸ್ ಹೆಸರು")]
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        [ValidateNever]
        public Employee Employee { get; set; }


        [DisplayName("ಸಂಬಂಧ")]
        public string Relationship { get; set; }

        [Range(5, 60)]
        [DisplayName("ವಯಸ್ಸು")]
        public int Age { get; set; }

        [MaxLength(30)]
        [DisplayName("ವಿಧ್ಯಾರ್ಹತೆ")]
        public string Education { get; set; }

        [MaxLength(30)]
        [DisplayName("ಅಗತ್ಯವಿರುವ ತರಬೇತಿ")]
        public string RequiredTraining { get; set; }

        [ValidateNever]
        public string CreatedBy { get; set; }
        [ValidateNever]
        public DateTime CreatedAt { get; set; }
        [ValidateNever]
        public string ModifiedBy { get; set; }
        [ValidateNever]
        public DateTime ModifiedAt { get; set; }

    }
}
