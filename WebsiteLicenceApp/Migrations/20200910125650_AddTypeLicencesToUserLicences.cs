using Microsoft.EntityFrameworkCore.Migrations;

namespace WebsiteLicenceApp.Migrations
{
    public partial class AddTypeLicencesToUserLicences : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeLicienceId",
                table: "UserLicence",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserLicence_TypeLicienceId",
                table: "UserLicence",
                column: "TypeLicienceId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLicence_TypeLicences_TypeLicienceId",
                table: "UserLicence",
                column: "TypeLicienceId",
                principalTable: "TypeLicences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLicence_TypeLicences_TypeLicienceId",
                table: "UserLicence");

            migrationBuilder.DropIndex(
                name: "IX_UserLicence_TypeLicienceId",
                table: "UserLicence");

            migrationBuilder.DropColumn(
                name: "TypeLicienceId",
                table: "UserLicence");
        }
    }
}
