using EPrescribingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescribingSystem.Areas.Admin.Data.Repository
{
    public class PharmacyRepository : IPharmacyRepository
    {
        public Task<IEnumerable<Pharmacy>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
