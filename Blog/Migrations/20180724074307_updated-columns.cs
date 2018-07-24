using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Migrations
{
    public partial class updatedcolumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageFile",
                table: "Images",
                newName: "UserId");

            migrationBuilder.AddColumn<byte[]>(
                name: "Data",
                table: "Images",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Images",
                newName: "ImageFile");
        }
    }
}
