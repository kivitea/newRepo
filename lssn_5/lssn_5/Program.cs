/* Иван Васильев
 *  1. Создать программу, которая будет проверять корректность ввода логина. Корректным логином будет строка от 2 до 10 символов, 
 *      содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой:
 *      а) без использования регулярных выражений;
 *      б) с использованием регулярных выражений.
 *  2. Разработать класс Message, содержащий следующие статические методы для обработки текста:
 *      а) Вывести только те слова сообщения, которые содержат не более n букв.
 *      б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
 *      в) Найти самое длинное слово сообщения.
 *      г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
 *      Продемонстрируйте работу программы на текстовом файле с вашей программой.
 *  3. *Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой. Регистр можно не учитывать:
 *      а) с использованием методов C#;
 *      б) *разработав собственный алгоритм.
 *  Например:
 *   badc являются перестановкой abcd.
 *  4. Задача ЕГЭ.
 * *На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней школы. В первой строке сообщается количество учеников N, 
 * которое не меньше 10, но не превосходит 100, каждая из следующих N строк имеет следующий формат: <Фамилия> <Имя> <оценки>, где <Фамилия> — строка, состоящая 
 * не более чем из 20 символов, <Имя> — строка, состоящая не более чем из 15 символов, <оценки> — через пробел три целых числа, соответствующие оценкам по
 * пятибалльной системе. <Фамилия> и <Имя>, а также <Имя> и <оценки> разделены одним пробелом.
 * Пример входной строки:
 * Иванов Петр 4 5 3
 * Требуется написать как можно более эффективную программу, которая будет выводить на экран фамилии и имена трёх худших по среднему баллу учеников. 
 * Если среди остальных есть ученики, набравшие тот же средний балл, что и один из трёх худших, следует вывести и их фамилии и имена.
 *  
 *  5. **Написать игру «Верю. Не верю». В файле хранятся вопрос и ответ, правда это или нет. 
 *  Например: «Шариковую ручку изобрели в древнем Египте», «Да». Компьютер загружает эти данные, случайным образом выбирает 5 вопросов и задаёт их игроку. 
 *  Игрок отвечает Да или Нет на каждый вопрос и набирает баллы за каждый правильный ответ. Список вопросов ищите во вложении или воспользуйтесь интернетом.
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using lssn_5;

namespace lssn_5
{
    class Program
    {
        static void WriteHead()
        {
            Console.Clear();
            Console.WriteLine("Исполнитель: Иван Васильев\nДомашнее задание к 5-му уроку\n\n");
        }

        /// <summary>
        /// Метод для решения 3-й задачи с использованием встроенных функций (вариант а)
        /// </summary>
        /// <param name="str_a"></param>
        /// <param name="str_b"></param>
        /// <returns></returns>
        static bool IsAnagram(string str_a, string str_b)
        {
            if (str_a.Length != str_b.Length) return false;

            char[]  arr_a = str_a.ToArray();
            char[]  arr_b = str_b.ToArray();
                
            Array.Sort(arr_a);
            Array.Sort(arr_b);
            str_a = string.Concat(arr_a);
            str_b = string.Concat(arr_b);

            return str_a.Equals(str_b);

        }

        /// <summary>
        /// Метод для решения 3-й задачи с использованием встроенных функций (вариант б)
        /// </summary>
        /// <param name="str_a"></param>
        /// <param name="str_b"></param>
        /// <returns></returns>
        static bool IsAnagram_Atyp(string str_a, string str_b)
        {
            if (str_a.Length != str_b.Length) return false;

            for (int i = 0; i < str_a.Length; i++)
            {
                bool chFound = false;
                for (int j = 0; j < str_b.Length; j++)
                {
                    if (str_a[i] == str_b[j])
                    {
                        str_b = str_b.Remove(j, 1);
                        chFound = true;
                        break;
                    }
                }
                if (!chFound) return false;
            }

            return true;
        }

        /// <summary>
        /// Метод проверки корректности символа пароля. "IsLetterOrDigit" не подходит, т.к. пропускает буквы других алфавитов
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        static bool CorrectSym(char a)
        {

            string s = a.ToString();
            return (s.CompareTo("0") > -1 && s.CompareTo("9") < 1) || (s.CompareTo("A") > -1 && s.CompareTo("Z") < 1) || (s.CompareTo("a") > -1 && s.CompareTo("z") < 1);

        }

        /// <summary>
        /// Метод для проверки логина с использованием регулярных выражений (вариант б)
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        static bool CheckLogin(string log)
        {
            Regex regex = new Regex("^[A-Za-z]{1}[0-9A-Za-z]{1,9}$");
            return regex.IsMatch(log);
        }

        /// <summary>
        /// Метод для проверки логина без использования регулярных выражений (вариант а)
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        static bool CheckLogin_nr(string log)
        {

            if (log.Length < 2 || log.Length > 10)
            {
                Console.WriteLine("Длина логина должна быть в диапазоне от 2-х до 10-ти символов");
                return false;
            }

            if(char.IsDigit(log[0]))
            {
                Console.WriteLine("Логин должен состоять только из латинских букв и цифр и не может начинаться с цифры");
                return false;
            }

            for (int i=0; i<log.Length; i++)
            {
                if (!CorrectSym(log[i]))
                {
                    Console.WriteLine("Логин должен состоять только из латинских букв и цифр и не может начинаться с цифры");
                    return false;
                }
            }

            return true;
        }

        static bool FirstRun = true;

        static void Main()
        {
            WriteHead();

            //  Решение 1-й задачи
            if (FirstRun)
            {
                bool LogCorrect = false;

                while (!LogCorrect)
                {
                    Console.Write("Введите логин: ");
                    string login = Console.ReadLine();

                    LogCorrect = CheckLogin(login);

                    if (!LogCorrect) Console.WriteLine("Логин должен состоять только из латинских букв и цифр и не может начинаться с цифры");
                }

                FirstRun = false;
            }

            Console.WriteLine("Выберите действие:\n1. Работа с сообщениями\n2. Проверка анаграмм\n3. Оценки\n4. Верю. Не верю");
            string varNum = Console.ReadLine();

            if (varNum == "1") Ex_2();
            else if (varNum == "2") Ex_3();
            else if (varNum == "3") Ex_4();
            else if (varNum == "4") Ex_5();
            else Console.WriteLine("Такого варианта нет.\n");

            Console.WriteLine("\nВыберите дальнейшее дествие:\nВведите \"1\" чтобы вернуться в меню\nЧтобы завершить программу нажмите любую другую кнопку");
            varNum = Console.ReadLine();

            if (varNum == "1") Main();

        }

        //  Решение 2-й задачи
        static void Ex_2()
        {
            WriteHead();

            Console.WriteLine("Введите текст сообщения:");
            StringBuilder sb = new StringBuilder(Console.ReadLine());

            Console.WriteLine("\nВыберите действие:\n1. Вывести слова, содержащие не более n букв\n2. Удалить слова по последней букве" +
                "\n3. Вывести самое длинное слово (первое вхождение)\n4. Сформировать строку из длинных слов");

            string varNum = Console.ReadLine();
            if (varNum == "1")
            {
                Console.Write("Введите максимальное количество символов: ");
                int n = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine($"Новое сообщение:\n{Message.shWords(sb, n)}");
            }
            else if (varNum == "2")
            {
                Console.Write("Введите букву: ");
                string ch = Console.ReadLine();

                Console.WriteLine($"Новое сообщение:\n{Message.CheckLastSym(sb, ch)}");
            }
            else if (varNum == "3")
            {
                Console.WriteLine($"Первое длинное слово:\n{Message.getLongWord(sb)}");
            }
            else if (varNum == "4")
            {
                Console.WriteLine($"Новое сообщение:\n{Message.longWords(sb)}");
            }
            else Console.WriteLine("Такого варианта нет.\n");

        }

        //  Решение 3-й задачи
        static void Ex_3()
        {

            WriteHead();

            string str_a, str_b;
            Console.Write("Введите первую строку:");
            str_a = Console.ReadLine();
            Console.Write("\nВведите вторую строку:");
            str_b = Console.ReadLine();

            Console.WriteLine($"Строка a {(IsAnagram_Atyp(str_a, str_b) ? "" : "не ")}является перестановкой строки b");
            Console.ReadKey();
        }

        // Решение 4-й задачи. Без проверок на корректность входных данных
        static void Ex_4()
        {
            WriteHead();

            StreamReader sr = new StreamReader(@"d:\students.txt");
            int stNum = Convert.ToInt32(sr.ReadLine());
            Student[] stArray = new Student[stNum];

            for(int i = 1; i <= stNum; i++)
            {
                stArray[i - 1] = new Student(sr.ReadLine());
            }

            Student.Sort(ref stArray);
            int j = 0;

            while (j<stArray.Length && stArray[j].AvRating <= stArray[2].AvRating)
            {
                Console.WriteLine(stArray[j].ToString());
                j++;
            }
        }

        //  Решение 5-й задачи
        static void Ex_5()
        {
            WriteHead();

            Question[] Quest_Arr = new Question[0];
            StreamReader sr = new StreamReader(@"d:\quest.txt");
            int result = 0;
            
            while (!sr.EndOfStream)
            {
                string s = sr.ReadLine();
                Array.Resize(ref Quest_Arr, Quest_Arr.Length + 1);
                Quest_Arr[Quest_Arr.Length - 1] = new Question(s);
            }

            for (int i=0; i<Quest_Arr.Length; i++)
            {
                bool currAnswer = Quest_Arr[i].getAnswer();
                if (Quest_Arr[i].CheckAnswer(currAnswer)) result++;
            }

            Console.WriteLine($"Ваш результат: {result}");
        }
    }
}
