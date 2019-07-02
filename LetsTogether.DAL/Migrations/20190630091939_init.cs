using Microsoft.EntityFrameworkCore.Migrations;

namespace LetsTogether.DAL.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "453e6911-cd8d-4172-9b30-e6435d6ae54d", "da8435cc-acd5-4008-bb39-9734d9c48351", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "23310f08-c069-4003-8417-342201d0a733", "abe10343-9dea-46de-80f4-e92d1424743e", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "23310f08-c069-4003-8417-342201d0a733", "abe10343-9dea-46de-80f4-e92d1424743e" });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "453e6911-cd8d-4172-9b30-e6435d6ae54d", "da8435cc-acd5-4008-bb39-9734d9c48351" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "51edbffd-01de-4896-a4f9-ebedb9a1cd14", "b3b73f40-77d3-4880-abd1-bf58255365c3", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2be943fc-f8ac-44cc-89d2-1693c6dde987", "0c778991-25f5-4dea-9313-91b25f671a52", "User", "USER" });
        }
    }
}
