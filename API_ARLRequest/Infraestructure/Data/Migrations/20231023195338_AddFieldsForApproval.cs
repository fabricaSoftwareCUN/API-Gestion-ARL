using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_ARLRequest.Infraestructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldsForApproval : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EstadoSolicitud",
                table: "ArlRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FechaSolicitud",
                table: "ArlRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NombreAprobador",
                table: "ArlRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZonaResidencial",
                table: "ArlRequests",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstadoSolicitud",
                table: "ArlRequests");

            migrationBuilder.DropColumn(
                name: "FechaSolicitud",
                table: "ArlRequests");

            migrationBuilder.DropColumn(
                name: "NombreAprobador",
                table: "ArlRequests");

            migrationBuilder.DropColumn(
                name: "ZonaResidencial",
                table: "ArlRequests");
        }
    }
}
