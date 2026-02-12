using DumpsterLeagueLeaderboard.Application.Features.LeagueEventFeatures.Queries.GetLeagueEventById;
using DumpsterLeagueLeaderboard.Application.Features.LeagueEventFeatures.Requests;
using DumpsterLeagueLeaderboard.Application.Features.LeagueEventFeatures.Commands.AddLeagueEvent;
using DumpsterLeagueLeaderboard.Application.Features.LeagueEventFeatures.Queries.GetActiveLeagueEvents;
using DumpsterLeagueLeaderboard.Application.Features.PlayersFeatures.Queries.GetPlayerById;
using DumpsterLeagueLeaderboard.Application.Features.SeasonFeatures.Commands.AddSeason;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using DumpsterLeagueLeaderboard.Application.Features.SeasonFeatures.Requests;
using DumpsterLeagueLeaderboard.Application.Features.SeasonFeatures.Queries.GetSeasonsByLeagueEvent;
using DumpsterLeagueLeaderboard.Application.Features.PlayersFeatures.Requests;
using DumpsterLeagueLeaderboard.Application.Features.PlayersFeatures.Command.AddPlayer;
using DumpsterLeagueLeaderboard.Application.Features.PlayersFeatures.Queries.GetActivePlayers;

namespace DumpsterLeagueLeaderboard.WebApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v1/players")]
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
