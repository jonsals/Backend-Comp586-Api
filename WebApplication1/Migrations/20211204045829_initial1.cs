using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SomethingPeoples_PeopleName_PersonId",
                table: "SomethingPeoples");

            migrationBuilder.DropIndex(
                name: "IX_SomethingPeoples_PersonId",
                table: "SomethingPeoples");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SomethingPeoples_PersonId",
                table: "SomethingPeoples",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_SomethingPeoples_PeopleName_PersonId",
                table: "SomethingPeoples",
                column: "PersonId",
                principalTable: "PeopleName",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
