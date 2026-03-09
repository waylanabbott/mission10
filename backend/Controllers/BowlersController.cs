using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BowlingApi.Data;

namespace BowlingApi.Controllers;

// API Controller for serving bowler data to the React frontend
// Base route: /api/bowlers
[Route("api/[controller]")]
[ApiController]
public class BowlersController : ControllerBase
{
    private readonly BowlingLeagueContext _context;

    // Inject the database context via constructor
    public BowlersController(BowlingLeagueContext context)
    {
        _context = context;
    }

    // GET: /api/bowlers
    // Returns bowlers who are on the Marlins or Sharks teams
    // Includes: name, team name, address, city, state, zip, phone
    [HttpGet]
    public async Task<IActionResult> GetBowlers()
    {
        // Query the database for bowlers, filtering by team name
        var bowlers = await _context.Bowlers
            .Where(b => b.Team != null &&
                        (b.Team.TeamName == "Marlins" || b.Team.TeamName == "Sharks"))
            .Include(b => b.Team)
            // Project into anonymous type to avoid circular JSON references
            .Select(b => new
            {
                b.BowlerID,
                b.BowlerFirstName,
                b.BowlerMiddleInit,
                b.BowlerLastName,
                TeamName = b.Team!.TeamName,
                b.BowlerAddress,
                b.BowlerCity,
                b.BowlerState,
                b.BowlerZip,
                b.BowlerPhoneNumber
            })
            .ToListAsync();

        // Return the filtered list of bowlers as JSON
        return Ok(bowlers);
    }
}
