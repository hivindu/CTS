using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CovidTracing.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CDC",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    NIC = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CDC", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Citizen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    NIC = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Proffession = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Affiliation = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    HealthStatus = table.Column<int>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Longtitude = table.Column<double>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citizen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PCR",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CID = table.Column<int>(nullable: false),
                    dateTime = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PCR", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PHI",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    NIC = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Affiliation = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHI", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shop",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShopName = table.Column<string>(nullable: true),
                    Contact = table.Column<int>(nullable: false),
                    Latitude = table.Column<string>(nullable: true),
                    Longtitude = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    BrNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shop", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TravelLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CID = table.Column<int>(nullable: false),
                    SID = table.Column<int>(nullable: false),
                    Lat = table.Column<double>(nullable: false),
                    Long = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelLog", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CDC");

            migrationBuilder.DropTable(
                name: "Citizen");

            migrationBuilder.DropTable(
                name: "PCR");

            migrationBuilder.DropTable(
                name: "PHI");

            migrationBuilder.DropTable(
                name: "Shop");

            migrationBuilder.DropTable(
                name: "TravelLog");
        }
    }
}
