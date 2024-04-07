using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fitness_Diet_Reviewer.Migrations
{
    /// <inheritdoc />
    public partial class RequestedFoodsRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_requested_foods_user_id",
                table: "requested_foods",
                column: "user_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_requested_foods",
                table: "requested_foods",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_requested_foods",
                table: "requested_foods");

            migrationBuilder.DropIndex(
                name: "IX_requested_foods_user_id",
                table: "requested_foods");
        }
    }
}
