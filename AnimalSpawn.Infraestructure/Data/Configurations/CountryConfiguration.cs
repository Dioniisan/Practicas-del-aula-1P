﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using AnimalSpawn.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimalSpawn.Infraestructure.Data.Configurations
{
    class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.Property(e => e.Code)
                                .HasMaxLength(25)
                                .IsUnicode(false);

            builder.Property(e => e.CreateAt).HasColumnType("datetime");

            builder.Property(e => e.Isocode)
                .HasColumnName("ISOCode")
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Status).HasDefaultValueSql("((1))");

            builder.Property(e => e.UpdateAt).HasColumnType("datetime");
        }
    }
}