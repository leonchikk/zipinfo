using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZipInfo.Domain.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ZipInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ZipCode = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    TemperatureInCelsius = table.Column<double>(nullable: false),
                    TimeZoneName = table.Column<string>(nullable: true),
                    TimeZoneId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZipInfos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZipInfos");
        }
    }
}
