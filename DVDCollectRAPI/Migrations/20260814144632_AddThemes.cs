using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DVDCollectRAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddThemes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Themes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    IsBuiltIn = table.Column<bool>(type: "INTEGER", nullable: false),
                    BodyBg = table.Column<string>(type: "TEXT", nullable: false),
                    BodyColor = table.Column<string>(type: "TEXT", nullable: false),
                    CardBg = table.Column<string>(type: "TEXT", nullable: false),
                    CardBorderColor = table.Column<string>(type: "TEXT", nullable: false),
                    PrimaryColor = table.Column<string>(type: "TEXT", nullable: false),
                    NavbarBg = table.Column<string>(type: "TEXT", nullable: false),
                    NavbarTextColor = table.Column<string>(type: "TEXT", nullable: false),
                    FooterBg = table.Column<string>(type: "TEXT", nullable: false),
                    MutedColor = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Themes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Themes");
        }
    }
}
