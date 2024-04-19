using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Farmacia.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMedicamentoSToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_medicamentos",
                table: "medicamentos");

            migrationBuilder.RenameTable(
                name: "medicamentos",
                newName: "Medicamentos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Medicamentos",
                table: "Medicamentos",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Medicamentos",
                table: "Medicamentos");

            migrationBuilder.RenameTable(
                name: "Medicamentos",
                newName: "medicamentos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_medicamentos",
                table: "medicamentos",
                column: "Id");
        }
    }
}
