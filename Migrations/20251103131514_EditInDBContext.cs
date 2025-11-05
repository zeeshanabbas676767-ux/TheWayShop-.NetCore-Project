using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewCoreProject.Migrations
{
    /// <inheritdoc />
    public partial class EditInDBContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Detail_Orders_Order_Id",
                table: "Order_Detail");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_Category_Id",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_Category_Id",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Order_Detail_Order_Id",
                table: "Order_Detail");

            migrationBuilder.DropColumn(
                name: "Category_Id",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Order_Id",
                table: "Order_Detail");

            migrationBuilder.AlterColumn<decimal>(
                name: "Sale_Price",
                table: "Order_Detail",
                type: "decimal(18,0)",
                precision: 18,
                scale: 0,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Purchase_Price",
                table: "Order_Detail",
                type: "decimal(18,0)",
                precision: 18,
                scale: 0,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Order_Fid",
                table: "Order_Detail",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Category_Fid",
                table: "Product",
                column: "Category_Fid");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Detail_Order_Fid",
                table: "Order_Detail",
                column: "Order_Fid");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Detail_Orders_Order_Fid",
                table: "Order_Detail",
                column: "Order_Fid",
                principalTable: "Orders",
                principalColumn: "Order_Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_Category_Fid",
                table: "Product",
                column: "Category_Fid",
                principalTable: "Category",
                principalColumn: "Category_Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Detail_Orders_Order_Fid",
                table: "Order_Detail");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_Category_Fid",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_Category_Fid",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Order_Detail_Order_Fid",
                table: "Order_Detail");

            migrationBuilder.AddColumn<int>(
                name: "Category_Id",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Sale_Price",
                table: "Order_Detail",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,0)",
                oldPrecision: 18,
                oldScale: 0,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Purchase_Price",
                table: "Order_Detail",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,0)",
                oldPrecision: 18,
                oldScale: 0,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Order_Fid",
                table: "Order_Detail",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Order_Id",
                table: "Order_Detail",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_Category_Id",
                table: "Product",
                column: "Category_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Detail_Order_Id",
                table: "Order_Detail",
                column: "Order_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Detail_Orders_Order_Id",
                table: "Order_Detail",
                column: "Order_Id",
                principalTable: "Orders",
                principalColumn: "Order_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_Category_Id",
                table: "Product",
                column: "Category_Id",
                principalTable: "Category",
                principalColumn: "Category_Id");
        }
    }
}
