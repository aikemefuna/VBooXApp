using System.Collections.Generic;
using VBooX.Domain.Common;

namespace VBooX.Domain.Entities
{
    public class Customer : AuditableBaseEntity
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string State { get; set; }

        public string LGA { get; set; }

        public string Gender { get; set; }

        public string Email { get; set; }

        public string PhoneNo { get; set; }

        public string Photograph { get; set; }

        public string AccountNumber { get; set; }

        public string AccessToken { get; set; }

        public string UserId { get; set; }

        public int ClientId { get; set; }

        public Client Client { get; set; }

        public string FullName => FirstName + " " + LastName;

        public List<VisitorBook> VisitorBooks { get; set; } = new List<VisitorBook>();
    }
}
