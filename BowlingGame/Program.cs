// See https://aka.ms/new-console-template for more information
using bowling_game.Models;
using bowling_game.Controllers;
using System.Linq.Expressions;
using System.Numerics;

List<Player> playerList = new List<Player>();
GameController setupController = new GameController();

bool playerAmountCorrect = false;

Console.WriteLine("Please input amount of players in this bowling game");

while (!playerAmountCorrect)
{
    string amountPlayersString = Console.ReadLine();
    setupController.SetPlayerCount(amountPlayersString);
    if (setupController.game.Players != -1)
    {
        playerAmountCorrect = true;
    }
}

Console.WriteLine($"A game with {setupController.game.Players} players will be started.");

for (int i = 0; i < setupController.game.Players; i++)
{
    Player player = new Player();
    Console.WriteLine($"Input name for player {i + 1}");
    player.Name = Console.ReadLine();
    playerList.Add(player);
}
Console.WriteLine($"Alright, everything is now set up. Game will start now");

Player winningPlayer = setupController.PlayGame(playerList);

Console.WriteLine($"Thanks for Playing. Player {winningPlayer.Name} won with score of {winningPlayer.Score}");
Console.ReadLine();
