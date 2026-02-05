# Building a Neural Network from Scratch: A 20 Questions Journey

## Course Overview

**Goal:** Build a fully-functional 20 Questions game while deeply understanding machine learning and neural networks — not just using libraries, but understanding the math, intuition, and design decisions behind them.

**Student Background:** Developer with web stack experience (C#/.NET/Blazor), psychology/neuroscience academic background. Values clean code, SOLID principles, and understanding "why" not just "how."

**Teaching Philosophy:** Socratic method — guide through questions, let the student discover insights, make mistakes and debug them. Build intuition before formulas.

---

## The Complete Learning Path

### Module 1: Foundations — What Is Classification? ✅ COMPLETE

**Core Question:** How do you teach a computer to guess what you're thinking?

**Key Concepts:**
- Information theory basics (bits, entropy)
- Representing objects as feature vectors (fingerprints)
- Similarity as distance in feature space
- k-Nearest Neighbors (k-NN) algorithm

**What We Built:**
- `Game.cs` — distance-based 20Q using Manhattan distance
- Hardcoded animals with feature arrays
- Learned: identical fingerprints = indistinguishable objects

**Key Insight:** The quality of your questions (features) determines the ceiling of any algorithm's intelligence.

---

### Module 2: From Lookup to Learning ✅ COMPLETE

**Core Question:** What if the computer could figure out the patterns itself?

**Key Concepts:**
- What "learning" means mathematically (adjusting parameters to reduce error)
- Weights as learned importance of each feature
- Bias as threshold for activation
- The perceptron learning rule
- Sigmoid activation (biological inspiration: neurons fire or don't)

**What We Built:**
- `Neuron.cs` — single neuron with weights, bias, Train(), Compute()
- Implemented from scratch: `output = sigmoid(Σ(weight × input) + bias)`
- Training rule: `weight += learning_rate × error × input`

**Key Insight:** Weights encode knowledge. Training is just adjusting weights until errors shrink.

---

### Module 3: Multi-Class Classification ✅ COMPLETE

**Core Question:** How do you recognize many categories, not just one?

**Key Concepts:**
- One neuron per class (output layer)
- Softmax-style selection (pick highest activation)
- Training on multiple examples
- Convergence and error curves

**What We Built:**
- `NeuralNetwork.cs` — array of neurons, one per animal
- `BetterGame.cs` — neural network-based 20Q
- Error tracking during training

**Key Insight:** A network is just neurons working together. Each learns to recognize one pattern.

---

### Module 4: Data Management ✅ COMPLETE

**Core Question:** How do you scale beyond hardcoded data?

**Key Concepts:**
- Separation of concerns (entities vs models)
- Relational data modeling (many-to-many relationships)
- Dynamic network sizing based on data
- Entity Framework Core basics

**What We Built:**
- Database schema: Animals, Questions, AnimalAnswers
- `TwentyQContext.cs` with seeding
- Dynamic loading: add animals/questions without code changes

**Key Insight:** The network structure should be driven by data, not hardcoded.

---

### Module 5: Hidden Layers & Deep Learning ⏳ CURRENT

**Core Question:** Why can't a single layer solve everything?

**Key Concepts:**
- Linear separability (what one neuron CAN'T learn)
- XOR problem as the classic example
- Hidden layers as "feature detectors"
- Composition: combining simple patterns into complex ones
- Universal approximation theorem (enough neurons can learn anything)

**To Build:**
- Multi-layer network: Input → Hidden → Output
- Understanding what hidden neurons "see"

**Key Insight:** Hidden layers learn intermediate representations — "water bird", "flying mammal" — that make the final classification easier.

---

### Module 6: Backpropagation ⏳ UPCOMING

**Core Question:** How do errors flow backward through layers?

**Key Concepts:**
- The credit assignment problem (which weight caused the error?)
- Chain rule from calculus (don't panic — we'll build intuition first)
- Gradient descent: walking downhill on the error surface
- Forward pass vs backward pass

**To Build:**
- Backpropagation algorithm from scratch
- Visualizing error gradients

**Key Insight:** Each layer asks "how much did I contribute to the error?" and adjusts accordingly.

---

### Module 7: Training at Scale ⏳ UPCOMING

**Core Question:** How do you train on millions of examples efficiently?

**Key Concepts:**
- Batch vs stochastic vs mini-batch training
- Learning rate schedules (start big, go small)
- Overfitting and generalization
- Validation sets: "trust but verify"

**To Build:**
- Configurable training loop
- Early stopping when converged

**Key Insight:** More data beats better algorithms — but only if you train properly.

---

### Module 8: Persistence & Production ⏳ UPCOMING

**Core Question:** How do you save and load a trained network?

**Key Concepts:**
- Model serialization (weights + architecture)
- Database schema for multi-layer networks
- Incremental learning (train more without starting over)
- Model versioning

**To Build:**
- Save/load network state to database
- Skip retraining on startup
- Continue learning from new games

**Key Insight:** Training is expensive. Inference is cheap. Save your work.

---

### Module 9: Smart Question Selection ⏳ OPTIONAL/ADVANCED

**Core Question:** What question gives the most information?

**Key Concepts:**
- Entropy and information gain
- Decision trees vs neural networks
- Active learning: let the model choose what to learn

**To Build:**
- Question ranking by discriminative power
- Dynamic question ordering during gameplay

**Key Insight:** Not all questions are equal. "Does it fly?" might be useless if you've narrowed to aquatic animals.

---

### Module 10: Comparison with ML Libraries ⏳ OPTIONAL

**Core Question:** What do real libraries do differently?

**Key Concepts:**
- ML.NET architecture
- Tensor operations and GPU acceleration
- Why frameworks exist (and when to use them)

**To Explore:**
- Reimplement 20Q in ML.NET
- Compare code complexity and performance

**Key Insight:** Understanding the fundamentals makes you a better user of libraries.

---

### Module 11: Building the UI ⏳ FINAL

**Core Question:** How do you make this fun to play?

**Tech Stack:** Blazor + MudBlazor (student's comfort zone)

**To Build:**
- Web interface for the game
- Training dashboard showing network learning
- Animal/question management UI

---

## Progress Tracking

| Module | Status | Key Deliverable |
|--------|--------|-----------------|
| 1. Foundations | ✅ Complete | `Game.cs` with k-NN |
| 2. Learning | ✅ Complete | `Neuron.cs` from scratch |
| 3. Multi-Class | ✅ Complete | `NeuralNetwork.cs` |
| 4. Data | ✅ Complete | EF Core integration |
| 5. Hidden Layers | ⏳ In Progress | Multi-layer network |
| 6. Backprop | ⏳ Upcoming | Training deep networks |
| 7. Scale | ⏳ Upcoming | Efficient training |
| 8. Persistence | ⏳ Upcoming | Save/load models |
| 9. Questions | 🔷 Optional | Smart question selection |
| 10. Libraries | 🔷 Optional | ML.NET comparison |
| 11. UI | ⏳ Final | Blazor app |

---

## Key Bugs & Lessons (Learning Log)

**Reference vs Value Types:**
All neurons shared the same weights array because arrays are reference types. Fix: create new array inside the loop.

**Loop Variable Scope:**
`var i = 0` inside foreach resets every iteration. Fix: declare outside loop.

**EF Core Seeding:**
Navigation properties with `= new Entity()` break seeding. Fix: leave them null.

**Dynamic Sizing:**
Hardcoded `[0,0,0,0]` breaks when questions change. Fix: use `questions.Count`.

---

## How to Resume This Course

1. Upload this document to the conversation
2. Share current code state (or repo access)
3. Say "Let's continue from Module X" or "Where did we leave off?"

**Last checkpoint:** Beginning of Module 5 (Hidden Layers). Student was asked: "If TWO neurons feed into a THIRD neuron, what can it detect that a single neuron couldn't?"

---

## Resources & References

- **Neural Networks from Scratch** (book by Harrison Kinsley)
- **3Blue1Brown Neural Network series** (YouTube) — excellent visualizations
- **Michael Nielsen's online book** — math with intuition

---

## Project Repository

GitHub: https://github.com/luiscmt22/TwentyQ

---

*Last updated: During Module 5 introduction*
