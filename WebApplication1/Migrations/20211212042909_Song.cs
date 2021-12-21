using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class Song : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AlbumId",
                table: "SomethingPeoples",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SongInfos",
                columns: table => new
                {
                    SongId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SongName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Minute = table.Column<int>(type: "int", nullable: false),
                    Seconds = table.Column<int>(type: "int", nullable: false),
                    AlbumId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongInfos", x => x.SongId);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SomethingPeoples_SongInfos_AlbumId",
                table: "SomethingPeoples");

            migrationBuilder.DropTable(
                name: "SongInfos");

            migrationBuilder.DropIndex(
                name: "IX_SomethingPeoples_AlbumId",
                table: "SomethingPeoples");

            migrationBuilder.DropColumn(
                name: "AlbumId",
                table: "SomethingPeoples");
        }
    }
}
