using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_ARLRequest.Infraestructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldsToArlRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ArlRequestID",
                table: "ArlRequests",
                newName: "ArlRequestId");

            migrationBuilder.AddColumn<string>(
                name: "EmailEstudiante",
                table: "ArlRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NombreEstudiante",
                table: "ArlRequests",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TipoIdentificacion",
                table: "ArlRequests",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailEstudiante",
                table: "ArlRequests");

            migrationBuilder.DropColumn(
                name: "NombreEstudiante",
                table: "ArlRequests");

            migrationBuilder.DropColumn(
                name: "TipoIdentificacion",
                table: "ArlRequests");

            migrationBuilder.RenameColumn(
                name: "ArlRequestId",
                table: "ArlRequests",
                newName: "ArlRequestID");
        }
    }
}
