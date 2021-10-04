using System.Collections.Generic;

namespace VBooX.Application.DTOs.Email
{
    public class BulkEmailRequest
    {
        public List<string> RecieverEmails { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public string SenderEmai { get; set; }

        public string SenderName { get; set; }
    }
}
