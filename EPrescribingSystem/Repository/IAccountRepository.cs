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
        Task<IdentityResult> ConfirmEmailAsync(string uid, string token);
        Task GenerateEmailConfirmationTokenAsync(ApplicationUser user);
        Task<ApplicationUser> GetUserByEmailAsync(string email);
        Task GenerateForgotPasswordAsync(ApplicationUser user);
        Task<IdentityResult> ResetPassworsAsync(ResetPasswordModel model);
    }
}