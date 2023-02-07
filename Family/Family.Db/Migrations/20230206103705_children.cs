using Microsoft.EntityFrameworkCore.Migrations;

namespace Family.Db.Migrations
{
    public partial class children : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Children",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Children", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Children",
                columns: new[] { "Id", "Age", "FirstName", "LastName" },
                values: new object[] { 1, 19, "Denis", "Kudryavov" });

            migrationBuilder.InsertData(
                table: "Children",
                columns: new[] { "Id", "Age", "FirstName", "LastName" },
                values: new object[] { 2, 3, "Daria", "Kudryavova" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Children");
        }
    }
}
