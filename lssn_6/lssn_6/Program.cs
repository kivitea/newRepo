/*  Иван Васильев
 * 1. Изменить программу вывода функции так, чтобы можно было передавать функции типа double (double,double). 
 * Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).
 * 2. Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата.
 *      а) Сделайте меню с различными функциями и предоставьте пользователю выбор, для какой функции и на каком отрезке находить минимум.
 *      б) Используйте массив (или список) делегатов, в котором хранятся различные функции.
 *      в) *Переделайте функцию Load, чтобы она возвращала массив считанных значений. Пусть она возвращает минимум через параметр.
 *  3. Переделать программу «Пример использования коллекций» для решения следующих задач:
 *      а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
 *      б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся (частотный массив);
 *      в) отсортировать список по возрасту студента;
 *      г) *отсортировать список по курсу и возрасту студента;
 *      д) разработать единый метод подсчета количества студентов по различным параметрам выбора с помощью делегата и методов предикатов.
*/ 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using lssn_6;

namespace lssn_6
{
    public delegate double Fun(double x, double a);

    class Program
    {
        static void WriteHead()
        {
            Console.Clear();
            Console.WriteLine("Исполнитель: Иван Васильев\nДомашнее задание к 6-му уроку\n\n");
        }

        public static void Table(Fun F, double a, double b, double k)
        {
            while (a <= b)
            {
                Console.WriteLine($"x = {a}  y = {Math.Round(F(a, k), 2)}");
                a++;
            }

        }

        public static double NewPow(double x, double a)
        {
            return a * Math.Pow(x, 2);
        }

        public static double NewSin(double x, double a)
        {
            return a * Math.Sin(x);
        }

        public static void SaveFunc(string FileName, Fun F, double a, double b, double h, double k)
        {
            FileStream fs = new FileStream(FileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);

            double x = a;
            while (x <= b)
            {
                bw.Write(F(x, 2));
                x += h;
            }

            bw.Close();
            fs.Close();

        }

        public static double[] Load(string FileName, out double min)
        {
            FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            min = double.MaxValue;

            double[] newArr = new double[0];

            for (int i = 0; i<fs.Length/sizeof(double); i++)
            {
                Array.Resize(ref newArr, i + 1);
                newArr[i] = br.ReadDouble();

                if (newArr[i] < min) min = newArr[i];
            }

            br.Close();
            fs.Close();
            return newArr;
        }

        static void Main()
        {
            WriteHead();

            Console.WriteLine("Выберите действие:\n1. Вывод значений функции\n2. Минимум функции\n3. Пример использования коллекций");
            string varNum = Console.ReadLine();

            if (varNum == "1") Ex_1();
            else if (varNum == "2") Ex_2();
            else if (varNum == "3") Ex_3();
            else Console.WriteLine("Такого варианта нет");
            
            Console.WriteLine("\nВыберите дальнейшее дествие:\nВведите \"1\" чтобы вернуться в меню\nЧтобы завершить программу нажмите любую другую кнопку");
            varNum = Console.ReadLine();

            if (varNum == "1") Main();
        }

        //  Решение 1-й задачи
        static void Ex_1()
        {
            WriteHead();

            Console.WriteLine("Выберите действие:\n1. Вывести значения функции a*x^2\n2. Вывести значения функции a*sin(x)");
            string varNum = Console.ReadLine();

            Console.Write("\nВведите a: ");
            double a = Convert.ToDouble(Console.ReadLine());

            WriteHead();
            Console.WriteLine($"Значения функции {(varNum == "1" ? "a*x^2" : "a*sin(x)")}:");
            if (varNum == "1") Table(NewPow, -2, 2, a);
            else Table(NewSin, -2, 2, a);

        }

        //  Решение 2-й задачи
        //  Для демонстрации использованы те же функции, что и в 1-й задаче
        //  Не совсем понял, что нужно было сделать в пункте (б) - не стал делать, т.к. используются только две функции
        static void Ex_2()
        {
            WriteHead();

            Console.WriteLine("Выберите действие:\n1. Вывести значения функции 2*x^2\n2. Вывести значения функции 2*sin(x)");
            string varNum = Console.ReadLine();

            Console.Write("\nВведите начало интервала (a): ");
            double a = Convert.ToDouble(Console.ReadLine());

            Console.Write("\nВведите конец интервала (b): ");
            double b = Convert.ToDouble(Console.ReadLine());

            Console.Write("\nВведите шаг (h): ");
            double h = Convert.ToDouble(Console.ReadLine());

            if (varNum == "1") SaveFunc("data.bin", NewPow, a, b, h, 2);
            else SaveFunc("data.bin", NewSin, a, b, h, 2);

            double min;
            double[] newArr = Load("data.bin", out min);

            Console.WriteLine($"Минимум функции: {min}");

        }

        //  Решение 3-й задачи
        static void Ex_3()
        {
            WriteHead();

            int[] courseCountArr = new int[6];
            int studCount_5 = 0;
            int studCount_6 = 0;
            List<Student> newList = new List<Student>();

            StreamReader sr = new StreamReader("students_1.csv");

            while (!sr.EndOfStream)
            {
                string[] s = sr.ReadLine().Split(';');
                newList.Add(new Student(s[0], s[1], s[2], s[3], s[4], Convert.ToInt32(s[5]), Convert.ToInt32(s[6]), Convert.ToInt32(s[7]), s[8]));

                if (newList[newList.Count - 1].age >= 18 && newList[newList.Count - 1].age <= 20) courseCountArr[newList[newList.Count - 1].course - 1]++;
                if (newList[newList.Count - 1].course == 5) studCount_5++;
                else if (newList[newList.Count - 1].course == 6) studCount_6++;
            }
            sr.Close();

            newList.Sort(new Comparison<Student>(Student.MyDelegat));

            Console.WriteLine($"Всего студентов: {newList.Count}\nКоличество студентов 5-го курса: {studCount_5}\nКоличество студентов 6-го курса: {studCount_6}\n");

            for (int i = 0; i<courseCountArr.Length; i++)
            {
                Console.WriteLine($"Количество студентов в возрасте от 18-ти до 20-ти лет на {i+1}-м курсе: {courseCountArr[i]}");
            }

            Console.WriteLine("\nДалее список будет отсортирован по курсу и возрасту. Нажмите любую клавишу");
            Console.ReadKey();
            WriteHead();

            foreach (Student st in newList) Console.WriteLine($"{st.firstName} {st.lastName} курс: {st.course} возраст: {st.age}");
        }
    }
}
