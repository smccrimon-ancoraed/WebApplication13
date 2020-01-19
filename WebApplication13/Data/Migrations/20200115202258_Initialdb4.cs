using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication13.Data.Migrations
{
    public partial class Initialdb4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            return;
            migrationBuilder.AlterColumn<byte>(
                name: "Staff_id",
                table: "Rental",
                nullable: false,
                oldClrType: typeof(byte),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Return_date",
                table: "Rental",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Staff_id",
                table: "Rental",
                nullable: true,
                oldClrType: typeof(byte));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Return_date",
                table: "Rental",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
