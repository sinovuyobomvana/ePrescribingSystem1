﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescribingSystem.Models
{
    public class PrescriptionModel
    {
        [Key]
        public int PrescriptionID { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Descritpion { get; set; }

        [Required]
        public int NumberOfRepeats { get; set; }

        [ForeignKey("MedicationID")]
        public int MedicationID { get; set; }
        public MedicationModel MedicationModel { get; set; }
    }
}
