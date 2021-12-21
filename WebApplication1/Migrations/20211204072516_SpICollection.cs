using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class SpICollection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "PeopleName",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PeopleName_PersonId",
                table: "PeopleName",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_PeopleName_SomethingPeoples_PersonId",
                table: "PeopleName",
                column: "PersonId",
                principalTable: "SomethingPeoples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PeopleName_SomethingPeoples_PersonId",
                table: "PeopleName");

            migrationBuilder.DropIndex(
                name: "IX_PeopleName_PersonId",
                table: "PeopleName");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "PeopleName");
        }
    }
}
