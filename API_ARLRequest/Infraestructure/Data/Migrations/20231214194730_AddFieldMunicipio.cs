using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_ARLRequest.Infraestructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldMunicipio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aprobo",
                table: "ArlRequests");

            migrationBuilder.DropColumn(
                name: "CorreoInstitucional",
                table: "ArlRequests");

            migrationBuilder.DropColumn(
                name: "RiesgoEstudiante",
                table: "ArlRequests");

            migrationBuilder.RenameColumn(
                name: "Seleccion",
                table: "ArlRequests",
                newName: "Municipio");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Municipio",
                table: "ArlRequests",
                newName: "Seleccion");

            migrationBuilder.AddColumn<string>(
                name: "Aprobo",
                table: "ArlRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CorreoInstitucional",
                table: "ArlRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RiesgoEstudiante",
                table: "ArlRequests",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
