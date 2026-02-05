using TwentyQ.Core;
using TwentyQ.Services;

using Microsoft.Extensions.Configuration;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

var context = new DbContextFactoryService(configuration).CreateDbContext();

var userChoice = "";
while (userChoice != "no")
{
    BetterNeuralNetworkGame();
    Console.WriteLine("Do you want to play again?");
    userChoice = Console.ReadLine()?.ToLower() ?? "no";
}


void BetterNeuralNetworkGame()
{
    var betterGame = new BetterGame(context);
    betterGame.PlayBetterGame();
}
/* This was a previous version that only used a single layer of neurons */
/*void NeuralNetworkGame()
{
    // Create 4 neurons (one per animal), all starting with zero weights
    var network = new NeuralNetwork([
        new Neuron([0.0, 0.0, 0.0, 0.0], 0.0),  // Penguin detector
        new Neuron([0.0, 0.0, 0.0, 0.0], 0.0),  // Dog detector
        new Neuron([0.0, 0.0, 0.0, 0.0], 0.0),  // Eagle detector
        new Neuron([0.0, 0.0, 0.0, 0.0], 0.0),  // Shark detector
    ]);

    // Training data
    double[] penguin = [0, 2, 0, 2];
    double[] dog = [0, 0, 2, 0];
    double[] eagle = [2, 0, 0, 2];
    double[] shark = [0, 2, 0, 0];

    // Expected outputs: [Penguin?, Dog?, Eagle?, Shark?]
    double[] isPenguin = [1, 0, 0, 0];
    double[] isDog = [0, 1, 0, 0];
    double[] isEagle = [0, 0, 1, 0];
    double[] isShark = [0, 0, 0, 1];

    Console.WriteLine("Before training:");
    PrintScores(network.Compute(penguin), "Penguin");

    // Train
    for (int i = 0; i < 1000; i++)
    {
        network.Train(penguin, isPenguin, 0.1);
        network.Train(dog, isDog, 0.1);
        network.Train(eagle, isEagle, 0.1);
        network.Train(shark, isShark, 0.1);
    }

    Console.WriteLine("\nAfter training:");
    PrintScores(network.Compute(penguin), "Penguin");
    PrintScores(network.Compute(dog), "Dog");
    PrintScores(network.Compute(eagle), "Eagle");
    PrintScores(network.Compute(shark), "Shark");

    void PrintScores(double[] scores, string animal)
    {
        Console.WriteLine($"{animal}: P={scores[0]:F2} D={scores[1]:F2} E={scores[2]:F2} S={scores[3]:F2}");
    }
}
*/

void SingleNeuronGame()
{
    Console.WriteLine("Welcome to the Single Neuron 20 Questions Game!");
    Console.WriteLine("We will train a single neuron to distinguish between penguins and dogs.");
    Console.WriteLine("Features: [Can Fly, Lives in Water, Is Mammal, Is Bird]");
    Console.WriteLine("Penguin: [0, 2, 0, 2]");
    Console.WriteLine("Dog:     [0, 0, 2, 0]");
    Console.WriteLine();
    var neuron = new Neuron(
    weights: [0.0, 0.0, 0.0, 0.0],  // start with zeros
    bias: 0.0
);

    double[] penguin = [0, 2, 0, 2];
    double[] dog = [0, 0, 2, 0];

    Console.WriteLine($"Before training:");
    Console.WriteLine($"Penguin score: {neuron.Compute(penguin)}");
    Console.WriteLine($"Dog score: {neuron.Compute(dog)}");

    Console.WriteLine("\nTraining...");

    // Train 100 times: Penguin should output 1, Dog should output 0
    for (int i = 0; i < 100; i++)
    {
        neuron.Train(penguin, 1.0, 0.1);  // Penguin = yes (1)
        neuron.Train(dog, 0.0, 0.1);      // Dog = no (0)
    }

    Console.WriteLine($"\nAfter training:");
    Console.WriteLine($"Penguin score: {neuron.Compute(penguin)}");
    Console.WriteLine($"Dog score: {neuron.Compute(dog)}");
    Console.WriteLine($"\nLearned weights:");
    Console.WriteLine($"  Fly:    {neuron.Weights[0]:F3}");
    Console.WriteLine($"  Water:  {neuron.Weights[1]:F3}");
    Console.WriteLine($"  Mammal: {neuron.Weights[2]:F3}");
    Console.WriteLine($"  Bird:   {neuron.Weights[3]:F3}");
    Console.WriteLine($"  Bias:   {neuron.Bias:F3}");

    double[] eagle = [2, 0, 0, 2];
    double[] shark = [0, 2, 0, 0];

    Console.WriteLine($"\nAnimals it never saw:");
    Console.WriteLine($"Eagle score: {neuron.Compute(eagle)}");
    Console.WriteLine($"Shark score: {neuron.Compute(shark)}");
}
void Vector4Game()
{
    Game game = new Game();

    game.PlayGame();
}


