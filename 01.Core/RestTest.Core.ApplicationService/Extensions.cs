using CSharpFunctionalExtensions;
using FluentValidation.Results;

namespace RestTest.Core.ApplicationService;

public static class Extensions
{
    public static Result<TResult, ValidationResult> CreateOutput<TResult>(TResult resultSet, ValidationResult validationResultSet)
    {
        return validationResultSet.IsValid
            ? Result.Success<TResult, ValidationResult>(resultSet)
            : Result.Failure<TResult, ValidationResult>(validationResultSet);
    }
}