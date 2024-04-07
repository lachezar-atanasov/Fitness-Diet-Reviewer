using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fitness_Diet_Reviewer.Migrations
{
    /// <inheritdoc />
    public partial class IndexEdit1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
    name: "IX_requested_foods_user_id",
    table: "requested_foods"); 

            migrationBuilder.CreateIndex(
                name: "IX_requested_foods_user_id",
                table: "requested_foods",
                column: "user_id",
                unique:false)
                .Annotation("SqlServer:Clustered", false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_requested_foods_user_id",
                table: "requested_foods");
        }
    }
}
