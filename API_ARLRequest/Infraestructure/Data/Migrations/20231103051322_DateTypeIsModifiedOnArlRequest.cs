using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_ARLRequest.Infraestructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DateTypeIsModifiedOnArlRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "DocumentoEpsFile",
                table: "ArlRequests");

            migrationBuilder.DropColumn(
                name: "DocumentoIdentidadFile",
                table: "ArlRequests");

            migrationBuilder.DropColumn(
                name: "RutFile",
                table: "ArlRequests");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaSolicitud",
                table: "ArlRequests",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FechaSolicitud",
                table: "ArlRequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ActaInicioPractica",
                table: "ArlRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Aprobo",
                table: "ArlRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CamaraComercioFile",
                table: "ArlRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DocumentoEpsFile",
                table: "ArlRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DocumentoIdentidadFile",
                table: "ArlRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RutFile",
                table: "ArlRequests",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
