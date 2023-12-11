using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backendAPI.Migrations
{
    /// <inheritdoc />
    public partial class blep2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_info_Parts_PartsId",
                table: "info");

            migrationBuilder.DropForeignKey(
                name: "FK_info_Service_ServiceId",
                table: "info");

            migrationBuilder.DropIndex(
                name: "IX_info_PartsId",
                table: "info");

            migrationBuilder.DropIndex(
                name: "IX_info_ServiceId",
                table: "info");

            migrationBuilder.DropColumn(
                name: "PartsId",
                table: "info");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "info");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PartsId",
                table: "info",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "info",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_info_PartsId",
                table: "info",
                column: "PartsId");

            migrationBuilder.CreateIndex(
                name: "IX_info_ServiceId",
                table: "info",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_info_Parts_PartsId",
                table: "info",
                column: "PartsId",
                principalTable: "Parts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_info_Service_ServiceId",
                table: "info",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
