using EPrescribingSystem.Models;
using EPrescribingSystem.ViewModel;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace EPrescribingSystem.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(UserCreateModel userModel);
        Task<SignInResult> PasswordSignInAsync(SignInModel signInModel);
        Task SignOutAsync();
        Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel changePassword);
    }
}