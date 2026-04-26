using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelSystem.Services.Migrations
{
    /// <inheritdoc />
    public partial class RenameStudentIdToPersonalId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Locations",
                newName: "PersonalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PersonalId",
                table: "Locations",
                newName: "StudentId");
        }
    }
}
