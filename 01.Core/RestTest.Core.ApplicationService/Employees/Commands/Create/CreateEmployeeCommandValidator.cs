using FluentValidation;
using RestTest.Core.Contract.Employees.Commands.Create;

namespace RestTest.Core.ApplicationService.Employees.Commands.Create;

public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
{
    public CreateEmployeeCommandValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("نام الزامی است.");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("نام خانوادگی الزامی است.");
        RuleFor(x => x.NationalCode).NotEmpty().WithMessage("کد ملی الزامی است.");
        RuleFor(x => x.Email).EmailAddress().WithMessage("ایمیل الزامی است.");
    }
}