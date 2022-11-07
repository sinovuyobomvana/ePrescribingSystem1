using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EPrescribingSystem.Data;
using EPrescribingSystem.Models;

namespace EPrescribingSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DiseaseController : Controller
    {
        private readonly EprescribingDBContext _context;

        public DiseaseController(EprescribingDBContext context)
        {
            _context = context;
        }

        // GET: Admin/Disease
        [Route("[area]/[controller]/[action]")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Disease.ToListAsync());
        }

        // GET: Admin/Disease/Details/5
        [Route("[area]/[controller]/[action]")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disease = await _context.Disease
                .FirstOrDefaultAsync(m => m.DiseaseID == id);
            if (disease == null)
            {
                return NotFound();
            }

            return View(disease);
        }

        // GET: Admin/Disease/Create
        [HttpGet]
        [Route("[area]/[controller]/[action]")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Disease/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DiseaseID,ICD_10_CODE,Diagnosis")] Disease disease)
        {
            if (ModelState.IsValid)
            {
                _context.Add(disease);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(disease);
        }

        // GET: Admin/Disease/Edit/5
        [HttpGet]
        [Route("[area]/[controller]/[action]")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disease = await _context.Disease.FindAsync(id);
            if (disease == null)
            {
                return NotFound();
            }
            return View(disease);
        }

        // POST: Admin/Disease/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DiseaseID,ICD_10_CODE,Diagnosis")] Disease disease)
        {
            if (id != disease.DiseaseID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disease);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiseaseExists(disease.DiseaseID))
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
            return View(disease);
        }

        // GET: Admin/Disease/Delete/5
        [HttpGet]
        [Route("[area]/[controller]/[action]")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disease = await _context.Disease
                .FirstOrDefaultAsync(m => m.DiseaseID == id);
            if (disease == null)
            {
                return NotFound();
            }

            return View(disease);
        }

        // POST: Admin/Disease/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var disease = await _context.Disease.FindAsync(id);
            _context.Disease.Remove(disease);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiseaseExists(int id)
        {
            return _context.Disease.Any(e => e.DiseaseID == id);
        }
    }
}
