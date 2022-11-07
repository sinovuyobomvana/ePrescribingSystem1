using EPrescribingSystem.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace EPrescribingSystem.Areas.Doctor.ViewModel
{
    public class ConditionViewModel
    {

        public ConditionDiagnosis condition { get; set; }
        public int ConditionID { get; set; }

        public string ICD_10_CODE { get; set; }

        public string Diagnosis { get; set; }

        public string DiagnosisDate { get; set; }
     
        public string ApplicationUser { get; set; }

      
    }
}
