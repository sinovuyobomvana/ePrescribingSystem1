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

        [Required(ErrorMessage = "Please enter address line 2.")]
        [StringLength(50)]
        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "Please select city.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter postal code.")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Please enter contact no.")]
        public string ContactNumber { get; set; }

      
        public virtual Suburb Suburb { get; set; }

    }
}
