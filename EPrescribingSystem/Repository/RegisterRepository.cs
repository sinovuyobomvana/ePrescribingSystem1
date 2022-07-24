using EPrescribingSystem.Controllers;
using EPrescribingSystem.Models;
using EPrescribingSystem.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescribingSystem.Repository
{
    public class RegisterRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegisterRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IdentityResult> CreateUserAsync(UserCreateModel userModel)
        {
            var user = new ApplicationUser()
            {
                Email = userModel.RegisterUserModel.Email,
                UserName = userModel.RegisterUserModel.Email,
                FirstName = userModel.RegisterUserModel.FirstName,
                LastName = userModel.RegisterUserModel.LastName,
                DateOfBirth = userModel.RegisterUserModel.DateOfBirth.Date,
                IDNumber = userModel.RegisterUserModel.IDNumber,
                Gender = userModel.RegisterUserModel.Gender,
                Addressine1 = userModel.RegisterUserModel.Addressine1,
                AddressLine2 = userModel.RegisterUserModel.AddressLine2,
                ContactNumber = userModel.RegisterUserModel.ContactNumber,
                RegistrationDate = DateTime.Now,
                PostalCode = userModel.RegisterUserModel.PostalCode,
                SuburbID = userModel.RegisterUserModel.Suburb.SuburbID,
                HighestQualification = userModel.RegisterUserModel.HighestQualification,
                HealthCouncilRegistrationNumber = userModel.RegisterUserModel.HealthCouncilRegistrationNumber,
                RegistrationNumber = userModel.RegisterUserModel.RegistrationNumber,
                
            };

            var result = await _userManager.CreateAsync(user, userModel.RegisterUserModel.Password);

            if (result.Succeeded)
            {
                if (userModel.RegisterUserModel.Role == "Doctor")
                {
                    await _userManager.AddToRoleAsync(user, Enums.Roles.Doctor.ToString());
                }
                else if(userModel.RegisterUserModel.Role == "Pharmacist")
                {
                    await _userManager.AddToRoleAsync(user, Enums.Roles.Pharmacist.ToString());
                }
            }

            return result;
        }

    }
}

