using Microsoft.EntityFrameworkCore.Migrations;

namespace WebsiteLicenceApp.Migrations
{
    public partial class ordersnew2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdTypeLicence",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "TypeLicenceId",
                table: "Order",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_TypeLicenceId",
                table: "Order",
                column: "TypeLicenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_TypeLicences_TypeLicenceId",
                table: "Order",
                column: "TypeLicenceId",
                principalTable: "TypeLicences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_TypeLicences_TypeLicenceId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_TypeLicenceId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "TypeLicenceId",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "IdTypeLicence",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
