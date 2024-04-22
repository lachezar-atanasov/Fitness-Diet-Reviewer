﻿// <auto-generated />
using System;
using Fitness_Diet_Reviewer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Fitness_Diet_Reviewer.Migrations
{
    [DbContext(typeof(DietReviewerContext))]
    [Migration("20240422171549_Fitness-Diet-Status-Support-3")]
    partial class FitnessDietStatusSupport3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Fitness_Diet_Reviewer.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ActivityLevel")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Gender")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<decimal?>("Height")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<string>("LastName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Stars")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<decimal?>("Weight")
                        .HasColumnType("decimal(5, 2)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Fitness_Diet_Reviewer.Models.DailyMealRow", b =>
                {
                    b.Property<int>("DailyMealRowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("daily_meal_row_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DailyMealRowId"));

                    b.Property<decimal>("AmountInGrams")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("amount_in_grams");

                    b.Property<string>("DayOfWeek")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("day_of_week");

                    b.Property<TimeOnly>("EatTime")
                        .HasColumnType("time")
                        .HasColumnName("eat_time");

                    b.Property<int?>("FitnessDietId")
                        .HasColumnType("int")
                        .HasColumnName("fitness_diet_id");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.HasKey("DailyMealRowId")
                        .HasName("PK__daily_me__6EDFDB04FA5FB744");

                    b.HasIndex(new[] { "FitnessDietId" }, "IX_daily_meal_rows_fitness_diet_id");

                    b.HasIndex(new[] { "ProductId" }, "IX_daily_meal_rows_product_id");

                    b.ToTable("daily_meal_rows", (string)null);
                });

            modelBuilder.Entity("Fitness_Diet_Reviewer.Models.FitnessDiet", b =>
                {
                    b.Property<int>("DietId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("diet_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DietId"));

                    b.Property<string>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("NotReady")
                        .HasColumnName("status");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("user_id");

                    b.HasKey("DietId")
                        .HasName("PK_fitness_diets");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.HasIndex(new[] { "UserId" }, "IX_fitness_diets_users");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex(new[] { "UserId" }, "IX_fitness_diets_users"), false);

                    b.ToTable("fitness_diets", (string)null);
                });

            modelBuilder.Entity("Fitness_Diet_Reviewer.Models.Food", b =>
                {
                    b.Property<int>("FoodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("food_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FoodId"));

                    b.Property<decimal>("Carbohydrates")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("carbohydrates");

                    b.Property<decimal>("Fats")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("fats");

                    b.Property<string>("FoodName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("food_name");

                    b.Property<decimal>("Proteins")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("proteins");

                    b.HasKey("FoodId")
                        .HasName("PK__foods__2F4C4DD8E3741D6D");

                    b.ToTable("foods", (string)null);
                });

            modelBuilder.Entity("Fitness_Diet_Reviewer.Models.Guideline", b =>
                {
                    b.Property<int>("GuidelineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GuidelineId"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("content");

                    b.Property<int>("FitnessDietId")
                        .HasColumnType("int")
                        .HasColumnName("fitness_diet_id");

                    b.Property<string>("FitnessInstructorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("fitness_instructor_id");

                    b.HasKey("GuidelineId")
                        .HasName("PK__guideline_id");

                    b.HasIndex(new[] { "FitnessDietId" }, "IX_guidelines_fitness_diet_id");

                    b.HasIndex(new[] { "FitnessInstructorId" }, "IX_guidelines_fitness_instructor_id");

                    b.ToTable("guidelines", (string)null);
                });

            modelBuilder.Entity("Fitness_Diet_Reviewer.Models.RequestedFood", b =>
                {
                    b.Property<int>("FoodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("food_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FoodId"));

                    b.Property<decimal>("Carbohydrates")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("carbohydrates");

                    b.Property<decimal>("Fats")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("fats");

                    b.Property<string>("FoodName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("food_name");

                    b.Property<decimal>("Proteins")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("proteins");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("user_id");

                    b.HasKey("FoodId")
                        .HasName("PK__request__food__2F4C4DD8E3741D6D");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.HasIndex(new[] { "UserId" }, "IX_requested_foods_user_id")
                        .HasDatabaseName("IX_requested_foods_user_id1");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex(new[] { "UserId" }, "IX_requested_foods_user_id"), false);

                    b.HasIndex(new[] { "UserId" }, "IX_requested_foods_users");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex(new[] { "UserId" }, "IX_requested_foods_users"), false);

                    b.ToTable("requested_foods", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Fitness_Diet_Reviewer.Models.DailyMealRow", b =>
                {
                    b.HasOne("Fitness_Diet_Reviewer.Models.FitnessDiet", "FitnessDiet")
                        .WithMany("DailyMealRows")
                        .HasForeignKey("FitnessDietId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_daily_meal_rows_fitness_diets1");

                    b.HasOne("Fitness_Diet_Reviewer.Models.Food", "Product")
                        .WithMany("DailyMealRows")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK__daily_mea__produ__2F10007B");

                    b.Navigation("FitnessDiet");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Fitness_Diet_Reviewer.Models.FitnessDiet", b =>
                {
                    b.HasOne("Fitness_Diet_Reviewer.Models.ApplicationUser", "User")
                        .WithOne("FitnessDietUser")
                        .HasForeignKey("Fitness_Diet_Reviewer.Models.FitnessDiet", "UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_AspNetUsers_fitness_diets");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Fitness_Diet_Reviewer.Models.Guideline", b =>
                {
                    b.HasOne("Fitness_Diet_Reviewer.Models.FitnessDiet", "FitnessDiet")
                        .WithMany("Guidelines")
                        .HasForeignKey("FitnessDietId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_guidelines_fitness_diets");

                    b.HasOne("Fitness_Diet_Reviewer.Models.ApplicationUser", "FitnessInstructor")
                        .WithMany("GuidelinesFitnessInstructors")
                        .HasForeignKey("FitnessInstructorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_guidelines_fitness_instructors");

                    b.Navigation("FitnessDiet");

                    b.Navigation("FitnessInstructor");
                });

            modelBuilder.Entity("Fitness_Diet_Reviewer.Models.RequestedFood", b =>
                {
                    b.HasOne("Fitness_Diet_Reviewer.Models.ApplicationUser", "User")
                        .WithOne("RequestedFoodUser")
                        .HasForeignKey("Fitness_Diet_Reviewer.Models.RequestedFood", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_AspNetUsers_requested_foods");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Fitness_Diet_Reviewer.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Fitness_Diet_Reviewer.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fitness_Diet_Reviewer.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Fitness_Diet_Reviewer.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Fitness_Diet_Reviewer.Models.ApplicationUser", b =>
                {
                    b.Navigation("FitnessDietUser")
                        .IsRequired();

                    b.Navigation("GuidelinesFitnessInstructors");

                    b.Navigation("RequestedFoodUser")
                        .IsRequired();
                });

            modelBuilder.Entity("Fitness_Diet_Reviewer.Models.FitnessDiet", b =>
                {
                    b.Navigation("DailyMealRows");

                    b.Navigation("Guidelines");
                });

            modelBuilder.Entity("Fitness_Diet_Reviewer.Models.Food", b =>
                {
                    b.Navigation("DailyMealRows");
                });
#pragma warning restore 612, 618
        }
    }
}
