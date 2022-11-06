using EPrescribingSystem.Areas.Admin.Data.Repository;
using EPrescribingSystem.Models;
using EPrescribingSystem.Areas.Admin.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using EPrescribingSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace EPrescribingSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MedicationController : Controller
    {
        private readonly IMedicationRepository _service;
        private readonly EprescribingDBContext _context = null;


        public MedicationController(EprescribingDBContext context, IMedicationRepository service)
        {
            _service = service;
            _context = context;
        }

        [Route("[area]/[controller]/[action]")]
        public async Task<IActionResult> Index()
        {
            var medications = await _context.Medications.ToListAsync();
            var medicationViewModel = new List<MedicationViewModel>();
            foreach (Medication meds in medications)
            {
                var thisViewModel = new MedicationViewModel();
                
                thisViewModel.Name = meds.Name;
                thisViewModel.Schedule = meds.Schedule;
                thisViewModel.DosageForm = meds.DosageForm;
                thisViewModel.ActiveIngredientName = GetActiveIngredient(meds.ActiveIngredient.ActiveIngredientID);
                thisViewModel.Strength = meds.Strength;

                medicationViewModel.Add(thisViewModel);
            }
            return View(medicationViewModel);
        }

        public string GetActiveIngredient(int Id)
        {
            string activeIngredientName;

            return activeIngredientName = _context.ActiveIngredients.Where(s => s.ActiveIngredientID == Id).Select(s => s.Name).FirstOrDefault();
        }
        //public async Task<IActionResult> Index()
        //{
        //    var data = await _service.GetAllAsync();
        //    return View(data);
        //}


        //Get: Pharmacy/Create
        [HttpGet]
        [Route("[area]/[controller]/[action]")]
        public IActionResult Create()
        {
            MedicalPracticeViewModel medicalPracticeModel = new MedicalPracticeViewModel();

            medicalPracticeModel.MedicalPractice = new Models.MedicalPractice();
            List<SelectListItem> ActiveIngredients = _context.ActiveIngredients
                .OrderBy(n => n.Name)
                .Select(n =>
                new SelectListItem
                {
                    Value = n.ActiveIngredientID.ToString(),
                    Text = n.Name
                }).ToList();

            medicalPracticeModel.ActiveIngredients = ActiveIngredients;
            

            return View(medicalPracticeModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(MedicalPracticeViewModel medicalPracticeModel)
        {
            //MedicalPracticeViewModel medicalPracticeModel = new MedicalPracticeViewModel();

            if (!ModelState.IsValid)
            {
                medicalPracticeModel.MedicalPractice = new Models.MedicalPractice();
                List<SelectListItem> ActiveIngredients = _context.ActiveIngredients
                    .OrderBy(n => n.Name)
                    .Select(n =>
                    new SelectListItem
                    {
                        Value = n.ActiveIngredientID.ToString(),
                        Text = n.Name
                    }).ToList();

                medicalPracticeModel.ActiveIngredients = ActiveIngredients;
                

                return View(medicalPracticeModel);
            }
            await _service.AddAsync(medicalPracticeModel);
            return RedirectToAction(nameof(Index));
        }

        //////////////////////////////////

        //[HttpGet]
        //[Route("[area]/[controller]/[action]")]
        //public IActionResult Create()
        //{

        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Create([Bind("Name,DosageForm,Schedule,ActiveIngredientID,Strength")] Medication medication)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(medication);
        //    }
        //    await _service.AddAsync(medication);
        //    return RedirectToAction(nameof(Index));
        //}


        //Get: Pharmacy/Details
        [Route("[area]/[controller]/[action]")]
        public async Task<IActionResult> Details(int id)
        {
            var medicationDetails = await _service.GetByIdAsync(id);

            if (medicationDetails == null) return View("Not Found!!!");
            return View(medicationDetails);
        }

        //Get: Pharmacy/Update
        [HttpGet]
        [Route("[area]/[controller]/[action]")]
        public async Task<IActionResult> Edit(int id)
        {
            var medicationDetails = await _service.GetByIdAsync(id);

            if (medicationDetails == null)
            {
                return NotFound();
            }


            return View(medicationDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Medication medication)
        {
            try
            {
                medication = await _service.UpdateAsync(medication);
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
            var medication = _service.GetById(id);
            return View(medication);
        }

        [HttpPost]
        public IActionResult Delete(Medication medication)
        {
            try
            {
                medication = _service.Delete(medication);
            }
            catch
            {

            }
            return RedirectToAction("Index");
        }
    }
}
