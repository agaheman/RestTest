using RestTest.Core.Domain.Employees.Entities;

namespace RestTest.Core.Domain.Notes.Entities;

public class Note
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Content { get; set; }
    public bool Published { get; set; }

    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
}
