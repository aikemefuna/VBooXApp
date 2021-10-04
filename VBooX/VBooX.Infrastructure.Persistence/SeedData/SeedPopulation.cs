using Microsoft.EntityFrameworkCore;
using VBooX.Domain.Entities;

namespace VBooX.Infrastructure.Persistence.SeedData
{
    public static class SeedPopulation
    {
        public static void SeedFreeSubscriptionPlanData(this ModelBuilder builder)
        {
            builder.Entity<SubscriptionPlan>().HasData(
                new SubscriptionPlan[]
                {
                    new SubscriptionPlan { SubscriptionPlanId = 1, CreatedOn = System.DateTime.Now, CreatedBy = "Default", DurationInDaysForFreePlan = 180, IsFree = true, MonthlyFee = 0,  Type = "FREE Plan" }

                }
                );

        }
    }
}
