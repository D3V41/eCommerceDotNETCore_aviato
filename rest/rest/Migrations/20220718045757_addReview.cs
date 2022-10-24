using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace rest.Migrations
{
    public partial class addReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productId = table.Column<int>(nullable: false),
                    userId = table.Column<int>(nullable: false),
                    date = table.Column<DateTime>(nullable: false),
                    username = table.Column<string>(nullable: true),
                    review = table.Column<string>(nullable: true),
                    Src = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");
        }
    }
}
