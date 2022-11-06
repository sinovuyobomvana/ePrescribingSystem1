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

        [Required(ErrorMessage = "Please enter contact no.")]
        [RegularExpression("^((?:\\+27|27)|0)(=72|82|73|83|74|84)(\\d{7})$", ErrorMessage = "Phone number is not vallid")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "A valid phone number must have 10 digits.")]
        public string ContactNumber { get; set; }

        
        [Required(ErrorMessage = "Please enter your email")]
        [Display(Name = "Email address")]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$", ErrorMessage = "Invalid email address.")]
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
