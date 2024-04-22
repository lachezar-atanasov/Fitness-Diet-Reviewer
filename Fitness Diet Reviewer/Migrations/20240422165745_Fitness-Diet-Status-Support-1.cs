using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fitness_Diet_Reviewer.Migrations
{
    /// <inheritdoc />
    public partial class FitnessDietStatusSupport1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_fitness_diets",
                table: "fitness_diets");

            migrationBuilder.DropForeignKey(
                name: "FK_fitness_diets_AspNetUsers_ApplicationUserId",
                table: "fitness_diets");

            migrationBuilder.DropIndex(
                name: "IX_fitness_diets_ApplicationUserId",
                table: "fitness_diets");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "fitness_diets");

            migrationBuilder.AddForeignKey(
                name: "FK_fitness_diets_AspNetUsers_user_id",
                table: "fitness_diets",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fitness_diets_AspNetUsers_user_id",
                table: "fitness_diets");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "fitness_diets",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_fitness_diets_ApplicationUserId",
                table: "fitness_diets",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_fitness_diets",
                table: "fitness_diets",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_fitness_diets_AspNetUsers_ApplicationUserId",
                table: "fitness_diets",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
