using RestTest.Core.Domain.Notes.Entities;

namespace RestTest.Core.Domain.Employees.Entities;

public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public long NationalCode { get; set; }
    public ICollection<Note> Notes { get; set; }
    public string Email { get; set; }
}
