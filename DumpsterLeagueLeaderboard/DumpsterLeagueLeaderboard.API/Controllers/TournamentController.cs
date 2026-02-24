using Microsoft.AspNetCore.Mvc;

using DumpsterLeagueLeaderboard.Application.Features.TournamentFeatures.Commands.AddTournament;
using DumpsterLeagueLeaderboard.Application.Features.TournamentFeatures.Queries.GetTournamentsByEventAndSeason;
using DumpsterLeagueLeaderboard.Application.Features.TournamentFeatures.Queries.GetTournamentsByLeagueEvent;

using MediatR;
using DumpsterLeagueLeaderboard.Application.Features.TournamentFeatures.Requests;

namespace DumpsterLeagueLeaderboard.WebApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version}/tournaments")]
    public class TournamentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TournamentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddTournamentRequest request, CancellationToken cancellationToken)
        {
            var tournament = await _mediator.Send(new AddTournamentCommand(request), cancellationToken);
            return CreatedAtAction(nameof(Create), new { id = tournament.Id }, tournament);
        }

        [HttpGet("league-events/{leagueEventId}")]
        public async Task<IActionResult> GetTournamentsByLeagueEventId(Guid leagueEventId, CancellationToken cancellationToken)
        {
            var tournaments = await _mediator.Send(new GetTournamentsByLeagueEventQuery(leagueEventId), cancellationToken);
            return Ok(tournaments);
        }

        [HttpGet("league-events/{leagueEventId}/seasons/{seasonId}")]
        public async Task<IActionResult> GetTournamentsByLeagueEventAndSeason(Guid leagueEventId, Guid seasonId, CancellationToken cancellationToken)
        {
            var tournaments = await _mediator.Send(new GetTournamentsByEventAndSeasonQuery(leagueEventId, seasonId), cancellationToken);
            return Ok(tournaments);
        }
    }
}
