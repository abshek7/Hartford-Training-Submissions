namespace Resource.Application.DTOs;

public class SubmitQuizDto
{
    public int QuizId { get; set; }
    public int SelectedAnswer { get; set; } // 1=OptionA, 2=OptionB, 3=OptionC, 4=OptionD
}
