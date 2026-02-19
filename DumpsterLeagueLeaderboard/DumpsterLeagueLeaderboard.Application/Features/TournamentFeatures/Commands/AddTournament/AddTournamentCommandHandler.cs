using DumpsterLeagueLeaderboard.Application.Features.LeagueEventFeatures.Responses;
using DumpsterLeagueLeaderboard.Application.Features.SeasonFeatures.Responses;
using DumpsterLeagueLeaderboard.Application.Features.TournamentFeatures.Responses;
using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Commands;
using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Queries;
using DumpsterLeagueLeaderboard.Application.Repositories;
using DumpsterLeagueLeaderboard.Domain.Entities;

using MediatR;

namespace DumpsterLeagueLeaderboard.Application.Features.TournamentFeatures.Commands.AddTournament;

public class AddTournamentCommandHandler : IRequestHandler<AddTournamentCommand, TournamentDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITournamentRepository _tournamentRepository;
    private readonly ILeagueEventQueryRepository _leagueEventQueryRepository;
    private readonly ISeasonQueryRepository _seasonQueryRepository;

    public AddTournamentCommandHandler(
        IUnitOfWork unitOfWork,
        ITournamentRepository tournamentRepository,
        ILeagueEventQueryRepository leagueEventQueryRepository,
        ISeasonQueryRepository seasonQueryRepository)
    {
        _unitOfWork = unitOfWork;
        _tournamentRepository = tournamentRepository;
        _leagueEventQueryRepository = leagueEventQueryRepository;
        _seasonQueryRepository = seasonQueryRepository;
    }

    public async Task<TournamentDto> Handle(AddTournamentCommand request, CancellationToken cancellationToken)
    {
        if (request.Request.LeagueEventId is not null && request.Request.SeasonId is not null)
        {
            var leagueEvent = await _leagueEventQueryRepository.GetByIdAsync(request.Request.LeagueEventId!.Value, true, cancellationToken);
            if (leagueEvent is null)
            {
                throw new ArgumentException("League event not found.");
            }
            var season = await _seasonQueryRepository.GetByIdAsync(request.Request.SeasonId!.Value, true, cancellationToken);
            if (season is null)
            {
                throw new ArgumentException("Season not found.");
            }
        }

        var tournament = new Tournament
        {
            TournamentName = request.Request.TournamentName,
            TournamentDate = request.Request.TournamentDate,
            LeagueEventId = request.Request.LeagueEventId,
            SeasonId = request.Request.SeasonId,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            IsActive = true
        };
        var addedTournament = await _tournamentRepository.AddAsync(tournament, cancellationToken);

        try
        {
            await _unitOfWork.Save(cancellationToken);
            return new TournamentDto
            {
                Id = addedTournament.Id,
                TournamentName = addedTournament.TournamentName,
                TournamentDate = addedTournament.TournamentDate,
                LeagueEventId = addedTournament.LeagueEventId,
                SeasonId = addedTournament.SeasonId,
                StartGgLink = addedTournament.StartGgLink,
                CreatedAt = addedTournament.CreatedAt,
                UpdatedAt = addedTournament.UpdatedAt,
                IsActive = addedTournament.IsActive
            };
        }
        //TODO: More specific exception handling
        catch (Exception ex)
        {
            // Handle exception (e.g., log it)
            throw new ApplicationException("An error occurred while saving the tournament.", ex);
        }

    }
}
