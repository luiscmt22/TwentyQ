using TwentyQ.Data;
using TwentyQ.Models;

namespace TwentyQ.Core;
public class Game
{
    public AnswerValue[] playerAnswers = [];
    public Animal[] animals = [];
    public Question[] questions = [];
    public int[] distances = [];

    public void PlayGame()
    {
        Console.WriteLine("Welcome to Twenty Questions!");

        DistanceCalculator calculator = new DistanceCalculator();

        animals = GetAllAnimals();
        questions = GetAllQuestions();
        playerAnswers = GetPlayerAnswers();
        distances = GetDistances();

        foreach (var questionText in questions)
        {
            Console.WriteLine(questionText.Text + " (yes/no/maybe)");
            var questionIndex = questions.ToList().IndexOf(questionText);
            var playerInput = Console.ReadLine();
            AnswerValue answer;
            if (playerInput?.ToLower() == "yes")
            {
                answer = AnswerValue.Yes;
            }
            else if (playerInput?.ToLower() == "no")
            {
                answer = AnswerValue.No;
            }
            else if (playerInput?.ToLower() == "maybe")
            {
                answer = AnswerValue.Maybe;
            }
            else
            {
                Console.WriteLine("Invalid input. Please answer 'yes', 'no', or 'maybe'.");
                continue;
            }

            playerAnswers[questionIndex] = (answer);
            
            foreach (var animal in animals)
            {
                var animalIndex = animals.ToList().IndexOf(animal);
                distances[animalIndex] += calculator.GetDistance(answer, questionIndex, animal);
            }
                
            calculator.IncrementNumberOfAnswers();
        }

        var guessedAnimalIndex = Array.IndexOf(distances, distances.Min());
        Console.WriteLine($"I guess your animal is: {animals[guessedAnimalIndex].Name}!");
    }

    Animal[] GetAllAnimals()
    {
        var dog = new Animal { Id = 1, Name = "Dog", features = [AnswerValue.No, AnswerValue.No, AnswerValue.Yes, AnswerValue.No] };
        var eagle = new Animal { Id = 2, Name = "Eagle", features = [AnswerValue.Yes, AnswerValue.No, AnswerValue.No, AnswerValue.Yes] };
        var shark = new Animal { Id = 3, Name = "Shark", features = [AnswerValue.No, AnswerValue.Yes, AnswerValue.No, AnswerValue.No] };
        var penguin = new Animal { Id = 4, Name = "Penguin", features = [AnswerValue.No, AnswerValue.Yes, AnswerValue.No, AnswerValue.Yes] };

        Animal[] animalData = [dog, eagle, shark, penguin];

        return animalData;
    }

    Question[] GetAllQuestions()
    {
        var q1 = new Question { Text = "Does it fly?" };
        var q2 = new Question { Text = "Does it swim?" };
        var q3 = new Question { Text = "Is it a mammal?" };
        var q4 = new Question { Text = "Is it a bird?" };

        Question[] questionData = [q1, q2, q3, q4];

        return questionData;
    }

    AnswerValue[] GetPlayerAnswers()
    {
        return playerAnswers = [AnswerValue.Maybe, AnswerValue.Maybe, AnswerValue.Maybe, AnswerValue.Maybe];
    }

    int[] GetDistances()
    {
        return distances = [0, 0, 0, 0];
    }

}

