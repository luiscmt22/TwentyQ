namespace TwentyQ.Entities;

public class AnimalEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public List<AnimalAnswerEntity>? Answers { get; set; }
}
