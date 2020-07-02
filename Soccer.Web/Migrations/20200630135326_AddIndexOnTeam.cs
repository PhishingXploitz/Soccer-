using Microsoft.EntityFrameworkCore.Migrations;

namespace Soccer.Web.Migrations
{
    public partial class AddIndexOnTeam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TeamEntity_Name",
                table: "TeamEntity",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TeamEntity_Name",
                table: "TeamEntity");
        }
    }
}
