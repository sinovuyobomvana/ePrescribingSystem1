using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescribingSystem.Models
{
    public class CityModel
    {
        [Key]
        public int CityID { get; set; }
        [Required]
        public string Name { get; set; }
        
        public string Abbreviation { get; set; }
    }
}
