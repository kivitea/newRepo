using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lssn_5
{
    class Message
    {
        static string[] GetWordsArray(StringBuilder sb)
        {
            for (int i = 0; i < sb.Length;)
            {
                if (char.IsPunctuation(sb[i])) sb.Remove(i, 1);
                else i++;
            }
            string s = sb.ToString();
            string[] Words_arr = s.Split(' ');

            return Words_arr;
        }

        public static StringBuilder shWords(StringBuilder sb, int MaxLength)
        {

            string[] s = GetWordsArray(sb);
            StringBuilder NewSB = new StringBuilder();

            for(int i = 0; i<s.Length; i++)
            {
                if (s[i].Length <= MaxLength) NewSB = NewSB.Append($"{s[i]} ");
            }

            return NewSB;

        }

        public static StringBuilder CheckLastSym(StringBuilder sb, string LastSym)
        {
            string[] s = GetWordsArray(sb);
            StringBuilder NewSB = new StringBuilder();

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i][s[i].Length - 1] != LastSym[0]) NewSB = NewSB.Append($"{s[i]} ");
            }

            return NewSB;
        }

        public static string getLongWord(StringBuilder sb)
        {
            string[] s = GetWordsArray(sb);
            int MaxLength = 0;
            string result = string.Empty;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].Length > MaxLength) MaxLength = s[i].Length;
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].Length == MaxLength) return s[i];
            }

            return result;

        }

        public static StringBuilder longWords(StringBuilder sb)
        {

            string[] s = GetWordsArray(sb);
            int MaxLength = 0;
            string result = string.Empty;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].Length > MaxLength) MaxLength = s[i].Length;
            }

            StringBuilder NewSB = new StringBuilder();

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].Length == MaxLength) NewSB = NewSB.Append($"{s[i]} ");
            }

            return NewSB;

        }
    }
}
