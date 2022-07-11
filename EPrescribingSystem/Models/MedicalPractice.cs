using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescribingSystem.Models
{
    [Table("MedicalPractice")]
    public class MedicalPractice
    { 
        [Key]

        public int PracticeID { get; set; }

        public string PracticeNumber { get; set; }
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
