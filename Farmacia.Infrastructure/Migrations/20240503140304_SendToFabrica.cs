using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Farmacia.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SendToFabrica : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fabricas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Medicamentos_Id = table.Column<int>(type: "int", nullable: false),
                    Local = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fabricas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fabricas_Medicamentos_Medicamentos_Id",
                        column: x => x.Medicamentos_Id,
                        principalTable: "Medicamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Fabricas",
                columns: new[] { "Id", "Local", "Medicamentos_Id", "Name" },
                values: new object[,]
                {
                    { 1, "Estrada Alfragide 67 Alfrapark, Edifício D, 2610-008 Amadora, Portugal", 1, "AbbVie Portugal" },
                    { 2, "Lagoas Park, Edifício 10, Piso 0, 2740-244 Porto Salvo, Portugal", 2, "Pfizer Portugal" },
                    { 3, "Rua da Quinta do Pinheiro, 5, 2790-143 Carnaxide, Portugal", 3, "Bayer Portugal" },
                    { 4, "Quinta da Fonte, Edifício D. Amélia, 2770-192 Paço de Arcos, Portugal", 4, "Novartis Portugal" },
                    { 5, "Lagoas Park, Edifício 14, Piso 0, 2740-262 Porto Salvo, Portugal", 1, "Merck Sharp & Dohme Portugal" },
                    { 6, "Rua 25 de Abril 25, 2740-262 Porto Salvo, Portugal", 2, "Johnson & Johnson Portugal" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fabricas_Medicamentos_Id",
                table: "Fabricas",
                column: "Medicamentos_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fabricas");
        }
    }
}
