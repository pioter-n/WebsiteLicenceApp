using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebsiteLicenceApp.Migrations
{
    public partial class orders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLicence_AspNetUsers_ApplicationUserId",
                table: "UserLicence");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_UserLicence_ApplicationUserId",
                table: "UserLicence");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "UserLicence");

            migrationBuilder.AddColumn<int>(
                name: "TypeLicienceId",
                table: "UserLicence",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UserLicence",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "TypeLicences",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<int>(nullable: false),
                    LicenceId = table.Column<int>(nullable: true),
                    Actual = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_TypeLicences_LicenceId",
                        column: x => x.LicenceId,
                        principalTable: "TypeLicences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserLicence_TypeLicienceId",
                table: "UserLicence",
                column: "TypeLicienceId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLicence_UserId",
                table: "UserLicence",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_LicenceId",
                table: "Order",
                column: "LicenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLicence_TypeLicences_TypeLicienceId",
                table: "UserLicence",
                column: "TypeLicienceId",
                principalTable: "TypeLicences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLicence_AspNetUsers_UserId",
                table: "UserLicence",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLicence_TypeLicences_TypeLicienceId",
                table: "UserLicence");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLicence_AspNetUsers_UserId",
                table: "UserLicence");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropIndex(
                name: "IX_UserLicence_TypeLicienceId",
                table: "UserLicence");

            migrationBuilder.DropIndex(
                name: "IX_UserLicence_UserId",
                table: "UserLicence");

            migrationBuilder.DropColumn(
                name: "TypeLicienceId",
                table: "UserLicence");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserLicence");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "TypeLicences");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "UserLicence",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HasBeenShipped = table.Column<bool>(type: "bit", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentTransactionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UsernameId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UsernameId",
                        column: x => x.UsernameId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: true),
                    UsernameId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_AspNetUsers_UsernameId",
                        column: x => x.UsernameId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserLicence_ApplicationUserId",
                table: "UserLicence",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_UsernameId",
                table: "OrderDetails",
                column: "UsernameId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UsernameId",
                table: "Orders",
                column: "UsernameId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLicence_AspNetUsers_ApplicationUserId",
                table: "UserLicence",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
