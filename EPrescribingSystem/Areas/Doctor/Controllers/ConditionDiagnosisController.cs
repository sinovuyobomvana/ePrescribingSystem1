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
    public class ConditionDiagnosisController : Controller
    {
        private readonly EprescribingDBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ConditionDiagnosisController(EprescribingDBContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Doctor/ConditionDiagnosis
        [Route("[area]/[controller]/[action]")]
        public async Task<IActionResult> Index()
        {
            var eprescribingDBContext = _context.ConditionDiagnoses.Include(m=>m.Medication).Include(c => c.ApplicationUser);
            return View(await eprescribingDBContext.ToListAsync());
        }

        // GET: Doctor/ConditionDiagnosis/Details/5
        [HttpGet]
        [Route("[area]/[controller]/[action]")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conditionDiagnosis = await _context.ConditionDiagnoses
                .Include(c => c.ApplicationUser)
                .FirstOrDefaultAsync(m => m.ConditionID == id);
            if (conditionDiagnosis == null)
            {
                return NotFound();
            }

            return View(conditionDiagnosis);
        }

        // GET: Doctor/ConditionDiagnosis/Create
        [HttpGet]
        [Route("[area]/[controller]/[action]/{id?}")]
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

            ViewData["MedicationID"] = new SelectList(_context.Medications, "MedicationID", "Name");

            //ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "FirstName");
            //ViewData["ApplicationUserIdL"] = new SelectList(_context.Users, "Id", "LastName");

            return View();
        }

        // POST: Doctor/ConditionDiagnosis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConditionID,ICD_10_CODE,Diagnosis,DiagnosisDate,ApplicationUserId,Allergy,MedicationID,Doctor")] ConditionDiagnosis conditionDiagnosis)
        {
            if (ModelState.IsValid)
            {
                _context.Add(conditionDiagnosis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", conditionDiagnosis.ApplicationUserId);
            return View(conditionDiagnosis);
        }

        // GET: Doctor/ConditionDiagnosis/Edit/5
        [HttpGet]
        [Route("[area]/[controller]/[action]")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conditionDiagnosis = await _context.ConditionDiagnoses.FindAsync(id);
            if (conditionDiagnosis == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", conditionDiagnosis.ApplicationUserId);
            return View(conditionDiagnosis);
        }

        // POST: Doctor/ConditionDiagnosis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConditionID,ICD_10_CODE,Diagnosis,DiagnosisDate,ApplicationUserId,Allergy")] ConditionDiagnosis conditionDiagnosis)
        {
            if (id != conditionDiagnosis.ConditionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conditionDiagnosis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConditionDiagnosisExists(conditionDiagnosis.ConditionID))
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
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", conditionDiagnosis.ApplicationUserId);
            return View(conditionDiagnosis);
        }

        // GET: Doctor/ConditionDiagnosis/Delete/5
        [HttpGet]
        [Route("[area]/[controller]/[action]")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conditionDiagnosis = await _context.ConditionDiagnoses
                .Include(c => c.ApplicationUser)
                .FirstOrDefaultAsync(m => m.ConditionID == id);
            if (conditionDiagnosis == null)
            {
                return NotFound();
            }

            return View(conditionDiagnosis);
        }

        // POST: Doctor/ConditionDiagnosis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var conditionDiagnosis = await _context.ConditionDiagnoses.FindAsync(id);
            _context.ConditionDiagnoses.Remove(conditionDiagnosis);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConditionDiagnosisExists(int id)
        {
            return _context.ConditionDiagnoses.Any(e => e.ConditionID == id);
        }
    }
}
