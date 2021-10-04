using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using QRCoder;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SmartHomes.Data.Models;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using VBooX.Application.DTOs.Email;
using VBooX.Application.Interfaces;
using VBooX.Application.Interfaces.Repositories;
using VBooX.Domain.Entities;
using VBooX.Infrastructure.Persistence.Contexts;
using VBooX.Infrastructure.Persistence.Repository;

namespace VBooX.Infrastructure.Persistence.Repositories
{
    public class VisitorBookRepositoryAsync :
    GenericRepositoryAsync<VisitorBook>,
    IVisitorBookRepositoryAsync,
    IGenericRepositoryAsync<VisitorBook>
    {
        private readonly IGenericRepositoryAsync<VisitorBook> _visitorBookRepository;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IEmailService _emailService;
        private readonly ApplicationDbContext _context;

        public VisitorBookRepositoryAsync(
          IGenericRepositoryAsync<VisitorBook> visitorBookRepository,
          IHostingEnvironment hostingEnvironment,
          IEmailService emailService,
          ApplicationDbContext context) : base(context)
        {
            _visitorBookRepository = visitorBookRepository;
            _hostingEnvironment = hostingEnvironment;
            _emailService = emailService;
            _context = context;
        }

        public async Task<string> EncryptTagNo(string tagNo)
        {
            var visitorBook = await _visitorBookRepository.GetAll().Where(c => c.VisitTagNo == tagNo).Include(c => c.Customer).Include(c => c.Customer.Client).FirstOrDefaultAsync();

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(visitorBook.VisitTagNo, QRCodeGenerator.ECCLevel.Q);

            string fileGuid = Guid.NewGuid().ToString().Substring(0, 4);

            qrCodeData.SaveRawData("wwwroot/qrr/file-" + fileGuid + ".qrr", QRCodeData.Compression.Uncompressed);

            QRCodeData qrCodeData1 = new QRCodeData("wwwroot/qrr/file-" + fileGuid + ".qrr", QRCodeData.Compression.Uncompressed);


            QRCode qrCode = new QRCode(qrCodeData1);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            var qrBit = Convert.ToBase64String(BitmapToBytes(qrCodeImage));
            var ImageName = SaveProfileImage(qrBit, visitorBook.VisitTagNo);
            char ps = Path.DirectorySeparatorChar; // This gives "\"
            char psWeb = Path.AltDirectorySeparatorChar; // This gives "/"

            // Generates absolute paths to image
            var webRootPath = _hostingEnvironment.WebRootPath;
            string profilePicPath = webRootPath + ps + "Upload";
            var imageurl = profilePicPath + ps + ImageName;




            //SendQRToVisitor(imageurl, visitorBook);
            //SendTagAsSMS(visitorBook.VisitTagNo, visitorBook);
            //visitorBook.SentTag = true;
            //// ISSUE: explicit non-virtual call
            //await UpdateAsync(visitorBook);
            return imageurl;
        }

        public void SendQRToVisitor(string filePath, VisitorBook visitorBook)
        {
            EmailTemplatesObj emailTemplatesObj = new EmailTemplatesObj();
            string str1 = "<br />";
            string str2 = "<strong>";
            string str3 = "</strong>";
            string message = "The below information is as regards your visit to " + visitorBook.Customer.FullName + "." + str1 + str1 + str2 + "Your Name:" + str3 + " " + visitorBook.FullName + "," + str1 + str2 + "Who to see:" + str3 + visitorBook.Customer.FullName + "," + str1 + str2 + "Who to see Address:" + str3 + visitorBook.Customer.Address + str1 + str2 + "Purpose of Visit:" + str3 + visitorBook.PurposeOfVisit + "," + str1 + str2 + "Date & Time:" + str3 + " " + visitorBook.ProposedVisitDateAndTime.ToString("dd/MM/yyyy hh:mm ttt") + str1 + str2 + "Visit Tag No:" + str3 + visitorBook.VisitTagNo + "." + str1 + str1 + str1 + "Kindly note, the visit tag number above is your passcode into " + visitorBook.Customer.Client.Name + "." + str1 + str1 + "You may be required to scan the attached QR Code at the entrance or enter the 10 digits visit tag number generated." + str1;
            string str4 = "Visitor Tag To Visit " + visitorBook.Customer.FullName;
            string str5 = emailTemplatesObj.VistTagEmailTemplate(message, visitorBook.VisitorEmail, visitorBook.VisitorLastName);
            _emailService.SendEmailWithAttachment(new EmailRequestWithAttachment()
            {
                Body = str5,
                FileName = filePath,
                RecieverEmail = visitorBook.VisitorEmail,
                RecieverName = visitorBook.VisitorLastName,
                SenderEmai = visitorBook.Customer.Email,
                SenderName = visitorBook.Customer.FullName,
                Subject = str4
            });
        }

        private static byte[] BitmapToBytes(Bitmap img)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                img.Save((Stream)memoryStream, ImageFormat.Png);
                return memoryStream.ToArray();
            }
        }

        private string SaveProfileImage(string base64, string TagNo)
        {

            var imageB64 = base64;
            string fileExt = ".jpg";
            string filename = TagNo + fileExt;
            imageB64 = CleanBase64Image(imageB64);
            byte[] imageBytes = Convert.FromBase64String(imageB64);


            // Initialize directory paths
            char ps = Path.DirectorySeparatorChar; // This gives "\"
            char psWeb = Path.AltDirectorySeparatorChar; // This gives "/"

            // Generates absolute paths to image
            var webRootPath = _hostingEnvironment.WebRootPath;
            string profilePicPath = webRootPath + ps + "Upload";
            if (!Directory.Exists(profilePicPath)) Directory.CreateDirectory(profilePicPath);
            string profilePicPathFull = profilePicPath + ps + filename;

            // Generates url friendly paths to image
            string profilePicPathWeb = webRootPath + psWeb + "Upload";
            string profilePicPathFullWeb = profilePicPathWeb + psWeb + filename;

            // Initialize SixLabors.ImageSharp
            Image<Rgba32> image = SixLabors.ImageSharp.Image.Load<Rgba32>(imageBytes); // pass image bytes

            //Create Image
            int width = 500;
            int height = 500;
            image.Mutate(x => x.Resize(width, height));

            //Save Image to Disk
            // profilePicPathFull: C:\path_to_webroot\uploads\wjefjwkywojksdivvwe.jpg
            image.Save(profilePicPathFull);

            // Return the image url with response 
            // profilePicPathFullWeb: /uploads/wjefjwkywojksdivvwe.jpg
            return filename; // handle response
        }

        private static string UrlDecodeBase64(string encodedBase64Input) => encodedBase64Input.Replace('.', '+').Replace('_', '/').Replace('-', '=');

        private static string CleanBase64Image(string imageB64) => imageB64.Replace("data:image/png;base64,", "").Replace("data:image/jpg;base64,", "").Replace("data:image/jpeg;base64,", "").Replace("data:image/gif;base64,", "").Replace("data:image/bmp;base64,", "").Replace("data:image/webp;base64,", "");

        private static string GenerateFileName(string extension) => Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Replace("=", "").Replace("\\", "").Replace("/", "") + extension;

        public void SendTagAsSMS(string tagNumber, VisitorBook visitorBook)
        {
            TwilioClient.Init("ACc6318887e655c4b381e67ce49a9a58f9", "3c4c12bf39a69f0633ac5329cb34f850");
            string body = "Hello " + visitorBook.VisitorLastName + ", You have be scheduled to visit " + visitorBook.Customer.FullName + " Please check your email @ " + visitorBook.VisitorEmail + " for more details.  You tag number is " + visitorBook.VisitTagNo + " Thank you.";
            Twilio.Types.PhoneNumber from = new Twilio.Types.PhoneNumber("+16787218547");
            Console.WriteLine(MessageResource.Create(new Twilio.Types.PhoneNumber(visitorBook.VisitorPhoneNo), from: from, body: body).Sid);
        }
    }
}
