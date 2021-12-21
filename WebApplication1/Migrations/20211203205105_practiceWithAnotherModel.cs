using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class practiceWithAnotherModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SomethingPeoples",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FavoriteFood = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<double>(type: "float", nullable: false),
                    DifferentSize = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SomethingPeoples", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SomethingPeoples_PeopleName_PersonId",
                        column: x => x.PersonId,
                        principalTable: "PeopleName",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SomethingPeoples_PersonId",
                table: "SomethingPeoples",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SomethingPeoples");
        }
    }
}
