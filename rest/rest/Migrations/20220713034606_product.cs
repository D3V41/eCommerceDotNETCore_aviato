using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace rest.Migrations
{
    public partial class product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Details = table.Column<string>(nullable: true),
                    oldPrice = table.Column<double>(nullable: false),
                    newPrice = table.Column<double>(nullable: false),
                    Src = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
