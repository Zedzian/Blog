using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Migrations
{
    public partial class updatedcolumns1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Images",
                newName: "PostId");

			migrationBuilder.DropForeignKey(
				name: "FK_Comments_Posts_PostId",
				table: "Comments");

			migrationBuilder.DropPrimaryKey(
				name: "PK_Posts",
				table: "Posts");

			migrationBuilder.DropColumn(
				name: "PostId",
				table: "Posts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
