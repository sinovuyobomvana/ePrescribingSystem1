using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescribingSystem.Models
{
    public class SuburbModel
    {
        [Key]
        public int SuburbID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string PostalCode { get; set; }

        [ForeignKey("CityID")]
        public int CityID { get; set; }
        public CityModel CityModel { get; set; }
    }
}
