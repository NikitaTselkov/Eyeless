using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eyeless.Models
{
    public class MainModel
    {

        public string Divide()
        {
            string name1 = "Array   Int   String   Array   Int   String   Int   String   Array   Int   String   Int   String   Array   Int   String";

            //char[] item = name1.ToCharArray();
            //foreach (var Item in item)
            //{
            //    return Item.ToString();
            //}
            return name1;
        }


        public string LevelControll(int Score, int Level)
        {
                Level = Score / 25;

            return $"Level {Level}";
        }


    }
}
