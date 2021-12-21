using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class Tweaks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "IX_HotelRoomImages_RoomId",
                table: "AlbumImages",
                newName: "IX_AlbumImage_AlbumId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "IX_AlbumImage_AlbumId",
                table: "AlbumImages",
                newName: "IX_HotelRoomImages_RoomId");
        }
    }
}
