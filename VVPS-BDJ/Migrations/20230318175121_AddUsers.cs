using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VVPS_BDJ.Migrations
{
    /// <inheritdoc />
    public partial class AddUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TimetableRecord",
                table: "TimetableRecord");

            migrationBuilder.RenameTable(
                name: "TimetableRecord",
                newName: "TimetableRecords");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimetableRecords",
                table: "TimetableRecords",
                column: "TimetableRecordId");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsAdmin = table.Column<bool>(type: "INTEGER", nullable: false),
                    DiscountCardId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_DiscountCards_DiscountCardId",
                        column: x => x.DiscountCardId,
                        principalTable: "DiscountCards",
                        principalColumn: "DiscountCardId");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "DateOfBirth", "DiscountCardId", "FirstName", "IsAdmin", "LastName", "UserName" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Admin", true, "Admin", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_DiscountCardId",
                table: "Users",
                column: "DiscountCardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimetableRecords",
                table: "TimetableRecords");

            migrationBuilder.RenameTable(
                name: "TimetableRecords",
                newName: "TimetableRecord");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimetableRecord",
                table: "TimetableRecord",
                column: "TimetableRecordId");
        }
    }
}
