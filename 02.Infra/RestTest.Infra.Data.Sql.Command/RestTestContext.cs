using Microsoft.EntityFrameworkCore;
using RestTest.Core.Domain.Employees.Entities;

namespace RestTest.Infra.Data.Sql.Command;

public class RestTestContext1 : DbContext
{
    public RestTestContext1(DbContextOptions<RestTestContext1> options)
        : base(options)
    {
    }

    public DbSet<Employee> Employee { get; set; } = default!;
}
