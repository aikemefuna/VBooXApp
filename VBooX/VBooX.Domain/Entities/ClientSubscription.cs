using System;
using VBooX.Domain.Common;

namespace VBooX.Domain.Entities
{
    public class ClientSubscription : AuditableBaseEntity
    {
        public int ClientSubscriptionId { get; set; }
        public int SubscriptionPlanId { get; set; }
        public int ClientId { get; set; }
        public double AmountPaid { get; set; }
        public DateTime DateDue { get; set; }
    }
}
