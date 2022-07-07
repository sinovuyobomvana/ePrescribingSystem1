﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescribingSystem.Models
{
    public class ContraIndication
    {
        [Key]

        public int ContraIndicationID { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Effect { get; set; }
    }
}
