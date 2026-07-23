using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DVDCollectRAPI.Migrations
{
    public partial class AddTmdbAndAppSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE TABLE IF NOT EXISTS "AppSettings" (
                    "Key" TEXT NOT NULL CONSTRAINT "PK_AppSettings" PRIMARY KEY,
                    "Value" TEXT NOT NULL
                )
                """);

            migrationBuilder.Sql("""
                CREATE TABLE IF NOT EXISTS "Tmdb" (
                    "DvdId" INTEGER NOT NULL CONSTRAINT "PK_Tmdb" PRIMARY KEY,
                    "PosterPath" TEXT NULL,
                    "VoteAverage" REAL NULL,
                    "VoteCount" INTEGER NULL,
                    "Overview" TEXT NULL,
                    "LastUpdated" TEXT NULL,
                    CONSTRAINT "FK_Tmdb_DVDs_DvdId" FOREIGN KEY ("DvdId") REFERENCES "DVDs" ("Id") ON DELETE CASCADE
                )
                """);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "AppSettings");
            migrationBuilder.DropTable(name: "Tmdb");
        }
    }
}
