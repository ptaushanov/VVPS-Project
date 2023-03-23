using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VVPS_BDJ.Migrations
{
    /// <inheritdoc />
    public partial class AddTravelPriceTimetableRecord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TravelPrice",
                table: "TimetableRecords",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "TimetableRecords",
                keyColumn: "TimetableRecordId",
                keyValue: 1,
                column: "TravelPrice",
                value: 10.0);

            migrationBuilder.UpdateData(
                table: "TimetableRecords",
                keyColumn: "TimetableRecordId",
                keyValue: 2,
                column: "TravelPrice",
                value: 15.35);

            migrationBuilder.UpdateData(
                table: "TimetableRecords",
                keyColumn: "TimetableRecordId",
                keyValue: 3,
                column: "TravelPrice",
                value: 11.800000000000001);

            migrationBuilder.UpdateData(
                table: "TimetableRecords",
                keyColumn: "TimetableRecordId",
                keyValue: 4,
                column: "TravelPrice",
                value: 9.9000000000000004);

            migrationBuilder.UpdateData(
                table: "TimetableRecords",
                keyColumn: "TimetableRecordId",
                keyValue: 5,
                column: "TravelPrice",
                value: 15.35);

            migrationBuilder.UpdateData(
                table: "TimetableRecords",
                keyColumn: "TimetableRecordId",
                keyValue: 6,
                column: "TravelPrice",
                value: 14.5);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TravelPrice",
                table: "TimetableRecords");
        }
    }
}
