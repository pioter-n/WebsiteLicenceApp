using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebsiteLicenceApp.Migrations
{
    public partial class AddTypeLicences : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Licence",
                table: "UserLicence");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "UserLicence",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Licences",
                table: "UserLicence",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TypeLicences",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Month = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeLicences", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TypeLicences");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "UserLicence");

            migrationBuilder.DropColumn(
                name: "Licences",
                table: "UserLicence");

            migrationBuilder.AddColumn<string>(
                name: "Licence",
                table: "UserLicence",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
