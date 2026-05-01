# 🤖 Development & Learning Protocol: EcosystemSim

This document serves as the architectural guide for agents and developers working on this C# project. The goal is to master **Enterprise Design Patterns** and **SOLID Principles** within the .NET ecosystem.

---

## 🎯 Current Project Phase: Junior-to-Intermediate Transition
We are building a grid-based ecosystem simulation to demonstrate how decoupled code allows for complex system behavior.

## 🛠 Architectural Standards

### 1. The State Pattern (Behavioral Logic)
- **Rule:** No `if/else` or `switch` blocks are allowed inside `Critter.cs` to handle behavior based on energy or environment.
- **Implementation:** All logic must be encapsulated in classes implementing `IState`.
- **Transitioning:** The `Critter` class maintains a `TransitionTo(IState newState)` method. States are responsible for triggering transitions.

### 2. The Factory Pattern (Creation Logic)
- **Rule:** Never use the `new` keyword for Entities inside `Program.cs`.
- **Implementation:** Use `EntityFactory.CreateCritter(string type)`.
- **Goal:** Centralize configuration and validation of entity stats.

### 3. The Strategy Pattern (Behavior Swapping)
- **Rule:** Movement logic must not be hardcoded in `Critter.cs`.
- **Implementation:** Movement is delegated to `IMovementStrategy` instances (Walk, Fly, Swim).
- **Swapping:** The `MovementStrategy` property on `Critter` can be changed at runtime.

### 4. Dependency Injection
- **Rule:** The Factory must not use the `new` keyword for strategies or system components.
- **Implementation:** Strategies are injected via `[FromKeyedServices]` in the `EntityFactory` constructor.
- **Registration:** All services are registered in `Program.cs` using `ServiceCollection` with keyed strategies.

### 5. Folder Structure
Maintain strict separation of concerns:
- `/Sandbox/Core`: Interfaces (`IEntity.cs`, `IState.cs`, `IMovementStrategy.cs`).
- `/Sandbox/Entities`: Domain objects (`Critter.cs`).
- `/Sandbox/States`: State logic (`IdleState.cs`, `HungryState.cs`, `RainState.cs`).
- `/Sandbox/Strategies`: Strategy implementations (`MovementStrategies.cs`).
- `/Sandbox/Systems`: System services (`WeatherSystem.cs`).
- `/Sandbox/Factories`: Creation logic (`EntityFactory.cs`).

---

## 🏗 Future Roadmap (Learning Milestones)

| Pattern | Goal | Status |
| :--- | :--- | :--- |
| **State** | Handle Hunger vs. Idle behaviors | ✅ Completed |
| **Factory** | Centralized creation of Wolves/Rabbits | ✅ Completed |
| **Observer** | Implement a `WeatherSystem` to notify all Entities | ✅ Completed |
| **Strategy** | Swapping movement types (Swim, Fly, Walk) | ✅ Completed |
| **Dependency Injection** | Refactor Factory to use .NET DI Container | ✅ Completed |

---

## 📝 Instructions for AI Agents
When assisting with this project:
1. **Prioritize Scannability:** Use code blocks and bullet points.
2. **C# Idioms:** Use modern C# features (File-scoped namespaces, Primary constructors, Expression-bodied members).
3. **The "Why" Before "How":** Explain which SOLID principle is being applied before providing code.
4. **Zero-Footprint Personalization:** Do not reference the user's background or skill level in the response; focus purely on technical execution.
