using System.Threading.Tasks;
using VBooX.Application.DTOs.Email;

namespace VBooX.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequest request);

        // void SendEmail(SingleEmailRequest request);

        void SendEmailWithAttachment(EmailRequestWithAttachment request);

        //  void SendBulkEmail(BulkEmailRequest request);
    }
}
