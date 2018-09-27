/* Иван Васильев
 * 1.   а) Дописать структуру Complex, добавив метод вычитания комплексных чисел. Продемонстрировать работу структуры;
 *      б) Дописать класс Complex, добавив методы вычитания и произведения чисел. Проверить работу класса;
 * 2.   а) С клавиатуры вводятся числа, пока не будет введен 0 (каждое число в новой строке). Требуется подсчитать сумму всех нечетных положительных чисел. 
 *          Сами числа и сумму вывести на экран, используя tryParse;
 *      б) Добавить обработку исключительных ситуаций на то, что могут быть введены некорректные данные. При возникновении ошибки вывести сообщение. 
 *          Напишите соответствующую функцию;
 * 3.   *Описать класс дробей - рациональных чисел, являющихся отношением двух целых чисел. Предусмотреть методы сложения, вычитания, умножения и деления дробей. 
 *          Написать программу, демонстрирующую все разработанные элементы класса. Достаточно решить 2 задачи. Все программы сделать в одном решении.
 *      ** Добавить проверку, чтобы знаменатель не равнялся 0. Выбрасывать исключение ArgumentException("Знаменатель не может быть равен 0");
 *      Добавить упрощение дробей.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lssn_3
{
    /// <summary>
    /// Класс для работы с комплексными числами
    /// </summary>
    class ComplexNumber
    {

        private double re, im;

        public ComplexNumber(double newValue_re, double newValue_im)
        {
            re = newValue_re;
            im = newValue_im;
        }

        public ComplexNumber Plus(ComplexNumber a)
        {
            return new ComplexNumber(re + a.re, im + a.im);
        }

        public ComplexNumber Mult(ComplexNumber a)
        {
            return new ComplexNumber(re * a.re - im * a.im, re * a.im + im * a.re);
        }

        public ComplexNumber Minus(ComplexNumber a)
        {
            return new ComplexNumber(re - a.re, im - a.im);
        }

        public string ToString()
        {
            string im_str, actSym;
            im_str = (im >= 0 ? im : -1 * im).ToString();
            actSym = im >= 0 ? "+" : "-";
            return $"{re} {actSym} {im_str}i";
        }

    }

    /// <summary>
    /// Класс для работы с дробями
    /// </summary>
    class FractionalNumber
    {

        private int num, den;

        /// <summary>
        /// Пустой контсруктор для обработки ошибок ввода
        /// </summary>
        public FractionalNumber()
        {
            num = 0;
            den = 1;
        }

        public FractionalNumber(int newVulue_num, int newValue_den)
        {
            num = newVulue_num;
            if (newValue_den == 0) throw new ArgumentException("Знаменатель не может быть равен 0");
            else den = newValue_den;
        }

        /// <summary>
        /// Проверка является ли дробь целым числом
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public bool isInt()
        {
            return num % den == 0;
        }

        /// <summary>
        /// Получение целой части
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public int ToInt()
        {
            return num / den;
        }

        /// <summary>
        /// Сложение дробей
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public FractionalNumber Plus(FractionalNumber a)
        {
            return a.den == den ? new FractionalNumber(num + a.num, den) : new FractionalNumber(num * a.den + den * a.num, den * a.den);
        }

        /// <summary>
        /// Вычитание дробей
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public FractionalNumber Minus(FractionalNumber a)
        {
            return a.den == den ? new FractionalNumber(num - a.num, den) : new FractionalNumber(num * a.den - den * a.num, den * a.den);
        }

        /// <summary>
        /// Умножение дробей
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public FractionalNumber Mult(FractionalNumber a)
        {
            return new FractionalNumber(num * a.num, den * a.den);
        }

        /// <summary>
        /// Деление дробей
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public FractionalNumber Div(FractionalNumber a)
        {
            return new FractionalNumber(num * a.den, den * a.num);
        }

        /// <summary>
        /// Упрощение дробей. Возвращает истину, если дробь была упрощена
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool Simp(ref FractionalNumber a)
        {
            int min = a.den < a.num ? a.den : a.num;

            for (int i = 2; i<= min; i++)
            {
                if (a.den % i == 0 && a.num % i == 0)
                {
                    a = new FractionalNumber(a.num/i, a.den/i);
                    Simp(ref a);
                    return true;
                }
            }

            return false;

        }

        public string ToString()
        {
            return $"{num}/{den}";
        }

    }

    class Program
    { 
       static void WriteHead()
        {
            Console.Clear();
            Console.WriteLine("Исполнитель: Иван Васильев\nДомашнее задание к 3-му уроку\n\n");
        }

        /// <summary>
        /// Функция для ввода числа пользователем. Запрашивает число пока не будет введено верное значение
        /// </summary>
        /// <param name="message">Сообщение пользователю</param>
        /// <param name="a">Ссылочный параметр, в который записывается число (тип: int, double)</param>
        static void getNumber(string message, out double a)
        {
            string s;
            while (true)
            {
                Console.Write(message);
                s = Console.ReadLine();
                if (double.TryParse(s, out a)) break;
                else Console.WriteLine("Введенное значение не является числом");
            }
        }

        /// <summary>
        /// Функция для ввода числа пользователем. Запрашивает число пока не будет введено верное значение
        /// </summary>
        /// <param name="message">Сообщение пользователю</param>
        /// <param name="a">Ссылочный параметр, в который записывается число (тип: int, double)</param>
        static void getNumber(string message, out int a)
        {
            string s;
            while (true)
            {
                Console.Write(message);
                s = Console.ReadLine();
                if (int.TryParse(s, out a)) break;
                else Console.WriteLine("Введенное значение не является целым числом");
            }
        }

        /// <summary>
        /// Ввод комплексного числа пользователем
        /// </summary>
        /// <returns></returns>
        static ComplexNumber GetComplexNumber()
        {
            double new_re, new_im;
            getNumber("Введите вещественную часть: ", out new_re);
            getNumber("Введите вещественную часть: ", out new_im);

            return new ComplexNumber(new_re, new_im);
        }

        static FractionalNumber GetFractionalNumber()
        {
            int new_num, new_den;

            getNumber("Введите числитель: ", out new_num);
            getNumber("Введите знаменатель: ", out new_den);

            try
            {
                return new FractionalNumber(new_num, new_den);
            }catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                return new FractionalNumber();
            }
        }

        static void Main()
        {

            WriteHead();

            Console.WriteLine("Выберите действие:\n1. Операции с комплексными числами\n2. Сумма нечетных положиельных чисел\n3. Операции с дробями");
            string varNum = Console.ReadLine();

            if (varNum == "1") Ex_1();
            else if (varNum == "2") Ex_2();
            else if (varNum == "3") Ex_3();
            else Console.WriteLine("Такого варианта нет.\n");

            Console.WriteLine("\nВыберите дальнейшее дествие:\nВведите \"1\" чтобы вернуться в меню\nЧтобы завершить программу нажмите любую другую кнопку");
            varNum = Console.ReadLine();

            if (varNum == "1") Main();

        }

        //  Решение 1-й задачи
        static void Ex_1()
        {
            WriteHead();

            ComplexNumber a, b;

            Console.WriteLine("Выберите действие:\n1. Сложение комплексных чисел\n2. Произведение комплексных чисел\n3. Вычитание комплексных чисел");
            string varNum = Console.ReadLine();
            if (!(varNum == "1" || varNum == "2" || varNum == "3")) Console.WriteLine("Такого варианта нет.\n");
            else
            {
                WriteHead();
                Console.WriteLine("\nВведите первое число");
                a = GetComplexNumber();

                WriteHead();
                Console.WriteLine("\nВведите второе число");
                b = GetComplexNumber();

                WriteHead();
                if (varNum == "1") Console.WriteLine($"({a.ToString()}) + ({b.ToString()}) = ({a.Plus(b).ToString()})");
                else if(varNum == "2") Console.WriteLine($"({a.ToString()}) * ({b.ToString()}) = ({a.Mult(b).ToString()})");
                else Console.WriteLine($"({a.ToString()}) - ({b.ToString()}) = ({a.Minus(b).ToString()})");
            }
            
        }

        //  Решение 2-й задачи
        static void Ex_2()
        {

            string s = "";
            int x;
            int count = 0;
            string numString = "";

            while (s != "0")
            {
                WriteHead();
                if (count > 0) Console.WriteLine($"Числа: {numString}\nТекущая сумма: {count}\n");
                Console.Write("Введите число (для завершения введите 0): ");
                s = Console.ReadLine();

                if (int.TryParse(s, out x))
                {
                    if (x > 0 && x % 2 != 0)
                    {
                        numString += (count == 0 ? "" : ", ") + s;
                        count += x;
                    }
                }
                else
                {
                    Console.WriteLine("Введенное значение не является целым числом");
                    Console.ReadKey();
                }
            }

            WriteHead();
            if (count > 0) Console.WriteLine($"Числа: {numString}\nИтоговая сумма: {count}\n");
        }

        //  Решение 3-й задачи
        static void Ex_3()
        {

            WriteHead();

            FractionalNumber a, b, c;
            string result;

            Console.WriteLine("Выберите действие:\n1. Сложение дробей\n2. Вычитание дробей\n3. Умножение дробей\n4. Деление дробей");
            string varNum = Console.ReadLine();
            if (!(varNum == "1" || varNum == "2" || varNum == "3" || varNum == "4")) Console.WriteLine("Такого варианта нет.\n");
            else
            {
                WriteHead();
                Console.WriteLine("\nВведите первое число");
                a = GetFractionalNumber();

                WriteHead();
                Console.WriteLine("\nВведите второе число");
                b = GetFractionalNumber();

                if (varNum == "1")
                {
                    c = a.Plus(b);
                    result = $"{a.ToString()} + {b.ToString()} = {c.ToString()}";
                }
                else if (varNum == "2")
                {
                    c = a.Minus(b);
                    result = $"{a.ToString()} - {b.ToString()} = {c.ToString()}";
                }
                else if (varNum == "3")
                {
                    c = a.Mult(b);
                    result = $"{a.ToString()} * {b.ToString()} = {c.ToString()}";
                }
                else
                {
                    c = a.Div(b);
                    result = $"{a.ToString()} : {b.ToString()} = {c.ToString()}";
                }

                if (c.isInt()) result += $" = {c.ToInt()}";
                else if (FractionalNumber.Simp(ref c)) result += $" = {c.ToString()}";

                WriteHead();
                Console.WriteLine(result);
            }

        }
    }
}
