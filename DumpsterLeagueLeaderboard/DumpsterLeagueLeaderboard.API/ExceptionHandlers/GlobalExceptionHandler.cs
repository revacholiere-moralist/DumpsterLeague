using System.Diagnostics;
using System.Net;
using DumpsterLeagueLeaderboard.Application.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace DumpsterLeagueLeaderboard.WebApi.ExceptionHandlers;
public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger = logger;
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        string? currentId = Activity.Current?.Id ?? httpContext.TraceIdentifier;
        Dictionary<string, object> otherDetails = new()
        {
            { "CurrentId", currentId },
            { "TraceId", Convert.ToString(Activity.Current!.Context.TraceId)! }
        };

        var statusCode = exception switch
        {
            OperationCanceledException => (int)HttpStatusCode.ServiceUnavailable,
            BadRequestException => (int)HttpStatusCode.BadRequest,
            UnauthorizedAccessException => (int)HttpStatusCode.Forbidden,
            NotFoundException => (int)HttpStatusCode.NotFound,
                       
            _ => (int)HttpStatusCode.InternalServerError
        };

        var exceptionTitle = exception switch
        {
            OperationCanceledException => "Service Unavailable",
            BadRequestException => "Bad Request",
            UnauthorizedAccessException => "Unauthorised",
            NotFoundException => "Resource not found",
            DatabaseException => "Database Error",
            
            _ => "An unexpected error occurred"
        };
        var problemDetail = new ProblemDetails
            {
                Status = statusCode,
                Type = exception.GetType().Name,
                Title = exceptionTitle,
                Detail = exception.Message,
                Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}",
                Extensions = otherDetails!
            };
        await httpContext.Response.WriteAsJsonAsync(
            problemDetail,
            cancellationToken
        );
        _logger.LogError(@"Exception occured 
                            with status code {@statusCode} 
                            with type {@exceptionType} 
                            on instance {@instance} 
                            with message {@message}", problemDetail.Status, problemDetail.Type, problemDetail.Instance, problemDetail.Detail);
        return true;
    }
}