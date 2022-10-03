﻿using System;
using Core.Security.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Model> Models { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<OperationClaim> OperationClaims { get; set; }

        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(x =>
            {
                x.ToTable("Brands").HasKey(k => k.Id);
                x.Property(p => p.Id).HasColumnName("Id");
                x.Property(p => p.Name).HasColumnName("Name");

                x.HasMany(p => p.Models);
            });

            modelBuilder.Entity<Model>(x =>
            {
                x.ToTable("Models").HasKey(k => k.Id);
                x.Property(p => p.Id).HasColumnName("Id");
                x.Property(p => p.Name).HasColumnName("Name");
                x.Property(p => p.BrandId).HasColumnName("BrandId");
                x.Property(p => p.DailyPrice).HasColumnName("DailyPrice");
                x.Property(p => p.ImageUrl).HasColumnName("ImageUrl");

                x.HasOne(p => p.Brand);
            });

            Brand[] brandEntitySeeds = { new(1, "BMW"), new(2, "Audi") };
            modelBuilder.Entity<Brand>().HasData(brandEntitySeeds);


            Model[] modelEntitySeeds = {
                new(1, 1, "3.20", 1200,""),
                new(2, 1, "3.30", 1300, ""),
                new(3, 1, "5.20", 2300, ""),
                new(4, 2, "A4", 1700,"") ,
                new(5, 2, "A6", 2600, "")
            };

            modelBuilder.Entity<Model>().HasData(modelEntitySeeds);
        }
    }
}

