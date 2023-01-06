using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestTest.Core.Domain.Employees.Entities;
using RestTest.Core.Domain.Notes.Entities;

namespace RestTest.Infra.Data.Sql.Command.Employees.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(c => c.Id).IsRequired();
            builder.Property(c => c.FirstName).IsRequired(required:false);
            builder.Property(c => c.FirstName).IsRequired(required:false);
            builder.Property(c => c.NationalCode).IsRequired().IsFixedLength(true).HasMaxLength(10);

            builder.HasMany(c => c.Notes).WithOne()
                .HasForeignKey(c => c.EmployeeId).HasPrincipalKey(c => c.Id)
                .OnDelete(DeleteBehavior.Cascade);


            #region SampleData
            var Taher = new Employee
            {
                Id= 1,
                FirstName = "Taher",
                LastName = "Samadi",
                Email = "TaherSamadi@gmail.com",
                NationalCode = 2660039991,
                Notes = new List<Note>
                {
                    new Note { Content = "Chekhof1", Published = true },
                    new Note { Content = "Chekhof2", Published = false }
                }
            };
            var AmirHossein = new Employee
            {
                Id=2,
                FirstName = "AmirHossein",
                LastName = "Lesani",
                Email = "AmirHosseinLesani@gmail.com",
                NationalCode = 2660039993,
                Notes = new List<Note>
                {
                    new Note { Content = "Veronic1", Published = true },
                    new Note { Content = "Veronic2", Published = true }
                }
            };
            var Nima = new Employee
            {
                Id = 3,
                FirstName = "Nima",
                LastName = "Khandabi",
                Email = "NimaKhandabi@gmail.com",
                NationalCode = 2660039995,
                Notes = new List<Note>
                {
                    new Note { Content = "LastState1", Published = true },
                    new Note { Content = "LastState2", Published = true }
                }
            };
            #endregion

            builder.HasData(Taher, AmirHossein, Nima);
        }
    }
}
