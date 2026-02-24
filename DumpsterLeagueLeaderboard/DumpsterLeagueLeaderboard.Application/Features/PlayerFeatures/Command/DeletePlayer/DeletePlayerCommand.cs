using DumpsterLeagueLeaderboard.Application.Features.LeagueEventFeatures.Requests;
using DumpsterLeagueLeaderboard.Application.Features.PlayerFeatures.Requests;
using DumpsterLeagueLeaderboard.Application.Features.PlayerFeatures.Responses;
using DumpsterLeagueLeaderboard.Domain.Entities;
using MediatR;
namespace DumpsterLeagueLeaderboard.Application.Features.PlayerFeatures.Command.DeletePlayer;

public record DeletePlayerCommand(UpdatePlayerRequest Request) : IRequest;
