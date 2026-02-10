using DumpsterLeagueLeaderboard.Application.Features.LeagueEventFeatures.Queries.GetLeagueEventById;
using DumpsterLeagueLeaderboard.Application.Features.LeagueEventFeatures.Requests;
using DumpsterLeagueLeaderboard.Application.Features.LeagueEventFeatures.Commands.AddLeagueEvent;
using DumpsterLeagueLeaderboard.Application.Features.LeagueEventFeatures.Queries.GetActiveLeagueEvents;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DumpsterLeagueLeaderboard.WebApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v1/league-events")]
    public class LeagueEventController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeagueEventController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddLeagueEventRequest request, CancellationToken cancellationToken)
        {
            var leagueEvent = await _mediator.Send(new AddLeagueEventCommand(request), cancellationToken);
            return CreatedAtAction(nameof(Create), new { id = leagueEvent.Id }, leagueEvent);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLeagueEventById(Guid id, CancellationToken cancellationToken)
        {
            var leagueEvent = await _mediator.Send(new GetLeagueEventByIdQuery(id), cancellationToken);
            return Ok(leagueEvent);
        }
    }
}
