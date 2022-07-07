using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescribingSystem.Models
{
    public class MedicalHistoryModel
    {
        [Key]

        public int MedicalHistoryID { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        [ForeignKey("PrescriptionID")]
        public int PrescriptionID { get; set; }
        public PrescriptionModel PrescriptionModel { get; set; }

        [ForeignKey("ConditionID")]
        public int ConditionID { get; set; }
        public ConditionDiagnosisModel ConditionDiagnosisModel { get; set; }


    }
}
