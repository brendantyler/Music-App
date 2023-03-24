using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment1.Migrations
{
    /// <inheritdoc />
    public partial class AddLogicSongs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PodcastEpisode");

            migrationBuilder.AddColumn<int>(
                name: "PodcastId",
                table: "Episodes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PodcastId",
                table: "Artists",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PodcastAuth",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PodcastId = table.Column<int>(type: "int", nullable: false),
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PodcastAuth", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PodcastAuth_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PodcastAuth_Podcast_PodcastId",
                        column: x => x.PodcastId,
                        principalTable: "Podcast",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_PodcastId",
                table: "Episodes",
                column: "PodcastId");

            migrationBuilder.CreateIndex(
                name: "IX_Artists_PodcastId",
                table: "Artists",
                column: "PodcastId");

            migrationBuilder.CreateIndex(
                name: "IX_PodcastAuth_ArtistId",
                table: "PodcastAuth",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_PodcastAuth_PodcastId",
                table: "PodcastAuth",
                column: "PodcastId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Podcast_PodcastId",
                table: "Artists",
                column: "PodcastId",
                principalTable: "Podcast",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Episodes_Podcast_PodcastId",
                table: "Episodes",
                column: "PodcastId",
                principalTable: "Podcast",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Podcast_PodcastId",
                table: "Artists");

            migrationBuilder.DropForeignKey(
                name: "FK_Episodes_Podcast_PodcastId",
                table: "Episodes");

            migrationBuilder.DropTable(
                name: "PodcastAuth");

            migrationBuilder.DropIndex(
                name: "IX_Episodes_PodcastId",
                table: "Episodes");

            migrationBuilder.DropIndex(
                name: "IX_Artists_PodcastId",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "PodcastId",
                table: "Episodes");

            migrationBuilder.DropColumn(
                name: "PodcastId",
                table: "Artists");

            migrationBuilder.CreateTable(
                name: "PodcastEpisode",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PodcastId = table.Column<int>(type: "int", nullable: false),
                    EpisodesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PodcastEpisode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PodcastEpisode_Episodes_EpisodesId",
                        column: x => x.EpisodesId,
                        principalTable: "Episodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PodcastEpisode_Podcast_PodcastId",
                        column: x => x.PodcastId,
                        principalTable: "Podcast",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PodcastEpisode_EpisodesId",
                table: "PodcastEpisode",
                column: "EpisodesId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PodcastEpisode_PodcastId",
                table: "PodcastEpisode",
                column: "PodcastId");
        }
    }
}
