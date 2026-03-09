namespace BowlingApi.Models;

public class Team
{
    public int TeamID { get; set; }
    public string TeamName { get; set; } = string.Empty;
    public int? CaptainID { get; set; }
    public ICollection<Bowler> Bowlers { get; set; } = new List<Bowler>();
}
