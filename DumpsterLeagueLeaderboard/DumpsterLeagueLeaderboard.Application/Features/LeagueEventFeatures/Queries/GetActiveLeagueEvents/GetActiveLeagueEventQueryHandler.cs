using MediatR;
using DumpsterLeagueLeaderboard.Application.Features.LeagueEventFeatures.Responses;
using DumpsterLeagueLeaderboard.Application.Repositories;
using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Queries;
namespace DumpsterLeagueLeaderboard.Application.Features.LeagueEventFeatures.Queries.GetActiveLeagueEvents;
public class GetActiveLeagueEventQueryHandler : IRequestHandler<GetActiveLeagueEventQuery, List<LeagueEventDto>>
{
    private readonly ILeagueEventQueryRepository _leagueEventQueryRepository;

    public GetActiveLeagueEventQueryHandler(
        ILeagueEventQueryRepository leagueEventQueryRepository)
    {
        _leagueEventQueryRepository = leagueEventQueryRepository;
    }

    public async Task<List<LeagueEventDto>> Handle(GetActiveLeagueEventQuery request, CancellationToken cancellationToken)
    {
       var leagueEvents = await _leagueEventQueryRepository.GetActiveLeagueEventsAsync(cancellationToken);
       if (leagueEvents is null || !leagueEvents.Any())
       {
           throw new ArgumentException("No active league events found.");
       }
       
       return leagueEvents.Select(leagueEvent => new LeagueEventDto
       {
           Id = leagueEvent.Id,
           EventName = leagueEvent.EventName,
           IsOngoing = leagueEvent.IsOngoing,
           CreatedAt = leagueEvent.CreatedAt,
           UpdatedAt = leagueEvent.UpdatedAt,
           IsActive = leagueEvent.IsActive
       }).ToList();
    }
}