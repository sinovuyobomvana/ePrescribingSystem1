using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPrescribingSystem.Models
{
    [Table("Disease")]
    public class Disease
    {
        [Key]
        public int DiseaseID { get; set; }
        [Display(Name = "ICD-10 CODE")]
        public string ICD_10_CODE { get; set; }
        [Display(Name = "Diagnosis")]
        public string Diagnosis { get; set; }
    }
}
