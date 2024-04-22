using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fitness_Diet_Reviewer.Migrations
{
    /// <inheritdoc />
    public partial class GuidelinesUserRemoved2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fitness_diets_AspNetUsers_FitnessInstructorId",
                table: "fitness_diets");

            migrationBuilder.RenameColumn(
                name: "FitnessInstructorId",
                table: "fitness_diets",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_fitness_diets_FitnessInstructorId",
                table: "fitness_diets",
                newName: "IX_fitness_diets_ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_fitness_diets_AspNetUsers_ApplicationUserId",
                table: "fitness_diets",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fitness_diets_AspNetUsers_ApplicationUserId",
                table: "fitness_diets");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "fitness_diets",
                newName: "FitnessInstructorId");

            migrationBuilder.RenameIndex(
                name: "IX_fitness_diets_ApplicationUserId",
                table: "fitness_diets",
                newName: "IX_fitness_diets_FitnessInstructorId");

            migrationBuilder.AddForeignKey(
                name: "FK_fitness_diets_AspNetUsers_FitnessInstructorId",
                table: "fitness_diets",
                column: "FitnessInstructorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
