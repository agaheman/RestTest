using CSharpFunctionalExtensions;
using FluentValidation.Results;
using MediatR;
using RestTest.Core.Domain.Employees.Entities;

namespace RestTest.Core.Contract.Employees.Commands.Create;

public class CreateEmployeeCommand : IRequest<Result<int, ValidationResult>>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public long NationalCode { get; set; }

    public Employee MapToEmployee()
    {
        return new Employee()
        {
            FirstName = FirstName,
            LastName = LastName,
            Email = Email,
            NationalCode = NationalCode
        };
    }
}
