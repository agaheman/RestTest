using RestTest.Core.Contract.Employees.Commands.Create;

namespace RestTest.Core.Contract.Employees.Commands;

public interface IEmployeeCommandRepository
{
    Task<int> ExecuteAsync(CreateEmployeeCommand createEmployeeCommand, CancellationToken cancellationToken);
}
