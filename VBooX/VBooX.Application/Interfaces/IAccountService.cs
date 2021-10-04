using System.Threading.Tasks;
using VBooX.Application.DTOs.Account;
using VBooX.Application.Wrappers;

namespace VBooX.Application.Interfaces
{
    public interface IAccountService
    {
        Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request, string ipAddress);
        Task<Response<string>> RegisterAsync(RegisterRequest request, string origin, string role);

        Task<Response<string>> ConfirmEmailAsync(string userId, string code);

        Task<ForgotPasswordResponse> GetResetToken(ForgotPasswordRequest model, string origin);

        Task<Response<string>> ResetPassword(ResetPasswordRequest model);

        Task<Response<string>> ChangePassword(ChangePasswordVM model);

        Task<bool> IsEmailExists(string email);
        Task<bool> IsPhoneExists(string phoneNumber);

        void SendPasswordResetSMS(string code, string number);

        string GetPhoneNumberByUserId(string phone);
    }
}
