using DumpsterLeagueLeaderboard.Application.Features.TournamentFeatures.Responses;
using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Queries;

using MediatR;

namespace DumpsterLeagueLeaderboard.Application.Features.TournamentFeatures.Queries.GetActiveTournaments;
public class GetActiveTournamentsQueryHandler : IRequestHandler<GetActiveTournamentsQuery, List<TournamentDto>>
{
    private readonly ITournamentQueryRepository _tournamentQueryRepository;

    public GetActiveTournamentsQueryHandler(
        ITournamentQueryRepository tournamentQueryRepository)
    {
        _tournamentQueryRepository = tournamentQueryRepository;
    }

    public async Task<List<TournamentDto>> Handle(GetActiveTournamentsQuery request, CancellationToken cancellationToken)
    {
        var tournaments = await _tournamentQueryRepository.GetAllAsync(true, cancellationToken);  
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