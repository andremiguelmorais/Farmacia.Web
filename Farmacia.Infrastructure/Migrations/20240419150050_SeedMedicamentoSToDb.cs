using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Farmacia.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedMedicamentoSToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Medicamentos",
                columns: new[] { "Id", "Amount", "CreateDate", "Description", "ImageUrl", "Name", "Price", "UpdateDate" },
                values: new object[,]
                {
                    { 1, 20.0, null, "txt", "https://placehold.co/600x400", "Benuron", 28.0, null },
                    { 2, 30.0, null, "Analgésico e antipirético", "https://placehold.co/600x400", "Paracetamol", 15.0, null },
                    { 3, 25.0, null, "Antibiótico de amplo espectro", "https://placehold.co/600x400", "Amoxicilina", 10.0, null },
                    { 4, 40.0, null, "Anti-inflamatório não esteroide", "https://placehold.co/600x400", "Ibuprofeno", 20.0, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Medicamentos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Medicamentos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Medicamentos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Medicamentos",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
