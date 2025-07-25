using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Addlevel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "LevelId", "DiscountSharePercent", "LevelName", "MinSales" },
                values: new object[,]
                {
                    { 1, 10m, "Bronze", 0m },
                    { 2, 15m, "Silver", 50000000m },
                    { 3, 20m, "Gold", 100000000m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: 3);
        }
    }
}
