using Microsoft.EntityFrameworkCore;
using RestTest.Core.Domain.Employees.Entities;
using RestTest.Core.Domain.Notes.Entities;

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

        #region SampleData

        var Employees = new[]
        { 
            new Employee
            {
                Id = 1,
                FirstName = "Taher",
                LastName = "Samadi",
                Email = "TaherSamadi@gmail.com",
                NationalCode = 2660039991
            },
            new Employee
            {
                Id = 2,
                FirstName = "AmirHossein",
                LastName = "Lesani",
                Email = "AmirHosseinLesani@gmail.com",
                NationalCode = 2660039993,
            },
            new Employee
            {
                Id = 3,
                FirstName = "Nima",
                LastName = "Khandabi",
                Email = "NimaKhandabi@gmail.com",
                NationalCode = 2660039995,
            }
        };

        modelBuilder.Entity<Employee>().HasData(Employees);


        var Notes = new[]
        {
            new Note {Id = 1, Name = "Montakhab1", Content = "Chekhof1", Published = true , EmployeeId = Employees[0].Id },
            new Note {Id = 2, Name = "Dibache2"  , Content = "Chekhof2", Published = false, EmployeeId = Employees[0].Id },

            new Note {Id = 3, Name = "Montakhab3", Content = "Veronic1", Published = true, EmployeeId = Employees[1].Id },
            new Note {Id = 4, Name = "Dibache4"  , Content = "Veronic2", Published = true, EmployeeId = Employees[1].Id },
            
            new Note {Id = 5, Name = "Montakhab5", Content = "LastState1", Published = true , EmployeeId = Employees[2].Id },
            new Note {Id = 6, Name = "Dibache6"  , Content = "LastState2", Published = true , EmployeeId = Employees[2].Id }
        };

        modelBuilder.Entity<Note>().HasData(Notes);

        #endregion
    }
}
