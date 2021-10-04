using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VBooX.Infrastructure.Persistence.Migrations
{
    public partial class SeededDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SubscriptionPlan",
                columns: new[] { "SubscriptionPlanId", "CreatedBy", "CreatedOn", "DurationInDaysForFreePlan", "IsFree", "LastModifiedBy", "LastModifiedOn", "MonthlyFee", "Type" },
                values: new object[] { 1, "Default", new DateTime(2021, 10, 2, 19, 12, 16, 503, DateTimeKind.Local).AddTicks(8383), 180, true, null, null, 0.0, "FREE Plan" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SubscriptionPlan",
                keyColumn: "SubscriptionPlanId",
                keyValue: 1);
        }
    }
}
