using RestTest.Core.Contract.Employees.Queries.GetById;

namespace RestTest.Core.Contract.Employees.Queries;

public interface IEmployeeQueryRepository
{
    Task<GetEmployeeByIdQueryResult> ExecuteAsync(GetEmployeeByIdQuery getEmployeeByIdQuery, CancellationToken cancellationToken);
}
