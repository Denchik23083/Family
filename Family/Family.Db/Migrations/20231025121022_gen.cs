using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Family.Db.Migrations
{
    public partial class gen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Children_Genders_GenderId",
                table: "Children");

            migrationBuilder.DropForeignKey(
                name: "FK_Parents_Genders_GenderId",
                table: "Parents");

            migrationBuilder.DropTable(
                name: "ParentsChildren");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "FatherId",
                table: "Genus");

            migrationBuilder.DropColumn(
                name: "MotherId",
                table: "Genus");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Children");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Children");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Children");

            migrationBuilder.RenameColumn(
                name: "GenderId",
                table: "Parents",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Parents_GenderId",
                table: "Parents",
                newName: "IX_Parents_UserId");

            migrationBuilder.RenameColumn(
                name: "GenderId",
                table: "Children",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Children_GenderId",
                table: "Children",
                newName: "IX_Children_UserId");

            migrationBuilder.AddColumn<int>(
                name: "GenusId",
                table: "Parents",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "BirthDay",
                value: new DateTime(1993, 10, 25, 15, 10, 21, 948, DateTimeKind.Local).AddTicks(5145));

            migrationBuilder.CreateIndex(
                name: "IX_Parents_GenusId",
                table: "Parents",
                column: "GenusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Children_Users_UserId",
                table: "Children",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parents_Genus_GenusId",
                table: "Parents",
                column: "GenusId",
                principalTable: "Genus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Parents_Users_UserId",
                table: "Parents",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Children_Users_UserId",
                table: "Children");

            migrationBuilder.DropForeignKey(
                name: "FK_Parents_Genus_GenusId",
                table: "Parents");

            migrationBuilder.DropForeignKey(
                name: "FK_Parents_Users_UserId",
                table: "Parents");

            migrationBuilder.DropIndex(
                name: "IX_Parents_GenusId",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "GenusId",
                table: "Parents");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Parents",
                newName: "GenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Parents_UserId",
                table: "Parents",
                newName: "IX_Parents_GenderId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Children",
                newName: "GenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Children_UserId",
                table: "Children",
                newName: "IX_Children_GenderId");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Parents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Parents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Parents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "FatherId",
                table: "Genus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MotherId",
                table: "Genus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Children",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Children",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Children",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ParentsChildren",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChildId = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentsChildren", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "BirthDay",
                value: new DateTime(1993, 10, 24, 9, 5, 32, 350, DateTimeKind.Local).AddTicks(8044));

            migrationBuilder.AddForeignKey(
                name: "FK_Children_Genders_GenderId",
                table: "Children",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parents_Genders_GenderId",
                table: "Parents",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
