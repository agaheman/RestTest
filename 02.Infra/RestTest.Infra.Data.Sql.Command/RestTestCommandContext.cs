using Microsoft.EntityFrameworkCore;
using RestTest.Core.Domain.Employees.Entities;

namespace RestTest.Infra.Data.Sql.Command;

public class RestTestCommandContext : DbContext
{
    public RestTestCommandContext(DbContextOptions<RestTestCommandContext> options)
        : base(options)
    {
    }

    public DbSet<Employee> Employee { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
}
