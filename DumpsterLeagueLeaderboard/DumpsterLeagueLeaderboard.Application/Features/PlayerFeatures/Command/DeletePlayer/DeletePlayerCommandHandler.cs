using DumpsterLeagueLeaderboard.Application.Repositories;
using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Commands;
using DumpsterLeagueLeaderboard.Domain.Entities;
using MediatR;
using DumpsterLeagueLeaderboard.Application.Features.PlayerFeatures.Responses;
using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Queries;
namespace DumpsterLeagueLeaderboard.Application.Features.PlayerFeatures.Command.DeletePlayer;
    
public class DeletePlayerCommandHandler : IRequestHandler<DeletePlayerCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPlayerRepository _playerRepository;
    private readonly IPlayerQueryRepository _playerQueryRepository;

    public DeletePlayerCommandHandler(
        IUnitOfWork unitOfWork,
        IPlayerRepository playerRepository)
    {
        _unitOfWork = unitOfWork;
        _playerRepository = playerRepository;
    }

    public async Task Handle(DeletePlayerCommand request, CancellationToken cancellationToken)
    {
        var existingPlayer = await _playerQueryRepository.GetByIdAsync(request.Request.PlayerId, true, cancellationToken);
        if (existingPlayer is null)
        {
            throw new Exception("Player does not exist.");
        }

        existingPlayer.UpdatedAt = DateTime.UtcNow;
        existingPlayer.IsActive = false;

        await _playerRepository.Update(existingPlayer);
        await _unitOfWork.Save(cancellationToken);
    }
}
