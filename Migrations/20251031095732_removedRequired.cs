using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hyper_Radio_API.Migrations
{
    /// <inheritdoc />
    public partial class removedRequired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Shows",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Shows");
        }
    }
}
