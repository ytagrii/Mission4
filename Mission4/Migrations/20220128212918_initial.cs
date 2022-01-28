﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Mission4.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    cName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "directors",
                columns: table => new
                {
                    DirectorId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    dFirstName = table.Column<string>(nullable: false),
                    dLastName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_directors", x => x.DirectorId);
                });

            migrationBuilder.CreateTable(
                name: "ratings",
                columns: table => new
                {
                    RatingId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    rateName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ratings", x => x.RatingId);
                });

            migrationBuilder.CreateTable(
                name: "responses",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: false),
                    Year = table.Column<ushort>(nullable: false),
                    Edited = table.Column<bool>(nullable: false),
                    LentTo = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(maxLength: 25, nullable: true),
                    DirectorId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    RatingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_responses", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_responses_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_responses_directors_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "directors",
                        principalColumn: "DirectorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_responses_ratings_RatingId",
                        column: x => x.RatingId,
                        principalTable: "ratings",
                        principalColumn: "RatingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CategoryId", "cName" },
                values: new object[] { 1, "Action/Adventure" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CategoryId", "cName" },
                values: new object[] { 2, "War" });

            migrationBuilder.InsertData(
                table: "directors",
                columns: new[] { "DirectorId", "dFirstName", "dLastName" },
                values: new object[] { 1, "Christopher", "Nolan" });

            migrationBuilder.InsertData(
                table: "directors",
                columns: new[] { "DirectorId", "dFirstName", "dLastName" },
                values: new object[] { 2, "Jon", "Watts" });

            migrationBuilder.InsertData(
                table: "directors",
                columns: new[] { "DirectorId", "dFirstName", "dLastName" },
                values: new object[] { 3, "Sam", "Mendes" });

            migrationBuilder.InsertData(
                table: "ratings",
                columns: new[] { "RatingId", "rateName" },
                values: new object[] { 1, "G" });

            migrationBuilder.InsertData(
                table: "ratings",
                columns: new[] { "RatingId", "rateName" },
                values: new object[] { 2, "PG" });

            migrationBuilder.InsertData(
                table: "ratings",
                columns: new[] { "RatingId", "rateName" },
                values: new object[] { 3, "PG-13" });

            migrationBuilder.InsertData(
                table: "ratings",
                columns: new[] { "RatingId", "rateName" },
                values: new object[] { 4, "R" });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "MovieId", "CategoryId", "DirectorId", "Edited", "LentTo", "Notes", "RatingId", "Title", "Year" },
                values: new object[] { 1, 1, 1, false, null, null, 3, "Inception", (ushort)2010 });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "MovieId", "CategoryId", "DirectorId", "Edited", "LentTo", "Notes", "RatingId", "Title", "Year" },
                values: new object[] { 2, 1, 2, false, null, null, 3, "Spiderman No Way Home", (ushort)2021 });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "MovieId", "CategoryId", "DirectorId", "Edited", "LentTo", "Notes", "RatingId", "Title", "Year" },
                values: new object[] { 3, 2, 3, false, null, null, 4, "1917", (ushort)2019 });

            migrationBuilder.CreateIndex(
                name: "IX_responses_CategoryId",
                table: "responses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_responses_DirectorId",
                table: "responses",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_responses_RatingId",
                table: "responses",
                column: "RatingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "responses");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "directors");

            migrationBuilder.DropTable(
                name: "ratings");
        }
    }
}
