using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TwentyQ.Migrations
{
    /// <inheritdoc />
    public partial class _1stMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnimalAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalAnswers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AnimalAnswers",
                columns: new[] { "Id", "AnimalId", "QuestionId", "Value" },
                values: new object[,]
                {
                    { 1, 1, 1, 0.0 },
                    { 2, 1, 2, 2.0 },
                    { 3, 1, 3, 0.0 },
                    { 4, 1, 4, 2.0 },
                    { 5, 2, 1, 0.0 },
                    { 6, 2, 2, 0.0 },
                    { 7, 2, 3, 2.0 },
                    { 8, 2, 4, 0.0 },
                    { 9, 3, 1, 2.0 },
                    { 10, 3, 2, 0.0 },
                    { 11, 3, 3, 0.0 },
                    { 12, 3, 4, 2.0 },
                    { 13, 4, 1, 0.0 },
                    { 14, 4, 2, 2.0 },
                    { 15, 4, 3, 0.0 },
                    { 16, 4, 4, 0.0 },
                    { 17, 5, 1, 0.0 },
                    { 18, 5, 2, 0.0 },
                    { 19, 5, 3, 2.0 },
                    { 20, 5, 4, 0.0 },
                    { 21, 6, 1, 0.0 },
                    { 22, 6, 2, 2.0 },
                    { 23, 6, 3, 2.0 },
                    { 24, 6, 4, 0.0 },
                    { 25, 7, 1, 2.0 },
                    { 26, 7, 2, 0.0 },
                    { 27, 7, 3, 2.0 },
                    { 28, 7, 4, 0.0 },
                    { 29, 8, 1, 0.0 },
                    { 30, 8, 2, 2.0 },
                    { 31, 8, 3, 0.0 },
                    { 32, 8, 4, 0.0 }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Penguin" },
                    { 2, "Dog" },
                    { 3, "Eagle" },
                    { 4, "Shark" },
                    { 5, "Cat" },
                    { 6, "Whale" },
                    { 7, "Bat" },
                    { 8, "Salmon" }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Text" },
                values: new object[,]
                {
                    { 1, "Does it fly?" },
                    { 2, "Does it swim?" },
                    { 3, "Is it a mammal?" },
                    { 4, "Is it a bird?" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalAnswers");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
