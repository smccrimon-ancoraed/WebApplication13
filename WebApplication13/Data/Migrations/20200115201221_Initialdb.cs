using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication13.Data.Migrations
{
    public partial class Initialdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

           // return;
            migrationBuilder.CreateTable(
                name: "Rental",
                columns: table => new
                {
                    Rental_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Rental_date = table.Column<DateTime>(nullable: false),
                    Inventory_id = table.Column<int>(nullable: false),
                    Customer_id = table.Column<int>(nullable: false),
                    Return_date = table.Column<DateTime>(nullable: false),
                    Staff_id = table.Column<short>(nullable: false),
                    Last_update = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rental", x => x.Rental_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rental");
        }
    }
}
