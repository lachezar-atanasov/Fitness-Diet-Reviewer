﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Fitness_Diet_Reviewer.Models;

public partial class DietReviewerContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
{
    public DietReviewerContext()
    {
    }
    public DietReviewerContext(DbContextOptions<DietReviewerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public virtual DbSet<DailyMealRow> DailyMealRows { get; set; }
    public virtual DbSet<FitnessDiet> FitnessDiets { get; set; }
    public virtual DbSet<Guideline> Guideline { get; set; }
    public virtual DbSet<Food> Foods { get; set; }
    public virtual DbSet<RequestedFood> RequestedFoods { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();
        var connectionString = configuration.GetConnectionString("DietAuditorContext")
            .Replace("{{YourPassword}}", Environment.GetEnvironmentVariable("DB_PASSWORD"));
        optionsBuilder.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers");

        modelBuilder.Entity<ApplicationUser>()
          .Property(user => user.Description)
          .HasMaxLength(255).IsRequired(false);

        modelBuilder.Entity<ApplicationUser>()
  .Property(user => user.FirstName)
  .HasMaxLength(255).IsRequired(false);

        modelBuilder.Entity<ApplicationUser>()
  .Property(user => user.LastName)
  .HasMaxLength(255).IsRequired(false);

        modelBuilder.Entity<ApplicationUser>()
    .Property(user => user.Stars)
    .HasMaxLength(255).IsRequired(false);

        modelBuilder.Entity<ApplicationUser>()
            .Property(user => user.Age)
            .IsRequired(false);

        modelBuilder.Entity<ApplicationUser>()
            .Property(user => user.Height)
            .HasColumnType("decimal(5, 2)")
            .IsRequired(false);

        modelBuilder.Entity<ApplicationUser>()
            .Property(user => user.Weight)
            .HasColumnType("decimal(5, 2)")
            .IsRequired(false);

        modelBuilder.Entity<ApplicationUser>()
            .Property(user => user.Gender)
            .HasMaxLength(10).IsRequired(false);

        modelBuilder.Entity<ApplicationUser>()
            .Property(user => user.ActivityLevel)
            .HasMaxLength(20).IsRequired(false);


        modelBuilder.Entity<ApplicationUser>()
    .HasMany(user => user.GuidelinesFitnessInstructors)
    .WithOne(guideline => guideline.FitnessInstructor)
    .HasForeignKey(diet => diet.FitnessInstructorId)
    .IsRequired();

        modelBuilder.Entity<ApplicationUser>()
            .HasOne(user => user.FitnessDietUser)
            .WithOne(diet => diet.User)
            .HasForeignKey<FitnessDiet>(diet => diet.UserId)
            .IsRequired();


        modelBuilder.Entity<Guideline>(entity =>
        {
            entity.HasKey(e => e.GuidelineId).HasName("PK__guideline_id");

            entity.ToTable("guidelines");

            entity.HasIndex(e => e.FitnessDietId, "IX_guidelines_fitness_diet_id");

            entity.HasIndex(e => e.FitnessInstructorId, "IX_guidelines_fitness_instructor_id");

            entity.Property(e => e.GuidelineId).HasColumnName("id");
            entity.Property(e => e.FitnessInstructorId).HasColumnName("fitness_instructor_id");
            entity.Property(e => e.FitnessDietId).HasColumnName("fitness_diet_id");

            entity.Property(e => e.Content)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("content");

            entity.HasOne(d => d.FitnessDiet).WithMany(p => p.Guidelines)
                .HasForeignKey(d => d.FitnessDietId)
                .HasConstraintName("FK_guidelines_fitness_diets")
                .OnDelete(DeleteBehavior.Restrict);
            ;

            entity.HasOne(d => d.FitnessInstructor).WithMany(p => p.GuidelinesFitnessInstructors)
                .HasForeignKey(d => d.FitnessInstructorId)
                .HasConstraintName("FK_guidelines_fitness_instructors")
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<DailyMealRow>(entity =>
        {
            entity.HasKey(e => e.DailyMealRowId).HasName("PK__daily_me__6EDFDB04FA5FB744");

            entity.ToTable("daily_meal_rows");

            entity.HasIndex(e => e.FitnessDietId, "IX_daily_meal_rows_fitness_diet_id");

            entity.HasIndex(e => e.ProductId, "IX_daily_meal_rows_product_id");

            entity.Property(e => e.DailyMealRowId).HasColumnName("daily_meal_row_id");
            entity.Property(e => e.AmountInGrams)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("amount_in_grams");
            entity.Property(e => e.DayOfWeek)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("day_of_week");
            entity.Property(e => e.EatTime).HasColumnName("eat_time");
            entity.Property(e => e.FitnessDietId).HasColumnName("fitness_diet_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");

            entity.HasOne(d => d.FitnessDiet).WithMany(p => p.DailyMealRows)
                .HasForeignKey(d => d.FitnessDietId)
                .HasConstraintName("FK_daily_meal_rows_fitness_diets1")
                .OnDelete(DeleteBehavior.Cascade); ;

            entity.HasOne(d => d.Product).WithMany(p => p.DailyMealRows)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__daily_mea__produ__2F10007B");
        });

        modelBuilder.Entity<FitnessDiet>(entity =>
        {
            entity.HasKey(e => e.DietId).HasName("PK_fitness_diets");

            entity.ToTable("fitness_diets");

            entity.HasIndex(e => e.UserId, "IX_fitness_diets_users").IsClustered(false);

            entity.Property(e => e.DietId)
                .ValueGeneratedOnAdd()
                .HasColumnName("diet_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Status).HasColumnName("status").HasDefaultValue("NotReady");

            entity.HasOne(d => d.User).WithOne(p => p.FitnessDietUser)
                .HasForeignKey<FitnessDiet>(d => d.UserId)
                .HasConstraintName("FK_AspNetUsers_fitness_diets")
                .OnDelete(DeleteBehavior.Restrict); 
        });

        modelBuilder.Entity<Food>(entity =>
        {
            entity.HasKey(e => e.FoodId).HasName("PK__foods__2F4C4DD8E3741D6D");

            entity.ToTable("foods");

            entity.Property(e => e.FoodId).HasColumnName("food_id").ValueGeneratedOnAdd();
            entity.Property(e => e.Carbohydrates)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("carbohydrates");
            entity.Property(e => e.Fats)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("fats");
            entity.Property(e => e.FoodName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("food_name");
            entity.Property(e => e.Proteins)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("proteins");
        });
        modelBuilder.Entity<RequestedFood>(entity =>
        {
            entity.HasKey(e => e.FoodId).HasName("PK__request__food__2F4C4DD8E3741D6D");

            entity.HasIndex(e => e.UserId, "IX_requested_foods_users").IsClustered(false).IsUnique(false);

            entity.HasIndex(e => e.UserId, "IX_requested_foods_user_id").IsClustered(false).IsUnique(false);

            entity.ToTable("requested_foods");

            entity.Property(e => e.FoodId).HasColumnName("food_id").ValueGeneratedOnAdd();
            entity.Property(e => e.Carbohydrates)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("carbohydrates");
            entity.Property(e => e.Fats)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("fats");
            entity.Property(e => e.FoodName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("food_name");
            entity.Property(e => e.Proteins)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("proteins");
            entity.Property(e=>e.UserId)
            .HasMaxLength(450)
            .HasColumnName("user_id").IsRequired();


            entity.HasOne(f => f.User).WithOne(u => u.RequestedFoodUser)
     .HasForeignKey<RequestedFood>(f => f.UserId)
     .HasConstraintName("FK_AspNetUsers_requested_foods")
     .IsRequired(false)
     .OnDelete(DeleteBehavior.Cascade);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}