using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_ARLRequest.Infraestructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class FieldIsModified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TelefonoPersonasACargo",
                table: "ArlRequests",
                newName: "TelefonoPersonasAcargoPractica");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TelefonoPersonasAcargoPractica",
                table: "ArlRequests",
                newName: "TelefonoPersonasACargo");
        }
    }
}
