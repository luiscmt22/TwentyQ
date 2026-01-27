using System.ComponentModel.DataAnnotations.Schema;

namespace TwentyQ.Entities;

public class AnimalAnswerEntity
{
    public int Id { get; set; }
    public int AnimalId { get; set; }
    public int QuestionId { get; set; }
    public double Value { get; set; }

    [ForeignKey("AnimalId")]
    public AnimalEntity? Animal { get; set; }
    [ForeignKey("QuestionId")]
    public QuestionEntity? Question { get; set; }
}
