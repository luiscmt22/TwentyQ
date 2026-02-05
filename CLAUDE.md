# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

TwentyQ is an educational 20 Questions AI game that implements neural networks from scratch in C#. The project follows a structured curriculum (see `TwentyQ_Curriculum.md`) to teach machine learning concepts through building a playable game. Currently at Module 5: Hidden Layers.

## Build & Run Commands

```bash
dotnet build              # Build the project
dotnet run                # Run the game (console app)
```

**Database (EF Core with SQL Server):**
```bash
dotnet ef migrations add <MigrationName>   # Create migration
dotnet ef database update                   # Apply migrations
dotnet ef database drop                     # Drop database
```

## Architecture

**Layer Structure:**
```
Program.cs
    └── BetterGame.cs (game logic, EF Core data loading)
            └── NeuralNetwork.cs (collection of neurons)
                    └── Neuron.cs (weights, bias, sigmoid activation)
```

**Data Flow:**
1. Load animals/questions from SQL Server via `TwentyQContext`
2. Convert to feature vectors (0=No, 1=Maybe, 2=Yes)
3. Train network: one neuron per animal, 1000 iterations
4. Get player answers → run inference → pick highest score
5. Learn from feedback using perceptron rule

**Key Separation:**
- `Entities/` - Database models (AnimalEntity, QuestionEntity, AnimalAnswerEntity)
- `Models/` - Business models (Animal, Question)
- `Core/` - Neural network and game logic
- `Data/` - EF Core DbContext with seed data

## Neural Network Implementation

The network is implemented from scratch (not ML.NET):
- **Neuron**: `output = sigmoid(Σ(weight × input) + bias)`
- **Training**: `weight += learning_rate × error × input`
- **Network**: Array of neurons, one per animal class
- **Selection**: Pick animal with highest neuron output

## Database Schema

Three tables with many-to-many relationship:
- `Animals` (Id, Name)
- `Questions` (Id, Text)
- `AnimalAnswers` (AnimalId, QuestionId, Value)

Seeded with 8 animals and 4 questions. Connection string in `appsettings.json` uses local SQL Server.

## Curriculum Context

When working on this project, refer to `TwentyQ_Curriculum.md` for:
- Current learning module and progress
- Key bugs and lessons learned
- Next steps (Module 5: Hidden Layers, then backpropagation)

The project intentionally builds ML from first principles rather than using libraries.
