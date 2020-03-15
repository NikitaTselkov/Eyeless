
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eyeless.Models
{
    public class MainModel
    {

        public int LevelControll(int Score, int Level)
        {
                Level = Score / 25;

            return Level;
        }

    }
}
