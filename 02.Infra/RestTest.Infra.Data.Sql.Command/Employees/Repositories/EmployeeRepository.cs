using RestTest.Core.Contract.Employees.Commands;
using RestTest.Core.Contract.Employees.Commands.Create;

namespace RestTest.Infra.Data.Sql.Command.Employees.Repositories
{
    public class EmployeeCommandRepository : IEmployeeCommandRepository
    {
        private readonly RestTestContext restTestContext;

        public EmployeeCommandRepository(RestTestContext restTestContext)
        {
            this.restTestContext = restTestContext;
        }

        public Task<int> ExecuteAsync(CreateEmployeeCommand createEmployeeCommand, CancellationToken cancellationToken)
        {
            restTestContext.Employee.AddAsync(createEmployeeCommand.MapToEmployee(), cancellationToken);
            return restTestContext.SaveChangesAsync(cancellationToken);
        }
    }
}