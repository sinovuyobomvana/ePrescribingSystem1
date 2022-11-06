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
        public string Name { get; set; }

        [Required]
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string ContactNumber { get; set; }

        public string EmailAddress { get; set; }
       
        public string PostalCode { get; set; }

        public string Province { get; set; }

        [ForeignKey("ApplicationUserId")]
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [Required]
        public string LicenseNumber { get; set; }

        [ForeignKey("SuburbID")]
        public int SuburbID { get; set; }
        public Suburb Suburb { get; set; }
    }
}
