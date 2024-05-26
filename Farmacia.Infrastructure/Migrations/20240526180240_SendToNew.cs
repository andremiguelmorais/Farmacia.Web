using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Farmacia.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SendToNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Fabricas",
                columns: new[] { "Id", "Local", "Medicamentos_Id", "Name" },
                values: new object[] { 7, "Rua 25 de Abril 25, 2740-262 Porto Salvo, Portugal", 2, "Johnson & Johnson Portugal" })
                .Annotation("SqlServer:Identity", "1, 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Fabricas",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
