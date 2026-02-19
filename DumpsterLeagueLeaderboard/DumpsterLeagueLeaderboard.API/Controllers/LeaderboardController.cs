using DumpsterLeagueLeaderboard.Application.Features.GenerateLeaderboardFeatures.Commands.GenerateLeaderboard;
using DumpsterLeagueLeaderboard.Application.Features.PlayerFeatures.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DumpsterLeagueLeaderboard.WebApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v1/leaderboards")]
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
    }
}
