using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Migrations
{
    public partial class updatedcolumns3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PostName",
                table: "Posts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostName",
                table: "Posts",
                nullable: true);
        }
    }
}
