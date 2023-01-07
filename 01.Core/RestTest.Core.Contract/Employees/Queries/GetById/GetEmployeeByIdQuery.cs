using CSharpFunctionalExtensions;
using FluentValidation.Results;
using MediatR;

namespace RestTest.Core.Contract.Employees.Queries.GetById;

public class GetEmployeeByIdQuery : IRequest<Result<GetEmployeeByIdQueryResult, ValidationResult>>
{
    public int EmployeeId { get; set; }


    public GetEmployeeByIdQuery(int employeeId)
    {
        EmployeeId = employeeId;
    }

    public static implicit operator GetEmployeeByIdQuery(int employeeId) => new(employeeId);
}
