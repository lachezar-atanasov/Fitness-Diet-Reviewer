using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fitness_Diet_Reviewer.Migrations
{
    /// <inheritdoc />
    public partial class OnDeleteCascadeDailyMealRowsFitnessDiets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_daily_meal_rows_fitness_diets1",
                table: "daily_meal_rows");

            migrationBuilder.AddForeignKey(
                name: "FK_daily_meal_rows_fitness_diets1",
                table: "daily_meal_rows",
                column: "fitness_diet_id",
                principalTable: "fitness_diets",
                principalColumn: "diet_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_daily_meal_rows_fitness_diets1",
                table: "daily_meal_rows");

            migrationBuilder.AddForeignKey(
                name: "FK_daily_meal_rows_fitness_diets1",
                table: "daily_meal_rows",
                column: "fitness_diet_id",
                principalTable: "fitness_diets",
                principalColumn: "diet_id");
        }
    }
}
