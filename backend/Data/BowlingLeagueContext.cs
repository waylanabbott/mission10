using Microsoft.EntityFrameworkCore;
using BowlingApi.Models;

namespace BowlingApi.Data;

// Entity Framework Core DbContext for the Bowling League SQLite database
// Provides access to the Bowlers and Teams tables
public class BowlingLeagueContext : DbContext
{
    // Constructor accepts DbContextOptions for dependency injection
    public BowlingLeagueContext(DbContextOptions<BowlingLeagueContext> options)
        : base(options) { }

    // DbSet for querying and saving Bowler entities
    public DbSet<Bowler> Bowlers { get; set; }

    // DbSet for querying and saving Team entities
    public DbSet<Team> Teams { get; set; }
}
