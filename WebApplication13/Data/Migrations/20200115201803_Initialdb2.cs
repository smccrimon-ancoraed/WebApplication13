using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication13.Data.Migrations
{
    public partial class Initialdb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Staff_id",
                table: "Rental",
                nullable: false,
                oldClrType: typeof(short));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "Staff_id",
                table: "Rental",
                nullable: false,
                oldClrType: typeof(byte));
        }
    }
}
