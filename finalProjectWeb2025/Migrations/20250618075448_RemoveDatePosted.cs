using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace finalProjectWeb2025.Migrations
{
    public partial class RemoveDatePosted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatePosted",
                table: "tips");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DatePosted",
                table: "tips",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
