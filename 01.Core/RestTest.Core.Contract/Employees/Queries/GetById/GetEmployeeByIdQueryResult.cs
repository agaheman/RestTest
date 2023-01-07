using RestTest.Core.Domain.Notes.Entities;

namespace RestTest.Core.Contract.Employees.Queries.GetById;

public class GetEmployeeByIdQueryResult
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public long NationalCode { get; set; }
    public List<Note> Notes { get; set; }
}
