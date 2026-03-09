namespace BowlingApi.Models;

// Represents a team in the Bowling League database
// Maps to the "Teams" table in the SQLite database
public class Team
{
    // Primary key for the team
    public int TeamID { get; set; }

    // Name of the bowling team (e.g., "Marlins", "Sharks")
    public string TeamName { get; set; } = string.Empty;

    // Foreign key to the bowler who is the team captain
    public int? CaptainID { get; set; }

    // Navigation property - collection of bowlers on this team
    public ICollection<Bowler> Bowlers { get; set; } = new List<Bowler>();
}
