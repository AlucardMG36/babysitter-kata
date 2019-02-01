using BabysitterKata.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BabysitterKata.Data.ModelBuilders
{
    class BabysitterModelBuilder
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
            
            entity.HasAlternateKey(e => e.CurrentFamily);

        }
    }
}
