using EPrescribingSystem.Data;
using EPrescribingSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescribingSystem.Areas.Admin.Data.Repository
{
    public class MedicationRepository : IMedicationRepository
    {
        private readonly EprescribingDBContext _context;
        public MedicationRepository(EprescribingDBContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Medication medication)
        {
            await _context.Medications.AddAsync(medication);
            await _context.SaveChangesAsync();
        }

        public Medication Delete(Medication medication)
        {
            _context.Medications.Attach(medication);
            _context.Entry(medication).State = EntityState.Deleted;
            _context.SaveChanges();
            return medication;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Medication>> GetAllAsync()
        {
            var result = await _context.Medications.ToListAsync();
            return result;
        }

        public Medication GetById(int id)
        {
            Medication medication = _context.Medications.Where(c => c.MedicationID == id).FirstOrDefault();
            return medication;
        }

        public async Task<Medication> GetByIdAsync(int id)
        {
            var result = await _context.Medications.FirstOrDefaultAsync(n => n.MedicationID == id);
            return result;
        }

        public async Task<Medication> UpdateAsync(Medication newMedication)
        {
            _context.Medications.Attach(newMedication);
            _context.Entry(newMedication).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return newMedication;
        }
    }
}
