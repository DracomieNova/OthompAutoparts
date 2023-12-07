using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityFramWork.Migrations
{
    public partial class corrections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FristName",
                schema: "dbo",
                table: "AspNetUsers",
                newName: "FirstName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstName",
                schema: "dbo",
                table: "AspNetUsers",
                newName: "FristName");
        }
    }
}
