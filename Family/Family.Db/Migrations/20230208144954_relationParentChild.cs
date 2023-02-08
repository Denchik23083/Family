using Microsoft.EntityFrameworkCore.Migrations;

namespace Family.Db.Migrations
{
    public partial class relationParentChild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParentsChildren",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    ChildId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentsChildren", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParentsChildren_Children_ChildId",
                        column: x => x.ChildId,
                        principalTable: "Children",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParentsChildren_Parents_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Parents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ParentsChildren",
                columns: new[] { "Id", "ChildId", "ParentId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 2, 1 },
                    { 4, 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParentsChildren_ChildId",
                table: "ParentsChildren",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_ParentsChildren_ParentId",
                table: "ParentsChildren",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParentsChildren");
        }
    }
}
