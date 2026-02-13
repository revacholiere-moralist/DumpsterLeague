using DumpsterLeagueLeaderboard.Application.Features.LeagueEventFeatures.Queries.GetLeagueEventById;
using DumpsterLeagueLeaderboard.Application.Features.LeagueEventFeatures.Requests;
using DumpsterLeagueLeaderboard.Application.Features.LeagueEventFeatures.Commands.AddLeagueEvent;
using DumpsterLeagueLeaderboard.Application.Features.LeagueEventFeatures.Queries.GetActiveLeagueEvents;
using DumpsterLeagueLeaderboard.Application.Features.SeasonFeatures.Commands.AddSeason;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using DumpsterLeagueLeaderboard.Application.Features.SeasonFeatures.Requests;
using DumpsterLeagueLeaderboard.Application.Features.SeasonFeatures.Queries.GetSeasonsByLeagueEvent;

namespace DumpsterLeagueLeaderboard.WebApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v1/seasons")]
    public class SeasonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SeasonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddSeasonRequest request, CancellationToken cancellationToken)
        {
            var season = await _mediator.Send(new AddSeasonCommand(request), cancellationToken);
            return CreatedAtAction(nameof(Create), new { id = season.Id }, season);
        }

        [HttpGet("league-events/{leagueEventId}")]
        public async Task<IActionResult> GetSeasonsByLeagueEventId(Guid leagueEventId, CancellationToken cancellationToken)
        {
            var seasons = await _mediator.Send(new GetSeasonsByLeagueEventIdQuery(leagueEventId), cancellationToken);
            return Ok(seasons);
        }
    }
}
