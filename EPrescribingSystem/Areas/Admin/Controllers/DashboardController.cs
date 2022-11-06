using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System;
using EPrescribingSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using EPrescribingSystem.Data;

namespace EPrescribingSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly EprescribingDBContext _context = null;
        public DashboardController(UserManager<ApplicationUser> userManager, EprescribingDBContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [Route("[area]/[controller]/[action]")]
        public async Task<IActionResult> Index()
        {

            ViewBag.UserCount = _userManager.Users.Count();
            ViewBag.Pharmacies = _context.Pharmacies.Count();
            ViewBag.MedicalPracs = _context.MedicalPractices.Count();
            ViewBag.Medication = _context.Medications.Count();

            var users = await _userManager.Users.ToListAsync();
            var userRolesViewModel = new List<UserRolesViewModel>();
            int i = 0;
            int d = 0;
            int p = 0;

            //var thisViewModel2 = new UserRolesViewModel();
            foreach (ApplicationUser user in users)
            {
                var checkrol = await _userManager.IsInRoleAsync(user, "Pharmacist");
                var checkDoc = await _userManager.IsInRoleAsync(user, "Doctor");
                var checkPat = await _userManager.IsInRoleAsync(user, "Patient");
                if (checkrol)
                {
                    i++;
                    
                }
                else if (checkDoc)
                {
                    d++;
                }
                else if(checkPat)
                {
                    p++;   
                }
            }
            ViewBag.PharmacistsCount = i;
            ViewBag.DocCount = d;
            ViewBag.PatCount = p;


            return View(users);
        }
    }

   
}
