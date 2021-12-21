using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class AlbumChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlbumImages");

            migrationBuilder.AddColumn<int>(
                name: "ArtistId",
                table: "AlbumInfos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_PeopleName_AlbumInfos_PersonId",
                table: "PeopleName",
                column: "PersonId",
                principalTable: "AlbumInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PeopleName_AlbumInfos_PersonId",
                table: "PeopleName");

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "AlbumInfos");

            migrationBuilder.CreateTable(
                name: "AlbumImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlbumId = table.Column<int>(type: "int", nullable: true),
                    AlbumImageId = table.Column<int>(type: "int", nullable: false),
                    AlbumImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlbumImages_AlbumInfos_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "AlbumInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlbumImages_AlbumId",
                table: "AlbumImages",
                column: "AlbumId");
        }
    }
}
