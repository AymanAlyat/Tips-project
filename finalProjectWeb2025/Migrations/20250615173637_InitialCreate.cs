using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace finalProjectWeb2025.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "tips",
                columns: table => new
                {
                    TipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatePosted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tips", x => x.TipId);
                    table.ForeignKey(
                        name: "FK_tips_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "UserId", "Email", "Name", "Password" },
                values: new object[,]
                {
                    { 1, "ali@example.com", "Ali Talal", "123" },
                    { 2, "dalia@example.com", "Dalia Ahmed", "456" },
                    { 3, "mohammad@example.com", "Mohammad Bader", "789" },
                    { 4, "sami@example.com", "Sami Adel", "abc" },
                    { 5, "faris@example.com", "Faris Esaam", "xyz" }
                });

            migrationBuilder.InsertData(
                table: "tips",
                columns: new[] { "TipId", "Category", "Content", "DatePosted", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "HTML", "Use semantic tags.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "HTML Basics", 1 },
                    { 2, "CSS", "Use flexbox for layouts.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CSS Flexbox", 2 },
                    { 3, "JavaScript", "Use addEventListener.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "JavaScript Events", 3 },
                    { 4, "CSS", "Use media queries.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Responsive Design", 4 },
                    { 5, "HTML", "Always use labels.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "HTML Forms", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tips_UserId",
                table: "tips",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tips");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
