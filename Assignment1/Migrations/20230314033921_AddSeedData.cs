using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment1.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SongArtist_Artist_ArtistId",
                table: "SongArtist");

            migrationBuilder.DropForeignKey(
                name: "FK_SongArtist_Songs_SongId",
                table: "SongArtist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SongArtist",
                table: "SongArtist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Artist",
                table: "Artist");

            migrationBuilder.RenameTable(
                name: "SongArtist",
                newName: "SongArtists");

            migrationBuilder.RenameTable(
                name: "Artist",
                newName: "Artists");

            migrationBuilder.RenameIndex(
                name: "IX_SongArtist_SongId",
                table: "SongArtists",
                newName: "IX_SongArtists_SongId");

            migrationBuilder.RenameIndex(
                name: "IX_SongArtist_ArtistId",
                table: "SongArtists",
                newName: "IX_SongArtists_ArtistId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SongArtists",
                table: "SongArtists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Artists",
                table: "Artists",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SongArtists_Artists_ArtistId",
                table: "SongArtists",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SongArtists_Songs_SongId",
                table: "SongArtists",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SongArtists_Artists_ArtistId",
                table: "SongArtists");

            migrationBuilder.DropForeignKey(
                name: "FK_SongArtists_Songs_SongId",
                table: "SongArtists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SongArtists",
                table: "SongArtists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Artists",
                table: "Artists");

            migrationBuilder.RenameTable(
                name: "SongArtists",
                newName: "SongArtist");

            migrationBuilder.RenameTable(
                name: "Artists",
                newName: "Artist");

            migrationBuilder.RenameIndex(
                name: "IX_SongArtists_SongId",
                table: "SongArtist",
                newName: "IX_SongArtist_SongId");

            migrationBuilder.RenameIndex(
                name: "IX_SongArtists_ArtistId",
                table: "SongArtist",
                newName: "IX_SongArtist_ArtistId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SongArtist",
                table: "SongArtist",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Artist",
                table: "Artist",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SongArtist_Artist_ArtistId",
                table: "SongArtist",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SongArtist_Songs_SongId",
                table: "SongArtist",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
