using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VVPS_BDJ.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiscountCards",
                columns: table => new
                {
                    DiscountCardId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    DiscountValue = table.Column<double>(type: "REAL", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountCards", x => x.DiscountCardId);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ReservedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Canceled = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationId);
                });

            migrationBuilder.CreateTable(
                name: "TimetableRecord",
                columns: table => new
                {
                    TimetableRecordId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DepartureLocation = table.Column<string>(type: "TEXT", nullable: false),
                    ArrivalLocation = table.Column<string>(type: "TEXT", nullable: false),
                    DeparuteTime = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    ArrivalTime = table.Column<TimeOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimetableRecord", x => x.TimetableRecordId);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FromCity = table.Column<string>(type: "TEXT", nullable: false),
                    ToCity = table.Column<string>(type: "TEXT", nullable: false),
                    IsTwoWay = table.Column<bool>(type: "INTEGER", nullable: false),
                    ChildUnder16Present = table.Column<bool>(type: "INTEGER", nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UsedDiscountCardDiscountCardId = table.Column<int>(type: "INTEGER", nullable: true),
                    Price = table.Column<double>(type: "REAL", nullable: true),
                    ReservationId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Tickets_DiscountCards_UsedDiscountCardDiscountCardId",
                        column: x => x.UsedDiscountCardDiscountCardId,
                        principalTable: "DiscountCards",
                        principalColumn: "DiscountCardId");
                    table.ForeignKey(
                        name: "FK_Tickets_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "ReservationId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ReservationId",
                table: "Tickets",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UsedDiscountCardDiscountCardId",
                table: "Tickets",
                column: "UsedDiscountCardDiscountCardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "TimetableRecord");

            migrationBuilder.DropTable(
                name: "DiscountCards");

            migrationBuilder.DropTable(
                name: "Reservations");
        }
    }
}
