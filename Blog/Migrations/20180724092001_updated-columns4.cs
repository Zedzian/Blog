using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Migrations
{
    public partial class updatedcolumns4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Images",
                newName: "ImageId");

            migrationBuilder.AlterColumn<string>(
                name: "PostId",
                table: "Images",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_PostId",
                table: "Images",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Posts_PostId",
                table: "Images",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Posts_PostId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_PostId",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "ImageId",
                table: "Images",
                newName: "ID");

            migrationBuilder.AlterColumn<string>(
                name: "PostId",
                table: "Images",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
