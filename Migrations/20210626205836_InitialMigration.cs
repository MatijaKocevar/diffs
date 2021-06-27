using Microsoft.EntityFrameworkCore.Migrations;

//created using dotnet entity framework. List of instructions to create our database table
// CREATE TABLE: dotnet ef database update
// DELETE TABLE: dotnet ef database drop

namespace Diffing.Migrations
{
    public partial class InitialMigration : Migration
    {
        //UP creates
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pairs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Left = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Right = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>    //creates primary key out of our ID
                {
                    table.PrimaryKey("PK_Pairs", x => x.Id);
                });
        }

        //DOWN deletes database
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pairs");
        }
    }
}
