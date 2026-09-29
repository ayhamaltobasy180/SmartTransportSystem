# Smart Transport System

A console-based management system written in C# to manage transport company operations, including passengers, drivers, trips, bookings, and notifications.

## Key Feature
- **OOP Principles**: Applied abstraction, inheritance, encapsulation, and polymorphism across entities.
- **Generic Repository**: Generic `Repository<T>` class for managing entities.
- **Event Handling**: Custom delegates and events for booking and cancellation notifications.
- **Interfaces**: Implemented interfaces including `IBookable`, `IPayable`, `INotifiable`, `IRatable`, and `IReportable`.
- **Input Validation**: System-wide input validation including email format checking using Regex.

## Project Structure
- `classes/`: Core domain models, interfaces, and business logic.
- `Program.cs`: Console interface and execution entry point with sample demo data.

## Getting Started

### Prerequisites
- .NET SDK (6.0 or later)
- Visual Studio or VS Code

### Run the Application
1. Clone the repository:
   git clone https://github.com/ayhamaltobasy180/SmartTransportSystem.git

2. Open the solution in Visual Studio or navigate to the project directory.

3. Build and run:
   dotnet run
