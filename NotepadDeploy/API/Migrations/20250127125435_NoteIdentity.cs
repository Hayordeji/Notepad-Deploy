using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class NoteIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d647d2a-f7f3-43c6-8bd5-b0e4485c0e3c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d45de2f1-b03a-44e5-bfa3-df02f17ff89f");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Notes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7231e1e8-2c3e-4d15-87dd-49134e2c7372", null, "User", "USER" },
                    { "c75032ad-3d18-41aa-a4a3-43a47accaaf0", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7231e1e8-2c3e-4d15-87dd-49134e2c7372");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c75032ad-3d18-41aa-a4a3-43a47accaaf0");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Notes");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3d647d2a-f7f3-43c6-8bd5-b0e4485c0e3c", null, "Admin", "ADMIN" },
                    { "d45de2f1-b03a-44e5-bfa3-df02f17ff89f", null, "User", "USER" }
                });
        }
    }
}
