using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bowling_game.Models
{
    public class Player
    {
        public string Name { get; set; } = "";
        public int Score { get; set; } = 0;
        public List<Frame> Frames { get; set; } = new List<Frame>();
    }
}
