using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EPrescribingSystem.Data;
using EPrescribingSystem.Models;
using Microsoft.AspNetCore.Identity;

namespace EPrescribingSystem.Areas.Doctor.Controllers
{
    [Area("Doctor")]
    public class PrescriptionController : Controller
    {
        private readonly EprescribingDBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public PrescriptionController(EprescribingDBContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Doctor/Prescription

        [Route("[area]/[controller]/[action]")]
        public async Task<IActionResult> Index()
        {
            var eprescribingDBContext = _context.Prescriptions.Include(d=>d.Doctor).Include(p => p.ApplicationUser).Include(p => p.Medication).Include(p => p.Pharmacy);

            //var Userid = 
            //ViewBag.Doctor = _context.Users.Where(u=>u.Id == eprescribingDBContext.ToList())
            return View(await eprescribingDBContext.ToListAsync());
        }


        // GET: Doctor/Prescription/Details/5
        [HttpGet]
        [Route("[area]/[controller]/[action]")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prescription = await _context.Prescriptions
                .Include(p => p.ApplicationUser)
                .Include(p => p.Medication)
                .Include(p => p.Pharmacy)
                .FirstOrDefaultAsync(m => m.PrescriptionID == id);
            if (prescription == null)
            {
                return NotFound();
            }

            return View(prescription);
        }

        // GET: Doctor/Prescription/Create
        [HttpGet]
        [Route("[area]/[controller]/[action]")]
        public async Task<IActionResult> Create()
        {
            var users = await _userManager.Users.ToListAsync();
            var userRolesViewModel = new List<UserRolesViewModel>();


            foreach (ApplicationUser user in users)
            {
                var checkrol = await _userManager.IsInRoleAsync(user, "Patient");
                if (checkrol)
                {
                    var thisViewModel = new UserRolesViewModel();
                    thisViewModel.UserId = user.Id;
                    thisViewModel.Email = user.Email;
                    thisViewModel.FirstName = user.FirstName;
                    thisViewModel.LastName = user.LastName;
                    userRolesViewModel.Add(thisViewModel);
                }
            }

            List<SelectListItem> Users = userRolesViewModel.Select(a => new SelectListItem
            {
                Value = a.UserId,
                Text = a.FirstName + " " + a.LastName
            }).ToList();

            ViewBag.Users = Users;

            //ViewData["ApplicationUserID"] = new SelectList(_context.Users, "Id", "FirstName");
            //ViewData["ApplicationUserIDL"] = new SelectList(_context.Users, "Id", "LastName");
            ViewData["MedicationID"] = new SelectList(_context.Medications, "MedicationID", "Name");
            ViewData["PharmacyID"] = new SelectList(_context.Pharmacies, "PharmacyID", "AddressLine1");
            return View();
        }

        // POST: Doctor/Prescription/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PrescriptionID,PrescriptionDate,DispensingDate,Instruction,Quantity,NumberOfRepeats,NumberOfRepeatsLeft,MedicationID,PharmacyID,ApplicationUserID,DoctorID")] Prescription prescription)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prescription);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserID"] = new SelectList(_context.Users, "Id", "Id", prescription.ApplicationUserID);
            ViewData["MedicationID"] = new SelectList(_context.Medications, "MedicationID", "MedicationID", prescription.MedicationID);
            ViewData["PharmacyID"] = new SelectList(_context.Pharmacies, "PharmacyID", "AddressLine1", prescription.PharmacyID);
            return View(prescription);
        }

        // GET: Doctor/Prescription/Edit/5
        [HttpGet]
        [Route("[area]/[controller]/[action]")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prescription = await _context.Prescriptions.FindAsync(id);
            if (prescription == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserID"] = new SelectList(_context.Users, "Id", "Id", prescription.ApplicationUserID);
            ViewData["MedicationID"] = new SelectList(_context.Medications, "MedicationID", "MedicationID", prescription.MedicationID);
            ViewData["PharmacyID"] = new SelectList(_context.Pharmacies, "PharmacyID", "AddressLine1", prescription.PharmacyID);
            return View(prescription);
        }

        // POST: Doctor/Prescription/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PrescriptionID,PrescriptionDate,DispensingDate,Instruction,Quantity,NumberOfRepeats,NumberOfRepeatsLeft,MedicationID,PharmacyID,ApplicationUserID,Doctor")] Prescription prescription)
        {
            if (id != prescription.PrescriptionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prescription);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrescriptionExists(prescription.PrescriptionID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserID"] = new SelectList(_context.Users, "Id", "Id", prescription.ApplicationUserID);
            ViewData["MedicationID"] = new SelectList(_context.Medications, "MedicationID", "MedicationID", prescription.MedicationID);
            ViewData["PharmacyID"] = new SelectList(_context.Pharmacies, "PharmacyID", "AddressLine1", prescription.PharmacyID);
            return View(prescription);
        }

        // GET: Doctor/Prescription/Delete/5
        [HttpGet]
        [Route("[area]/[controller]/[action]")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prescription = await _context.Prescriptions
                .Include(p => p.ApplicationUser)
                .Include(p => p.Medication)
                .Include(p => p.Pharmacy)
                .FirstOrDefaultAsync(m => m.PrescriptionID == id);
            if (prescription == null)
            {
                return NotFound();
            }

            return View(prescription);
        }

        // POST: Doctor/Prescription/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prescription = await _context.Prescriptions.FindAsync(id);
            _context.Prescriptions.Remove(prescription);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrescriptionExists(int id)
        {
            return _context.Prescriptions.Any(e => e.PrescriptionID == id);
        }
    }
}
