using TwentyQ.Data;
using TwentyQ.Models;

namespace TwentyQ.Core;

public class BetterGame
{
    public List<Question> questions = [
        new Question { Text = "Does it fly?" },
        new Question { Text = "Does it swim?" },
        new Question { Text = "Is it a mammal?" },
        new Question { Text = "Is it a bird?" },

    ];

    public AnswerValue[] playerAnswers = [];
    public double[] answers = [];

    public NeuralNetwork network;  

    public List<Animal> animals = [
        new Animal { Name = "Penguin", featureValues = [0, 2, 0, 2] },
        new Animal { Name = "Dog", featureValues = [0, 0, 2, 0] },
        new Animal { Name = "Eagle", featureValues = [2, 0, 0, 2] },
        new Animal { Name = "Shark", featureValues = [0, 2, 0, 0]},
        new Animal { Name = "Cat", featureValues = [0, 0, 2, 0]},
        new Animal { Name = "Whale", featureValues = [0, 2, 2, 0]},
        new Animal { Name = "Bat", featureValues = [2, 0, 2, 0]},
        new Animal { Name = "Salmon", featureValues = [0, 2, 0, 0]},
    ];

    //// Expected outputs: [Penguin?, Dog?, Eagle?, Shark?] This is the neuron's target output for each animal LEGACY
    //double[] isPenguin = [1, 0, 0, 0];
    //double[] isDog = [0, 1, 0, 0];
    //double[] isEagle = [0, 0, 1, 0];
    //double[] isShark = [0, 0, 0, 1];

    //// Training data for each animal. This represents the answers to the questions for each animal LEGACY
    //double[] penguin = [0, 2, 0, 2];
    //double[] dog = [0, 0, 2, 0];
    //double[] eagle = [2, 0, 0, 2];
    //double[] shark = [0, 2, 0, 0];

    public void PlayBetterGame()
    {
        CreateNetwork();
        TrainInitialNetwork();
        playerAnswers = GetPlayerAnswers();

        Console.WriteLine("Welcome to the Better Twenty Questions!");

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
        }

        foreach (var answer in playerAnswers)
        {
            answers = answers.Append((double)answer).ToArray();
        }

        var bestGuessIndex = FindBestGuess(network.Compute(answers));
        var animal = GetAnimal(bestGuessIndex);
        Console.WriteLine($"I guess your animal is: {animal.Name}! Did I guess right?");
        var playerResponse = Console.ReadLine();

        if (playerResponse?.ToLower() == "yes")
        {
            Console.WriteLine("Yay! I guessed it right!");
            network.Train(answers, GetExpectedOutput(animal), 0.1);
        }
        else
        {
            Console.WriteLine("Oh no! I'll try to do better next time. Which animal were you thinking of?");
            var animalName = Console.ReadLine() ?? "Unknown";
            animal = GetAnimalbyName(animalName);
            if (animal is not null )
            {
                network.Train(answers, GetExpectedOutput(animal), 0.1);
            }
            else
            {
                animal = new Animal();
                animal.Name = animalName;
                animal.featureValues = answers;
                animals.Add(animal);
            }
            foreach (var _animal in animals)
            { Console.WriteLine(_animal.Name.ToString()); }
        }
    }

    void CreateNetwork()
    {
        List<Neuron> neurons = new List<Neuron>();

        foreach (var animal in animals)
        {
            double[] weights = [0.0, 0.0, 0.0, 0.0];
            double bias = 0.0;
            neurons.Add(new Neuron(weights, bias));
        }
        network = new NeuralNetwork(neurons);
    }

    AnswerValue[] GetPlayerAnswers()
    {
        return playerAnswers = [AnswerValue.Maybe, AnswerValue.Maybe, AnswerValue.Maybe, AnswerValue.Maybe];
    }

    int FindBestGuess(double[] scores)
    {
        int bestIndex = 0;
        double bestScore = scores[0];
        for (int i = 1; i < scores.Length; i++)
        {
            if (scores[i] > bestScore)
            {
                bestScore = scores[i];
                bestIndex = i;
            }
        }
        return bestIndex;
    }

    Animal GetAnimal(int index)
    {
        return animals[index];
    }

    double[] GetExpectedOutput(Animal animal)
    {
        if (animal is not null)
        { 
            foreach (var a in animals)
            {
                if (a.Name.Equals(animal.Name, StringComparison.OrdinalIgnoreCase))
                {
                    double[] output = new double[animals.Count];
                    output[animals.IndexOf(a)] = 1.0;
                    return output;
                }
            }
        }
        return [0.0, 0.0, 0.0, 0.0];

    }

    void TrainInitialNetwork()
    {
        var learningRate = 0.1;
        // Train
        for (int i = 0; i <= 1000; i++)
        {
            foreach (var animal in animals)
            {
                network.Train(animal.featureValues, GetExpectedOutput(animal), learningRate);
            }

            if (i % 100 == 0)
            {
                var error = CalculateTotalError();
                Console.WriteLine($"Iteration {i}: Error = {error:F4}");
            }
        }
    }

    double CalculateTotalError()
    {
        double total = 0;
        foreach (var animal in animals)
        {
            var expectedOutput = GetExpectedOutput(animal);
            total += GetError(network.Compute(animal.featureValues), expectedOutput);
        }

        return total;
    }

    double GetError(double[] actual, double[] expected)
    {
        double sum = 0;
        for (int i = 0; i < actual.Length; i++)
        {
            sum += Math.Abs(expected[i] - actual[i]);
        }
        return sum;
    }

    Animal? GetAnimalbyName(string name)
    {
        foreach (var animal in animals)
        {
            if (animal.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                return animal;
            }
        }
        return null;
    }
}