using BabysitterKata.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BabysitterKata.Api.IntegrationTests.ModelBuilders
{
    public class BabysitterModelBuilder
    {
        public static void BuildModel(EntityTypeBuilder<Babysitter> entity)
        {
            entity.ToTable("Babysitter");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .IsRequired();

            entity.Property(e => e.CurrentFamily)
                .IsRequired();

            entity.Property(e => e.PayForShift);        
        }
    }
}
