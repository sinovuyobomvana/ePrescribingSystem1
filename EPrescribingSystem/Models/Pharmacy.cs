using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescribingSystem.Models
{
    [Table("Pharmacy")]
    public class Pharmacy
    {
        [Key]
        public int PharmacyID { get; set; }
        [Required]
        public string Address1 { get; set; }

        public string Address2 { get; set; }
        [Required, Phone]
        public string ContactNumber { get; set; }
        [Required, EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        public string LicenseNumber { get; set; }

        [ForeignKey("SuburbID")]
        public int SuburbID { get; set; }
        public Suburb SuburbModel { get; set; }
    }
}
