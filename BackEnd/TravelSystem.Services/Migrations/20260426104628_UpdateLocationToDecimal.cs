using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelSystem.Services.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLocationToDecimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Coordinates_Latitude_Degrees",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Coordinates_Latitude_Minutes",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Coordinates_Latitude_Seconds",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Coordinates_Longitude_Degrees",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Coordinates_Longitude_Minutes",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Coordinates_Longitude_Seconds",
                table: "Locations");

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Locations",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Locations",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Locations");

            migrationBuilder.AddColumn<string>(
                name: "Coordinates_Latitude_Degrees",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Coordinates_Latitude_Minutes",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Coordinates_Latitude_Seconds",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Coordinates_Longitude_Degrees",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Coordinates_Longitude_Minutes",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Coordinates_Longitude_Seconds",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
