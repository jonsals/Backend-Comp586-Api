using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class changedImageAlbum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PeopleImages");

            migrationBuilder.DropTable(
                name: "PeopleName");

            migrationBuilder.DropTable(
                name: "SomethingPeoples");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "AlbumInfos");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "AlbumInfos",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "AlbumInfos");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "AlbumInfos",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PeopleImages",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Occupancy = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeopleImages", x => x.ImageId);
                });

            migrationBuilder.CreateTable(
                name: "SomethingPeoples",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Age = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DifferentSize = table.Column<int>(type: "int", nullable: false),
                    FavoriteFood = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SomethingPeoples", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PeopleName",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: true),
                    RandomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeopleName", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeopleName_SomethingPeoples_PersonId",
                        column: x => x.PersonId,
                        principalTable: "SomethingPeoples",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PeopleName_PersonId",
                table: "PeopleName",
                column: "PersonId");
        }
    }
}
