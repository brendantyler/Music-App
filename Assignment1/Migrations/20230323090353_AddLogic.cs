using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment1.Migrations
{
    /// <inheritdoc />
    public partial class AddLogic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Episodes_Podcast_PodcastId",
                table: "Episodes");

            migrationBuilder.DropIndex(
                name: "IX_Episodes_PodcastId",
                table: "Episodes");

            migrationBuilder.DropColumn(
                name: "PodcastId",
                table: "Episodes");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "SongArtists",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PodcastEpisode");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "SongArtists",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<int>(
                name: "PodcastId",
                table: "Episodes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_PodcastId",
                table: "Episodes",
                column: "PodcastId");

            migrationBuilder.AddForeignKey(
                name: "FK_Episodes_Podcast_PodcastId",
                table: "Episodes",
                column: "PodcastId",
                principalTable: "Podcast",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
