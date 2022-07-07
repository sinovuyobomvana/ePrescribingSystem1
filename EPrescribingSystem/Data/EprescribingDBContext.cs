using EPrescribingSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescribingSystem.Data
{
    public class EprescribingDBContext : IdentityDbContext<ApplicationUser>
    {
        public EprescribingDBContext(DbContextOptions<EprescribingDBContext> options) : base(options)
        {

        }
    }
}
