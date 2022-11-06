using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescribingSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        //[Key]
        //public string UserID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter ID no.")]
        [Display(Name = "ID Number")]
        [RegularExpression("(((\\d{2}((0[13578]|1[02])(0[1-9]|[12]\\d|3[01])|(0[13456789]|1[012])(0[1-9]|[12]\\d|30)|02(0[1-9]|1\\d|2[0-8])))|([02468][048]|[13579][26])0229))(( |-)(\\d{4})( |-)(\\d{3})|(\\d{7}))", ErrorMessage = "Enter a valid South African ID Number")]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "A valid ID number must have 13 digits.")]
        public string IDNumber { get; set; }

        public string Title { get; set; }

        public byte[] ProfilePicture { get; set; }

        public string Gender { get; set; }

        //[Required, EmailAddress]
        //public string EmailAddress { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime RegistrationDate { get; set; }


        public string Addressine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string PostalCode { get; set; }

        //Doctor
        public string HealthCouncilRegistrationNumber { get; set; }

        public string HighestQualification { get; set; }

        [Required(ErrorMessage = "Please enter contact no.")]
        [RegularExpression("^((?:\\+27|27)|0)(=72|82|73|83|74|84)(\\d{7})$", ErrorMessage = "Phone number is not vallid")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "A valid phone number must have 10 digits.")]
        //[Required, Phone]
        public string ContactNumber { get; set; }
        public string RegistrationNumber { get; set; }

       
        //Pharmacist
        public string PracticeNumber { get; set; }

        [ForeignKey("SuburbID")]
        public int SuburbID { get; set; }

        public Suburb Suburb { get; set; }

        //[ForeignKey("PharmacyID")]
        //public string PharmacyID { get; set; }

        //public Pharmacy PharmacyModel { get; set; }

    }
}
