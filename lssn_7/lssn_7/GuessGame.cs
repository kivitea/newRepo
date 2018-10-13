using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lssn_7
{
    class GuessGame
    {
        public int Answer, RoundNum, MinValue, MaxValue;
        Random rnd = new Random();

        public GuessGame()
        {
            Answer = rnd.Next(1, 100);
            RoundNum = 0;
            MinValue = 0;
            MaxValue = 100;
        }

        public int checkValue(int currentValue)
        {
            RoundNum++;

            if (currentValue == Answer) return 0;
            else if (currentValue > Answer)
            {
                if (MaxValue > currentValue) MaxValue = currentValue;
                return 1;
            }
            else
            {
                if (MinValue < currentValue) MinValue = currentValue;
                return -1;
            }
        }

    }
}
