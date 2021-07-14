using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizCreatorServer.Migrations
{
    public partial class UserOptionalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Optional",
                table: "Users",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Optional",
                table: "Users");
        }
    }
}
