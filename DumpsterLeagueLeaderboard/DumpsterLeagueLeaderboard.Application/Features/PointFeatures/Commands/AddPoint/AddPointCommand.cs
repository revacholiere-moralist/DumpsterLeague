using DumpsterLeagueLeaderboard.Application.Features.LeagueEventFeatures.Requests;
using DumpsterLeagueLeaderboard.Application.Features.PlayerFeatures.Requests;
using DumpsterLeagueLeaderboard.Application.Features.PlayerFeatures.Responses;
using DumpsterLeagueLeaderboard.Application.Features.PointFeatures.Requests;
using DumpsterLeagueLeaderboard.Application.Features.PointFeatures.Responses;
using DumpsterLeagueLeaderboard.Domain.Entities;
using MediatR;
namespace DumpsterLeagueLeaderboard.Application.Features.PointFeatures.Commands.AddPoint;

public record AddPointCommand(AddPointRequest Request) : IRequest<PointDto>;
