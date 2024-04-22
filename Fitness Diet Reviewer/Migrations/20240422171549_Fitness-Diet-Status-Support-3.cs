using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fitness_Diet_Reviewer.Migrations
{
    /// <inheritdoc />
    public partial class FitnessDietStatusSupport3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fitness_diets_AspNetUsers_user_id",
                table: "fitness_diets");

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "fitness_diets",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "NotReady",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "fitness_diets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "NotReady");

            migrationBuilder.AddForeignKey(
                name: "FK_fitness_diets_AspNetUsers_user_id",
                table: "fitness_diets",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
