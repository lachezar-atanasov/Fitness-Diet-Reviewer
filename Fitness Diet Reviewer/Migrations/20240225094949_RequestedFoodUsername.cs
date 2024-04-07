using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fitness_Diet_Reviewer.Migrations
{
    /// <inheritdoc />
    public partial class RequestedFoodUsername : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "username",
                table: "requested_foods",
                type: "decimal(18,2)",
                maxLength: 100,
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "username",
                table: "requested_foods");
        }
    }
}
