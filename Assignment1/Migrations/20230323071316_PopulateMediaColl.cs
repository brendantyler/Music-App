using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment1.Migrations
{
    /// <inheritdoc />
    public partial class PopulateMediaColl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PodcastListenerLists_Playlists_ListenerListId",
                table: "PodcastListenerLists");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Playlists");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Albums");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Albums",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ListenerLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListenerLists", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_PodcastListenerLists_ListenerLists_ListenerListId",
                table: "PodcastListenerLists",
                column: "ListenerListId",
                principalTable: "ListenerLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PodcastListenerLists_ListenerLists_ListenerListId",
                table: "PodcastListenerLists");

            migrationBuilder.DropTable(
                name: "ListenerLists");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Albums");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Playlists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Albums",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_PodcastListenerLists_Playlists_ListenerListId",
                table: "PodcastListenerLists",
                column: "ListenerListId",
                principalTable: "Playlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
