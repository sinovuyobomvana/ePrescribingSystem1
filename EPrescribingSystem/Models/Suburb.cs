using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescribingSystem.Models
{
    [Table("Suburb")]
    public class Suburb
    {
        [Key]
        [Required(ErrorMessage = "Please select suburb.")]
        public int SuburbID { get; set; }

        
        public string Name { get; set; }
   
        public string PostalCode { get; set; }

        [ForeignKey("CityID")]
        public int CityID { get; set; }
        public City CityModel { get; set; }
    }
}
