using DumpsterLeagueLeaderboard.Application.Features.LeagueEventFeatures.Responses;
using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Commands;
using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Queries;
using DumpsterLeagueLeaderboard.Application.Repositories;
using DumpsterLeagueLeaderboard.Domain.Entities;

using MediatR;

namespace DumpsterLeagueLeaderboard.Application.Features.LeagueEventFeatures.Commands.UpdateLeagueEvent;
public class UpdateLeagueEventCommandHandler : IRequestHandler<UpdateLeagueEventCommand, LeagueEventDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILeagueEventRepository _leagueEventRepository;
    private readonly ILeagueEventQueryRepository _leagueEventQueryRepository;

    public UpdateLeagueEventCommandHandler(
        IUnitOfWork unitOfWork,
        ILeagueEventRepository leagueEventRepository,
        ILeagueEventQueryRepository leagueEventQueryRepository)
    {
        _unitOfWork = unitOfWork;
        _leagueEventRepository = leagueEventRepository;
        _leagueEventQueryRepository = leagueEventQueryRepository;
    }

    public async Task<LeagueEventDto> Handle(UpdateLeagueEventCommand request, CancellationToken cancellationToken)
    {
        var existingLeagueEvent = await _leagueEventQueryRepository.GetByIdAsync(request.Request.LeagueEventId, true, cancellationToken);
        if (existingLeagueEvent is null)
        {
            throw new Exception("League event with id does not exist.");
        }

        existingLeagueEvent.EventName = request.Request.EventName;
        existingLeagueEvent.IsOngoing = request.Request.IsOngoing;
        existingLeagueEvent.UpdatedAt = DateTime.UtcNow;

        await _leagueEventRepository.Update(existingLeagueEvent);

        await _unitOfWork.Save(cancellationToken);
        return new LeagueEventDto
        {
            Id = existingLeagueEvent.Id,
            EventName = existingLeagueEvent.EventName,
            IsOngoing = existingLeagueEvent.IsOngoing,
            CreatedAt = existingLeagueEvent.CreatedAt,
            UpdatedAt = existingLeagueEvent.UpdatedAt,
            IsActive = existingLeagueEvent.IsActive
        };
        
    }
}
