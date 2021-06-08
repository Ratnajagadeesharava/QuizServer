using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizCreatorServer.Migrations
{
    public partial class secondmigraion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Option4",
                table: "Questions",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Option4",
                table: "Questions");
        }
    }
}
