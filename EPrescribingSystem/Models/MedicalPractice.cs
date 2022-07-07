using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescribingSystem.Models
{
    public class MedicalPractice
    { 
        [Key]
        public int practiceNum { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Address1 { get; set; }
        
        public string Address2 { get; set; }
        [Required, Phone]
        public string ContactNum { get; set; }
        [Required, EmailAddress]
        public string EmailAddress { get; set; }
    }
}
