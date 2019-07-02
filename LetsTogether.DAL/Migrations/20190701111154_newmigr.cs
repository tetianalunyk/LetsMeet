using Microsoft.EntityFrameworkCore.Migrations;

namespace LetsTogether.DAL.Migrations
{
    public partial class newmigr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "b5381e68-3d5d-4a25-9983-9c2501e274ef", "16bc0ec3-62b8-4bfc-a130-b875e720c74d" });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "bf444199-0742-49c5-843d-7fda1f905926", "6fd66132-9bad-4f51-ad1b-7495fa294642" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fbf95942-bb94-4afc-8ea9-34429f45ebb2", "55853c9c-2432-4d2f-9157-52d8a496a15a", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "599600c4-2690-4e96-9bdc-f3191ef5df13", "03b194d1-b3f6-449c-a79c-bfbb990d8542", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "599600c4-2690-4e96-9bdc-f3191ef5df13", "03b194d1-b3f6-449c-a79c-bfbb990d8542" });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "fbf95942-bb94-4afc-8ea9-34429f45ebb2", "55853c9c-2432-4d2f-9157-52d8a496a15a" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bf444199-0742-49c5-843d-7fda1f905926", "6fd66132-9bad-4f51-ad1b-7495fa294642", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b5381e68-3d5d-4a25-9983-9c2501e274ef", "16bc0ec3-62b8-4bfc-a130-b875e720c74d", "User", "USER" });
        }
    }
}
