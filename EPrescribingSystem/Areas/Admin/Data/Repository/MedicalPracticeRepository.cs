using EPrescribingSystem.Areas.Admin.Data.Repository;
using EPrescribingSystem.Areas.Admin.Data.Services;
using EPrescribingSystem.Data;
using EPrescribingSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescribingSystem.Areas.Admin.Data.Repository
{
    public class MedicalPracticeRepository : IMedicalPracticeRepository
    {
        private readonly EprescribingDBContext _context;

        public MedicalPracticeRepository(EprescribingDBContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<MedicalPractice>> GetAllAsync()
        {
            var result = await _context.MedicalPractices.ToListAsync();
            return result;
        }

        public async Task AddAsync(MedicalPractice medicalPractice)
        {
            await _context.MedicalPractices.AddAsync(medicalPractice);
            await _context.SaveChangesAsync();
        }

        public async Task<MedicalPractice> GetByIdAsync(int id)
        {
            var result = await _context.MedicalPractices.FirstOrDefaultAsync(n => n.MedicalPracticeID == id);
            return result;
        }

        public MedicalPractice GetById(int id)
        {
            MedicalPractice medicalPractice = _context.MedicalPractices.Where(c => c.MedicalPracticeID == id).FirstOrDefault();
            return medicalPractice;
        }

        public async Task<MedicalPractice> UpdateAsync(MedicalPractice newMedicalPractice)
        {
            _context.MedicalPractices.Attach(newMedicalPractice);
            _context.Entry(newMedicalPractice).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return newMedicalPractice;
        }
        //public async Task<MedicalPractice> UpdateAsync(int id, MedicalPractice newMedicalPractice)
        //{
        //    _context.Update(newMedicalPractice);
        //    await _context.SaveChangesAsync();
        //    return newMedicalPractice;
        //}

        public async Task DeleteAsync(int id)
        {
            var result = await _context.MedicalPractices.FirstOrDefaultAsync(n => n.MedicalPracticeID == id);
            _context.MedicalPractices.Remove(result);
            await _context.SaveChangesAsync();
        }

        public MedicalPractice Delete(MedicalPractice medicalPractice)
        {
            _context.MedicalPractices.Attach(medicalPractice);
            _context.Entry(medicalPractice).State = EntityState.Deleted;
            _context.SaveChanges();
            return medicalPractice;
        }


    }
}
