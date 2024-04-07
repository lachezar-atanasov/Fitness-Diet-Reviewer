using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fitness_Diet_Reviewer.Migrations
{
    /// <inheritdoc />
    public partial class AddRequestedFoodSupport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "requested_foods",
                columns: table => new
                {
                    food_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    food_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    proteins = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    carbohydrates = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    fats = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__request__food__2F4C4DD8E3741D6D", x => x.food_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "requested_foods");
        }
    }
}
