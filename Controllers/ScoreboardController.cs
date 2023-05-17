using Microsoft.AspNetCore.Mvc;
using DBScoreboard;

namespace backendAPIDatabase.Controllers;

[ApiController]
[Route("[controller]")]
public class ScoreboardController : ControllerBase
{
    private readonly ILogger<ScoreboardController> _logger;

    public ScoreboardController(ILogger<ScoreboardController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [Route("Scoreboard")]
    public IEnumerable<ScoreEntry> Get()
    {
        DBScoreboard.AccessScoreboard db = new();
        return db.GetScoreBoard().ToArray(); //test scoreboard
    }
}
