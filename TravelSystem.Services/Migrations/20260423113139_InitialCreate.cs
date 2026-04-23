using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelSystem.Services.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coordinates_Longitude_Degrees = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coordinates_Longitude_Minutes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coordinates_Longitude_Seconds = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coordinates_Latitude_Degrees = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coordinates_Latitude_Minutes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coordinates_Latitude_Seconds = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    PersonalId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassGroup = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.PersonalId);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    PersonalId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassGroup = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.PersonalId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
