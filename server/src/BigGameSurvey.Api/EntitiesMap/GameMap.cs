using BigGameSurvey.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigGameSurvey.Api.EntitiesMap
{
    public class GameMap : IEntityTypeConfiguration<GameEntity>
    {
        public void Configure(EntityTypeBuilder<GameEntity> builder)
        {
            builder.ToTable("TB_GAME").HasKey(g => g.Id);

            builder
                .Property(r => r.Id)
                .HasColumnName("PK_ID");
            builder
                .Property(g => g.Title)
                .HasColumnName("DS_TITLE")
                .HasMaxLength(50)
                .IsRequired();
            builder
                .Property(g => g.Platform)
                .HasColumnName("FK_PLATFORM")
                .IsRequired();
            builder
                .Property(g => g.GenreId)
                .HasColumnName("FK_GENRE")
                .IsRequired();

            builder
                .HasOne(ga => ga.Genre)
                .WithMany(ge => ge.Games)
                .HasForeignKey(ga => ga.GenreId);
            builder
                .HasMany(g => g.Records)
                .WithOne(r => r.Game)
                .HasForeignKey(g => g.GameId);
        }
    }
}
