using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fitness_Diet_Reviewer.Migrations
{
    /// <inheritdoc />
    public partial class Guidelines : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fitness_instructors_AspNetUsers",
                table: "fitness_diets");

            migrationBuilder.DropColumn(
                name: "guidelines",
                table: "fitness_diets");

            migrationBuilder.RenameColumn(
                name: "fitness_instructor_id",
                table: "fitness_diets",
                newName: "FitnessInstructorId");

            migrationBuilder.RenameIndex(
                name: "IX_fitness_diets_fitness_instructor_id",
                table: "fitness_diets",
                newName: "IX_fitness_diets_FitnessInstructorId");

            migrationBuilder.CreateTable(
                name: "guidelines",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    content = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FitnessInstructorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FitnessDietId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__guideline_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_guidelines_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_guidelines_fitness_diets",
                        column: x => x.FitnessDietId,
                        principalTable: "fitness_diets",
                        principalColumn: "diet_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_guidelines_fitness_instructors",
                        column: x => x.FitnessInstructorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_guidelines_fitness_diet_id",
                table: "guidelines",
                column: "FitnessDietId");

            migrationBuilder.CreateIndex(
                name: "IX_guidelines_fitness_instructor_id",
                table: "guidelines",
                column: "FitnessInstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_guidelines_UserId",
                table: "guidelines",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_fitness_diets_AspNetUsers_FitnessInstructorId",
                table: "fitness_diets",
                column: "FitnessInstructorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fitness_diets_AspNetUsers_FitnessInstructorId",
                table: "fitness_diets");

            migrationBuilder.DropTable(
                name: "guidelines");

            migrationBuilder.RenameColumn(
                name: "FitnessInstructorId",
                table: "fitness_diets",
                newName: "fitness_instructor_id");

            migrationBuilder.RenameIndex(
                name: "IX_fitness_diets_FitnessInstructorId",
                table: "fitness_diets",
                newName: "IX_fitness_diets_fitness_instructor_id");

            migrationBuilder.AddColumn<string>(
                name: "guidelines",
                table: "fitness_diets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_fitness_instructors_AspNetUsers",
                table: "fitness_diets",
                column: "fitness_instructor_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
