using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class NoteIdentity3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7cf3fac9-bfbf-4be4-9675-edc3f6bf88f1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4ae009f-fe12-4397-9642-c6c5729e2065");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8906a669-5d43-4f75-9925-928f3de5e9cc", null, "Admin", "ADMIN" },
                    { "e89dd661-6470-4407-bb93-d491d8d1edd8", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8906a669-5d43-4f75-9925-928f3de5e9cc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e89dd661-6470-4407-bb93-d491d8d1edd8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7cf3fac9-bfbf-4be4-9675-edc3f6bf88f1", null, "Admin", "ADMIN" },
                    { "e4ae009f-fe12-4397-9642-c6c5729e2065", null, "User", "USER" }
                });
        }
    }
}
