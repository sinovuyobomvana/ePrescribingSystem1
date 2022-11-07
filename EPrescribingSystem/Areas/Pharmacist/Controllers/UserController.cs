using EPrescribingSystem.Data;
using EPrescribingSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescribingSystem.Areas.Pharmacist.Controllers
{
    [Area("Pharmacist")]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly EprescribingDBContext _context = null;
        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [Route("[area]/[controller]/[action]")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("[area]/[controller]/[action]")]
        public async Task<IActionResult> GetPatient(string idNumber)
        {
            ViewData["GetIDNumber"] = idNumber;

            var userQuery = from c in _userManager.Users select c;
            ViewBag.IsSuccess = true;

            if (!string.IsNullOrEmpty(idNumber))
            {
                userQuery = userQuery.Where(c => c.IDNumber.Equals(idNumber));


                if (userQuery.FirstOrDefault() == null)
                {
                    ViewBag.IsSuccess = false;
                }

            }
            else
            {
                ViewBag.IsSuccess = false;
                return View("Index");
            }


            return View("Index", await userQuery.AsNoTracking().ToListAsync());
        }

        
        //[HttpGet]
        //public async Task<IActionResult> GetPatient(string idNumber)
        //{
        //    ViewData["GetIDNumber"] = idNumber;

        //    var userQuery = from c in _userManager.Users.Where(x => x.Id == idNumber) select c;
        //    ViewBag.IsSuccess = true;

        //    if (!string.IsNullOrEmpty(idNumber))
        //    {
        //        userQuery = userQuery.Where(c => c.IDNumber.Equals(idNumber));


        //        if (userQuery.FirstOrDefault() == null)
        //        {
        //            ViewBag.IsSuccess = false;
        //        }

        //    }
        //    else
        //    {
        //        ViewBag.IsSuccess = false;
        //        return View("Index1");
        //    }


        //    return View("Index1", await userQuery.AsNoTracking().ToListAsync());
        //}
    }
}
