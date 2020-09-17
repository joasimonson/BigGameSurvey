using BigGameSurvey.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigGameSurvey.Api.EntitiesMap
{
    public class GenreMap : IEntityTypeConfiguration<GenreEntity>
    {
        public void Configure(EntityTypeBuilder<GenreEntity> builder)
        {
            builder.ToTable("TB_GENRE").HasKey(g => g.Id);

            builder
                .Property(r => r.Id)
                .HasColumnName("PK_ID");
            builder
                .Property(g => g.Name)
                .HasColumnName("DS_NAME")
                .HasMaxLength(50)
                .IsRequired();

            builder
                .HasMany(ge => ge.Games)
                .WithOne(ga => ga.Genre)
                .HasForeignKey(ge => ge.GenreId);
        }
    }
}
