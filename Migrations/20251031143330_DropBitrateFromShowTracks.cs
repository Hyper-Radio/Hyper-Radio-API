using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hyper_Radio_API.Migrations
{
    /// <inheritdoc />
    public partial class DropBitrateFromShowTracks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bitrate",
                table: "ShowTracks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Bitrate",
                table: "ShowTracks",
                type: "int",
                nullable: true);
        }
    }
}
