using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fitness_Diet_Reviewer.Migrations
{
    /// <inheritdoc />
    public partial class FitnessDietStatusSupport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_fitness_diets",
                table: "fitness_diets");

            migrationBuilder.RenameColumn(
                name: "FitnessInstructorId",
                table: "guidelines",
                newName: "fitness_instructor_id");

            migrationBuilder.RenameColumn(
                name: "FitnessDietId",
                table: "guidelines",
                newName: "fitness_diet_id");

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "fitness_diets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_fitness_diets",
                table: "fitness_diets",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_fitness_diets",
                table: "fitness_diets");

            migrationBuilder.DropColumn(
                name: "status",
                table: "fitness_diets");

            migrationBuilder.RenameColumn(
                name: "fitness_instructor_id",
                table: "guidelines",
                newName: "FitnessInstructorId");

            migrationBuilder.RenameColumn(
                name: "fitness_diet_id",
                table: "guidelines",
                newName: "FitnessDietId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_fitness_diets",
                table: "fitness_diets",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
