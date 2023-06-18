using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bowling_game.Models;

namespace bowling_game.Controllers
{
    public class GameController: IGameController
    {
        public Game game;
        public GameController()
        {
            game = new Game();
        }
        public void SetPlayerCount(string consoleInput)
        {
            try
            {
                game.Players = Convert.ToInt32(consoleInput);
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Couldn't convert input to integer. Try again");
            }
        }

        private ShootType GetFirstShootType(int score)
        {
            if (score == 0)
            {
                return ShootType.GutterOrFoul;
            }
            else if (score == 10)
            {
                return ShootType.Strike;
            }
            else return ShootType.Standard;
        }

        public Player PlayGame(List<Player> playerList)
        {
            for (int i = 1; i < 13; i++)
            {
                playerList.ForEach(player =>
                {
                    // Check if 10th frame was strike - grant 2 extra shots
                    if (i == 10 && player.Frames.Last().Shot != ShootType.Strike)
                    {
                        return;
                    }

                    Frame frame = new Frame();
                    Console.WriteLine($"It is now {player.Name}'s {i} turn:");
                    Console.WriteLine($"Please input score.");
                    int score = GetInput();
                    ShootType firstShotType = GetFirstShootType(score);
                    // If not a strike, ask for second throw result
                    if (firstShotType != ShootType.Strike) {
                        Console.WriteLine($"Input score for second throw.");
                        int scoreSecondThrow = GetInput();
                        if (score + scoreSecondThrow == 10)
                        {
                            frame.Shot = ShootType.Spare;
                        } else
                        {
                            frame.Shot = ShootType.Standard;
                        }
                    }
                    else
                    {
                        frame.Shot = ShootType.Strike;
                    }
                    List<ShootType> latestTwoFrames = GetLastTwoFramesShootTypes(player);
                    int scoreAdjusted = CalculateScoreFirstThrow(score, latestTwoFrames);
                    int scoreSecondThrowAdjusted = CalculateScoreSecondThrow(score, latestTwoFrames[1], firstShotType);

                    frame.Score = scoreAdjusted + scoreSecondThrowAdjusted;

                    player.Frames.Add(frame);
                    player.Score = player.Frames.Select(frame => frame.Score).Sum();
                    Console.WriteLine($"Player {player.Name} now has {player.Score} points.");

                });
            }

            return playerList.MaxBy(player => player.Score);
        }

        public int CalculateScoreFirstThrow(int score, List<ShootType> latestTwoFrames)
        {
            ShootType lastFrameShot = latestTwoFrames[1];
            ShootType SecondLastFrameShot = latestTwoFrames[0];
            if (lastFrameShot == ShootType.Strike || lastFrameShot == ShootType.Spare || (SecondLastFrameShot == ShootType.Strike && lastFrameShot == ShootType.Strike))
            {
                if (lastFrameShot == ShootType.Strike && SecondLastFrameShot == ShootType.Strike)
                {
                    return score * 3;
                }
                else return score * 2;
            }
            else return score;

        }

        private int CalculateScoreSecondThrow(int scoreSecondThrow, ShootType lastFrameSecondShot, ShootType lastShot)
        {
            if (lastShot == ShootType.Strike)
            {
                return 0;
            } else if (lastFrameSecondShot == ShootType.Strike)
            {
                return scoreSecondThrow * 2;
            }
            else return scoreSecondThrow;
        }

        private List<ShootType> GetLastTwoFramesShootTypes(Player player)
        {
            if (player.Frames.Count == 0)
            {
                return new List<ShootType> {ShootType.Standard, ShootType.Standard};
            } else if (player.Frames.Count == 1)
            {
                return new List<ShootType> { ShootType.Standard, player.Frames[0].Shot };
            } else
            {
                return new List<ShootType> { player.Frames[^2].Shot, player.Frames[^1].Shot };
            }
        }


        private static int GetInput()
        {
            try
            {
                string consoleInput = Console.ReadLine();
                int score = Convert.ToInt32(consoleInput);
                if (score > 10 || score < 0)
                {
                    throw new System.FormatException();
                }
                return score;
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Couldn't convert input to integer or invalid score. Try again");
                return GetInput();
            }
        }
    }
}
