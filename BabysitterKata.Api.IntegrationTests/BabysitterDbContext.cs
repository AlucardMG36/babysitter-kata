using BabysitterKata.Api.IntegrationTests.ModelBuilders;
using BabysitterKata.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BabysitterKata.Api.IntegrationTests
{
    public class BabysitterDbContext : DbContext
    {
        public BabysitterDbContext() : base()
        {
        }

        public DbSet<Babysitter> Babysitter { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseInMemoryDatabase("BabysitterIntegrationTests");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            BabysitterModelBuilder.BuildModel(modelBuilder.Entity<Babysitter>());
        }
    }
}
