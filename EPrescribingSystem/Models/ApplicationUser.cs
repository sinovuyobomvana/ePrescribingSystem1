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
        [Key]
        public string UserID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public byte[] ProfilePicture { get; set; }

        public string Gender { get; set; }
        [Required, EmailAddress]
        public string EmailAddress { get; set; }

        public string DOB { get; set; }
        [Required, Phone]
        public string ContactNum { get; set; }
        public string RegistrationNum { get; set; }
        public string PracticeNum { get; set; }
        [ForeignKey("SuburbID")]
        public string SuburbID { get; set; }
        public SuburbModel SuburbModel { get; set; }

        [ForeignKey("PharmacyID")]
        public string PharmacyID { get; set; }
        public PharmacyModel pharmacyModel { get; set; }

    }
}
