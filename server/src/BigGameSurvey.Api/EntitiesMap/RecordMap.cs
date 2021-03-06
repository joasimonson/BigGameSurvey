﻿using BigGameSurvey.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigGameSurvey.Api.EntitiesMap
{
    public class RecordMap : IEntityTypeConfiguration<RecordEntity>
    {
        public void Configure(EntityTypeBuilder<RecordEntity> builder)
        {
            builder.ToTable("TB_RECORD").HasKey(t => t.Id);

            builder
                .Property(r => r.Id)
                .HasColumnName("PK_ID");
            builder
                .Property(r => r.Name)
                .HasColumnName("DS_NAME")
                .HasMaxLength(50)
                .IsRequired();
            builder
                .Property(r => r.Age)
                .HasColumnName("NR_AGE")
                .IsRequired();
            builder
                .Property(r => r.InsertedAt)
                .HasColumnName("DT_INSERTEDAT")
                .IsRequired();
            builder
                .Property(r => r.GameId)
                .HasColumnName("FK_GAME")
                .IsRequired();

            builder
                .HasOne(r => r.Game)
                .WithMany(g => g.Records)
                .HasForeignKey(r => r.GameId);
        }
    }
}
