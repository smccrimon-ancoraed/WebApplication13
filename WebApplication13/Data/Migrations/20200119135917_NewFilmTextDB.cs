using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication13.Data.Migrations
{
    public partial class NewFilmTextDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            return;
            migrationBuilder.CreateTable(
                name: "Film_text",
                columns: table => new
                {
                    Film_id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Film_text", x => x.Film_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Film_text");
        }
    }
}
