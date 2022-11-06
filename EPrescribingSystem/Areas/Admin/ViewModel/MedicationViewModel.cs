using EPrescribingSystem.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EPrescribingSystem.Areas.Admin.ViewModel
{
    public class MedicationViewModel
    {
        public int MedicationID { get; set; }
        public string Name { get; set; }
        public string Schedule { get; set; }
        public string DosageForm { get; set; }
        public string ActiveIngredientName { get; set; }
        public int Strength { get; set; }
        
    }
}
