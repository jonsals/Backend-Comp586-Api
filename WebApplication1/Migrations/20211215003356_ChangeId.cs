using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class ChangeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SomethingPeoples_SongInfos_AlbumId",
                table: "SomethingPeoples");

            migrationBuilder.DropIndex(
                name: "IX_SomethingPeoples_AlbumId",
                table: "SomethingPeoples");

            migrationBuilder.DropColumn(
                name: "AlbumId",
                table: "SomethingPeoples");

            migrationBuilder.AddColumn<int>(
                name: "AlbumId",
                table: "AlbumInfos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AlbumInfos_AlbumId",
                table: "AlbumInfos",
                column: "AlbumId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumInfos_SongInfos_AlbumId",
                table: "AlbumInfos",
                column: "AlbumId",
                principalTable: "SongInfos",
                principalColumn: "SongId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlbumInfos_SongInfos_AlbumId",
                table: "AlbumInfos");

            migrationBuilder.DropIndex(
                name: "IX_AlbumInfos_AlbumId",
                table: "AlbumInfos");

            migrationBuilder.DropColumn(
                name: "AlbumId",
                table: "AlbumInfos");

            migrationBuilder.AddColumn<int>(
                name: "AlbumId",
                table: "SomethingPeoples",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SomethingPeoples_AlbumId",
                table: "SomethingPeoples",
                column: "AlbumId");

            migrationBuilder.AddForeignKey(
                name: "FK_SomethingPeoples_SongInfos_AlbumId",
                table: "SomethingPeoples",
                column: "AlbumId",
                principalTable: "SongInfos",
                principalColumn: "SongId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
