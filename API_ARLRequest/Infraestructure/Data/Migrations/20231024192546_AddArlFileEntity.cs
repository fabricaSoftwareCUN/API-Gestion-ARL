using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_ARLRequest.Infraestructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddArlFileEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArlFiles",
                columns: table => new
                {
                    IdDocumentoARL = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreArchivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenciaArchivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdSolicitudArl = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArlFiles", x => x.IdDocumentoARL);
                    table.ForeignKey(
                        name: "FK_ArlFiles_ArlRequests_IdSolicitudArl",
                        column: x => x.IdSolicitudArl,
                        principalTable: "ArlRequests",
                        principalColumn: "IdSolicitudArl",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArlFiles_IdSolicitudArl",
                table: "ArlFiles",
                column: "IdSolicitudArl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArlFiles");
        }
    }
}
