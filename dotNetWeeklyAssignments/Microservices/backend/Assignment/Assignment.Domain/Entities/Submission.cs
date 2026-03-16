namespace Assignment.Domain.Entities;

public class Submission
{
    public int Id { get; set; }
    public string StudentName { get; set; }
    public string Email { get; set; }
    public int AssignmentId { get; set; }
    public string AssignmentLink { get; set; }
}
