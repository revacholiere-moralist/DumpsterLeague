using MediatR;
using DumpsterLeagueLeaderboard.Application.Features.LeagueEventFeatures.Responses;
using DumpsterLeagueLeaderboard.Application.Repositories;
using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Queries;
using DumpsterLeagueLeaderboard.Application.Features.LeagueEventFeatures.Queries.GetLeagueEventById;
using DumpsterLeagueLeaderboard.Domain.Entities;
using DumpsterLeagueLeaderboard.Application.Features.SeasonFeatures.Responses;
namespace DumpsterLeagueLeaderboard.Application.Features.SeasonFeatures.Queries.GetSeasonsByLeagueEvent;
public class GetSeasonsByLeagueEventQueryHandler : IRequestHandler<GetSeasonsByLeagueEventIdQuery, List<SeasonDto>>
{
    private readonly ISeasonQueryRepository _seasonQueryRepository;
    private readonly ILeagueEventQueryRepository _leagueEventQueryRepository;

    public GetSeasonsByLeagueEventQueryHandler(
        ISeasonQueryRepository seasonQueryRepository,
        ILeagueEventQueryRepository leagueEventQueryRepository)
    {
        _seasonQueryRepository = seasonQueryRepository;
        _leagueEventQueryRepository = leagueEventQueryRepository;
    }

    public async Task<List<SeasonDto>> Handle(GetSeasonsByLeagueEventIdQuery request, CancellationToken cancellationToken)
    {
        var seasons = await _seasonQueryRepository.GetSeasonsByLeagueEvent(request.LeagueEventId, cancellationToken);
        var leagueEvent = await _leagueEventQueryRepository.GetByIdAsync(request.LeagueEventId, cancellationToken);
        if (leagueEvent is null)
        {
            throw new ArgumentException("League event not found.");
        }

        return seasons.Select(season => new SeasonDto
        {
            Id = season.Id,
            LeagueEventId = leagueEvent.Id,
            LeagueEventName = leagueEvent.EventName,
            SeasonName = season.SeasonName,
            SeasonStartDate = season.SeasonStartDate,
            SeasonEndDate = season.SeasonEndDate,
            CreatedAt = season.CreatedAt,
            UpdatedAt = season.UpdatedAt,
            IsActive = season.IsActive
        }).ToList();
    }
}