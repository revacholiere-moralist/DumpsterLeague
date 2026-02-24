using DumpsterLeagueLeaderboard.Application.Exceptions;
using DumpsterLeagueLeaderboard.Application.Features.LeagueEventFeatures.Responses;
using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Commands;
using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Queries;
using DumpsterLeagueLeaderboard.Application.Repositories;
using DumpsterLeagueLeaderboard.Domain.Entities;

using MediatR;

namespace DumpsterLeagueLeaderboard.Application.Features.LeagueEventFeatures.Commands.DeleteLeagueEvent;

public class DeleteLeagueEventCommandHandler : IRequestHandler<DeleteLeagueEventCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILeagueEventRepository _leagueEventRepository;
    private readonly ILeagueEventQueryRepository _leagueEventQueryRepository;

    public DeleteLeagueEventCommandHandler(
        IUnitOfWork unitOfWork,
        ILeagueEventRepository leagueEventRepository,
        ILeagueEventQueryRepository leagueEventQueryRepository)
    {
        _unitOfWork = unitOfWork;
        _leagueEventRepository = leagueEventRepository;
        _leagueEventQueryRepository = leagueEventQueryRepository;
    }

    public async Task Handle(DeleteLeagueEventCommand request, CancellationToken cancellationToken)
    {
        var existingLeagueEvent = await _leagueEventQueryRepository.GetByIdAsync(request.LeagueEventId, true, cancellationToken);
        if (existingLeagueEvent is null)
        {
            throw new Exception("League event does not exist.");
        }
        
        existingLeagueEvent.UpdatedAt = DateTime.UtcNow;
        existingLeagueEvent.IsActive = false;
        
        await _leagueEventRepository.Update(existingLeagueEvent);
        try
        {
            await _unitOfWork.Save(cancellationToken);
        }
        catch (Exception ex)
        {
            throw new DatabaseException(string.Format("exception occurred during League Event Creation: {0}", ex.Message));
        }
    }
}
