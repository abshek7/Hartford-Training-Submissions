using Microsoft.AspNetCore.Mvc;
using Resource.Domain.Entities;
using Resource.Application.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace Resource.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class QuizController : ControllerBase
{
    private static List<QuizQuestion> _questions = new();

    [HttpPost("create")]
    public IActionResult CreateQuiz(QuizQuestion question)
    {
        question.Id = _questions.Count + 1;
        _questions.Add(question);
        return Ok(question);
    }

    [HttpGet]
    public IActionResult GetQuiz()
    {
        var quizResponses = _questions.Select(q => new QuizResponseDto
        {
            Id = q.Id,
            Question = q.Question,
            OptionA = q.OptionA,
            OptionB = q.OptionB,
            OptionC = q.OptionC,
            OptionD = q.OptionD
        }).ToList();
        
        return Ok(quizResponses);
    }

    [HttpPost("submit")]
    public IActionResult SubmitQuiz(SubmitQuizDto submission)
    {
        var question = _questions.FirstOrDefault(q => q.Id == submission.QuizId);
        
        if (question == null)
        {
            return NotFound(new { message = "Quiz question not found" });
        }

        var isCorrect = (int)question.CorrectAnswer == submission.SelectedAnswer;
        var result = new QuizSubmissionResultDto
        {
            IsCorrect = isCorrect,
            Message = isCorrect ? "Correct! Well done!" : "Wrong answer. Try again!",
            CorrectAnswer = $"Option {question.CorrectAnswer} ({GetOptionText(question, question.CorrectAnswer)})"
        };

        return Ok(result);
    }

    private string GetOptionText(QuizQuestion question, AnswerOption answer)
    {
        return answer switch
        {
            AnswerOption.OptionA => question.OptionA,
            AnswerOption.OptionB => question.OptionB,
            AnswerOption.OptionC => question.OptionC,
            AnswerOption.OptionD => question.OptionD,
            _ => "Unknown"
        };
    }
}
