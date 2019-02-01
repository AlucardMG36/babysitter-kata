using BabysitterKata.Data.ModelBuilders;
using BabysitterKata.Entities;
using Microsoft.EntityFrameworkCore;

namespace BabysitterKata.Data
{
    public class BabysitterDBContext : DbContext

    {
        public BabysitterDBContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Babysitter> Babysitters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            BabysitterModelBuilder.BuildModel(modelBuilder.Entity<Babysitter>());
        }
    }
}