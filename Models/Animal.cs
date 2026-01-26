using TwentyQ.Data;

namespace TwentyQ.Models;
public class Animal
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public AnswerValue[] features {  get; set; } = []; // = Array.Empty<AnswerValue>(); kept for backward compatibility
    public double[] featureValues { get; set; } = [];


    void convertFeaturesToValues()
    {
        featureValues = features.Select(f => f switch
        {
            AnswerValue.Yes => 2.0,
            AnswerValue.Maybe => 1.0,
            AnswerValue.No => 0.0,
            _ => 0.0
        }).ToArray();
    }

}
