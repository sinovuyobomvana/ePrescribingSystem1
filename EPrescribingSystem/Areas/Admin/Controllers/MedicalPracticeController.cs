using EPrescribingSystem.Areas.Admin.Data.Repository;
using EPrescribingSystem.Areas.Admin.Data.Services;
using EPrescribingSystem.Areas.Admin.ViewModel;
using EPrescribingSystem.Data;
using EPrescribingSystem.Models;
using EPrescribingSystem.ViewModel;
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
    public class MedicalPracticeController : Controller
    {
        private readonly IMedicalPracticeRepository _service;
        private readonly EprescribingDBContext _context = null;

        public MedicalPracticeController(EprescribingDBContext context, IMedicalPracticeRepository service)
        {
            _service = service;
            _context = context;
        }
  
        [Route("[area]/[controller]/[action]")]
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //Get: Medical Practice/Create
        [HttpGet]
        [Route("[area]/[controller]/[action]")]
        public IActionResult Create()
        {
            MedicalPracticeViewModel medicalPracticeModel = new MedicalPracticeViewModel();

            medicalPracticeModel.MedicalPractice = new Models.MedicalPractice();
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

            medicalPracticeModel.MedicalPractice = new Models.MedicalPractice();
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

            return View(medicalPracticeModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(MedicalPracticeViewModel medicalPracticeModel)
        {
            //MedicalPracticeViewModel medicalPracticeModel = new MedicalPracticeViewModel();

            if (!ModelState.IsValid)
            {
                medicalPracticeModel.MedicalPractice = new Models.MedicalPractice();
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

                return View(medicalPracticeModel);
            }
            await _service.AddAsync(medicalPracticeModel);
            return RedirectToAction(nameof(Index));
        }

        //Get: Medical Practice/Details
        [Route("[area]/[controller]/[action]")]
        public async Task<IActionResult> Details(int id)
        {
            var medicalPracticeDetails = await _service.GetByIdAsync(id);

            if (medicalPracticeDetails == null) return View("Not Found!!!");
            return View(medicalPracticeDetails);
        }

        //Get: Medical Practice/Update
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

            var medicalPracticeDetails = await _service.GetByIdAsync(id);

            if (medicalPracticeDetails == null)
            {
                return NotFound();
            }


            return View(medicalPracticeDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MedicalPractice medicalPractice)
        {
            try
            {
                medicalPractice = await _service.UpdateAsync(medicalPractice);
            }
            catch
            {

            }

            return RedirectToAction("Index");
        }
        //[HttpPost]
        //public async Task<IActionResult> Edit(int id, [Bind("MedicalPracticeID,PracticeNumber,Name,Address1,Address2,ContactNum,EmailAddress")] MedicalPractice medicalPractice)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(medicalPractice);
        //    }
        //    await _service.UpdateAsync(id, medicalPractice);
        //    return RedirectToAction(nameof(Index));
        //}

        //Get: Medical Practice/Delete
        [HttpGet]
        [Route("[area]/[controller]/[action]")]
        public IActionResult Delete(int id)
        {
            var medicalPractice = _service.GetById(id);
            return View(medicalPractice);
        }

        [HttpPost]
        public IActionResult Delete(MedicalPractice medicalPractice)
        {
            try
            {
                medicalPractice = _service.Delete(medicalPractice);
            }
            catch
            {

            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetSuburbs(int? CityId)
        {
            if (CityId != null)
            {
                List<SelectListItem> suburbsSel = _context.Suburbs
                .Where(s => s.CityID == CityId)
                .OrderBy(n => n.Name)
                .Select(n =>
                new SelectListItem
                {
                    Value = n.CityID.ToString(),
                    Text = n.Name
                }).ToList();

                return Json(suburbsSel);
            }
            return null;
        }
        //[HttpGet]
        //[Route("[area]/[controller]/[action]")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var medicalPracticeDetails = await _service.GetByIdAsync(id);

        //    return View(medicalPracticeDetails);
        //}

        //[HttpPost, ActionName("Delete")]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var medicalPracticeDetails = await _service.GetByIdAsync(id);
        //    if (medicalPracticeDetails == null)
        //    {
        //        return NotFound();
        //    }

        //    await _service.DeleteAsync(id);
        //    return RedirectToAction(nameof(Index));
        //}
    }
}
