using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fitness_Diet_Reviewer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });


            migrationBuilder.CreateTable(
                name: "foods",
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
                    table.PrimaryKey("PK__foods__2F4C4DD8E3741D6D", x => x.food_id);
                });

            migrationBuilder.CreateTable(
                name: "fitness_diets",
                columns: table => new
                {
                    diet_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    fitness_instructor_id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    guidelines = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fitness_diets", x => x.diet_id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_fitness_diets",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_fitness_instructors_AspNetUsers",
                        column: x => x.fitness_instructor_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "daily_meal_rows",
                columns: table => new
                {
                    daily_meal_row_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<int>(type: "int", nullable: true),
                    amount_in_grams = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    fitness_diet_id = table.Column<int>(type: "int", nullable: true),
                    day_of_week = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    eat_time = table.Column<TimeOnly>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__daily_me__6EDFDB04FA5FB744", x => x.daily_meal_row_id);
                    table.ForeignKey(
                        name: "FK__daily_mea__produ__2F10007B",
                        column: x => x.product_id,
                        principalTable: "foods",
                        principalColumn: "food_id");
                    table.ForeignKey(
                        name: "FK_daily_meal_rows_fitness_diets1",
                        column: x => x.fitness_diet_id,
                        principalTable: "fitness_diets",
                        principalColumn: "diet_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_daily_meal_rows_fitness_diet_id",
                table: "daily_meal_rows",
                column: "fitness_diet_id");

            migrationBuilder.CreateIndex(
                name: "IX_daily_meal_rows_product_id",
                table: "daily_meal_rows",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_fitness_diets_fitness_instructor_id",
                table: "fitness_diets",
                column: "fitness_instructor_id");

            migrationBuilder.CreateIndex(
                name: "IX_fitness_diets_user_id",
                table: "fitness_diets",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_fitness_diets_users",
                table: "fitness_diets",
                column: "user_id")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "UserName", "NormalizedUserName", "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnabled", "AccessFailedCount" },
                values: new object[,]
                {
            { "b7d06e24-db26-4a70-b692-e68b15048abb", "Pesho", "PESHO", true, "AQAAAAIAAYagAAAAEImR8MkICuUdY9A7X6VcauRyeUlhCFz1PAepffVZvtfkjtO9giPrIbw5CwsxonzygQ==", "X53HPGTIWBWIP352MEPDBQ2QJTBJCLIP", "df1ea1bd-cefb-4bb7-a28e-7963bd73a18f", false, false, true, 0 },
            { "bfb9fe9b-54c2-4586-a61a-1a42628f7aeb", "Lachezar", "LACHEZAR", true, "AQAAAAIAAYagAAAAEBn9J7byESmmvwSNTuEVqjLgZSkE4SoqEu4LaPMMqHk/T5shu5NEv9e3R8tYg2Cqng==", "TEMP4ZI37R3QDBJNOG3O4DOQOTNTSGAQ", "62733f7d-8864-4f6b-b9b5-743531c157c6", false, false, true, 0 },
            { "eac715d8-85df-4807-ac1f-2d7567c1d4fa", "Lazar", "LAZAR", true, "AQAAAAIAAYagAAAAEDjEx12IVl7K8xc7qvNSOnVLJsvpvsfLoNsgxojJAR/KZcVNQCD4RArkhiMbeOT/9A==", "LKH6AKKH3X55IWO6SRQMRYXJ77EDJLAT", "12ebf892-3c62-48f3-95bc-90a95dbc02a9", false, false, true, 0 }
                });

            migrationBuilder.InsertData(
table: "AspNetRoles",
columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
values: new object[,]
{
            { "5585de5b-e060-4b40-bb94-2ed075127b65", "Administrator", "ADMINISTRATOR", null },
            { "690463c8-e63e-4aaf-a5f4-a7dfef1caba6", "User", "USER", null },
            { "ed2014e3-973a-47e7-9123-e39897464eb9", "Fitness Instructor", "FITNESS INSTRUCTOR", null }
});

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
            { "bfb9fe9b-54c2-4586-a61a-1a42628f7aeb", "5585de5b-e060-4b40-bb94-2ed075127b65" },
            { "b7d06e24-db26-4a70-b692-e68b15048abb", "690463c8-e63e-4aaf-a5f4-a7dfef1caba6" },
            { "eac715d8-85df-4807-ac1f-2d7567c1d4fa", "ed2014e3-973a-47e7-9123-e39897464eb9" }
                });

            migrationBuilder.InsertData(
        table: "fitness_diets",
        columns: new[] { "diet_id", "user_id", "fitness_instructor_id", "guidelines" },
        values: new object[] { 1, "bfb9fe9b-54c2-4586-a61a-1a42628f7aeb", null, null });
    

        migrationBuilder.InsertData(
        table: "foods",
        columns: new[]
        {
            "food_id", "food_name", "proteins", "carbohydrates", "fats"
        },
        values: new object[,]
        {
            { 1, "Chicken fillet", 31.00m, 0.00m, 5.00m },
            { 2, "Chicken Breast", 31.00m, 0.60m, 3.60m },
            { 3, "Salmon", 30.00m, 0.00m, 10.90m },
            { 4, "Tofu", 20.00m, 1.90m, 4.80m },
            { 5, "Quinoa", 14.00m, 18.00m, 1.90m },
            { 6, "Sweet Potato", 3.00m, 20.70m, 0.10m },
            { 7, "Broccoli", 4.00m, 5.20m, 0.60m },
            { 8, "Avocado", 3.00m, 8.50m, 14.70m },
            { 9, "Spinach", 5.00m, 3.60m, 0.40m },
            { 10, "Eggs", 20.00m, 1.10m, 9.50m },
            { 11, "Almonds", 25.00m, 6.70m, 49.90m },
            { 12, "Turkey", 29.00m, 0.00m, 7.00m },
            { 13, "Beef", 36.00m, 0.00m, 8.00m },
            { 14, "Lentils", 9.00m, 20.00m, 0.40m },
            { 15, "Greek Yogurt", 10.00m, 3.60m, 5.30m },
            { 16, "Cottage Cheese", 11.00m, 3.40m, 4.30m },
            { 17, "Peanut Butter", 25.00m, 20.00m, 50.00m },
            { 18, "Chickpeas", 19.00m, 35.00m, 6.00m },
            { 19, "Lamb", 25.00m, 0.00m, 20.00m },
            { 20, "Sardines", 25.00m, 0.00m, 14.00m },
            { 21, "Pumpkin Seeds", 30.00m, 10.00m, 49.00m },
            { 22, "Beef Jerky", 33.00m, 2.00m, 14.00m },
            { 23, "Cauliflower Rice", 2.00m, 5.00m, 0.30m },
            { 24, "Shrimp", 24.00m, 1.00m, 1.00m },
            { 25, "Canned Tuna", 30.00m, 0.00m, 1.00m },
            { 26, "Halibut", 23.00m, 0.00m, 2.00m },
            { 27, "Bison", 29.00m, 0.00m, 6.00m },
            { 28, "Pork Chops", 31.00m, 0.00m, 4.00m },
            { 29, "Quail Eggs", 13.00m, 1.10m, 11.00m },
            { 30, "Greek Salad", 6.00m, 8.00m, 10.00m },
            { 31, "Whey Protein", 70.00m, 2.00m, 1.00m },
            { 32, "Lobster", 19.00m, 0.00m, 0.90m },
            { 33, "Caviar", 24.00m, 1.00m, 17.00m },
            { 34, "Pheasant", 22.00m, 0.00m, 1.00m },
            { 35, "Venison", 36.00m, 0.00m, 1.00m },
            { 36, "Crab", 19.00m, 0.00m, 2.00m },
            { 37, "Pork Rinds", 61.00m, 0.00m, 42.00m },
            { 38, "Asparagus", 2.20m, 3.70m, 0.20m },
            { 39, "Kale", 2.90m, 8.80m, 0.40m },
            { 40, "Chia Seeds", 16.50m, 42.10m, 30.70m },
            { 41, "Wheat Germ", 23.20m, 51.00m, 1.70m },
            { 42, "Herring", 18.00m, 0.00m, 12.00m },
            { 43, "Venison Sausage", 24.00m, 0.00m, 16.00m },
            { 44, "Trout", 22.00m, 0.00m, 10.00m },
            { 45, "Duck Eggs", 12.80m, 0.60m, 9.60m },
            { 46, "Artichoke", 3.30m, 8.70m, 0.20m },
            { 47, "Brussels Sprouts", 3.40m, 8.00m, 0.30m },
            { 48, "Pecans", 9.20m, 14.00m, 72.00m },
            { 49, "Pistachios", 20.00m, 27.00m, 45.00m },
            { 50, "Blue Cheese", 21.00m, 2.30m, 29.00m },
        });
        }
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
