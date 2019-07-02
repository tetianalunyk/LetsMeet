using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LetsTogether.DAL.Migrations
{
    public partial class Visitors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "23310f08-c069-4003-8417-342201d0a733", "abe10343-9dea-46de-80f4-e92d1424743e" });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "453e6911-cd8d-4172-9b30-e6435d6ae54d", "da8435cc-acd5-4008-bb39-9734d9c48351" });

            migrationBuilder.CreateTable(
                name: "EventVisitors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: true),
                    EventId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventVisitors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventVisitors_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventVisitors_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bf444199-0742-49c5-843d-7fda1f905926", "6fd66132-9bad-4f51-ad1b-7495fa294642", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b5381e68-3d5d-4a25-9983-9c2501e274ef", "16bc0ec3-62b8-4bfc-a130-b875e720c74d", "User", "USER" });

            migrationBuilder.CreateIndex(
                name: "IX_EventVisitors_EventId",
                table: "EventVisitors",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventVisitors_UserId",
                table: "EventVisitors",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventVisitors");

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
                values: new object[] { "453e6911-cd8d-4172-9b30-e6435d6ae54d", "da8435cc-acd5-4008-bb39-9734d9c48351", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "23310f08-c069-4003-8417-342201d0a733", "abe10343-9dea-46de-80f4-e92d1424743e", "User", "USER" });
        }
    }
}
