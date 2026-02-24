using DumpsterLeagueLeaderboard.Application.Features.LeaderboardFeatures.Responses;
using DumpsterLeagueLeaderboard.Application.Features.PlayerFeatures.Requests;
using MediatR;

namespace DumpsterLeagueLeaderboard.Application.Features.LeaderboardFeatures.Commands.GenerateLeaderboard;

public record GenerateLeaderboardCommand(GenerateLeaderboardRequest Request) : IRequest<List<LeaderboardDto>>;