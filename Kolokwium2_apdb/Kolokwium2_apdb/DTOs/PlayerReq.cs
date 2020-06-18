using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium2_apdb.DTOs
{
    public class PlayerReq
    {
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }

        public DateTime birthdate { get; set; }
        public int numOnShirt { get; set; }
        
    }
}
