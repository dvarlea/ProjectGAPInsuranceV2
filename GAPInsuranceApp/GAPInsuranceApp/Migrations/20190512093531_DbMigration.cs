using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GAPInsuranceApp.Migrations
{
    public partial class DbMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Insurances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Coverages = table.Column<string>(nullable: true),
                    CoverageAmt = table.Column<double>(nullable: false),
                    Begining = table.Column<DateTime>(nullable: false),
                    TimePeriod = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Risk = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Role = table.Column<int>(nullable: false),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Insurances",
                columns: new[] { "Id", "Begining", "ClientId", "CoverageAmt", "Coverages", "Description", "Name", "Price", "Risk", "TimePeriod" },
                values: new object[] { 999999, new DateTime(2019, 5, 12, 3, 35, 31, 311, DateTimeKind.Local).AddTicks(7998), 123456789, 0.59999999999999998, "Accidente, Robo", "Seguro de Auto de Juan Rodriguez", "Seguro de Auto", 230000.0, 3, 6 });

            migrationBuilder.InsertData(
                table: "Insurances",
                columns: new[] { "Id", "Begining", "ClientId", "CoverageAmt", "Coverages", "Description", "Name", "Price", "Risk", "TimePeriod" },
                values: new object[] { 999998, new DateTime(2019, 5, 12, 3, 35, 31, 313, DateTimeKind.Local).AddTicks(3153), 123456789, 0.5, "Incendio, Robo", "Seguro de Vivienda de Juan Rodriguez", "Seguro de Vivienda", 500000.0, 1, 12 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "LastName", "Name", "PasswordHash", "PasswordSalt", "Role", "Username" },
                values: new object[] { 123456789, "Rodrigues", "Juan", null, null, 1, "GAPTest" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Insurances");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
