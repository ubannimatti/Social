using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Domain.Entities
{
    public class Taluk
    {
        public int TalukId { get; set; }

        [MaxLength(30)]
        [DisplayName("Taluk Name")]
        public required string TalukName { get; set; }
    }
}
