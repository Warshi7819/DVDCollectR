using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DVDCollectRAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DVDs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProfileId = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    OriginalTitle = table.Column<string>(type: "TEXT", nullable: true),
                    SortTitle = table.Column<string>(type: "TEXT", nullable: true),
                    ProductionYear = table.Column<int>(type: "INTEGER", nullable: true),
                    Released = table.Column<string>(type: "TEXT", nullable: true),
                    RunningTime = table.Column<int>(type: "INTEGER", nullable: true),
                    Rating = table.Column<string>(type: "TEXT", nullable: true),
                    RatingSystem = table.Column<string>(type: "TEXT", nullable: true),
                    RatingAge = table.Column<int>(type: "INTEGER", nullable: true),
                    RatingDetails = table.Column<string>(type: "TEXT", nullable: true),
                    CountryOfOrigin = table.Column<string>(type: "TEXT", nullable: true),
                    UPC = table.Column<string>(type: "TEXT", nullable: true),
                    CollectionNumber = table.Column<int>(type: "INTEGER", nullable: true),
                    CaseType = table.Column<string>(type: "TEXT", nullable: true),
                    Overview = table.Column<string>(type: "TEXT", nullable: true),
                    MediaTypes = table.Column<string>(type: "TEXT", nullable: true),
                    Genres = table.Column<string>(type: "TEXT", nullable: true),
                    Regions = table.Column<string>(type: "TEXT", nullable: true),
                    Studios = table.Column<string>(type: "TEXT", nullable: true),
                    Director = table.Column<string>(type: "TEXT", nullable: true),
                    Actors = table.Column<string>(type: "TEXT", nullable: true),
                    AudioTracks = table.Column<string>(type: "TEXT", nullable: true),
                    Subtitles = table.Column<string>(type: "TEXT", nullable: true),
                    DiscCount = table.Column<int>(type: "INTEGER", nullable: true),
                    PurchaseDate = table.Column<string>(type: "TEXT", nullable: true),
                    PurchasePrice = table.Column<decimal>(type: "TEXT", nullable: true),
                    PurchasePlace = table.Column<string>(type: "TEXT", nullable: true),
                    WishPriority = table.Column<int>(type: "INTEGER", nullable: true),
                    LastEdited = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DVDs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DVDs_ProfileId",
                table: "DVDs",
                column: "ProfileId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DVDs");
        }
    }
}
