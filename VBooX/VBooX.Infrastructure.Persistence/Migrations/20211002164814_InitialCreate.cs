using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace VBooX.Infrastructure.Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    Address = table.Column<string>(maxLength: 500, nullable: true),
                    Email = table.Column<string>(maxLength: 200, nullable: true),
                    PhoneNo = table.Column<string>(maxLength: 200, nullable: true),
                    Logo = table.Column<string>(maxLength: 200, nullable: true),
                    BusinessType = table.Column<string>(maxLength: 200, nullable: true),
                    SignatureUrl = table.Column<string>(maxLength: 200, nullable: true),
                    AccountNumber = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "ClientSubscription",
                columns: table => new
                {
                    ClientSubscriptionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedOn = table.Column<DateTime>(nullable: true),
                    SubscriptionPlanId = table.Column<int>(nullable: false),
                    ClientId = table.Column<int>(nullable: false),
                    AmountPaid = table.Column<double>(nullable: false),
                    DateDue = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientSubscription", x => x.ClientSubscriptionId);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionPlan",
                columns: table => new
                {
                    SubscriptionPlanId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedOn = table.Column<DateTime>(nullable: true),
                    Type = table.Column<string>(maxLength: 150, nullable: true),
                    MonthlyFee = table.Column<double>(nullable: false),
                    IsFree = table.Column<bool>(nullable: false),
                    DurationInDaysForFreePlan = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionPlan", x => x.SubscriptionPlanId);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedOn = table.Column<DateTime>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    LGA = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNo = table.Column<string>(nullable: true),
                    Photograph = table.Column<string>(nullable: true),
                    AccountNumber = table.Column<string>(nullable: true),
                    AccessToken = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customer_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VisitorBook",
                columns: table => new
                {
                    VisitorBookId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedOn = table.Column<DateTime>(nullable: true),
                    VisitorFirstName = table.Column<string>(nullable: true),
                    VisitorLastName = table.Column<string>(nullable: true),
                    VisitorPhoneNo = table.Column<string>(nullable: true),
                    VisitorEmail = table.Column<string>(nullable: true),
                    VisitorAddress = table.Column<string>(nullable: true),
                    ProposedVisitDate = table.Column<DateTime>(nullable: false),
                    ProposedVisitTime = table.Column<TimeSpan>(nullable: false),
                    VisitorPhotograph = table.Column<string>(nullable: true),
                    PurposeOfVisit = table.Column<string>(nullable: true),
                    VisitTagNo = table.Column<string>(nullable: true),
                    VisitorArriveDate = table.Column<DateTime>(nullable: false),
                    VisitorArriveTime = table.Column<TimeSpan>(nullable: false),
                    VisitorleavingDate = table.Column<DateTime>(nullable: false),
                    VisitorleavingTime = table.Column<TimeSpan>(nullable: false),
                    IsArrived = table.Column<bool>(nullable: false),
                    HasLeft = table.Column<bool>(nullable: false),
                    SentTag = table.Column<bool>(nullable: false),
                    IsCustomerCreated = table.Column<bool>(nullable: false),
                    CheckedInBy = table.Column<string>(nullable: true),
                    CheckOutedBy = table.Column<string>(nullable: true),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitorBook", x => x.VisitorBookId);
                    table.ForeignKey(
                        name: "FK_VisitorBook_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_ClientId",
                table: "Customer",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitorBook_CustomerId",
                table: "VisitorBook",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientSubscription");

            migrationBuilder.DropTable(
                name: "SubscriptionPlan");

            migrationBuilder.DropTable(
                name: "VisitorBook");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Client");


        }
    }
}
