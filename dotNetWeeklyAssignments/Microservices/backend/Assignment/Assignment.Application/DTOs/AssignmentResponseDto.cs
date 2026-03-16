namespace Assignment.Application.DTOs;

public class AssignmentResponseDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string AssignmentLink { get; set; }
    public DateTime DueDate { get; set; }
}

public class AssignmentSubmissionResultDto
{
    public bool IsSubmitted { get; set; }
    public string Message { get; set; }
    public int SubmissionId { get; set; }
}
