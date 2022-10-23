using EPrescribingSystem.Areas.Admin.ViewModel;
using EPrescribingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescribingSystem.Areas.Admin.Data.Repository
{
    public interface IPharmacyRepository
    {
        Task<IEnumerable<Pharmacy>> GetAllAsync();

        Task<Pharmacy> GetByIdAsync(int id);
        Pharmacy GetById(int id);
        Task AddAsync(MedicalPracticeViewModel pharmacy);
        Task<Pharmacy> UpdateAsync(Pharmacy pharmacy);
        //Task<pharmacy> UpdateAsync(int id, Pharmacy pharmacy);
        Pharmacy Update(Pharmacy pharmacy);
        Task DeleteAsync(int id);

        Pharmacy Delete(Pharmacy pharmacy);
    }
}
