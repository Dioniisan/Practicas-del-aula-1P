using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using AnimalSpawn.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimalSpawn.Infraestructure.Data.Configurations
{
    class FamilyConfiguration : IEntityTypeConfiguration<Family>
    {
        public void Configure(EntityTypeBuilder<Family> builder)
        {
            builder.Property(e => e.Code)
                                .HasMaxLength(15)
                                .IsUnicode(false);

            builder.Property(e => e.CommonName)
                .HasMaxLength(150)
                .IsUnicode(false);

            builder.Property(e => e.CreateAt).HasColumnType("datetime");

            builder.Property(e => e.Status).HasDefaultValueSql("((1))");

            builder.Property(e => e.UpdateAt).HasColumnType("datetime");
        }
    }
}
