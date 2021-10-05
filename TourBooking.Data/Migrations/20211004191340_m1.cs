using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TourBooking.Data.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<short>(type: "smallint", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Currency = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                });

            migrationBuilder.CreateTable(
                name: "PartyLeader",
                columns: table => new
                {
                    PartyLeaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartyLeader", x => x.PartyLeaderId);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FamilyName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "BookingPartyLeaders",
                columns: table => new
                {
                    BookingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PartyLeaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingPartyLeaders", x => new { x.BookingId, x.PartyLeaderId });
                    table.ForeignKey(
                        name: "FK_BookingPartyLeaders_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "BookingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingPartyLeaders_PartyLeader_PartyLeaderId",
                        column: x => x.PartyLeaderId,
                        principalTable: "PartyLeader",
                        principalColumn: "PartyLeaderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PartyLeader",
                columns: new[] { "PartyLeaderId", "Name" },
                values: new object[] { new Guid("d2fc8dea-e40c-4b09-805c-b19c99991f24"), "AliBaba" });

            migrationBuilder.InsertData(
                table: "PartyLeader",
                columns: new[] { "PartyLeaderId", "Name" },
                values: new object[] { new Guid("5b8a57ee-b147-4f8c-b7e6-f8725119deb4"), "EliGasht" });

            migrationBuilder.CreateIndex(
                name: "IX_BookingPartyLeaders_PartyLeaderId",
                table: "BookingPartyLeaders",
                column: "PartyLeaderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingPartyLeaders");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "PartyLeader");
        }
    }
}
