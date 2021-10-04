namespace VBooX.Application.DTOs.Email
{
    public class EmailRequestWithAttachment
    {
        public string RecieverEmail { get; set; }

        public string RecieverName { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public string SenderEmai { get; set; }

        public string SenderName { get; set; }

        public string FileName { get; set; }
    }
}
