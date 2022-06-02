using Microsoft.EntityFrameworkCore;

namespace Model
{
    public class Context : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<LogPlayerGame> LogPlayerGames { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = DESKTOP-S4T02R7\\SQLEXPRESS;Initial Catalog=ArcadeGames;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Password).IsRequired();
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Description).IsRequired();
            });

            modelBuilder.Entity<LogPlayerGame>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Score).IsRequired();
                entity.Property(e => e.Date).IsRequired();
                entity.HasOne(e => e.Player);
                entity.HasOne(e => e.Game);
            });
        }
    }
}