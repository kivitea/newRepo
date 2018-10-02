using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lssn_4
{
    class MyArray
    {

        private int[] a;
        Random rnd = new Random();

        /// <summary>
        /// Конструктор, создающий массив случайных чисел
        /// </summary>
        /// <param name="n">длина массива</param>
        /// <param name="minNum">нижняя граница рандома</param>
        /// <param name="maxNum">верхняя граница рандома</param>
        public MyArray(int n, int minNum, int maxNum)
        {

            a = new int[n];
            for (int i = 0; i < n; i++)
            {
                a[i] = rnd.Next(minNum, maxNum);
            }

        }

        /// <summary>
        /// Конструктор, создающий массив с заданным шагом. Добавил признак "по возрастанию", т.к. набор параметров (длина, стартовое значение, шаг) уже занят
        /// </summary>
        /// <param name="n">длина массива</param>
        /// <param name="minNum">стартовое значение</param>
        /// <param name="stValue">шаг</param>
        /// <param name="inc">признак по возрастанию - истина: по возрастанию; ложь: по убываниию</param>
        public MyArray(int n, int minNum, int stValue, bool inc)
        {

            a = new int[n];
            a[0] = minNum;
            for (int i = 1; i < n; i++)
            {
                a[i] = a[i - 1] + (inc ? 1 : -1) * stValue;
            }

        }

        // Решение 2-й задачи (б) и 4-й (в)
        public MyArray(string Path)
        {

            a = new int[0];
            int n = 0;
            int currentNum;
            string currentNum_str = "";
            string s = "";

            try
            {
                s = File.ReadAllText(Path);
            }
            catch { throw new ArgumentException("Файл не найден"); }

            for (int i = 0; i< s.Length; i++)
            {
                if (Int32.TryParse(s.Substring(i,1), out currentNum))
                {
                    currentNum_str += s.Substring(i, 1);
                }
                else if (currentNum_str != "")
                {
                    n++;
                    Array.Resize(ref a, n);
                    a[n - 1] = Convert.ToInt32(currentNum_str);
                    currentNum_str = "";
                }
            }

            if (currentNum_str != "")
            {
                n++;
                Array.Resize(ref a, n);
                a[n - 1] = Convert.ToInt32(currentNum_str);
            }

            if (a.Length == 0) throw new ArgumentException("Файл пустой или не содержит чисел");

        }

        public int this[int i]
        {
            get { return a[i]; }
            set { a[i] = value; }
        }

        public int Max
        {
            get
            {
                int Max = a[0];
                for(int i = 1; i<a.Length; i++)
                {
                    if (a[i] > Max) Max = a[i];
                }

                return Max;
            }
        }

        public int MaxCount
        {
            get
            {
                int MaxCount = 0;
                for (int i = 1; i < a.Length; i++)
                {
                    if (a[i] == Max) MaxCount++;
                }

                return MaxCount;
            }
        }

        public int length
        {
            get { return a.Length; }
        }

        public int Sum
        {
            get
            {
                int arr_sum = 0;
                for(int i=0; i<a.Length; i++)
                {
                    arr_sum += a[i];
                }

                return arr_sum;
            }
        }

        public string ToString()
        {
            string s = "";

            for (int i = 0; i < length; i++) s += $"{(i == 0 ? "" : " ")}{a[i]}{(i == length - 1 ? "" : ",")}";

            return s;
        }

        public void ToFile(string Path)
        {
            try
            {
                File.WriteAllText(Path, ToString());
            }
            catch { throw new ArgumentException("Не удалось записать файл");  }
        }

        public void Inverse()
        {
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = -1*a[i];
            }
        }

        public void Mult(int k)
        {
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = k * a[i];
            }
        }

    }
}
