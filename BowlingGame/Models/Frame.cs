using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bowling_game.Models
{
    public class Frame
    {
        public ShootType Shot { get; set; }
        public int Score { get; set; } = 0;
    }
}
