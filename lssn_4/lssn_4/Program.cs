/*  Иван Васильев
 *  1. Дан целочисленный массив из 20 элементов. Элементы массива могут принимать целые значения от –10 000 до 10 000 включительно. 
 *     Написать программу, позволяющую найти и вывести количество пар элементов массива, в которых хотя бы одно число делится на 3. 
 *     В данной задаче под парой подразумевается два подряд идущих элемента массива. Например, для массива из пяти элементов: 6; 2; 9; –3; 6 – ответ: 4. 
 *  2. а) Дописать класс для работы с одномерным массивом. Реализовать конструктор, создающий массив заданной размерности и заполняющий массив числами 
 *      от начального значения с заданным шагом. Создать свойство Sum, которые возвращают сумму элементов массива, метод Inverse, меняющий знаки у всех 
 *      элементов массива, метод Multi, умножающий каждый элемент массива на определенное число, свойство MaxCount, возвращающее количество максимальных 
 *      элементов. В Main продемонстрировать работу класса.
 *     б)Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
 *  3. Решить задачу с логинами из предыдущего урока, только логины и пароли считать из файла в массив. Создайте структуру Account, содержащую Login и Password.
 *  4. *а) Реализовать класс для работы с двумерным массивом. Реализовать конструктор, заполняющий массив случайными числами. Создать методы, которые возвращают 
 *       сумму всех элементов массива, сумму всех элементов массива больше заданного, свойство, возвращающее минимальный элемент массива, свойство, 
 *       возвращающее максимальный элемент массива, метод, возвращающий номер максимального элемента массива (через параметры, используя модификатор ref или out)
 *     *б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
 *  Дополнительные задачи
 *  в) Обработать возможные исключительные ситуации при работе с файлами.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using lssn_4;

namespace lssn_4
{
    struct Account
    {

        public string Login, Password;

        public bool checkAccess(string currentLogin, string currentPassword)
        {

            return currentLogin == Login && currentPassword == Password;

        }
    }

    class Program
    {

        static bool access = false;

        static void WriteHead()
        {
            Console.Clear();
            Console.WriteLine("Исполнитель: Иван Васильев\nДомашнее задание к 4-му уроку\n\n");
        }

        static int getNumSum(int a)
        {
            if (a == 0) return 0;
            else return getNumSum(a/10) + a % 10;
            
        }

        static void Main()
        {

            WriteHead();
            //  Решение 3-й задачи
            string s = File.ReadAllText(@"d:\logPass.txt");
            Account acc = new Account();
            for (int i = 0; i<s.Length; i++)
            {
                if (s.Substring(i, 1) == " ")
                {
                    acc.Login = s.Substring(0, i);
                    acc.Password = s.Substring(i + 1, s.Length - i - 1);
                    break;
                }
            }

            int currTry = 0;
            while(currTry < 3)
            {
                if (access) break;

                Console.Write("Введите логин: ");
                string currLogin = Console.ReadLine();

                Console.Write("Введите пароль: ");
                string currPass = Console.ReadLine();

                access = acc.checkAccess(currLogin.ToLower(), currPass);
                
                if (!access)
                {
                    Console.WriteLine("Логин или пароль не верный");
                    currTry++;
                }

            }

            if (!access)
            {
                Console.WriteLine("Попытки закончились");
                Console.ReadKey();
                return;
            }
            else WriteHead();

            Console.WriteLine("Выберите действие:\n1. Количество пар чисел\n2. Операции с одномерным массивом\n3. Операции с двумерным массивом");
            string varNum = Console.ReadLine();

            if (varNum == "1") Ex_1();
            else if (varNum == "2") Ex_2();
            else if (varNum == "3") Ex_4();
            else Console.WriteLine("Такого варианта нет.\n");

            Console.WriteLine("\nВыберите дальнейшее дествие:\nВведите \"1\" чтобы вернуться в меню\nЧтобы завершить программу нажмите любую другую кнопку");
            varNum = Console.ReadLine();

            if (varNum == "1") Main();

        }

        //  Решение 1-й задачи
        static void Ex_1()
        {

            WriteHead();

            int divPrNum = 0;
            bool prevNumDiv = false;
            
            MyArray newArr = new MyArray(20, -10000, 10000);

            Console.WriteLine($"Исходный массив:\n{newArr.ToString()}");

            for (int i = 0; i < newArr.length; i++)
            {
                if (getNumSum(newArr[i]) % 3 == 0)
                {
                    divPrNum += (i < 19 ? 1 : 0) + (prevNumDiv || i == 0? 0 : 1);
                    prevNumDiv = true;
                }
                else prevNumDiv = false;
            }

            Console.WriteLine($"Количество пар чисел: {divPrNum}");

        }

        //  Решение 2-й задачи
        static void Ex_2()
        {
            WriteHead();

            Console.WriteLine("Выберите действие:\n1. Создать массив случайных чисел\n2. Создать массив с заданным шагом\n3. Загрузить массив из файла (D:\\newArr.txt)");
            string varNum = Console.ReadLine();

            int n, minNum, secPar, k;
            string path;

            MyArray newArr;

            if (varNum == "1")
            {
                Console.Write("Введите длину массива: ");
                n = Convert.ToInt32(Console.ReadLine());

                Console.Write("Введите нижнюю границу ГСЧ: ");
                minNum = Convert.ToInt32(Console.ReadLine());

                Console.Write("Введите верхнюю границу ГСЧ: ");
                secPar = Convert.ToInt32(Console.ReadLine());

                newArr = new MyArray(n, minNum, secPar);
            }
            else if (varNum == "2")
            {
                Console.Write("Введите длину массива: ");
                n = Convert.ToInt32(Console.ReadLine());

                Console.Write("Введите первое значение: ");
                minNum = Convert.ToInt32(Console.ReadLine());

                Console.Write("Введите шаг: ");
                secPar = Convert.ToInt32(Console.ReadLine());

                newArr = new MyArray(n, minNum, secPar, true);
            }
            else
            {
                try
                {
                    newArr = new MyArray(@"d:\newArr.txt");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
             
            }

            Console.WriteLine($"\nИсходный массив:\n{newArr.ToString()}\n");
            Console.WriteLine($"Сумма элементов: {newArr.Sum}");

            Console.WriteLine($"\nМаксимальное число: {newArr.Max} Количество максимальных элементов: {newArr.MaxCount}");

            Console.Write("Введите коэффициент: ");
            k = Convert.ToInt32(Console.ReadLine());

            newArr.Mult(k);
            Console.WriteLine($"\nУмножение:\n{newArr.ToString()}\n");

            newArr.Inverse();

            Console.WriteLine($"\nИнверсированный массив:\n{newArr.ToString()}\n");

            Console.Write("Введите путь сохранения файла: ");
            path = Console.ReadLine();

            try { newArr.ToFile(path); }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return;
            }


        }

        static void Ex_4()
        {
            WriteHead();

            Console.WriteLine("Выберите действие:\n1. Создать массив случайных чисел\n2. Загрузить массив из файла  (D:\\newMatrix.txt)");
            string varNum = Console.ReadLine();
            Matrix newMatrix;
            
            if (varNum == "1")
            {
                Console.WriteLine("Введите количество строк: ");
                int n = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Введите количество колонок: ");
                int m = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Введите нижнюю границу ГСЧ: ");
                int minNum = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Введите верхнюю границу ГСЧ: ");
                int maxNum = Convert.ToInt32(Console.ReadLine());

                newMatrix = new Matrix(n, m, minNum, maxNum);

            }
            else
            {
                try
                {
                    newMatrix = new Matrix(@"d:\newMatrix.txt");
                }
                catch (ArgumentException e)
                {

                    Console.WriteLine(e.Message);
                    return;

                }
            }

            Console.WriteLine($"\nИсходный массив:\n{newMatrix.ToString()}");
            Console.WriteLine($"\nСумма элементов: {newMatrix.getSum()}");

            int MaxIndex_n, MaxIndex_m;
            newMatrix.GetMaxIndex(out MaxIndex_n, out MaxIndex_m);

            Console.WriteLine($"\nМинимальный элемент: {newMatrix.Min} Максимальный элемент: {newMatrix.Max} Номер максимального элемента (первый): [{MaxIndex_n + 1}, {MaxIndex_m + 1}]");

            Console.Write("\nВведите минимальное число: ");
            int Min = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"\nСумма элементов больше {Min}: {newMatrix.getSum(Min)}");

            Console.Write("\nВведите путь сохранения файла: ");
            try
            {
                newMatrix.ToFile(Console.ReadLine());
            } catch (ArgumentException e) { Console.WriteLine(e.Message); }
        }

    }
}
