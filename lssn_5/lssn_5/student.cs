using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lssn_5
{
    class Student
    {

        public string Name;
        public double AvRating;
        public int[] Rating_arr;

        public Student(string s)
        {
            int i = 1;

            while (!char.IsDigit(s[i]))
            {
                Name += s[i - 1];

                i++;
            }

            Rating_arr = new int[3];
            Rating_arr[0] = Convert.ToInt32(s[s.Length - 5].ToString());
            Rating_arr[1] = Convert.ToInt32(s[s.Length - 3].ToString());
            Rating_arr[2] = Convert.ToInt32(s[s.Length - 1].ToString());

            AvRating = Rating_arr.Sum() / 3.0;
        }

        public string ToString()
        {
            return $"{Name}. Оценки: {Rating_arr[0]} {Rating_arr[1]} {Rating_arr[2]}. Средний балл: {Math.Round(AvRating, 2)}";
        }

        public static void Sort(ref Student[] stArray)
        {
            for(int i = 0; i < stArray.Length; i++)
            {
                for(int j = i; j<stArray.Length; j++)
                {
                    if(stArray[i].AvRating > stArray[j].AvRating)
                    {
                        Student st_Temp = stArray[i];
                        stArray[i] = stArray[j];
                        stArray[j] = st_Temp;
                    }
                }
            }
        }

    }
}
