using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment1.Migrations
{
    /// <inheritdoc />
    public partial class CreateAndMoveSongsAndEpisodes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Artists_GuestArtistId",
                table: "Songs");

            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Podcast_PodcastId",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_Songs_GuestArtistId",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_Songs_PodcastId",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "AirDate",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "GuestArtistId",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "PodcastId",
                table: "Songs");

            migrationBuilder.AddColumn<int>(
                name: "MediaCollectId",
                table: "Songs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Episodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PodcastId = table.Column<int>(type: "int", nullable: false),
                    GuestArtistId = table.Column<int>(type: "int", nullable: true),
                    AirDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Duration = table.Column<int>(type: "int", maxLength: 550800, nullable: false),
                    MediaCollectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Episodes_Artists_GuestArtistId",
                        column: x => x.GuestArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Episodes_Podcast_PodcastId",
                        column: x => x.PodcastId,
                        principalTable: "Podcast",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_GuestArtistId",
                table: "Episodes",
                column: "GuestArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_PodcastId",
                table: "Episodes",
                column: "PodcastId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Episodes");

            migrationBuilder.DropColumn(
                name: "MediaCollectId",
                table: "Songs");

            migrationBuilder.AddColumn<DateTime>(
                name: "AirDate",
                table: "Songs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Songs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "GuestArtistId",
                table: "Songs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PodcastId",
                table: "Songs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Songs_GuestArtistId",
                table: "Songs",
                column: "GuestArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_PodcastId",
                table: "Songs",
                column: "PodcastId");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Artists_GuestArtistId",
                table: "Songs",
                column: "GuestArtistId",
                principalTable: "Artists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Podcast_PodcastId",
                table: "Songs",
                column: "PodcastId",
                principalTable: "Podcast",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
