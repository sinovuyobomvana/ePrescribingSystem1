﻿using EPrescribingSystem.Controllers;
using EPrescribingSystem.Models;
using EPrescribingSystem.ViewModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescribingSystem.Repository
{
    public class RegisterRepository : IRegisterRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public RegisterRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IdentityResult> CreateUserAsync(UserCreateModel userModel)
        {
            var user = new ApplicationUser()
            {
                Title = userModel.RegisterUserModel.Title,
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

        public async Task<SignInResult> PasswordSignInAsync(SignInModel signInModel)
        {
            var result = await _signInManager.PasswordSignInAsync(signInModel.Email, signInModel.Password, signInModel.RememberMe, false);

            return result;
        }

    }
}

