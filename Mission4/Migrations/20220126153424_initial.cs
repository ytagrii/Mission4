using Microsoft.EntityFrameworkCore.Migrations;

namespace Mission4.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "responses",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Category = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Year = table.Column<ushort>(nullable: false),
                    Director = table.Column<string>(nullable: false),
                    Rating = table.Column<string>(nullable: false),
                    Edited = table.Column<bool>(nullable: false),
                    LentTo = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_responses", x => x.MovieId);
                });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "MovieId", "Category", "Director", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 1, "Action/Adventure", "Christopher Nolan", false, null, null, "PG-13", "Inception", (ushort)2010 });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "MovieId", "Category", "Director", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 2, "Action/Adventure", "Jon Watts", false, null, null, "PG-13", "Spiderman No Way Home", (ushort)2021 });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "MovieId", "Category", "Director", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 3, "War", "Sam Mendes", false, null, null, "R", "1917", (ushort)2019 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "responses");
        }
    }
}
