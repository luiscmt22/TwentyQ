namespace TwentyQ.Entities;

public class QuestionEntity
{
    public int Id { get; set; }
    public string Text { get; set; } = string.Empty;

    List<AnimalAnswerEntity> Answers { get; set; } = [];
}
