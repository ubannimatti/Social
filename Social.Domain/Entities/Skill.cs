using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Domain.Entities
{
    public class Skill
    {
        public int SkillId { get; set; }

        [MaxLength(30)]
        [DisplayName("Skill Name")]
        public required string SkillName { get; set; }
    }
}
