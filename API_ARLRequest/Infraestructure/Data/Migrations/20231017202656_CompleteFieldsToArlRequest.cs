using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_ARLRequest.Infraestructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class CompleteFieldsToArlRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ActaInicioPractica",
                table: "ArlRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Aprobo",
                table: "ArlRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CamaraComercioFile",
                table: "ArlRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CapaOcho",
                table: "ArlRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CorreoInstitucional",
                table: "ArlRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DocumentoEpsFile",
                table: "ArlRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DocumentoIdentidadFile",
                table: "ArlRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmailPersonaACargoPractica",
                table: "ArlRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EpsEstudiante",
                table: "ArlRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FechaInicioPractica",
                table: "ArlRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FechaNacimiento",
                table: "ArlRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FechaTerminacionPractica",
                table: "ArlRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "JornadaEstablecida",
                table: "ArlRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ModalidadPractica",
                table: "ArlRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ModoPractica",
                table: "ArlRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MotivoAprobacion",
                table: "ArlRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NitEmprendimiento",
                table: "ArlRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NitEmpresaPracticas",
                table: "ArlRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NombreEmprendimiento",
                table: "ArlRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NombreEmpresaPracticas",
                table: "ArlRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NombrePersonaACargoPractica",
                table: "ArlRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NumeroTelEstudiante",
                table: "ArlRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PeriodoAcademico",
                table: "ArlRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProgramaAcademico",
                table: "ArlRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Regional",
                table: "ArlRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RiesgoEstudiante",
                table: "ArlRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RutFile",
                table: "ArlRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Seleccion",
                table: "ArlRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TelefonoPersonasACargo",
                table: "ArlRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TipoPractica",
                table: "ArlRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActaInicioPractica",
                table: "ArlRequests");

            migrationBuilder.DropColumn(
                name: "Aprobo",
                table: "ArlRequests");

            migrationBuilder.DropColumn(
                name: "CamaraComercioFile",
                table: "ArlRequests");

            migrationBuilder.DropColumn(
                name: "CapaOcho",
                table: "ArlRequests");

            migrationBuilder.DropColumn(
                name: "CorreoInstitucional",
                table: "ArlRequests");

            migrationBuilder.DropColumn(
                name: "DocumentoEpsFile",
                table: "ArlRequests");

            migrationBuilder.DropColumn(
                name: "DocumentoIdentidadFile",
                table: "ArlRequests");

            migrationBuilder.DropColumn(
                name: "EmailPersonaACargoPractica",
                table: "ArlRequests");

            migrationBuilder.DropColumn(
                name: "EpsEstudiante",
                table: "ArlRequests");

            migrationBuilder.DropColumn(
                name: "FechaInicioPractica",
                table: "ArlRequests");

            migrationBuilder.DropColumn(
                name: "FechaNacimiento",
                table: "ArlRequests");

            migrationBuilder.DropColumn(
                name: "FechaTerminacionPractica",
                table: "ArlRequests");

            migrationBuilder.DropColumn(
                name: "JornadaEstablecida",
                table: "ArlRequests");

            migrationBuilder.DropColumn(
                name: "ModalidadPractica",
                table: "ArlRequests");

            migrationBuilder.DropColumn(
                name: "ModoPractica",
                table: "ArlRequests");

            migrationBuilder.DropColumn(
                name: "MotivoAprobacion",
                table: "ArlRequests");

            migrationBuilder.DropColumn(
                name: "NitEmprendimiento",
                table: "ArlRequests");

            migrationBuilder.DropColumn(
                name: "NitEmpresaPracticas",
                table: "ArlRequests");

            migrationBuilder.DropColumn(
                name: "NombreEmprendimiento",
                table: "ArlRequests");

            migrationBuilder.DropColumn(
                name: "NombreEmpresaPracticas",
                table: "ArlRequests");

            migrationBuilder.DropColumn(
                name: "NombrePersonaACargoPractica",
                table: "ArlRequests");

            migrationBuilder.DropColumn(
                name: "NumeroTelEstudiante",
                table: "ArlRequests");

            migrationBuilder.DropColumn(
                name: "PeriodoAcademico",
                table: "ArlRequests");

            migrationBuilder.DropColumn(
                name: "ProgramaAcademico",
                table: "ArlRequests");

            migrationBuilder.DropColumn(
                name: "Regional",
                table: "ArlRequests");

            migrationBuilder.DropColumn(
                name: "RiesgoEstudiante",
                table: "ArlRequests");

            migrationBuilder.DropColumn(
                name: "RutFile",
                table: "ArlRequests");

            migrationBuilder.DropColumn(
                name: "Seleccion",
                table: "ArlRequests");

            migrationBuilder.DropColumn(
                name: "TelefonoPersonasACargo",
                table: "ArlRequests");

            migrationBuilder.DropColumn(
                name: "TipoPractica",
                table: "ArlRequests");
        }
    }
}
