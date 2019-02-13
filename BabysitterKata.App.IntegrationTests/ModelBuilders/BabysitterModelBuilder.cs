using BabysitterKata.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BabysitterKata.App.IntegrationTests.Data.ModelBuilders
{
    internal class BabysitterModelBuilder
    {
        public static void BuildModel(EntityTypeBuilder<Babysitter> entity)
        {
            entity.ToTable("Babysitter");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.PayForShift)

                .HasColumnName("Pay")

                .IsRequired();

            entity.Property(e => e.CurrentFamily)

                .HasColumnName("CurrentFamily")

                .IsRequired();

            entity.Property(e => e.StartTime)

                .HasColumnName("StartTime")

                .IsRequired();

            entity.Property(e => e.EndTime)

                .HasColumnName("EndTime")

                .IsRequired();

            //entity.HasAlternateKey(e => e.CurrentFamily);
        }
    }
}