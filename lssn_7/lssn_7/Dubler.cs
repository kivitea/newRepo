using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lssn_7
{
    class Dubler
    {
        public int RoundNum, CurrentValue, Answer;
        private Stack<int> Values;

        Random rnd = new Random();
        
        public Dubler()
        {
            RoundNum = 1;
            Values = new Stack<int>();
            CurrentValue = 1;

            Answer = rnd.Next(2, 1000);
        }

        private void newRound()
        {
            RoundNum++;
            Values.Push(CurrentValue);
        }

        public void Sum()
        {
            newRound();
            CurrentValue++;
        }

        public void Mult()
        {
            newRound();
            CurrentValue = CurrentValue*2;
        }

        public void Cancell()
        {
            if (Values.Count == 0) return;

            CurrentValue = Values.Pop();
            RoundNum--;
        }
    }
}
