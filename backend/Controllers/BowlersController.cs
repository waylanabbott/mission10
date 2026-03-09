using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BowlingApi.Data;

namespace BowlingApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BowlersController : ControllerBase
{
    private readonly BowlingLeagueContext _context;

    public BowlersController(BowlingLeagueContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetBowlers()
    {
        var bowlers = await _context.Bowlers
            .Where(b => b.Team != null &&
                        (b.Team.TeamName == "Marlins" || b.Team.TeamName == "Sharks"))
            .Include(b => b.Team)
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

        return Ok(bowlers);
    }
}
