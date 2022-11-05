using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EPrescribingSystem.Models
{
    public class RegisterUserModel
    {
        [Required(ErrorMessage = "Please enter first name.")]
        [DataType(DataType.Text)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter last name.")]
        [DataType(DataType.Text)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter ID no.")]
        [Display(Name = "ID Number")]
        [RegularExpression("(((\\d{2}((0[13578]|1[02])(0[1-9]|[12]\\d|3[01])|(0[13456789]|1[012])(0[1-9]|[12]\\d|30)|02(0[1-9]|1\\d|2[0-8])))|([02468][048]|[13579][26])0229))(( |-)(\\d{4})( |-)(\\d{3})|(\\d{7}))", ErrorMessage = "Enter a valid South African ID Number")]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "A valid ID number must have 13 digits.")]
        public string IDNumber { get; set; }

        [Required(ErrorMessage = "Please select Title.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter/select enter date of birth.")]
        [DataType(DataType.Date)]
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please select gender.")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        [Display(Name = "Email address")]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$", ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a strong password")]
        [Compare("ConfirmPassword", ErrorMessage = "Password does not match")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password{get; set; }

        [Required(ErrorMessage = "Please confirm your password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please enter address line 1.")]
        [StringLength(50)]
        [Display(Name = "Address Line 1")]
        public string Addressine1 { get; set; }

        //[Required(ErrorMessage = "Please enter address line 2.")]
        [StringLength(50)]
        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "Please select provice.")]
        public string Province { get; set; }

        [Required(ErrorMessage = "Please select city.")]
        public string City { get; set; }

        //[Required(ErrorMessage = "Please enter postal code.")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Please enter contact no.")]
        [RegularExpression("^((?:\\+27|27)|0)(=72|82|73|83|74|84)(\\d{7})$", ErrorMessage = "Phone number is not vallid") ]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "A valid phone number must have 10 digits.")]
        public string ContactNumber { get; set; }

        public Suburb Suburb { get; set; }

        //[Required(ErrorMessage = "Please select Highest Qualification.")]
        [Display(Name = "Highest Qualification")]
        public string HighestQualification { get; set; }

        //[RegularExpression("(^[a-zA-Z]{2}[0-9]{6})$)")]
        //[Required(ErrorMessage = "Please select enter Registration Number.")]
        [Display(Name = "Registration Number")]
        public string RegistrationNumber { get; set; }

        //[Required(ErrorMessage = "Please select enter Health Council Registration Number.")]
        [Display(Name = "Health Council Registration Number")]
        public string HealthCouncilRegistrationNumber { get; set; }

        [Required(ErrorMessage = "Please select Role.")]
        [Display(Name = "Role")]
        public string Role { get; set; }
    }
}
