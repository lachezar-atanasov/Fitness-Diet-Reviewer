using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fitness_Diet_Reviewer.Migrations
{
    /// <inheritdoc />
    public partial class RemovedPictureSupport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "AspNetUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "AspNetUsers",
                type: "NVARCHAR(MAX)",
                nullable: true);
        }
    }
}
