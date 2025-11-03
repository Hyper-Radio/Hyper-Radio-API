using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hyper_Radio_API.Migrations
{
    /// <inheritdoc />
    public partial class nullableFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Creators_CreatorId_FK",
                table: "Tracks");

            migrationBuilder.AlterColumn<int>(
                name: "CreatorId_FK",
                table: "Tracks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Creators_CreatorId_FK",
                table: "Tracks",
                column: "CreatorId_FK",
                principalTable: "Creators",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Creators_CreatorId_FK",
                table: "Tracks");

            migrationBuilder.AlterColumn<int>(
                name: "CreatorId_FK",
                table: "Tracks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Creators_CreatorId_FK",
                table: "Tracks",
                column: "CreatorId_FK",
                principalTable: "Creators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
