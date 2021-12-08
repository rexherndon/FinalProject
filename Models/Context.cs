using Microsoft.EntityFrameworkCore;

namespace FinalProject.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerTournament>().HasKey(p => new {p.PlayerID, p.TournamentID});
        }

        public DbSet<Player> Player {get; set;}
        public DbSet<Tournament> Tournament {get; set;}
        public DbSet<PlayerTournament> PlayerTournament {get; set;}
    }
}