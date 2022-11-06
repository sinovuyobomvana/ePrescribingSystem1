using EPrescribingSystem.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EPrescribingSystem.Areas.Admin.ViewModel
{
    public class PharmacyViewModel
    {
        public int PharmacyID { get; set; }
        public string Name { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "Please enter contact no.")]
        [RegularExpression("^((?:\\+27|27)|0)(=41|45|11|32|42|47)(\\d{7})$", ErrorMessage = "Phone number is not vallid")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "A valid phone number must have 10 digits.")]
        public string ContactNumber { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        [Display(Name = "Email address")]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$", ErrorMessage = "Invalid email address.")]
        public string EmailAddress { get; set; }
        public string PostalCode { get; set; }
        public string Province { get; set; }
        public string LicenseNumber { get; set; }
        public string SuburbName { get; set; }
        public int UserID { get; set; }
    }
}
