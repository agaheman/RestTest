using Microsoft.EntityFrameworkCore;
using RestTest.Core.Contract.Employees.Queries;
using RestTest.Core.Contract.Employees.Queries.GetById;

namespace RestTest.Infra.Data.Sql.Query.Employees.Repositories;

public class EmployeeQueryRepository : IEmployeeQueryRepository
{
    private readonly RestTestQueryContext _queryContext;

    public EmployeeQueryRepository(RestTestQueryContext restTestQueryContext)
    {
        _queryContext = restTestQueryContext;
    }
    public Task<GetEmployeeByIdQueryResult> ExecuteAsync(GetEmployeeByIdQuery getEmployeeByIdQuery, CancellationToken cancellationToken)
    {
        return _queryContext.Employee
            .Where(employee => employee.Id == getEmployeeByIdQuery.EmployeeId)
            .Include(n => n.Notes)
            .Select(employee => new GetEmployeeByIdQueryResult()
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                NationalCode = employee.NationalCode,
                Notes = employee.Notes.ToList()
            })
            .FirstOrDefaultAsync(cancellationToken);
    }
}
