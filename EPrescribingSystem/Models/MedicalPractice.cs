﻿using System;
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
        public int MedicalPracticeID { get; set; }

        [Required]
        public string PracticeNumber { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address1 { get; set; }
        
        public string Address2 { get; set; }

        
        public string Province { get; set; }

        public string PostalCode { get; set; }

        [ForeignKey("SuburbID")]
        public int SuburbID { get; set; }
        public virtual Suburb Suburb { get; set; }

        [Required, Phone]
        public string ContactNum { get; set; }
        [Required, EmailAddress]
        public string EmailAddress { get; set; }
    }
}
