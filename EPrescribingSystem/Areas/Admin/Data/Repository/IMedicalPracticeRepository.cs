using EPrescribingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescribingSystem.Areas.Admin.Data.Services
{
    public interface IMedicalPracticeRepository
    {

        Task<IEnumerable<MedicalPractice>> GetAllAsync();
        Task<MedicalPractice> GetByIdAsync(int id);
        MedicalPractice GetById(int id);
        Task AddAsync(MedicalPractice medicalPractice);
        Task<MedicalPractice> UpdateAsync(MedicalPractice newMedicalPractice);
        //Task<MedicalPractice> UpdateAsync(int id, MedicalPractice newMedicalPractice);
        Task DeleteAsync(int id);

        MedicalPractice Delete(MedicalPractice medicalPractice);

    }
}
