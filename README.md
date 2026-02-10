# TwentyQ — Neural Networks from Scratch

> An educational 20 Questions AI game that implements neural networks from first principles in C# — no ML libraries, just raw math and curiosity.

![.NET 10](https://img.shields.io/badge/.NET-10.0-purple)
![C#](https://img.shields.io/badge/C%23-latest-239120)
![EF Core](https://img.shields.io/badge/EF%20Core-10.0-blue)
![SQL Server](https://img.shields.io/badge/SQL%20Server-local-red)
![No ML Libraries](https://img.shields.io/badge/ML%20Libraries-None%20%E2%9C%93-brightgreen)

---

## About This Project

It started with a toy. I was showing my partner the classic 20Q handheld and she was amazed — so I decided to figure out how it works and build her one myself. I expected some intricate binary decision tree, but was stunned to discover it's actually a neural network, and the original algorithm dates back to 1988. That surprise turned into a project: implement the entire neural network from scratch in C#, no ML libraries, following an 11-module curriculum that builds from a single neuron all the way to backpropagation and batch training. Every weight, every bias, every gradient — written by hand to understand what's really happening under the hood.

---

## How It Works

```
  You think of an animal
          |
          v
  Answer 6 questions (yes / no / maybe)
          |
          v
  Answers become a feature vector [0, 2, 0, 2, 0, 0]
          |
          v
  Neural network runs inference
          |
          v
  Highest-scoring neuron = the guess
          |
     +---------+
     |  Right? |
     +----+----+
    Yes   |   No
     |    |    |
     v    |    v
  Reinforce    Learn correction
  pattern      from feedback
```

The game starts by training the network on all known animals, then plays an interactive guessing session. After each game, the network learns from the result — getting smarter over time.

---

## Neural Network Architecture

The entire neural network is implemented from scratch — no TensorFlow, no ML.NET, no libraries. Every weight, bias, activation function, and backpropagation step is hand-coded.

```
 INPUT LAYER            HIDDEN LAYER           OUTPUT LAYER
 (6 neurons)            (6 neurons)            (8 neurons)

 [Flies?]    ──┐
               ├──→  [ Hidden 1 ] ──┐
 [Swims?]    ──┤     [ Hidden 2 ]   ├──→  [ Penguin ]
               ├──→  [ Hidden 3 ] ──┤     [ Dog     ]
 [Mammal?]   ──┤     [ Hidden 4 ]   ├──→  [ Eagle   ]
               ├──→  [ Hidden 5 ] ──┤     [ Shark   ]
 [Bird?]     ──┤     [ Hidden 6 ] ──┘     [ Cat     ]
               │                          [ Whale   ]
 [Feline?]   ──┤                          [ Bat     ]
               │                          [ Salmon  ]
 [Dangerous?]──┘
```

### The Core Math

Each neuron computes a weighted sum of its inputs, adds a bias, and passes it through a sigmoid activation function:

```csharp
public double Compute(double[] inputs)
{
    var output = 0.0;
    for (int i = 0; i < inputs.Length; i++)
    {
        output += inputs[i] * Weights[i];
    }
    return ActivationFunction(output + Bias);
}

// Sigmoid: squashes any value into [0, 1]
private double ActivationFunction(double input)
{
    return 1 / (1 + Math.Exp(-input));
}
```

### Training with Backpropagation

The network learns through backpropagation — errors flow backward from the output layer to the hidden layer, and each neuron adjusts its weights proportionally to how much it contributed to the mistake:

```
Forward:   Input → Hidden → Output → Error
Backward:  Error → Output weights updated → Hidden weights updated
```

---

## Tech Stack

| Technology | Purpose |
|:--|:--|
| **.NET 10** | Runtime & framework |
| **C#** | Language (with nullable refs & implicit usings) |
| **Entity Framework Core** | ORM for animal/question data |
| **SQL Server** | Relational database |
| **Zero ML libraries** | All neural network math is from scratch |

---

## Project Structure

```
TwentyQ/
├── Core/                           # Neural network & game logic
│   ├── Neuron.cs                   # Weights, bias, sigmoid, training
│   ├── NeuralNetwork.cs            # Multi-layer forward pass & backprop
│   ├── BetterGame.cs               # Game loop with neural network
│   ├── Game.cs                     # Legacy k-NN distance-based game
│   └── DistanceCalculator.cs       # Manhattan distance (Module 1)
│
├── Models/                         # Business models
│   ├── Animal.cs                   # Animal with feature vectors
│   └── Question.cs                 # Question text
│
├── Entities/                       # Database entities
│   ├── AnimalEntity.cs             # Maps to Animals table
│   ├── QuestionEntity.cs           # Maps to Questions table
│   └── AnimalAnswerEntity.cs       # Junction table (many-to-many)
│
├── Data/                           # Data access layer
│   └── TwentyQContext.cs           # EF Core DbContext + seed data
│
├── Scripts/                        # SQL scripts for data expansion
│   └── NewQuestions.sql            # Additional questions & answers
│
├── Docs/Educational/               # Learning materials
│   └── Backpropagation.md          # Educational notes
│
├── Program.cs                      # Entry point
└── TwentyQ_Curriculum.md           # Full 11-module learning path
```

---

## Learning Curriculum

This project follows an 11-module curriculum that builds ML understanding progressively:

| # | Module | Status | Key Deliverable |
|:-:|:--|:-:|:--|
| 1 | **Foundations** — Classification & k-NN | Done | `Game.cs` with distance-based guessing |
| 2 | **From Lookup to Learning** — Single neuron | Done | `Neuron.cs` with sigmoid & training |
| 3 | **Multi-Class** — One neuron per animal | Done | `NeuralNetwork.cs` single layer |
| 4 | **Data Management** — EF Core integration | Done | Dynamic loading from SQL Server |
| 5 | **Hidden Layers** — Why depth matters | Current | Multi-layer network |
| 6 | **Backpropagation** — Error flows backward | Up next | Chain rule training |
| 7 | **Training at Scale** — Batch & optimization | Up next | Gradient accumulation |
| 8 | **Persistence** — Save/load models | Planned | Skip retraining on startup |
| 9 | **Smart Questions** — Information gain | Optional | Entropy-based question ranking |
| 10 | **ML Libraries** — ML.NET comparison | Optional | Side-by-side with from-scratch |
| 11 | **Blazor UI** — Web interface | Final | Interactive web game + dashboard |

---

## Quick Start

**Prerequisites:** .NET 10 SDK, SQL Server (local instance)

```bash
# Build and run
dotnet build
dotnet run

# Database setup (first time)
dotnet ef database update
```

The game seeds 8 animals and 6 questions automatically on first run.

---

## Key Concepts Implemented

- **Sigmoid activation** — biological neuron inspiration, squashes outputs to [0, 1]
- **Perceptron learning rule** — `weight += learning_rate * error * input`
- **Multi-class classification** — one output neuron per animal category
- **Hidden layers** — intermediate feature detectors that compose simple patterns into complex ones
- **Backpropagation** — credit assignment through chain rule derivatives
- **Batch training** — accumulate gradient "votes" before applying averaged updates
- **Feature vectors** — representing real-world objects as numerical arrays
- **Online learning** — the network continues to learn from each game played

---

## Lessons Learned

Building from scratch means hitting real bugs that teach lasting lessons:

**Arrays are reference types, not copies.**
Early on, all neurons shared the same weight array because I passed one array to multiple constructors. Every neuron learned the same thing. Fix: create a new array inside each loop iteration.

**EF Core seeding breaks with initialized navigation properties.**
Initializing `Answers = new List<AnimalAnswerEntity>()` on entity classes caused the seed data to silently fail. Fix: leave navigation properties null and let EF Core manage them.

**Hardcoded sizes create invisible ceilings.**
Using `new double[4]` instead of `new double[questions.Count]` meant the network broke silently when questions were added to the database. Fix: always derive sizes from data.

**Sigmoid derivative is elegantly simple.**
If `f(x) = sigmoid(x)`, then `f'(x) = f(x) * (1 - f(x))`. The output itself contains enough information to compute its own derivative — no need to recalculate the original sum.

---

## License

This project is open source and available for educational purposes.
