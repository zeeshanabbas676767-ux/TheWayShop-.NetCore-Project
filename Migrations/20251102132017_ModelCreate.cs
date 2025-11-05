using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewCoreProject.Migrations
{
    /// <inheritdoc />
    public partial class ModelCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "User");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Admin");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Admin",
                newName: "Admin_Id");

            migrationBuilder.AddColumn<string>(
                name: "Admin_Address",
                table: "Admin",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Admin_Contact",
                table: "Admin",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Admin_Email",
                table: "Admin",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Admin_Name",
                table: "Admin",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Admin_Password",
                table: "Admin",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admin",
                table: "Admin",
                column: "Admin_Id");

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Category_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Category_Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Order_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Order_Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Order_Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Order_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Order_Contact = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Order_Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Order_Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Order_Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Product_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Product_Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Product_PurchasePrice = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    Product_SalePrice = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    Product_Picture = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Category_Fid = table.Column<int>(type: "int", nullable: true),
                    Category_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Product_Id);
                    table.ForeignKey(
                        name: "FK_Product_Category_Category_Id",
                        column: x => x.Category_Id,
                        principalTable: "Category",
                        principalColumn: "Category_Id");
                });

            migrationBuilder.CreateTable(
                name: "Order_Detail",
                columns: table => new
                {
                    OrderDetail_Id = table.Column<int>(type: "int", nullable: false),
                    Order_Fid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_Fid = table.Column<int>(type: "int", nullable: true),
                    Sale_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Purchase_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Order_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Detail", x => x.OrderDetail_Id);
                    table.ForeignKey(
                        name: "FK_Order_Detail_Orders_Order_Id",
                        column: x => x.Order_Id,
                        principalTable: "Orders",
                        principalColumn: "Order_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_Detail_Order_Id",
                table: "Order_Detail",
                column: "Order_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Category_Id",
                table: "Product",
                column: "Category_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order_Detail");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Admin",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "Admin_Address",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "Admin_Contact",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "Admin_Email",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "Admin_Name",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "Admin_Password",
                table: "Admin");

            migrationBuilder.RenameTable(
                name: "Admin",
                newName: "User");

            migrationBuilder.RenameColumn(
                name: "Admin_Id",
                table: "User",
                newName: "UserID");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "User",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "User",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "User",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "User",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "User",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "UserID");
        }
    }
}
