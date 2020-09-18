using Microsoft.EntityFrameworkCore.Migrations;

namespace WebsiteLicenceApp.Migrations
{
    public partial class ordersnew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_TypeLicences_LicenceId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_LicenceId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "LicenceId",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "IdTypeLicence",
                table: "Order",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdTypeLicence",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "LicenceId",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_LicenceId",
                table: "Order",
                column: "LicenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_TypeLicences_LicenceId",
                table: "Order",
                column: "LicenceId",
                principalTable: "TypeLicences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
