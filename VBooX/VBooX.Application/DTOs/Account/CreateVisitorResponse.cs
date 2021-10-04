using System;

namespace VBooX.Application.DTOs.Account
{
    public class CreateVisitorResponse
    {
        public string VisitorFirstName { get; set; }

        public string VisitorLastName { get; set; }

        public string VisitorPhoneNo { get; set; }

        public string VisitorEmail { get; set; }

        public string VisitorAddress { get; set; }

        public DateTime ProposedVisitDate { get; set; }

        public string PurposeOfVisit { get; set; }

        public string VisitTagNo { get; set; }

        public string AccountNumber { get; set; }
    }
}
