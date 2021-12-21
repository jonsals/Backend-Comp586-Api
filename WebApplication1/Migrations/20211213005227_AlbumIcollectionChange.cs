using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class AlbumIcollectionChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PeopleName_AlbumInfos_PersonId",
                table: "PeopleName");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "ArtistInfos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArtistInfos_PersonId",
                table: "ArtistInfos",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistInfos_AlbumInfos_PersonId",
                table: "ArtistInfos",
                column: "PersonId",
                principalTable: "AlbumInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtistInfos_AlbumInfos_PersonId",
                table: "ArtistInfos");

            migrationBuilder.DropIndex(
                name: "IX_ArtistInfos_PersonId",
                table: "ArtistInfos");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "ArtistInfos");

            migrationBuilder.AddForeignKey(
                name: "FK_PeopleName_AlbumInfos_PersonId",
                table: "PeopleName",
                column: "PersonId",
                principalTable: "AlbumInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
