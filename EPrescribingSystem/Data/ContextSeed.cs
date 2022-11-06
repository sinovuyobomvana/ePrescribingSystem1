using EPrescribingSystem.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescribingSystem.Data
{
    public static class ContextSeed
    {
        //public static async Task SeedRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        //{
        //    Seed Roles

        //    await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Admin.ToString()));
        //    await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Basic.ToString()));
        //    await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Patient.ToString()));
        //    await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Doctor.ToString()));
        //    await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Pharmacist.ToString()));

        //}

        public static async Task SeedSuperAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new ApplicationUser
            {
                UserName = "superadmin@gmail.com",
                Email = "superadmin@gmail.com",
                FirstName = "Sinovuyo",
                LastName = "Bomvana",
                EmailConfirmed = true,
                PhoneNumber = "0731953257",
                PhoneNumberConfirmed = true,
                SuburbID = 1,
                RegistrationDate = DateTime.Now
                
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123aA+");

                    if (roleManager.Roles.ToList().Count == 0)
                    {
                        await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Admin.ToString()));
                        await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Basic.ToString()));
                        await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Patient.ToString()));
                        await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Doctor.ToString()));
                        await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Pharmacist.ToString()));

                       
                    }

                      userManager.FindByIdAsync(defaultUser.Id).ToString();
                     await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Admin.ToString());
                }

            }
        }

    }
}
