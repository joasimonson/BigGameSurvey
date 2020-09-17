using BigGameSurvey.Api.Entities;
using BigGameSurvey.Api.EntitiesMap;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BigGameSurvey.Api.Contexts
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<GameEntity> Games { get; set; }
        public DbSet<GenreEntity> Genres { get; set; }
        public DbSet<RecordEntity> Records { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new GameMap());
            builder.ApplyConfiguration(new GenreMap());
            builder.ApplyConfiguration(new RecordMap());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
             .EnableSensitiveDataLogging(true)
             .UseLoggerFactory(LoggerFactory.Create(builder =>
             {
                 builder
                  .AddFilter((category, level) =>
                     category == DbLoggerCategory.Database.Command.Name
                     && level == LogLevel.Information)
                  .AddConsole();
             }));

            base.OnConfiguring(optionsBuilder);
        }
    }
}
