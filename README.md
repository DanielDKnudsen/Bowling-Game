# Daniels bowling game

## Project structure:
This project is divided into 2 projects.

1. The program itself (console application in .NET 6 -> ./BowlingGame)
2. The tests for subset of logic in console application (./BowlingGame.Tests)

The Console application consists of the Program.cs file which is the entry-point of the application. The main part of the logic is found in the Controller class called "GameController.cs" while models are created in the Models folder.

The implementation "idea" is to place logic and state used for playing a 10-pin bowling game in the controller-class allowing for testability of the logic.

## Notes and afterthoughts

With more time I would have liked to implement the correct scoring system as I found out after implementing this program that my assumptions for the scoring system was incorrect (points for Strikes and Spares are calculated after subsequent shots).
