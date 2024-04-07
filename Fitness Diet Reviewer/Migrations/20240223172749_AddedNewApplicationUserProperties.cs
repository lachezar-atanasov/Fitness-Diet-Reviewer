using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fitness_Diet_Reviewer.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewApplicationUserProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ActivityLevel",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Height",
                table: "AspNetUsers",
                type: "decimal(5,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "AspNetUsers",
                type: "NVARCHAR(MAX)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Weight",
                table: "AspNetUsers",
                type: "decimal(5,2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivityLevel",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "AspNetUsers");
        }
    }
}
