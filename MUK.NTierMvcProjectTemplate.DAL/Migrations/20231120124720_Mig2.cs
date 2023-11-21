using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MUK.NTierMvcProjectTemplate.DAL.Migrations
{
    public partial class Mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Konular",
                columns: new[] { "Id", "Ad" },
                values: new object[] { 1, "Bilim" });

            migrationBuilder.InsertData(
                table: "Konular",
                columns: new[] { "Id", "Ad" },
                values: new object[] { 2, "Spor" });

            migrationBuilder.InsertData(
                table: "Konular",
                columns: new[] { "Id", "Ad" },
                values: new object[] { 3, "Siyaset" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Konular",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Konular",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Konular",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
