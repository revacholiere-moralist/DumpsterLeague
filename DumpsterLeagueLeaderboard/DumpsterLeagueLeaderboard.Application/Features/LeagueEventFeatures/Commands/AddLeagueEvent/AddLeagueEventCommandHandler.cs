using DumpsterLeagueLeaderboard.Application.Features.LeagueEventFeatures.Responses;
using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Commands;
using DumpsterLeagueLeaderboard.Application.Repositories;
using DumpsterLeagueLeaderboard.Domain.Entities;

using MediatR;

namespace DumpsterLeagueLeaderboard.Application.Features.LeagueEventFeatures.Commands.AddLeagueEvent;
public class AddLeagueEventCommandHandler : IRequestHandler<AddLeagueEventCommand, LeagueEventDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILeagueEventRepository _leagueEventRepository;

    public AddLeagueEventCommandHandler(
        IUnitOfWork unitOfWork,
        ILeagueEventRepository leagueEventRepository)
    {
        _unitOfWork = unitOfWork;
        _leagueEventRepository = leagueEventRepository;
    }

    public async Task<LeagueEventDto> Handle(AddLeagueEventCommand request, CancellationToken cancellationToken)
    {
        var leagueEvent = new LeagueEvent
        {
            EventName = request.Request.EventName,
            IsOngoing = request.Request.IsOngoing,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            IsActive = true
        };

        var addedLeagueEvent = await _leagueEventRepository.AddAsync(leagueEvent);

        try
        {
            await _unitOfWork.Save(cancellationToken);
            return new LeagueEventDto
            {
                Id = addedLeagueEvent.Id,
                EventName = addedLeagueEvent.EventName,
                IsOngoing = addedLeagueEvent.IsOngoing,
                CreatedAt = addedLeagueEvent.CreatedAt,
                UpdatedAt = addedLeagueEvent.UpdatedAt,
                IsActive = addedLeagueEvent.IsActive
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
