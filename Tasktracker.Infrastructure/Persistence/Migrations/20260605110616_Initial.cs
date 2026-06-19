using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tasktracker.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    IsDone = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedAt", "Description", "IsDone", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("00177286-b887-4bf3-bdba-315639370345"), new DateTime(2026, 6, 5, 11, 0, 0, 0, DateTimeKind.Unspecified), "Downloading Docker.", true, "Download Docker.", null },
                    { new Guid("19c8b5fe-81b3-46c7-a06b-9577d33245bf"), new DateTime(2026, 6, 5, 13, 0, 0, 0, DateTimeKind.Unspecified), "Creating an Docker image.", false, "Create image.", null },
                    { new Guid("4d152292-03bd-4d7c-890d-f1a27c4065fb"), new DateTime(2026, 6, 5, 15, 30, 0, 0, DateTimeKind.Unspecified), "Creating a docker-compose.yml file.", false, "Create docker-compose.", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
