using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAttribute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductAttributeDetails");

            migrationBuilder.DropTable(
                name: "ProductDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductAttributes",
                table: "ProductAttributes");

            migrationBuilder.DropColumn(
                name: "Attribute_Name",
                table: "ProductAttributes");

            migrationBuilder.RenameColumn(
                name: "Attribute_Id",
                table: "ProductAttributes",
                newName: "AttributeId");

            migrationBuilder.AlterColumn<int>(
                name: "AttributeId",
                table: "ProductAttributes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ProductAttributes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "ProductAttributes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductAttributes",
                table: "ProductAttributes",
                columns: new[] { "ProductId", "AttributeId" });

            migrationBuilder.CreateTable(
                name: "Attribute",
                columns: table => new
                {
                    AttributeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attribute", x => x.AttributeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributes_AttributeId",
                table: "ProductAttributes",
                column: "AttributeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributes_Attribute_AttributeId",
                table: "ProductAttributes",
                column: "AttributeId",
                principalTable: "Attribute",
                principalColumn: "AttributeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributes_Products_ProductId",
                table: "ProductAttributes",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributes_Attribute_AttributeId",
                table: "ProductAttributes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributes_Products_ProductId",
                table: "ProductAttributes");

            migrationBuilder.DropTable(
                name: "Attribute");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductAttributes",
                table: "ProductAttributes");

            migrationBuilder.DropIndex(
                name: "IX_ProductAttributes_AttributeId",
                table: "ProductAttributes");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductAttributes");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "ProductAttributes");

            migrationBuilder.RenameColumn(
                name: "AttributeId",
                table: "ProductAttributes",
                newName: "Attribute_Id");

            migrationBuilder.AlterColumn<int>(
                name: "Attribute_Id",
                table: "ProductAttributes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Attribute_Name",
                table: "ProductAttributes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductAttributes",
                table: "ProductAttributes",
                column: "Attribute_Id");

            migrationBuilder.CreateTable(
                name: "ProductDetails",
                columns: table => new
                {
                    Product_Detail_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetails", x => x.Product_Detail_Id);
                    table.ForeignKey(
                        name: "FK_ProductDetails_Products_Product_Id",
                        column: x => x.Product_Id,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductAttributeDetails",
                columns: table => new
                {
                    Product_Attribute_Detail_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductDetailProduct_Detail_Id = table.Column<int>(type: "int", nullable: true),
                    Product_Attribute = table.Column<int>(type: "int", nullable: false),
                    Product_Detail_Id = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttributeDetails", x => x.Product_Attribute_Detail_Id);
                    table.ForeignKey(
                        name: "FK_ProductAttributeDetails_ProductDetails_ProductDetailProduct_Detail_Id",
                        column: x => x.ProductDetailProduct_Detail_Id,
                        principalTable: "ProductDetails",
                        principalColumn: "Product_Detail_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributeDetails_ProductDetailProduct_Detail_Id",
                table: "ProductAttributeDetails",
                column: "ProductDetailProduct_Detail_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_Product_Id",
                table: "ProductDetails",
                column: "Product_Id");
        }
    }
}
