using CSharpFunctionalExtensions;
using FluentValidation.Results;
using MediatR;
using RestTest.Core.Domain.Notes.Entities;

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

public class GetEmployeeByIdQueryResult
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public long NationalCode { get; set; }
    public List<Note> Notes { get; set; }
}
