namespace Resource.Application.DTOs;

public class QuizResponseDto
{
    public int Id { get; set; }
    public string Question { get; set; }
    public string OptionA { get; set; }
    public string OptionB { get; set; }
    public string OptionC { get; set; }
    public string OptionD { get; set; }
    // Note: CorrectAnswer is not included in response to prevent cheating
}

public class QuizSubmissionResultDto
{
    public bool IsCorrect { get; set; }
    public string Message { get; set; }
    public string CorrectAnswer { get; set; }
}
