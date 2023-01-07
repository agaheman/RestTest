using Microsoft.EntityFrameworkCore;
using RestTest.Core.Contract.Employees.Queries;
using RestTest.Core.Contract.Employees.Queries.GetById;
using static RestTest.Core.Contract.Employees.Queries.GetById.GetEmployeeByIdQueryResult;

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
                Notes = employee.Notes.Select(note => new GetEmployeeById_NotesQueryResult()
                {
                    NoteId = note.Id,
                    Name = note.Name,
                    Content = note.Content,
                    Published = note.Published
                }).ToList()
            })
            .FirstOrDefaultAsync(cancellationToken);
    }
}
