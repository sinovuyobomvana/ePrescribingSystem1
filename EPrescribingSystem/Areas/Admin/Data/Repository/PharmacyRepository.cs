using EPrescribingSystem.Areas.Admin.ViewModel;
using EPrescribingSystem.Data;
using EPrescribingSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescribingSystem.Areas.Admin.Data.Repository
{
    public class PharmacyRepository : IPharmacyRepository
    {
        private readonly EprescribingDBContext _context;

        public PharmacyRepository(EprescribingDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pharmacy>> GetAllAsync()
        {
            var result = await _context.Pharmacies.ToListAsync();
            return result;
        }

        public async Task AddAsync(MedicalPracticeViewModel pharmacy)
        {
            await _context.Pharmacies.AddAsync(pharmacy.Pharmacy);
            await _context.SaveChangesAsync();
        }

        public async Task<Pharmacy> GetByIdAsync(int id)
        {
            var result = await _context.Pharmacies.Include(u => u.ApplicationUser).Include(x=>x.Suburb.City.Province).FirstOrDefaultAsync(n => n.PharmacyID == id);
            return result;
        }

        public Pharmacy GetById(int id)
        {
            Pharmacy pharmacy = _context.Pharmacies.Include(u=>u.ApplicationUser).Include(s=>s.Suburb.City.Province).Where(c => c.PharmacyID == id).FirstOrDefault();
            return pharmacy;
        }

        public Task<Pharmacy> UpdateAsync(Pharmacy pharmacy)
        {
            throw new NotImplementedException();
        }
        public Pharmacy Update(Pharmacy pharmacy)
        {
            _context.Pharmacies.Attach(pharmacy);
            _context.Entry(pharmacy).State = EntityState.Modified;
            _context.SaveChanges();
            return pharmacy;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Pharmacy Delete(Pharmacy pharmacy)
        {
            _context.Pharmacies.Attach(pharmacy);
            _context.Entry(pharmacy).State = EntityState.Deleted;
            _context.SaveChanges();
            return pharmacy;
        }

        

       

      
    }
}
