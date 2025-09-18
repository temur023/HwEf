using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfHw.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FullName = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    Position = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Club = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Nationality = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    ProfilePhoto = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
