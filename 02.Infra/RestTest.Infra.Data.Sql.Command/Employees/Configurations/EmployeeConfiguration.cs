using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestTest.Core.Domain.Employees.Entities;

namespace RestTest.Infra.Data.Sql.Command.Employees.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.Property(c => c.Id).IsRequired();
        builder.Property(c => c.FirstName).IsRequired(required: false);
        builder.Property(c => c.FirstName).IsRequired(required: false);
        builder.Property(c => c.NationalCode).IsRequired().IsFixedLength(true).HasMaxLength(10);

        builder.HasMany(c => c.Notes).WithOne(d => d.Employee)
            .HasForeignKey(c => c.EmployeeId).HasPrincipalKey(c => c.Id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
