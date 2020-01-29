using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication13.Data.Migrations
{
    public partial class NewActorDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            return;
            migrationBuilder.CreateTable(
                name: "Actor",
                columns: table => new
                {
                    Actor_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    First_name = table.Column<string>(nullable: false),
                    Last_name = table.Column<string>(nullable: false),
                    Last_update = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actor", x => x.Actor_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actor");
        }
    }
}
