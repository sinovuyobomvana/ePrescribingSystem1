using EPrescribingSystem.Data;
using EPrescribingSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescribingSystem.Areas.Admin.Data.Services
{
    public class MedicalPracticeService : IMedicalPracticeService
    {
        private readonly EprescribingDBContext _context;

        public MedicalPracticeService(EprescribingDBContext context)
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

        public async Task<MedicalPractice> UpdateAsync(int id, MedicalPractice newMedicalPractice)
        {
            _context.Update(newMedicalPractice);
            await _context.SaveChangesAsync();
            return newMedicalPractice;
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.MedicalPractices.FirstOrDefaultAsync(n => n.MedicalPracticeID == id);
            _context.MedicalPractices.Remove(result);
            await _context.SaveChangesAsync();
        }


    }
}
