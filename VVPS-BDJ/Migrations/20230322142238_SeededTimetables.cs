using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VVPS_BDJ.Migrations
{
    /// <inheritdoc />
    public partial class SeededTimetables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeparuteTime",
                table: "TimetableRecords",
                newName: "DepartureTime");

            migrationBuilder.InsertData(
                table: "TimetableRecords",
                columns: new[] { "TimetableRecordId", "ArrivalLocation", "ArrivalTime", "DepartureLocation", "DepartureTime" },
                values: new object[,]
                {
                    { 1, "Plovdiv", new TimeOnly(10, 0, 0), "Sofia", new TimeOnly(8, 0, 0) },
                    { 2, "Varna", new TimeOnly(12, 0, 0), "Sofia", new TimeOnly(10, 0, 0) },
                    { 3, "Burgas", new TimeOnly(14, 0, 0), "Sofia", new TimeOnly(12, 0, 0) },
                    { 4, "Plovdiv", new TimeOnly(16, 0, 0), "Sofia", new TimeOnly(14, 0, 0) },
                    { 5, "Sofia", new TimeOnly(18, 0, 0), "Varna", new TimeOnly(16, 0, 0) },
                    { 6, "Burgas", new TimeOnly(20, 0, 0), "Varna", new TimeOnly(18, 0, 0) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TimetableRecords",
                keyColumn: "TimetableRecordId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TimetableRecords",
                keyColumn: "TimetableRecordId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TimetableRecords",
                keyColumn: "TimetableRecordId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TimetableRecords",
                keyColumn: "TimetableRecordId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TimetableRecords",
                keyColumn: "TimetableRecordId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TimetableRecords",
                keyColumn: "TimetableRecordId",
                keyValue: 6);

            migrationBuilder.RenameColumn(
                name: "DepartureTime",
                table: "TimetableRecords",
                newName: "DeparuteTime");
        }
    }
}
