using DumpsterLeagueLeaderboard.Application.Features.LeagueEventFeatures.Requests;
using DumpsterLeagueLeaderboard.Application.Features.PlayerFeatures.Requests;
using DumpsterLeagueLeaderboard.Application.Features.PlayerFeatures.Responses;
using DumpsterLeagueLeaderboard.Domain.Entities;
using MediatR;
namespace DumpsterLeagueLeaderboard.Application.Features.PlayerFeatures.Command.AddPlayer;

public record AddPlayerCommand(AddPlayerRequest Request) : IRequest<PlayerDto>;
