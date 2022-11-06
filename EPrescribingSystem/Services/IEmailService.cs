using EPrescribingSystem.Models;
using System.Threading.Tasks;

namespace EPrescribingSystem.Service
{
    public interface IEmailService
    {
        Task SendTestEmail(UserEmailOptions userEmailOptions);
        Task SendEmailForEmailConfirmation(UserEmailOptions userEmailOptions);
        Task SendEmailForForgotPassword(UserEmailOptions userEmailOptions);
        Task SendEmailForAcceptance(UserEmailOptions userEmailOptions);
        Task SendEmailForDecline(UserEmailOptions userEmailOptions);
    }
}