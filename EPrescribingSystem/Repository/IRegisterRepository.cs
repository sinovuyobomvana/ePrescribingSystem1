using EPrescribingSystem.Models;
using EPrescribingSystem.ViewModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescribingSystem.Repository
{
    interface IRegisterRepository
    {
        Task<IdentityResult> CreateUserAsync(UserCreateModel userModel);
        Task<SignInResult> PasswordSignInAsync(SignInModel signInModel);
    }
}
