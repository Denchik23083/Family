using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Family.Db.Migrations
{
    public partial class addTests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Genus",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "TestGenus" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "BirthDay",
                value: new DateTime(1993, 12, 18, 14, 51, 45, 585, DateTimeKind.Local).AddTicks(5759));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDay", "Email", "FirstName", "GenderId", "Password", "RoleId" },
                values: new object[,]
                {
                    { 7, new DateTime(1990, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "testParent@gmail.com", "TestParent", 1, "0000", 3 },
                    { 8, new DateTime(2015, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "testChild@gmail.com", "TestChild", 2, "0000", 4 }
                });

            migrationBuilder.InsertData(
                table: "Children",
                columns: new[] { "Id", "GenusId", "UserId" },
                values: new object[] { 3, 2, 8 });

            migrationBuilder.InsertData(
                table: "Parents",
                columns: new[] { "Id", "GenusId", "UserId" },
                values: new object[] { 3, 2, 7 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Children",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Parents",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genus",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "BirthDay",
                value: new DateTime(1993, 12, 1, 17, 41, 59, 556, DateTimeKind.Local).AddTicks(4954));
        }
    }
}
