using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fitness_Diet_Reviewer.Migrations
{
    /// <inheritdoc />
    public partial class GuidelinesUserRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_guidelines_AspNetUsers_UserId",
                table: "guidelines");

            migrationBuilder.DropIndex(
                name: "IX_guidelines_UserId",
                table: "guidelines");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "guidelines");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "guidelines",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_guidelines_UserId",
                table: "guidelines",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_guidelines_AspNetUsers_UserId",
                table: "guidelines",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
