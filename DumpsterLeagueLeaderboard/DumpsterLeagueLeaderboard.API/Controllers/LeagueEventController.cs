using Microsoft.AspNetCore.Mvc;

using DumpsterLeagueLeaderboard.Application.Features.LeagueEventFeatures.Commands.AddLeagueEvent;
using DumpsterLeagueLeaderboard.Application.Features.LeagueEventFeatures.Queries.GetLeagueEventById;
using DumpsterLeagueLeaderboard.Application.Features.LeagueEventFeatures.Requests;

using MediatR;
using DumpsterLeagueLeaderboard.Application.Features.LeagueEventFeatures.Commands.UpdateLeagueEvent;
using DumpsterLeagueLeaderboard.Application.Features.LeagueEventFeatures.Commands.DeleteLeagueEvent;

namespace DumpsterLeagueLeaderboard.WebApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version}/league-events")]
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

        [HttpPut]
        public async Task<IActionResult> Update(UpdateLeagueEventRequest request, CancellationToken cancellationToken)
        {
            var leagueEvent = await _mediator.Send(new UpdateLeagueEventCommand(request), cancellationToken);
            return Ok(leagueEvent);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid leagueEventId, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteLeagueEventCommand(leagueEventId), cancellationToken);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLeagueEventById(Guid id, CancellationToken cancellationToken)
        {
            var leagueEvent = await _mediator.Send(new GetLeagueEventByIdQuery(id), cancellationToken);
            return Ok(leagueEvent);
        }
    }
}
