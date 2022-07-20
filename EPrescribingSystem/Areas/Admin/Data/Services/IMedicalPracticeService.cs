using EPrescribingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescribingSystem.Areas.Admin.Data.Services
{
    public interface IMedicalPracticeService
    {
        Task<IEnumerable<MedicalPractice>> GetAllAsync();
        Task<MedicalPractice> GetByIdAsync(int id);
        Task AddAsync(MedicalPractice medicalPractice);
        Task<MedicalPractice> UpdateAsync(int id, MedicalPractice newMedicalPractice);
        Task DeleteAsync(int id);

    }
}
