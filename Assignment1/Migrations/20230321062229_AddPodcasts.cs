using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment1.Migrations
{
    /// <inheritdoc />
    public partial class AddPodcasts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Playlists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Podcast",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Podcast", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PodcastListenerLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PodcastId = table.Column<int>(type: "int", nullable: false),
                    ListenerListId = table.Column<int>(type: "int", nullable: false),
                    TimeAdded = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PodcastListenerLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PodcastListenerLists_Playlists_ListenerListId",
                        column: x => x.ListenerListId,
                        principalTable: "Playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PodcastListenerLists_Podcast_PodcastId",
                        column: x => x.PodcastId,
                        principalTable: "Podcast",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Songs_GuestArtistId",
                table: "Songs",
                column: "GuestArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_PodcastId",
                table: "Songs",
                column: "PodcastId");

            migrationBuilder.CreateIndex(
                name: "IX_PodcastListenerLists_ListenerListId",
                table: "PodcastListenerLists",
                column: "ListenerListId");

            migrationBuilder.CreateIndex(
                name: "IX_PodcastListenerLists_PodcastId",
                table: "PodcastListenerLists",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Artists_GuestArtistId",
                table: "Songs");

            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Podcast_PodcastId",
                table: "Songs");

            migrationBuilder.DropTable(
                name: "PodcastListenerLists");

            migrationBuilder.DropTable(
                name: "Podcast");

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

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Playlists");
        }
    }
}
