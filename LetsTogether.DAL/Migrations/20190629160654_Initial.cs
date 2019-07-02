using Microsoft.EntityFrameworkCore.Migrations;

namespace LetsTogether.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "7e916fa4-76d0-4c58-b53f-0fd523616431", "679dd6c4-290d-471d-939e-d12982e64ebe" });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "efd3700c-56fd-4b7b-9d80-616670a4c733", "208174d8-8671-4354-8fe6-af03687adaa5" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "51edbffd-01de-4896-a4f9-ebedb9a1cd14", "b3b73f40-77d3-4880-abd1-bf58255365c3", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2be943fc-f8ac-44cc-89d2-1693c6dde987", "0c778991-25f5-4dea-9313-91b25f671a52", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "2be943fc-f8ac-44cc-89d2-1693c6dde987", "0c778991-25f5-4dea-9313-91b25f671a52" });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "51edbffd-01de-4896-a4f9-ebedb9a1cd14", "b3b73f40-77d3-4880-abd1-bf58255365c3" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7e916fa4-76d0-4c58-b53f-0fd523616431", "679dd6c4-290d-471d-939e-d12982e64ebe", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "efd3700c-56fd-4b7b-9d80-616670a4c733", "208174d8-8671-4354-8fe6-af03687adaa5", "User", "USER" });
        }
    }
}
