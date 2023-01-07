using CSharpFunctionalExtensions;
using FluentValidation.Results;
using MediatR;
using RestTest.Core.Contract.Employees.Queries;
using RestTest.Core.Contract.Employees.Queries.GetById;

namespace RestTest.Core.ApplicationService.Employees.Queries.GetById;

public class GetEmployeeByIdQueryHandler :
    IRequestHandler<GetEmployeeByIdQuery, Result<GetEmployeeByIdQueryResult, ValidationResult>>
{
    private readonly IEmployeeQueryRepository _employeeQueryRepository;
    private readonly GetEmployeeByIdQueryValidator _getEmployeeByIdQueryValidator;

    public GetEmployeeByIdQueryHandler(
        GetEmployeeByIdQueryValidator getEmployeeByIdQueryValidator,
        IEmployeeQueryRepository employeeQueryRepository)
    {
        _getEmployeeByIdQueryValidator = getEmployeeByIdQueryValidator;
        _employeeQueryRepository = employeeQueryRepository;
    }

    public async Task<Result<GetEmployeeByIdQueryResult, ValidationResult>> Handle(GetEmployeeByIdQuery getEmployeeByIdQuery, CancellationToken cancellationToken)
    {
        var validationResult = await _getEmployeeByIdQueryValidator.ValidateAsync(getEmployeeByIdQuery, cancellationToken);

        var repoResult = validationResult.IsValid 
            ? await _employeeQueryRepository.ExecuteAsync(getEmployeeByIdQuery, cancellationToken) 
            : default;

        return Extensions.CreateResult(repoResult, validationResult);
    }
}