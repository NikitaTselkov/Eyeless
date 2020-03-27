using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eyeless.Navigation
{
    public class NavigateArgs2
    {

        public NavigateArgs2()
        {

        }

        public NavigateArgs2(int score, int time, int level)
        {
            Score = score;
            Time = time;
            Level = level;
        }

        public int Score { get; set; }

        public int Time { get; set; }

        public int Level { get; set; }
    }
}
