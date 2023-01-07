using Microsoft.EntityFrameworkCore;
using RestTest.Core.Domain.Employees.Entities;

namespace RestTest.Infra.Data.Sql.Query.Employees;

public class RestTestQueryContext : DbContext
{
    public RestTestQueryContext(DbContextOptions<RestTestQueryContext> options)
        : base(options)
    {
    }

    public DbSet<Employee> Employee { get; set; } = default!;
}