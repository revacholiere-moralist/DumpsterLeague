using DumpsterLeagueLeaderboard.Application.Features.SeasonFeatures.Requests;
using DumpsterLeagueLeaderboard.Application.Features.SeasonFeatures.Responses;
using MediatR;
using DumpsterLeagueLeaderboard.Application.Features.LeagueEventFeatures.Responses;

namespace DumpsterLeagueLeaderboard.Application.Features.SeasonFeatures.Commands.AddSeason;

public record AddSeasonCommand(AddSeasonRequest Request) : IRequest<SeasonDto>;