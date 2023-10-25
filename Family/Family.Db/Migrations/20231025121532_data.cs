using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Family.Db.Migrations
{
    public partial class data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Genus",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Kudryavovs" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "BirthDay",
                value: new DateTime(1993, 10, 25, 15, 15, 31, 658, DateTimeKind.Local).AddTicks(8090));

            migrationBuilder.InsertData(
                table: "Children",
                columns: new[] { "Id", "GenusId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 5 },
                    { 2, 1, 6 }
                });

            migrationBuilder.InsertData(
                table: "Parents",
                columns: new[] { "Id", "GenusId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 3 },
                    { 2, 1, 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Children",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Children",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Parents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Parents",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genus",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "BirthDay",
                value: new DateTime(1993, 10, 25, 15, 10, 21, 948, DateTimeKind.Local).AddTicks(5145));
        }
    }
}
