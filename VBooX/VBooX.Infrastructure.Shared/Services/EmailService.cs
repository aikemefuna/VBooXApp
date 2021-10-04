using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using VBooX.Application.DTOs.Email;
using VBooX.Application.Exceptions;
using VBooX.Application.Interfaces;
using VBooX.Domain.Settings;

namespace VBooX.Infrastructure.Shared.Services
{
    public class EmailService : IEmailService
    {
        public MailSettings _mailSettings { get; }
        public ILogger<EmailService> _logger { get; }

        public EmailService(IOptions<MailSettings> mailSettings, ILogger<EmailService> logger)
        {
            _mailSettings = mailSettings.Value;
            _logger = logger;
        }

        public async Task SendAsync(EmailRequest request)
        {
            try
            {
                using (var message = new MailMessage())
                {
                    string from = _mailSettings.EmailFrom;

                    message.To.Add(new MailAddress(request.To, request.To));
                    message.From = new MailAddress(from, _mailSettings.DisplayName);

                    message.Subject = request.Subject;
                    message.Body = request.Body;
                    message.IsBodyHtml = true;


                    using (var client = new System.Net.Mail.SmtpClient(_mailSettings.SmtpHost))
                    {
                        client.Port = _mailSettings.SmtpPort;
                        client.UseDefaultCredentials = true;
                        client.Credentials = new NetworkCredential(_mailSettings.SmtpUser, _mailSettings.SmtpPass);
                        client.EnableSsl = true;
                        System.Net.ServicePointManager.ServerCertificateValidationCallback = (object s, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors) => true;
                        client.Send(message);
                    }
                }


                //// create message
                //var email = new MimeMessage();
                //email.Sender = MailboxAddress.Parse(request.From ?? _mailSettings.EmailFrom);
                //email.To.Add(MailboxAddress.Parse(request.To));
                //email.Subject = request.Subject;
                //var builder = new BodyBuilder();
                //builder.HtmlBody = request.Body;
                //email.Body = builder.ToMessageBody();
                //using var smtp = new MailKit.Net.Smtp.SmtpClient();
                //smtp.Connect(_mailSettings.SmtpHost, _mailSettings.SmtpPort, SecureSocketOptions.StartTls);
                //smtp.Authenticate(_mailSettings.SmtpUser, _mailSettings.SmtpPass);
                //await smtp.SendAsync(email);
                //smtp.Disconnect(true);

            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }
        }

        public void SendEmailWithAttachment(EmailRequestWithAttachment request)
        {
            using (var message = new MailMessage())
            {
                string from = _mailSettings.EmailFrom;

                message.To.Add(new MailAddress(request.RecieverEmail, request.RecieverName));
                message.From = new MailAddress(from, _mailSettings.DisplayName);
                Attachment attachment;
                attachment = new Attachment(request.FileName);
                message.Attachments.Add(attachment);                //message.CC.Add(new MailAddress("cc@email.com", "CC Name"));
                //message.Bcc.Add(new MailAddress("bcc@email.com", "BCC Name"));
                message.Subject = request.Subject;
                message.Body = request.Body;
                message.IsBodyHtml = true;


                using (var client = new System.Net.Mail.SmtpClient(_mailSettings.SmtpHost))
                {
                    client.Port = _mailSettings.SmtpPort;
                    client.UseDefaultCredentials = true;
                    client.Credentials = new NetworkCredential(_mailSettings.SmtpUser, _mailSettings.SmtpPass);
                    client.EnableSsl = true;
                    System.Net.ServicePointManager.ServerCertificateValidationCallback = (object s, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors) => true;
                    client.Send(message);
                }
            }
        }
    }
}
