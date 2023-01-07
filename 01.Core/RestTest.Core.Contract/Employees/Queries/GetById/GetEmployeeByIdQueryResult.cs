namespace RestTest.Core.Contract.Employees.Queries.GetById;

public class GetEmployeeByIdQueryResult
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public long NationalCode { get; set; }
    public List<GetEmployeeById_NotesQueryResult> Notes { get; set; }

    public class GetEmployeeById_NotesQueryResult
    {
        public int NoteId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public bool Published { get; set; }
    }
}
