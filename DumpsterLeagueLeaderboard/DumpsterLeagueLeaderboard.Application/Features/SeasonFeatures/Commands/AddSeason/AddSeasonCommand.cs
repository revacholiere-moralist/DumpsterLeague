using DumpsterLeagueLeaderboard.Application.Features.SeasonFeatures.Requests;
using DumpsterLeagueLeaderboard.Application.Features.SeasonFeatures.Responses;

using MediatR;

namespace DumpsterLeagueLeaderboard.Application.Features.SeasonFeatures.Commands.AddSeason;

public record AddSeasonCommand(AddSeasonRequest Request) : IRequest<SeasonDto>;