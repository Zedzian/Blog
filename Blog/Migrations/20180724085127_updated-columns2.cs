using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Migrations
{
    public partial class updatedcolumns2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.AddColumn<byte[]>(
				name: "PostId",
				table: "Posts",
				nullable: false);

			migrationBuilder.AddPrimaryKey(
				name: "PK_Posts",
				table: "Posts",
				column: "PostId");
		}

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
