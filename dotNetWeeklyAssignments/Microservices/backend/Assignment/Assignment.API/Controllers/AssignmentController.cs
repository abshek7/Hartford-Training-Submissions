using Microsoft.AspNetCore.Mvc;
using Assignment.Domain.Entities;
using Assignment.Application.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace Assignment.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class AssignmentController : ControllerBase
{
    private static List<Assignment.Domain.Entities.Assignment> _assignments = new();
    private static List<Submission> _submissions = new();

    [HttpPost]
    public IActionResult CreateAssignment(Assignment.Domain.Entities.Assignment assignment)
    {
        assignment.Id = _assignments.Count + 1;
        _assignments.Add(assignment);
        return Ok(assignment);
    }

    [HttpGet]
    public IActionResult GetAssignments()
    {
        var assignmentResponses = _assignments.Select(a => new AssignmentResponseDto
        {
            Id = a.Id,
            Title = a.Title,
            Description = a.Description,
            AssignmentLink = a.AssignmentLink,
            DueDate = a.DueDate
        }).ToList();
        
        return Ok(assignmentResponses);
    }

    [HttpPost("submit")]
    public IActionResult SubmitAssignment(Submission submission)
    {
        var assignment = _assignments.FirstOrDefault(a => a.Id == submission.AssignmentId);
        
        if (assignment == null)
        {
            return NotFound(new { message = "Assignment not found" });
        }

        submission.Id = _submissions.Count + 1;
        _submissions.Add(submission);
        
        var result = new AssignmentSubmissionResultDto
        {
            IsSubmitted = true,
            Message = "Assignment submitted successfully!",
            SubmissionId = submission.Id
        };

        return Ok(result);
    }

    [HttpGet("submissions")]
    public IActionResult GetSubmissions()
    {
        return Ok(_submissions);
    }
}
