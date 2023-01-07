using FluentValidation;
using RestTest.Core.Contract.Employees.Queries.GetById;

namespace RestTest.Core.ApplicationService.Employees.Queries.GetById;

public class GetEmployeeByIdQueryValidator : AbstractValidator<GetEmployeeByIdQuery>
{
    public GetEmployeeByIdQueryValidator()
    {
        RuleFor(x => x.EmployeeId).NotEmpty();
    }
}