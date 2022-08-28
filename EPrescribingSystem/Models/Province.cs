using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescribingSystem.Models
{
    [Table("Province")]
    public class Province
    {
        [Key]
        public int ProvinceID { get; set; }
        [Required]
        public string Name { get; set; }

        public string Abbreviation { get; set; }

    }
}
