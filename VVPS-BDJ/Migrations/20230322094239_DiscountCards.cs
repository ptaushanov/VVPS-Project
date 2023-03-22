using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VVPS_BDJ.Migrations
{
    /// <inheritdoc />
    public partial class DiscountCards : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_DiscountCardId",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DiscountCardId",
                table: "Users",
                column: "DiscountCardId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_DiscountCardId",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DiscountCardId",
                table: "Users",
                column: "DiscountCardId");
        }
    }
}
