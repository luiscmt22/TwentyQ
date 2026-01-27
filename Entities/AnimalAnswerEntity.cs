namespace TwentyQ.Entities;

public class AnimalAnswerEntity
{
    public int Id { get; set; }
    public int AnimalId { get; set; }
    public int QuestionId { get; set; }
    public double Value { get; set; }

    AnimalEntity? Animal { get; set; }
    QuestionEntity? Question { get; set; }
}
