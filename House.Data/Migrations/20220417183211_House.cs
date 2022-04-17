using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace House.Data.Migrations
{
    public partial class House : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "House",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    Rooms = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Floors = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Information = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_House", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "House");
        }
    }
}
