using bowling_game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bowling_game.Controllers
{
    internal interface IGameController
    {
        void SetPlayerCount(string consoleInput);
        Player PlayGame(List<Player> playerList);
        int CalculateScoreFirstThrow(int score, List<ShootType> latestTwoFrames);
    }
}