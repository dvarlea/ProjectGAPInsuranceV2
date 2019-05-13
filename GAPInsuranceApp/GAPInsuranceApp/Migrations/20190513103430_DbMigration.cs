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
                    Id = table.Column<int>(nullable: false),
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
                values: new object[,]
                {
                    { 1, new DateTime(2019, 5, 13, 4, 34, 30, 642, DateTimeKind.Local).AddTicks(2453), 123456789, 0.59999999999999998, "Accidente, Vandalismo", "Seguro de Auto de GAPClient", "Seguro de Auto", 3000.0, 3, 6 },
                    { 2, new DateTime(2019, 5, 13, 4, 34, 30, 643, DateTimeKind.Local).AddTicks(2499), 123456789, 0.5, "Incendio, Robo", "Seguro de Vivienda de GAPClient", "Seguro de Vivienda", 7000.0, 1, 12 },
                    { 3, new DateTime(2019, 5, 13, 4, 34, 30, 643, DateTimeKind.Local).AddTicks(2518), 123456789, 0.80000000000000004, "Muerte, accidentes", "Seguro de vida de GAPClient", "Seguro de Vida", 2000.0, 4, 24 },
                    { 4, new DateTime(2019, 5, 13, 4, 34, 30, 643, DateTimeKind.Local).AddTicks(2522), 123456789, 0.40000000000000002, "Desempleo", "Seguro de Desempleo de GAPClient", "Seguro de Desempleo", 50.0, 2, 3 },
                    { 5, new DateTime(2019, 5, 13, 4, 34, 30, 643, DateTimeKind.Local).AddTicks(2522), 123456787, 0.90000000000000002, "Incendio, Danos", "Seguro de Vivienda de GAPClient2", "Seguro de Vivienda", 200.0, 4, 2 },
                    { 6, new DateTime(2019, 5, 13, 4, 34, 30, 643, DateTimeKind.Local).AddTicks(2522), 123456787, 0.69999999999999996, "Accidente", "Seguro de Viaje de GAPClient2", "Seguro de Viaje", 40.0, 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "LastName", "Name", "PasswordHash", "PasswordSalt", "Role", "Username" },
                values: new object[,]
                {
                    { 123456789, "GAP", "GAP", null, null, 1, "GAPClient" },
                    { 123456788, "GAPAdmin", "GAPAdmin", null, null, 0, "GAPAdmin" },
                    { 123456787, "GAPClient2", "GAPClient2", null, null, 1, "GAPClient2" }
                });
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
