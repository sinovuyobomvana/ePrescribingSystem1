using EPrescribingSystem.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EPrescribingSystem.Areas.Admin.ViewModel
{
    public class PharmacyViewModel
    {
        public int PharmacyID { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public string PostalCode { get; set; }
        public string Province { get; set; }
        public string LicenseNumber { get; set; }
        public string SuburbName { get; set; }
    }
}
