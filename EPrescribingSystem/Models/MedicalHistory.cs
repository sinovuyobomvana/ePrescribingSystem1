using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescribingSystem.Models
{
    [Table("MedicalHistory")]
    public class MedicalHistory
    {
        [Key]

        public int MedicalHistoryID { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        [ForeignKey("PrescriptionID")]
        public int PrescriptionID { get; set; }
        public Prescription PrescriptionModel { get; set; }

        [ForeignKey("ConditionID")]
        public int ConditionID { get; set; }
        public ConditionDiagnosis ConditionDiagnosisModel { get; set; }


    }
}
