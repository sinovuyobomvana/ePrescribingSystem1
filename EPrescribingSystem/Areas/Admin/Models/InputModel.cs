using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescribingSystem.Models
{
    public class InputModel
    {
        public string InputID { get; set; }

        [Required(ErrorMessage ="Please enter First name.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter Last name.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        public byte[] ProfilePicture { get; set; }
        public string ProfilePictureUrl { get; set; }
    }
}
