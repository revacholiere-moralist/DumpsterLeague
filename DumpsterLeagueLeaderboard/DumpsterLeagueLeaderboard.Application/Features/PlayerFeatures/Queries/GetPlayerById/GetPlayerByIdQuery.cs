using DumpsterLeagueLeaderboard.Application.Features.PlayerFeatures.Requests;
using DumpsterLeagueLeaderboard.Application.Features.PlayerFeatures.Responses;
using MediatR;
namespace DumpsterLeagueLeaderboard.Application.Features.PlayerFeatures.Queries.GetPlayerById;

public record GetPlayerByIdQuery(Guid Id) : IRequest<PlayerDto>;