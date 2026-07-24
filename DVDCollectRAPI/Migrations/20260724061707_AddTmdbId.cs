using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DVDCollectRAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddTmdbId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TmdbId",
                table: "Tmdb",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TmdbId",
                table: "Tmdb");
        }
    }
}
