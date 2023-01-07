using CSharpFunctionalExtensions;
using FluentValidation.Results;
using MediatR;
using RestTest.Core.Contract.Employees.Commands;
using RestTest.Core.Contract.Employees.Commands.Create;

namespace RestTest.Core.ApplicationService.Employees.Commands.Create;

public class CreateEmployeeCommandHandler :
    IRequestHandler<CreateEmployeeCommand, Result<int, ValidationResult>>
{
    private readonly IEmployeeCommandRepository _employeeCommandRepository;
    private readonly CreateEmployeeCommandValidator _createEmployeeCommandValidator;

    public CreateEmployeeCommandHandler(
        CreateEmployeeCommandValidator createEmployeeCommandValidator,
        IEmployeeCommandRepository employeeCommandRepository)
    {
        _createEmployeeCommandValidator = createEmployeeCommandValidator;
        _employeeCommandRepository = employeeCommandRepository;
    }

    public async Task<Result<int, ValidationResult>> Handle(CreateEmployeeCommand createEmployeeCommand, CancellationToken cancellationToken)
    {
        var validationResult = await _createEmployeeCommandValidator.ValidateAsync(createEmployeeCommand, cancellationToken);

        int repoResult = validationResult.IsValid ? await _employeeCommandRepository.ExecuteAsync(createEmployeeCommand, cancellationToken) : default;

        return Extensions.CreateResult(repoResult, validationResult);
    }
}