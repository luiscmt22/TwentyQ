using System.Diagnostics;
using TwentyQ.Data;
using TwentyQ.Models;

namespace TwentyQ.Core;

public class DistanceCalculator
{
    public static readonly int NumberOfQuestions = 20;

    public static int NumberOfAnswers = 0;

    public int[] playerAnswer = [];

    public void IncrementNumberOfAnswers()
    {
        NumberOfAnswers++;
    }

    public int GetDistance(AnswerValue answer, int questionIndex, Animal animal)
    {
        int distance = 0;

        distance += Math.Abs((int)answer - (int)animal.features[questionIndex]);

        return distance;
    }
}

