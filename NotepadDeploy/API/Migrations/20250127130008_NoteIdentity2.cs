using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class NoteIdentity2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7231e1e8-2c3e-4d15-87dd-49134e2c7372");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c75032ad-3d18-41aa-a4a3-43a47accaaf0");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Notes",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7cf3fac9-bfbf-4be4-9675-edc3f6bf88f1", null, "Admin", "ADMIN" },
                    { "e4ae009f-fe12-4397-9642-c6c5729e2065", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7cf3fac9-bfbf-4be4-9675-edc3f6bf88f1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4ae009f-fe12-4397-9642-c6c5729e2065");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Notes",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7231e1e8-2c3e-4d15-87dd-49134e2c7372", null, "User", "USER" },
                    { "c75032ad-3d18-41aa-a4a3-43a47accaaf0", null, "Admin", "ADMIN" }
                });
        }
    }
}
