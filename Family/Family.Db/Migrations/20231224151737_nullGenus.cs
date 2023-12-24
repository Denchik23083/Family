using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Family.Db.Migrations
{
    public partial class nullGenus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Children_Genus_GenusId",
                table: "Children");

            migrationBuilder.DropForeignKey(
                name: "FK_Parents_Genus_GenusId",
                table: "Parents");

            migrationBuilder.AlterColumn<int>(
                name: "GenusId",
                table: "Parents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GenusId",
                table: "Children",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "BirthDay",
                value: new DateTime(1993, 12, 24, 17, 17, 37, 155, DateTimeKind.Local).AddTicks(2450));

            migrationBuilder.AddForeignKey(
                name: "FK_Children_Genus_GenusId",
                table: "Children",
                column: "GenusId",
                principalTable: "Genus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parents_Genus_GenusId",
                table: "Parents",
                column: "GenusId",
                principalTable: "Genus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Children_Genus_GenusId",
                table: "Children");

            migrationBuilder.DropForeignKey(
                name: "FK_Parents_Genus_GenusId",
                table: "Parents");

            migrationBuilder.AlterColumn<int>(
                name: "GenusId",
                table: "Parents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "GenusId",
                table: "Children",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "BirthDay",
                value: new DateTime(1993, 12, 18, 14, 51, 45, 585, DateTimeKind.Local).AddTicks(5759));

            migrationBuilder.AddForeignKey(
                name: "FK_Children_Genus_GenusId",
                table: "Children",
                column: "GenusId",
                principalTable: "Genus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Parents_Genus_GenusId",
                table: "Parents",
                column: "GenusId",
                principalTable: "Genus",
                principalColumn: "Id");
        }
    }
}
