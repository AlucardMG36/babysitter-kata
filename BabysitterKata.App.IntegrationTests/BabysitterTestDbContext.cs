using BabysitterKata.App.IntegrationTests.Data.ModelBuilders;
using BabysitterKata.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BabysitterKata.App.IntegrationTests
{
    public class BabysitterTestDbContext: DbContext
    {
        public BabysitterTestDbContext()
            : base()
        {
        }

        public DbSet<Babysitter> Babysitter { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var projectDirectory = Path.GetFullPath(@"..\..\..\");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(projectDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseInMemoryDatabase("BabysitterKata");
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            BabysitterModelBuilder.BuildModel(modelBuilder.Entity<Babysitter>());
        }
    }
}
