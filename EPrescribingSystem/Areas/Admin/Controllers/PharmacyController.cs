using EPrescribingSystem.Areas.Admin.Data.Repository;
using EPrescribingSystem.Areas.Admin.ViewModel;
using EPrescribingSystem.Data;
using EPrescribingSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescribingSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PharmacyController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPharmacyRepository _service;
        private readonly EprescribingDBContext _context = null;

        public PharmacyController(UserManager<ApplicationUser> userManager, EprescribingDBContext context, IPharmacyRepository service)
        {
            _service = service;
            _context = context;
            _userManager = userManager;
        }

        [Route("[area]/[controller]/[action]")]
        public async Task<IActionResult> Index()
        {
            var pharmacies = await _context.Pharmacies.ToListAsync();
            var pharmacyViewModel = new List<PharmacyViewModel>();
            foreach (Pharmacy pharm in pharmacies)
            {
                var thisViewModel = new PharmacyViewModel();
                thisViewModel.PharmacyID = pharm.PharmacyID;
                thisViewModel.AddressLine1 = pharm.AddressLine1;
                thisViewModel.AddressLine2 = pharm.AddressLine2;
                thisViewModel.EmailAddress = pharm.EmailAddress;
                thisViewModel.Province = pharm.Province;
                thisViewModel.Name = pharm.Name;
                thisViewModel.ContactNumber = pharm.ContactNumber;
                thisViewModel.LicenseNumber = pharm.LicenseNumber;
                thisViewModel.PostalCode = pharm.PostalCode;
                thisViewModel.SuburbName = GetSuburb(pharm.SuburbID);
                //thisViewModel.UserID = pharm.UserID;

                pharmacyViewModel.Add(thisViewModel);
            }
            return View(pharmacyViewModel);
        }

        public string GetSuburb(int Id)
        {
            string suburbName;

            return suburbName = _context.Suburbs.Where(s => s.SuburbID == Id).Select(x => x.Name).FirstOrDefault();
        }

        [HttpGet]
        [Route("[area]/[controller]/[action]")]
        public async Task <IActionResult> Create()
        {
            MedicalPracticeViewModel medicalPracticeModel = new MedicalPracticeViewModel();

            medicalPracticeModel.Pharmacy = new Models.Pharmacy();
            List<SelectListItem> Provinces = _context.Provinces
                .OrderBy(n => n.Name)
                .Select(n =>
                new SelectListItem
                {
                    Value = n.ProvinceID.ToString(),
                    Text = n.Name
                }).ToList();

            medicalPracticeModel.Provinces = Provinces;
            medicalPracticeModel.Cities = new List<SelectListItem>();

            medicalPracticeModel.Pharmacy = new Models.Pharmacy();
            List<SelectListItem> Cities = _context.Cities
                .OrderBy(n => n.Name)
                .Select(n =>
                new SelectListItem
                {
                    Value = n.CityID.ToString(),
                    Text = n.Name
                }).ToList();

            medicalPracticeModel.Cities = Cities;
            medicalPracticeModel.Suburbs = new List<SelectListItem>();

            var users = await _userManager.Users.ToListAsync();
            var userRolesViewModel = new List<UserRolesViewModel>();


            var thisViewModel = new UserRolesViewModel();
            foreach (ApplicationUser user in users)
            {
                var checkrol = await _userManager.IsInRoleAsync(user, "Pharmacist");
                if (checkrol)
                {
                    //var thisViewModel = new UserRolesViewModel();
                    thisViewModel.UserId = user.Id;
                    thisViewModel.Email = user.Email;
                    thisViewModel.FirstName = user.FirstName;
                    thisViewModel.LastName = user.LastName;
                    userRolesViewModel.Add(thisViewModel);
                }
            }

            List<SelectListItem> Users = _context.Users.Where(u => u.Id == thisViewModel.UserId).Select( 
                n=> new SelectListItem
                {
                    Value = n.Id,
                    Text = n.FirstName +" " + n.LastName

                }).ToList();

            medicalPracticeModel.Users = Users; 

            return View(medicalPracticeModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create( MedicalPracticeViewModel pharmacies)
        {
            if (!ModelState.IsValid)
            {
                return View(pharmacies);
            }
            await _service.AddAsync(pharmacies);
            return RedirectToAction(nameof(Index));
        }


        //Get: Pharmacy/Details
        [Route("[area]/[controller]/[action]")]
        public async Task<IActionResult> Details(int id)
        {
            var pharmacyDetails = await _service.GetByIdAsync(id);

            if (pharmacyDetails == null) return View("Not Found!!!");
            return View(pharmacyDetails);
        }

        //Get: Pharmacy/Update
        [HttpGet]
        [Route("[area]/[controller]/[action]")]
        public async Task<IActionResult> Edit(int id)
        {
            List<Suburb> suburbs = await _context.Suburbs.ToListAsync();
            List<Province> provinces = await _context.Provinces.ToListAsync();
            List<City> cities = await _context.Cities.ToListAsync();

            ViewBag.Suburbs = suburbs;
            ViewBag.Provinces = provinces;
            ViewBag.Cities = cities;

            Pharmacy pharmacy = await _service.GetByIdAsync(id);

            return View(pharmacy);
        }
        //public async Task<IActionResult> Edit(int id)
        //{
        //    var pharmacyDetails = await _service.GetByIdAsync(id);

        //    if (pharmacyDetails == null)
        //    {
        //        return NotFound();
        //    }


        //    return View(pharmacyDetails);
        //}

        [HttpPost]
        public IActionResult Edit(Pharmacy pharmacy)
        {
            try
            {
                pharmacy = _service.Update(pharmacy);
            }
            catch
            {

            }

            return RedirectToAction("Index");
        }


        //Get: Pharmacy/Delete
        [HttpGet]
        [Route("[area]/[controller]/[action]")]
        public IActionResult Delete(int id)
        {
            var pharmacy = _service.GetById(id);
            return View(pharmacy);
        }

        [HttpPost]
        public IActionResult Delete(Pharmacy pharmacy)
        {
            try
            {
                pharmacy = _service.Delete(pharmacy);
            }
            catch
            {

            }
            return RedirectToAction("Index");
        }
    }
}
