using EPrescribingSystem.Areas.Admin.ViewModel;
using EPrescribingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescribingSystem.Areas.Admin.Data.Repository
{
    public interface IMedicationRepository
    {
        Task<IEnumerable<Medication>> GetAllAsync();

        Task<Medication> GetByIdAsync(int id);
        Medication GetById(int id);
        Task AddAsync(Medication medication);
        Task<Medication> UpdateAsync(Medication medication);
        //Task<pharmacy> UpdateAsync(int id, Pharmacy pharmacy);
        Task DeleteAsync(int id);

        Medication Delete(Medication medication);
        Task AddAsync(MedicalPracticeViewModel medication);
    }
}
