using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hyper_Radio_API.Migrations
{
    /// <inheritdoc />
    public partial class fixforeignkeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Tracks_TrackId",
                table: "Favorites");

            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Users_UserId",
                table: "Favorites");

            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Creators_CreatorId",
                table: "Tracks");

            migrationBuilder.DropIndex(
                name: "IX_Tracks_CreatorId",
                table: "Tracks");

            migrationBuilder.DropIndex(
                name: "IX_Favorites_TrackId",
                table: "Favorites");

            migrationBuilder.DropIndex(
                name: "IX_Favorites_UserId",
                table: "Favorites");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "TrackId",
                table: "Favorites");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Favorites");

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_CreatorId_FK",
                table: "Tracks",
                column: "CreatorId_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_TrackId_FK",
                table: "Favorites",
                column: "TrackId_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_UserId_FK",
                table: "Favorites",
                column: "UserId_FK");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Tracks_TrackId_FK",
                table: "Favorites",
                column: "TrackId_FK",
                principalTable: "Tracks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Users_UserId_FK",
                table: "Favorites",
                column: "UserId_FK",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Creators_CreatorId_FK",
                table: "Tracks",
                column: "CreatorId_FK",
                principalTable: "Creators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Tracks_TrackId_FK",
                table: "Favorites");

            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Users_UserId_FK",
                table: "Favorites");

            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Creators_CreatorId_FK",
                table: "Tracks");

            migrationBuilder.DropIndex(
                name: "IX_Tracks_CreatorId_FK",
                table: "Tracks");

            migrationBuilder.DropIndex(
                name: "IX_Favorites_TrackId_FK",
                table: "Favorites");

            migrationBuilder.DropIndex(
                name: "IX_Favorites_UserId_FK",
                table: "Favorites");

            migrationBuilder.AddColumn<int>(
                name: "CreatorId",
                table: "Tracks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TrackId",
                table: "Favorites",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Favorites",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_CreatorId",
                table: "Tracks",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_TrackId",
                table: "Favorites",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_UserId",
                table: "Favorites",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Tracks_TrackId",
                table: "Favorites",
                column: "TrackId",
                principalTable: "Tracks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Users_UserId",
                table: "Favorites",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Creators_CreatorId",
                table: "Tracks",
                column: "CreatorId",
                principalTable: "Creators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
