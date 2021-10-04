using System.ComponentModel.DataAnnotations;
using VBooX.Domain.Common;

namespace VBooX.Domain.Entities
{
    public class SubscriptionPlan : AuditableBaseEntity
    {
        public int SubscriptionPlanId { get; set; }
        [StringLength(150)]
        public string Type { get; set; }
        public double MonthlyFee { get; set; }
        public bool IsFree { get; set; }
        public int DurationInDaysForFreePlan { get; set; }
    }
}
