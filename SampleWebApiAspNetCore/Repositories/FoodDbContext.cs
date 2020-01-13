using Microsoft.EntityFrameworkCore;
using SampleWebApiAspNetCore.Entities;
using System;

namespace SampleWebApiAspNetCore.Repositories
{
    public class FoodDbContext : DbContext
    {
        public FoodDbContext(DbContextOptions<FoodDbContext> options)
           : base(options)
        {

        }

        public DbSet<FoodEntity> FoodItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FoodEntity>().ToTable("Foods");
        }
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FoodEntity>().HasData(
                new FoodEntity
                {
                    Id = 1,
                    Calories = 1000,
                    Type = "Starter",
                    Name = "Emma1",
                    Created = DateTime.Now
                },
                new FoodEntity
                {
                    Id = 2,
                    Calories = 1000,
                    Type = "Main",
                    Name = "Emma2",
                    Created = DateTime.Now
                }
                );
        } */

    }
}
