using DumpsterLeagueLeaderboard.Application.Features.LeaderboardFeatures.Commands.GenerateLeaderboard;
using DumpsterLeagueLeaderboard.Application.Features.LeaderboardFeatures.Queries.GetLatestLeaderboard;
using DumpsterLeagueLeaderboard.Application.Features.PlayerFeatures.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DumpsterLeagueLeaderboard.WebApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version}/leaderboards")]
    public class LeaderboardController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaderboardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(GenerateLeaderboardRequest request, CancellationToken cancellationToken)
        {
            var leaderboards = await _mediator.Send(new GenerateLeaderboardCommand(request), cancellationToken);
            return CreatedAtAction(nameof(Create), leaderboards);
        }

        [HttpGet("league-events/{leagueEventId}/seasons/{seasonId}")]
        public async Task<IActionResult> GetLatestLeaderboard(Guid leagueEventId, Guid seasonId, CancellationToken cancellationToken)
        {
            var leaderboard = await _mediator.Send(new GetLatestLeaderboardQuery(leagueEventId, seasonId), cancellationToken);
            return Ok(leaderboard);
        }
    }
}
