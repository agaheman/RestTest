using CSharpFunctionalExtensions;
using FluentValidation.Results;

namespace RestTest.Endpoint.Api;

public static class ResultExtensions
{
    public static Microsoft.AspNetCore.Http.IResult CreateResult<TResult>(this Result<TResult, ValidationResult> serviceResult)
    {
        return serviceResult.IsSuccess
                    ? Results.StatusCode(StatusCodes.Status201Created)
                    : Results.ValidationProblem(serviceResult.Error.ToDictionary());
    }

    public static Microsoft.AspNetCore.Http.IResult QueryReult<TResult>(this Result<TResult, ValidationResult> serviceResult)
    {
        return serviceResult.IsSuccess
        ? serviceResult.Value is null ? Results.NotFound() : Results.Ok(serviceResult.Value)
        : Results.ValidationProblem(serviceResult.Error.ToDictionary());
    }
}