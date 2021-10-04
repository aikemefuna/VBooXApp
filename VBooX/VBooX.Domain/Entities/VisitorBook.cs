using System;
using VBooX.Domain.Common;

namespace VBooX.Domain.Entities
{
    public class VisitorBook : AuditableBaseEntity
    {
        public int VisitorBookId { get; set; }
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

        public Customer Customer { get; set; }

        public string FullName => this.VisitorLastName + " " + this.VisitorFirstName;

        public DateTime ProposedVisitDateAndTime => this.ProposedVisitDate + this.ProposedVisitTime;

        public DateTime VisitorArrivalTimeAndDate => this.VisitorArriveDate + this.VisitorArriveTime;

        public DateTime VisitorLeavingDateAndTime => this.VisitorleavingDate + this.VisitorleavingTime;
    }
}
