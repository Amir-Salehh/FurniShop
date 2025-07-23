using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddProductDiscountRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_DiscountCodes_DiscountCodeId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_DiscountCodeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DiscountCodeId",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Products",
                table: "DiscountCodes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.CreateTable(
                name: "Product_DiscountCode",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CodeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_DiscountCode", x => new { x.ProductId, x.CodeId });
                    table.ForeignKey(
                        name: "FK_Product_DiscountCode_DiscountCodes_CodeId",
                        column: x => x.CodeId,
                        principalTable: "DiscountCodes",
                        principalColumn: "DiscountCodeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_DiscountCode_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_DiscountCode_CodeId",
                table: "Product_DiscountCode",
                column: "CodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product_DiscountCode");

            migrationBuilder.DropColumn(
                name: "Products",
                table: "DiscountCodes");

            migrationBuilder.AddColumn<int>(
                name: "DiscountCodeId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_DiscountCodeId",
                table: "Products",
                column: "DiscountCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_DiscountCodes_DiscountCodeId",
                table: "Products",
                column: "DiscountCodeId",
                principalTable: "DiscountCodes",
                principalColumn: "DiscountCodeId");
        }
    }
}
