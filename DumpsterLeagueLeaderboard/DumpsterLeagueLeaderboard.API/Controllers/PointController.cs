using Microsoft.AspNetCore.Mvc;

using DumpsterLeagueLeaderboard.Application.Features.PointFeatures.Commands.AddPoint;
using DumpsterLeagueLeaderboard.Application.Features.PointFeatures.Queries.GetPointsByEventAndSeason;
using DumpsterLeagueLeaderboard.Application.Features.PointFeatures.Requests;

using MediatR;

namespace DumpsterLeagueLeaderboard.WebApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v1/points")]
    public class PointController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PointController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddPointRequest request, CancellationToken cancellationToken)
        {
            var point = await _mediator.Send(new AddPointCommand(request), cancellationToken);
            return CreatedAtAction(nameof(Create), new { id = point.Id }, point);
        }

        [HttpGet("league-events/{leagueEventId}/seasons/{seasonId}")]
        public async Task<IActionResult> GetPointsByEventAndSeason(Guid leagueEventId, Guid seasonId, CancellationToken cancellationToken)
        {
            var points = await _mediator.Send(new GetPointsByEventAndSeasonQuery(leagueEventId, seasonId), cancellationToken);
            return Ok(points);
        }
    }
}
