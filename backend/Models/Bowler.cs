namespace BowlingApi.Models;

// Represents a bowler in the Bowling League database
// Maps to the "Bowlers" table in the SQLite database
public class Bowler
{
    // Primary key for the bowler
    public int BowlerID { get; set; }

    // Bowler's name fields
    public string? BowlerLastName { get; set; }
    public string? BowlerFirstName { get; set; }
    public string? BowlerMiddleInit { get; set; }

    // Bowler's contact/address information
    public string? BowlerAddress { get; set; }
    public string? BowlerCity { get; set; }
    public string? BowlerState { get; set; }
    public string? BowlerZip { get; set; }
    public string? BowlerPhoneNumber { get; set; }

    // Foreign key to the Teams table
    public int? TeamID { get; set; }

    // Navigation property to the related Team
    public Team? Team { get; set; }
}
