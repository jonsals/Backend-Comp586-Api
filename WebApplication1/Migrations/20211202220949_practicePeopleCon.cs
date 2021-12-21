using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class practicePeopleCon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlbumImages_AlbumInfos_AlbumId",
                table: "AlbumImages");

            migrationBuilder.RenameColumn(
                name: "AlbumId",
                table: "AlbumImages",
                newName: "AlbumImageId");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "PeopleName",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RandomId",
                table: "PeopleName",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumImages_AlbumInfos_AlbumImageId",
                table: "AlbumImages",
                column: "AlbumImageId",
                principalTable: "AlbumInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlbumImages_AlbumInfos_AlbumImageId",
                table: "AlbumImages");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "PeopleName");

            migrationBuilder.DropColumn(
                name: "RandomId",
                table: "PeopleName");

            migrationBuilder.RenameColumn(
                name: "AlbumImageId",
                table: "AlbumImages",
                newName: "AlbumId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumImages_AlbumInfos_AlbumId",
                table: "AlbumImages",
                column: "AlbumId",
                principalTable: "AlbumInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
