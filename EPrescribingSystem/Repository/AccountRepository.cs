using EPrescribingSystem.Data;
using EPrescribingSystem.Models;
using EPrescribingSystem.Service;
using EPrescribingSystem.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
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
        private readonly EprescribingDBContext _context = null;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;

        public AccountRepository(IEmailService emailService, IConfiguration configuration, EprescribingDBContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser>signInManager, IUserService userService)
        {
             _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
            _context = context;
            _configuration = configuration;
            _emailService = emailService;
        }

        public async Task<IdentityResult> CreateUserAsync(UserCreateModel userModel)
        {
            string postal = GetPostalCodes(userModel);

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
                PostalCode = postal,
                SuburbID = userModel.RegisterUserModel.Suburb.SuburbID,
                HighestQualification = userModel.RegisterUserModel.HighestQualification,
                HealthCouncilRegistrationNumber = userModel.RegisterUserModel.HealthCouncilRegistrationNumber,
                RegistrationNumber = userModel.RegisterUserModel.RegistrationNumber,
            }; 

            var result = await _userManager.CreateAsync(user, userModel.RegisterUserModel.Password);

            if (result.Succeeded)
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                if (!string.IsNullOrEmpty(token))
                {
                    try
                    {
                        await SendEmailConfirmationEmail(user, token);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }


                }
            }

            if (result.Succeeded && userModel.RegisterUserModel.Role == "pharm")
            {
                await _userManager.AddToRoleAsync(user, Enums.Roles.Pharmacist.ToString());
            }
            else if (result.Succeeded && userModel.RegisterUserModel.Role == "doc")
            {
                await _userManager.AddToRoleAsync(user, Enums.Roles.Doctor.ToString());
            }
            else
            {
                await _userManager.AddToRoleAsync(user, Enums.Roles.Patient.ToString());
            }

            return result; 
        }

        public string GetPostalCodes(UserCreateModel userModel)
        {
            string result = _context.Suburbs
            .Where(s => s.SuburbID == userModel.RegisterUserModel.Suburb.SuburbID).Select(s=>s.PostalCode)
            .FirstOrDefault();
   
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

        private async Task SendEmailConfirmationEmail(ApplicationUser user, string token)
        {
            string appDomain = _configuration.GetSection("Application:AppDomain").Value;
            string confirmationLink = _configuration.GetSection("Application:EmailConfirmation").Value;

            UserEmailOptions options = new UserEmailOptions
            {
                ToEmails = new List<string>() { user.Email },
                Placeholders = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("{{UserName}}", user.FirstName),
                    new KeyValuePair<string, string>("{{Link}}", string.Format(appDomain + confirmationLink, user.Id, token))
                }
            };

            await _emailService.SendEmailForEmailConfirmation(options);

        }
        public async Task GenerateEmailConfirmationTokenAsync(ApplicationUser user)
        {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            if (!string.IsNullOrEmpty(token))
            {
                await SendEmailConfirmationEmail(user, token);
            }
        }

        public async Task GenerateForgotPasswordAsync(ApplicationUser user)
        {
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            if (!string.IsNullOrEmpty(token))
            {
                await SendForgotPasswordEmail(user, token);
            }
        }

        public async Task<ApplicationUser> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        private async Task SendForgotPasswordEmail(ApplicationUser user, string token)
        {
            string appDomain = _configuration.GetSection("Application:AppDomain").Value;
            string confirmationLink = _configuration.GetSection("Application:ForgotPassword").Value;

            UserEmailOptions options = new UserEmailOptions
            {
                ToEmails = new List<string>() { user.Email },
                Placeholders = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("{{UserName}}", user.FirstName),
                    new KeyValuePair<string, string>("{{Link}}", string.Format(appDomain + confirmationLink, user.Id, token))
                }
            };

            await _emailService.SendEmailForForgotPassword(options);

        }

        public async Task<IdentityResult> ConfirmEmailAsync(string uid, string token)
        {
            return await _userManager.ConfirmEmailAsync(await _userManager.FindByIdAsync(uid), token);
        }

        public async Task<IdentityResult> ResetPassworsAsync(ResetPasswordModel model)
        {
            return await _userManager.ResetPasswordAsync(await _userManager.FindByIdAsync(model.UserId), model.Token, model.NewPassword);
        }

    }
}
