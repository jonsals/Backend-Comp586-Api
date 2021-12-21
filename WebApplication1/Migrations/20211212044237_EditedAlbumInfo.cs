using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class EditedAlbumInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlbumImages_AlbumInfos_AlbumImageId",
                table: "AlbumImages");

            migrationBuilder.DropIndex(
                name: "IX_AlbumImage_AlbumId",
                table: "AlbumImages");

            migrationBuilder.DropColumn(
                name: "Details",
                table: "AlbumInfos");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "AlbumInfos",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalNumberOfSongs",
                table: "AlbumInfos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AlbumId",
                table: "AlbumImages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AlbumImages_AlbumId",
                table: "AlbumImages",
                column: "AlbumId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumImages_AlbumInfos_AlbumId",
                table: "AlbumImages",
                column: "AlbumId",
                principalTable: "AlbumInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlbumImages_AlbumInfos_AlbumId",
                table: "AlbumImages");

            migrationBuilder.DropIndex(
                name: "IX_AlbumImages_AlbumId",
                table: "AlbumImages");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "AlbumInfos");

            migrationBuilder.DropColumn(
                name: "TotalNumberOfSongs",
                table: "AlbumInfos");

            migrationBuilder.DropColumn(
                name: "AlbumId",
                table: "AlbumImages");

            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "AlbumInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AlbumImage_AlbumId",
                table: "AlbumImages",
                column: "AlbumImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumImages_AlbumInfos_AlbumImageId",
                table: "AlbumImages",
                column: "AlbumImageId",
                principalTable: "AlbumInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
