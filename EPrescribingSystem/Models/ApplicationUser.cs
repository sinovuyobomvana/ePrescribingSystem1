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
