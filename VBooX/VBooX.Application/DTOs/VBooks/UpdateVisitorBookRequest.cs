using System;

namespace VBooX.Application.DTOs.VBooks
{
    public class UpdateVisitorBookRequest
    {
        public int Id { get; set; }

        public string VisitorFirstName { get; set; }

        public string VisitorLastName { get; set; }

        public string VisitorPhoneNo { get; set; }

        public string VisitorEmail { get; set; }

        public string VisitorAddress { get; set; }

        public DateTime ProposedVisitDate { get; set; }

        public TimeSpan ProposedVisitTime { get; set; }

        public string VisitorPhotograph { get; set; }

        public string PurposeOfVisit { get; set; }

        public string VisitTagNo { get; set; }

        public DateTime VisitorArriveDate { get; set; }

        public TimeSpan VisitorArriveTime { get; set; }

        public DateTime VisitorleavingDate { get; set; }

        public TimeSpan VisitorleavingTime { get; set; }

        public bool IsArrived { get; set; }

        public bool HasLeft { get; set; }

        public bool SentTag { get; set; }

        public bool IsCustomerCreated { get; set; }

        public string CheckedInBy { get; set; }

        public string CheckOutedBy { get; set; }

        public int CustomerId { get; set; }

        public string FullName => VisitorLastName + " " + VisitorFirstName;

        public DateTime ProposedVisitDateAndTime => ProposedVisitDate + ProposedVisitTime;

        public DateTime VisitorArrivalTimeAndDate => VisitorArriveDate + VisitorArriveTime;

        public DateTime VisitorLeavingDateAndTime => VisitorleavingDate + VisitorleavingTime;
    }
}
