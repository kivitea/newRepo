using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lssn_4
{
    class Matrix
    {
        int[,] a;
        Random rnd = new Random();

        /// <summary>
        /// Конструктор, создающий массив случайных чисел
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <param name="minNum"></param>
        /// <param name="maxNum"></param>
        public Matrix(int n, int m, int minNum, int maxNum)
        {

            a = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    a[i, j] = rnd.Next(minNum, maxNum);
                }
            }

        }

        // Решение 4-й задачи (б, в)
        public Matrix(string Path)
        {
            StreamReader sr;
            try
            {
                sr = new StreamReader(Path);
            }
            catch { throw new ArgumentException("Файл не найден"); }

            int n=0, m=0, m_temp, currentNum;
            string currentNum_str = "";

            while (!sr.EndOfStream)
            {
                string s = sr.ReadLine();
                n++;
                m_temp = 0;

                for (int i = 0; i < s.Length; i++)
                {
                    if (Int32.TryParse(s.Substring(i, 1), out currentNum))
                    {
                        currentNum_str += s.Substring(i, 1);
                    }
                    else if (currentNum_str != "")
                    {
                        m_temp++;
                        currentNum_str = "";
                    }
                }
                if (currentNum_str != "")
                {
                    m_temp++;
                    currentNum_str = "";
                }

                    if (m_temp > m) m = m_temp;
                m_temp = 0;
            }

            if (n == 0) throw new ArgumentException("Файл пустой или не содержит чисел");

            a = new int[n, m];

            sr = new StreamReader(Path);
            n = 0;
            currentNum_str = "";

            while (!sr.EndOfStream)
            {
                string s = sr.ReadLine();
                m_temp = 0;

                for (int i = 0; i < s.Length; i++)
                {
                    if (Int32.TryParse(s.Substring(i, 1), out currentNum))
                    {
                        currentNum_str += s.Substring(i, 1);
                    }
                    else if (currentNum_str != "")
                    {
                        a[n, m_temp] = Convert.ToInt32(currentNum_str);
                        m_temp++;
                        currentNum_str = "";
                    }
                }
                if (currentNum_str != "")
                {
                    a[n, m_temp] = Convert.ToInt32(currentNum_str);
                    m_temp++;
                    currentNum_str = "";
                }

                m_temp = 0;
                n++;
            }

        }

        public int getSum()
        {

            int Sum = 0;

            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Sum += a[i, j];
                }
            }

            return Sum;

        }

        public int getSum(int MinNum)
        {

            int Sum = 0;

            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Sum += a[i, j] > MinNum ? a[i, j] : 0;
                }
            }

            return Sum;

        }

        public string ToString()
        {

            string s = "";

            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    s += $"{a[i, j]} ";
                }

                s += "\n";
            }

            return s;

        }

        public void ToFile(string Path)
        {

            string[] s = new string[a.GetLength(0)];

            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    s[i] += $"{a[i, j]} ";
                }

            }

            try
            {
                File.WriteAllLines(Path, s);
            }
            catch { throw new ArgumentException("Не удалось записать файл"); }
        }

        public int Min
        {
            get
            {
                int Min = a[0, 0];

                for (int i = 0; i < a.GetLength(0); i++)
                {
                    for (int j = 0; j < a.GetLength(1); j++)
                    {
                        if (a[i, j] < Min) Min = a[i, j];
                    }
                }

                return Min;
            }
        }

        public int Max
        {
            get
            {
                int Max = a[0, 0];

                for (int i = 0; i < a.GetLength(0); i++)
                {
                    for (int j = 0; j < a.GetLength(1); j++)
                    {
                        if (a[i, j] > Max) Max = a[i, j];
                    }
                }

                return Max;
            }
        }

        public void GetMaxIndex(out int n, out int m)
        {

            n = -1;
            m = -1;

            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (a[i, j] == Max)
                    {

                        n = i;
                        m = j;

                    }
                }
            }

        }
    }
}
