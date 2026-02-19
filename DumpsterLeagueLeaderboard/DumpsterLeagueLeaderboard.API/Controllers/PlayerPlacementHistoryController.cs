using DumpsterLeagueLeaderboard.Application.Features.PlayerPlacementHistoryFeatures.Commands.AddPlayerPlacementHistory;
using DumpsterLeagueLeaderboard.Application.Features.PlayerPlacementHistoryFeatures.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DumpsterLeagueLeaderboard.WebApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v1/player-placement-histories")]
    public class PlayerPlacementHistoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PlayerPlacementHistoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddPlayerPlacementHistoryRequest request, CancellationToken cancellationToken)
        {
            var playerPlacementHistories = await _mediator.Send(new AddPlayerPlacementHistoryCommand(request), cancellationToken);
            return CreatedAtAction(nameof(Create), playerPlacementHistories);
        }
    }
}
