using MediatR;
using DumpsterLeagueLeaderboard.Application.Features.LeagueEventFeatures.Responses;
using DumpsterLeagueLeaderboard.Application.Repositories;
using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Queries;
namespace DumpsterLeagueLeaderboard.Application.Features.LeagueEventFeatures.Queries.GetLeagueEventById;
public class GetLeagueEventByIdQueryHandler : IRequestHandler<GetLeagueEventByIdQuery, LeagueEventDto>
{
    private readonly ILeagueEventQueryRepository _leagueEventQueryRepository;

    public GetLeagueEventByIdQueryHandler(
        ILeagueEventQueryRepository leagueEventQueryRepository)
    {
        _leagueEventQueryRepository = leagueEventQueryRepository;
    }

    public async Task<LeagueEventDto> Handle(GetLeagueEventByIdQuery request, CancellationToken cancellationToken)
    {
       var leagueEvent = await _leagueEventQueryRepository.GetByIdAsync(request.Id, cancellationToken);
       if (leagueEvent is null)
       {
           throw new ArgumentException("League event not found.");
       }

       return new LeagueEventDto
       {
           Id = leagueEvent.Id,
           EventName = leagueEvent.EventName,
           IsOngoing = leagueEvent.IsOngoing,
           CreatedAt = leagueEvent.CreatedAt,
           UpdatedAt = leagueEvent.UpdatedAt,
           IsActive = leagueEvent.IsActive
       };
    }
}