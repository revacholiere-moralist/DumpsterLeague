using DumpsterLeagueLeaderboard.Application.Features.LeagueEventFeatures.Responses;
using DumpsterLeagueLeaderboard.Application.Features.SeasonFeatures.Responses;
using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Commands;
using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Queries;
using DumpsterLeagueLeaderboard.Application.Repositories;
using DumpsterLeagueLeaderboard.Domain.Entities;

using MediatR;

namespace DumpsterLeagueLeaderboard.Application.Features.SeasonFeatures.Commands.AddSeason;
public class AddSeasonCommandHandler : IRequestHandler<AddSeasonCommand, SeasonDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISeasonRepository _seasonRepository;
    private readonly ILeagueEventQueryRepository _leagueEventQueryRepository;

    public AddSeasonCommandHandler(
        IUnitOfWork unitOfWork,
        ISeasonRepository seasonRepository,
        ILeagueEventQueryRepository leagueEventQueryRepository)
    {
        _unitOfWork = unitOfWork;
        _seasonRepository = seasonRepository;
        _leagueEventQueryRepository = leagueEventQueryRepository;
    }

    public async Task<SeasonDto> Handle(AddSeasonCommand request, CancellationToken cancellationToken)
    {
        var leagueEvent = await _leagueEventQueryRepository.GetByIdAsync(request.Request.LeagueEventId, cancellationToken);
        if (leagueEvent is null)
        {
            throw new ArgumentException("League event not found.");
        }
        var season = new Season
        {
            SeasonName = request.Request.SeasonName,
            SeasonStartDate = request.Request.SeasonStartDate,
            SeasonEndDate = request.Request.SeasonEndDate,
            IsCurrent = request.Request.IsCurrent,
            LeagueEventId = request.Request.LeagueEventId,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            IsActive = true
        };

        var addedSeason = await _seasonRepository.AddAsync(season, cancellationToken);

        try
        {
            await _unitOfWork.Save(cancellationToken);
            return new SeasonDto
            {
                Id = addedSeason.Id,
                LeagueEventName = leagueEvent.EventName,
                SeasonName = addedSeason.SeasonName,
                SeasonStartDate = addedSeason.SeasonStartDate,
                SeasonEndDate = addedSeason.SeasonEndDate,
                IsCurrent = addedSeason.IsCurrent,
                LeagueEventId = addedSeason.LeagueEventId,
                CreatedAt = addedSeason.CreatedAt,
                UpdatedAt = addedSeason.UpdatedAt,
                IsActive = addedSeason.IsActive
            };
        }
        //TODO: More specific exception handling
        catch (Exception ex)
        {
            // Handle exception (e.g., log it)
            throw new ApplicationException("An error occurred while saving the league event.", ex);
        }


    }
}
