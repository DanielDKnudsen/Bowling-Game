using bowling_game.Controllers;
using bowling_game.Models;

namespace BowlingGame.Tests;

public class GameControllerTest
{
    [Fact]
    public void GetPlayerCount2()
    {
        var gameController = new GameController();
        gameController.SetPlayerCount("2");
        Assert.Equal(2, gameController.game.Players);
    }
    [Fact]
    public void GetPlayerCount5()
    {
        var gameController = new GameController();
        gameController.SetPlayerCount("5");
        Assert.Equal(5, gameController.game.Players);
    }

    [Fact]
    public void CalculateScoreFirstThrowStandardStrike() {
        var gameController = new GameController();
        int result = gameController.CalculateScoreFirstThrow(10, new List<ShootType> { ShootType.Standard, ShootType.Strike });

        Assert.Equal(20, result);
    }

    [Fact]
    public void CalculateScoreFirstThrowStrikeStrike()
    {
        var gameController = new GameController();
        int result = gameController.CalculateScoreFirstThrow(7, new List<ShootType> { ShootType.Strike, ShootType.Strike });

        Assert.Equal(21, result);
    }

    [Fact]
    public void CalculateScoreFirstThrowStrikeSpare()
    {
        var gameController = new GameController();
        int result = gameController.CalculateScoreFirstThrow(7, new List<ShootType> { ShootType.Strike, ShootType.Spare });

        Assert.Equal(14, result);
    }

    [Fact]
    public void CalculateScoreFirstThrowStandardStandard()
    {
        var gameController = new GameController();
        int result = gameController.CalculateScoreFirstThrow(7, new List<ShootType> { ShootType.Standard, ShootType.Standard });

        Assert.Equal(7, result);
    }

    [Fact]
    public void CalculateScoreFirstThrowStandardSpare()
    {
        var gameController = new GameController();
        int result = gameController.CalculateScoreFirstThrow(7, new List<ShootType> { ShootType.Standard, ShootType.Spare });

        Assert.Equal(14, result);
    }
}