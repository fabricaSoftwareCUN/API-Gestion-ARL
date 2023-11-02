using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_ARLRequest.Infraestructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRegionalEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Regionales",
                columns: table => new
                {
                    IdRegional = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Municipio = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regionales", x => x.IdRegional);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Regionales");
        }
    }
}
