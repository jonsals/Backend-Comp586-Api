using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class moreImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "PeopleImages");

            migrationBuilder.AddColumn<string>(
                name: "Occupancy",
                table: "PeopleImages",
                type: "nvarchar(50)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Occupancy",
                table: "PeopleImages");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "PeopleImages",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
