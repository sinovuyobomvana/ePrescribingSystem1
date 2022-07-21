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
    }
}
