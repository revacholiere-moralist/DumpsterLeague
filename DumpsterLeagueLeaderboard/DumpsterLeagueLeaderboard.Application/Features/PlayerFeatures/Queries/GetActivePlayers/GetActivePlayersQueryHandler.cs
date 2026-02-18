using DumpsterLeagueLeaderboard.Application.Features.PlayerFeatures.Responses;
using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Queries;
using DumpsterLeagueLeaderboard.Application.Repositories;

using MediatR;

namespace DumpsterLeagueLeaderboard.Application.Features.PlayerFeatures.Queries.GetActivePlayers;

public class GetActivePlayersQueryHandler : IRequestHandler<GetActivePlayersQuery, List<PlayerDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPlayerQueryRepository _playerQueryRepository;

    public GetActivePlayersQueryHandler(
        IUnitOfWork unitOfWork,
        IPlayerQueryRepository playerQueryRepository)
    {
        _unitOfWork = unitOfWork;
        _playerQueryRepository = playerQueryRepository;
    }

    public async Task<List<PlayerDto>> Handle(GetActivePlayersQuery request, CancellationToken cancellationToken)
    {
        var players = await _playerQueryRepository.GetAllAsync(cancellationToken);
        return players.Select(p => new PlayerDto
        {
            Id = p.Id,
            CurrentDiscordId = p.CurrentDiscordId,
            CurrentDiscordName = p.CurrentDiscordName,
            CurrentIgn = p.CurrentIgn,
            CurrentPoints = p.CurrentPoints,
            CreatedAt = p.CreatedAt,
            UpdatedAt = p.UpdatedAt,
            IsActive = p.IsActive
        }).ToList();
    }
}
