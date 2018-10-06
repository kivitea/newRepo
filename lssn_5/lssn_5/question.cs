using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lssn_5
{
    class Question
    {
        private string Quest;
        private bool Answer;

        public Question(string InputData)
        {

            Quest = InputData.Substring(0, InputData.IndexOf("?") + 1);
            Answer = InputData.Substring(InputData.Length - 1) == "+";

        }

        public bool CheckAnswer(bool currAnswer)
        {
            return Answer == currAnswer;
        }

        public bool getAnswer()
        {
            Console.WriteLine($"Верите ли вы что {Quest}\n0. Нет\n1. Да");
            string varNum = Console.ReadLine();

            return varNum == "1";
        }
    }
}
