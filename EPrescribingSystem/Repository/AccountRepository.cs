using EPrescribingSystem.Models;
using EPrescribingSystem.Service;
using EPrescribingSystem.ViewModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescribingSystem.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUserService _userService;

        public AccountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser>signInManager, IUserService userService)
        {
             _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
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
                await _userManager.AddToRoleAsync(user, Enums.Roles.Patient.ToString());
            }

            return result; 
        }

        public async Task<SignInResult> PasswordSignInAsync(SignInModel signInModel)
        {
          var result = await _signInManager.PasswordSignInAsync(signInModel.Email, signInModel.Password, signInModel.RememberMe, false);

            return result;
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel changePassword)
        {
            var userId = _userService.GetUserId();
            var user = await _userManager.FindByIdAsync(userId);

            return await _userManager.ChangePasswordAsync(user, changePassword.CurrentPassword, changePassword.NewPassword);
        }

    }
}
