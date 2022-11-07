using EPrescribingSystem.Data;
using EPrescribingSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescribingSystem.Areas.Pharmacist
{
    [Area("Pharmacist")]
    public class PharmacistController : Controller
    {
        private readonly EprescribingDBContext _context = null;
        
        public PharmacistController(EprescribingDBContext context)
        {
           
            _context = context;
        }

        [Route("[area]/[controller]/[action]")]
        public IActionResult Index()
        {
            ViewBag.Medication = _context.Medications.Count();
            return View();
        }

        
    }
}
