namespace Assignment.Domain.Entities;

public class Assignment
{
    public DateTime DueDate;
    public string Description;
    public string AssignmentLink;

    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime Deadline { get; set; }
    public string CreatedBy { get; set; }
}
