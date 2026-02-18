using DumpsterLeagueLeaderboard.Application.Features.TournamentFeatures.Responses;
using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Queries;

using MediatR;

namespace DumpsterLeagueLeaderboard.Application.Features.TournamentFeatures.Queries.GetTournamentsByEventAndSeason;
public class GetTournamentsByEventAndSeasonQueryHandler : IRequestHandler<GetTournamentsByEventAndSeasonQuery, List<TournamentDto>>
{
    private readonly ITournamentQueryRepository _tournamentQueryRepository;

    public GetTournamentsByEventAndSeasonQueryHandler(
        ITournamentQueryRepository tournamentQueryRepository)
    {
        _tournamentQueryRepository = tournamentQueryRepository;
    }

    public async Task<List<TournamentDto>> Handle(GetTournamentsByEventAndSeasonQuery request, CancellationToken cancellationToken)
    {
        var tournaments = await _tournamentQueryRepository.GetTournamentsByLeagueEventAndSeason(request.LeagueEventId, request.SeasonId, cancellationToken);  
        return tournaments.Select(tournament => new TournamentDto
        {
            Id = tournament.Id,
            LeagueEventId = tournament.LeagueEventId,
            SeasonId = tournament.SeasonId,
            TournamentName = tournament.TournamentName,
            TournamentDate = tournament.TournamentDate,
            CreatedAt = tournament.CreatedAt,
            UpdatedAt = tournament.UpdatedAt,
            IsActive = tournament.IsActive
        }).ToList();
    }
}