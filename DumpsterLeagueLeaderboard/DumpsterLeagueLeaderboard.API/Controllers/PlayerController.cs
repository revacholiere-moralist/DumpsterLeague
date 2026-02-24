using DumpsterLeagueLeaderboard.Application.Features.PlayerFeatures.Command.AddPlayer;
using DumpsterLeagueLeaderboard.Application.Features.PlayerFeatures.Queries.GetActivePlayers;
using DumpsterLeagueLeaderboard.Application.Features.PlayerFeatures.Queries.GetPlayerById;
using DumpsterLeagueLeaderboard.Application.Features.PlayerFeatures.Requests;

using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DumpsterLeagueLeaderboard.WebApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version}/players")]
    public class PlayerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PlayerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddPlayerRequest request, CancellationToken cancellationToken)
        {
            var season = await _mediator.Send(new AddPlayerCommand(request), cancellationToken);
            return CreatedAtAction(nameof(Create), new { id = season.Id }, season);
        }
        [HttpGet]
        public async Task<IActionResult> GetActivePlayers(CancellationToken cancellationToken)
        {
            var player = await _mediator.Send(new GetActivePlayersQuery(), cancellationToken);
            return Ok(player);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var player = await _mediator.Send(new GetPlayerByIdQuery(id), cancellationToken);
            return Ok(player);
        }

    }
}
