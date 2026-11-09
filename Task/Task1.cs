using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
 
    public class Task1
    {
        public void Swith(int i)

        {
            switch (i)
            {
                case 1: Base1(); break;
                case 2: Base2(); break;
                case 3: Base3(); break;
                case 4: Base4(); break;
                case 5: Base5(); break;
                case 7: Base7(); break;
                case 6: Base6(); break;
                case 8: Base8(); break;
                case 10: Base10(); break;
                case 11: Base11(); break;
                //case 9: Base9(); break;

                case 12: Base12(); break;
                case 13: Base13(); break;
                case 14: Base14(); break;

                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }


        }
        public void Base1()
        {
            Console.Clear();
            Console.WriteLine("Задание 1.Hello, World + текущая дата");
            Console.WriteLine("Что сделать: вывести приветствие и текущую дату.");
            Console.WriteLine("Требования:" + Environment.NewLine +
              "Использовать Console.WriteLine." + Environment.NewLine +
              "Дату получить через DateTime.Now, отформатировать как dd.MM.yyyy" + Environment.NewLine +
              "Вывести две строки: приветствие и дату." + Environment.NewLine
              );

            DateTime data = DateTime.Now;
            Console.WriteLine("========================================");
            Console.WriteLine($"HelloWorld {data.ToString("dd.MM.yyyy")}");
            Console.WriteLine("========================================");
        }
        public void Base2()
        {
            Console.Clear();
            Console.WriteLine("Задание 2. Переменные примитивных типов");
            Console.WriteLine("Что сделать: объявить переменные всех примитивных типов и вывести их значения и типы.");
            Console.WriteLine("Требования:" + Environment.NewLine +
              "Объявить минимум: int, long, double, float, decimal, bool, char, string." + Environment.NewLine +
              "Для каждой переменной вывести значение и GetType().Name." + Environment.NewLine +
              "decimal — с суффиксом m, float — с f." + Environment.NewLine
              );


            Console.WriteLine("========================================");
            int a1 = 1; long a2 = 2; double a3 = 3.1; float a4 = 4.1f; decimal a5 = 5.1m; ; bool a6 = true; char a7 = 'c'; string a8 = "bebe";
            object[] a9 = new object[] { a1, a2, a3, a4, a5, a6, a7, a8 };


            foreach (var item in a9)
            {

                Console.WriteLine($"Значение: {item}, Тип: {item?.GetType()}");
            }

            Console.WriteLine("========================================");
        }
        public void Base3()
        {
            Console.Clear();
            Console.WriteLine("Задание 3. Калькулятор с обработкой деления на ноль");
            Console.WriteLine("Что сделать: принимать два числа и оператор (+ - * /), выводить результат.");
            Console.WriteLine("Требования:" + Environment.NewLine +
              "Оператор обрабатывать через switch." + Environment.NewLine +
              "При делении на ноль — вывести сообщение об ошибке, не ронять приложение." + Environment.NewLine +
              "Некорректный оператор — вывести «Неизвестная операция»." + Environment.NewLine +
              "Ввод чисел — через double.Parse или TryParse." + Environment.NewLine);
            Console.WriteLine("========================================");

            Console.Write("Введите первое число: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Введите второе число: ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("Введите оператор (+, -, , /): ");
            string lol = Console.ReadLine();
            double result = 0;

            switch (lol)
            {
                case "+":
                    result = a + b;
                    Console.WriteLine("Результат: " + result);
                    break;

                case "-":
                    result = a - b;
                    Console.WriteLine("Результат: " + result);
                    break;

                case "":
                    result = a * b;
                    Console.WriteLine("Результат: " + result);
                    break;

                case "/":
                    if (b == 0)
                    {
                        Console.WriteLine("Ошибка: деление на ноль!");
                    }
                    else
                    {
                        result = a / b;
                        Console.WriteLine("Результат: " + result);
                    }
                    break;

                default:
                    Console.WriteLine("Неизвестная операция");
                    break;
            }
            Console.WriteLine("========================================");
        }
        public void Base4()
        {
            Console.Clear();
            Console.WriteLine("Задание 4. Чётность числа (два способа)");
            Console.WriteLine("Что сделать: определить, чётное ли введённое число.");
            Console.WriteLine("Требования:" + Environment.NewLine +
              "Способ 1: через % 2 == 0." + Environment.NewLine +
              "Способ 2: через тернарный оператор ? :." + Environment.NewLine +
              "Оба способа реализовать отдельными методами." + Environment.NewLine +
              "Вывести результат обоих способов." + Environment.NewLine
              );

            Console.WriteLine("========================================");
            Console.WriteLine("Способ 1:" + Environment.NewLine);
            Console.WriteLine("Введите любое число: ");
            int number = Convert.ToInt32(Console.ReadLine());
            if (number % 2 == 0)
            {
                Console.WriteLine("Число " + number + " четное");
            }
            else
            {
                Console.WriteLine("Число " + number + " не четное");
            }
            Console.WriteLine("========================================" + Environment.NewLine);
            Console.WriteLine("Способ 2:" + Environment.NewLine);
            Console.WriteLine("Введите любое число: ");
            int number2 = Convert.ToInt32(Console.ReadLine());
            string gg = (number2 % 2 == 0) ? "Четное" : "Не четное";
            Console.WriteLine(gg);
        }
        public void Base5()
        {
            Console.Clear();
            Console.WriteLine("Задание 5. Таблица умножения 10×10");
            Console.WriteLine("Что сделать: вывести таблицу умножения 10×10.");
            Console.WriteLine("Требования:" + Environment.NewLine +
              "Использовать вложенные циклы for.." + Environment.NewLine +
              "Выровнять столбцы." + Environment.NewLine +
              "Заголовки строк/столбцов — не обязательны, но приветствуются." + Environment.NewLine
              );
            Console.WriteLine("==========================================");
            for (int i = 1; i < 11; i++)
            {
                for (int j = 1; j < 11; j++)
                {
                    int value = j * i;
                    Console.Write($"{value,4}");
                }
                Console.Write(Environment.NewLine);

            }
            Console.WriteLine("==========================================");
        }
        public void Base6()
        {
            Console.Clear();
            Console.WriteLine("Сумма цифр числа (строка + арифметика)");
            Console.WriteLine("Что сделать: найти сумму цифр введённого числа (например, 1234 → 10).");
            Console.WriteLine("Требования:" + Environment.NewLine +
              "Способ 1 (строка): число → ToString() → пройти по символам → int.Parse каждой цифры." + Environment.NewLine +
              "Способ 2 (арифметика): цикл while (n > 0) { sum += n % 10; n /= 10; }." + Environment.NewLine +
              "Отрицательные числа — брать модуль." + Environment.NewLine +
              "Оба способа оформить отдельными методами." + Environment.NewLine);
            Console.WriteLine("==========================================");
            Console.Clear();
            Console.WriteLine("Сумма цифр числа (строка + арифметика)");
            Console.WriteLine("Введите целое число:");
            string text = Console.ReadLine();
            int number = int.Parse(text);

            Console.WriteLine("Полученное число: " + number);
            Console.WriteLine("================================");
            Console.WriteLine("Способ 1 (через строку):");
            Console.WriteLine("Сумма цифр: " + SumString(number));
            Console.WriteLine("================================");
            Console.WriteLine("Способ 2 (через арифметику):");
            Console.WriteLine("Сумма цифр: " + SumMath(number));
            Console.WriteLine("================================");
        }
        public int SumString(int n)
        {
            n = Math.Abs(n);
            string text = n.ToString();
            int sum = 0;

            foreach (char digit in text)
            {
                sum += int.Parse(digit.ToString());
            }

            return sum;
        }
        public int SumMath(int n)
        {
            n = Math.Abs(n);
            int sum = 0;

            while (n > 0)
            {
                sum += n % 10;
                n /= 10;
            }

            return sum;
        }

        public void Base7()
        {
            Console.Clear();
            Console.WriteLine("Задание 7. Реверс строки без LINQ");
            Console.WriteLine("Что сделать: перевернуть введённую строку.");
            Console.WriteLine("Требования:" + Environment.NewLine +
              "Не использовать Array.Reverse и LINQ." + Environment.NewLine +
              "Реализовать через цикл for от конца к началу (или через char[] и swap)." + Environment.NewLine +
              "Пустая строка и строка из одного символа — обрабатываются корректно." + Environment.NewLine
              );
            Console.WriteLine("==========================================");
            Console.WriteLine("Введите любую строку: ");
            string aa = Console.ReadLine();
            if (aa == "" || aa.Length == 1)
            {
                Console.WriteLine(aa);
            }
            else
            {
                string result = "";

                for (int i = aa.Length - 1; i >= 0; i--)
                {
                    result += aa[i];
                }

                Console.WriteLine("Результат: " + result);
            }
            Console.WriteLine("==========================================");
        }
        public void Base8()
        {
            Console.Clear();
            Console.WriteLine("Задание 8. FizzBuzz 1–100");
            Console.WriteLine("Что сделать: вывести числа от 1 до 100 с заменами.");
            Console.WriteLine("Требования:" + Environment.NewLine +
              "Кратно 3 → Fizz." + Environment.NewLine +
              "Кратно 5 → Buzz.." + Environment.NewLine +
              "Кратно 15 → FizzBuzz." + Environment.NewLine + "Иначе — само число." + Environment.NewLine + "Порядок проверок: сначала 15, потом 3 и 5.");
            Console.WriteLine("==========================================");
            for (int num = 1; num < 100; num++)
            {
                if (num % 15 == 0)
                { Console.WriteLine("FizzBuzz"); }
                else if (num % 3 == 0) { Console.WriteLine("Fizz"); } else if (num % 5 == 0) { Console.WriteLine("buzz"); } else { Console.WriteLine($"{num}"); }
            }
            Console.WriteLine("==========================================");
        }
        public void Base9()
        {
            Console.Clear();
            Console.WriteLine("Задание 9. Массивы: min/max/sum/avg");
            Console.WriteLine("Что сделать: для массива чисел найти минимум, максимум, сумму и среднее.");
            Console.WriteLine("Требования:" + Environment.NewLine +
              "Заполнить массив (например, случайными числами 1–100, размер 20)." + Environment.NewLine +
              "Реализовать без LINQ (Min/Max/Sum/Average запрещены)." + Environment.NewLine +
              "Оформить 4 отдельных метода." + Environment.NewLine +
              "Пустой массив — обработать (вернуть ошибку или 0, но не падать)." + Environment.NewLine
              );
            Console.WriteLine("==========================================");

            int[] massiv = new int[20];
            Random number = new Random();

            for (int i = 0; i < massiv.Length; i++)
            {
                massiv[i] = number.Next(1, 101);
            }

            Console.WriteLine("Исходный массив: ");
            for (int i = 0; i < massiv.Length; i++)
            {
                Console.WriteLine(massiv[i] + " ");
            }
            Console.WriteLine("\n");

            Console.WriteLine("Минимальное число: " + Min(massiv));
            Console.WriteLine("Максимальное число: " + Max(massiv));
            Console.WriteLine("Сумма чисел: " + Sum(massiv));
            Console.WriteLine("Среднее число:" + Avg(massiv));

            int Min(int[] array)
            {
                if (array == null || array.Length == 0)
                    return 0;

                int min = array[0];

                foreach (int item in array)
                {
                    if (item < min)
                    {
                        min = item;
                    }
                }

                return min;
            }

            int Max(int[] array)
            {
                if (array == null || array.Length == 0)
                    return 0;

                int max = array[0];

                for (int i = 1; i < array.Length; i++)
                {
                    if (array[i] > max)
                    {
                        max = array[i];
                    }
                }
                return max;
            }

            int Sum(int[] array)
            {
                if (array == null || array.Length == 0) return 0;

                int sum = 0;

                for (int i = 0; i < array.Length; i++)
                {
                    sum += array[i];
                }
                return sum;
            }

            double Avg(int[] array)
            {
                if (array.Length == 0) return 0.0;

                int sum = Sum(array);

                double avg = (double)sum / array.Length;

                return avg;
            }
        }
        public void Base10()
        {
            Console.Clear();
            Console.WriteLine("Задание 10. Сортировка пузырьком + вставками");
            Console.WriteLine("Что сделать: отсортировать массив двумя алгоритмами.");
            Console.WriteLine("Требования:" + Environment.NewLine +
              "Реализовать BubbleSort и InsertionSort отдельными методами." + Environment.NewLine +
              "Оба — без LINQ и Array.Sort." + Environment.NewLine +
              "Замерить время каждого через Stopwatch на массиве 10 000 элементов." + Environment.NewLine);
            Console.WriteLine("==========================================");
            Random rnd = new Random();

            int[] a = new int[10000];
            int[] b = new int[10000];

            for (int i = 0; i < 10000; i++)
            {
                a[i] = rnd.Next(1, 100);
                b[i] = a[i];
            }

            Stopwatch sw = new Stopwatch();

            sw.Start();
            BubbleSort(a);
            sw.Stop();

            Console.WriteLine("Пузырьковая сортировка: " + sw.ElapsedMilliseconds + " мс");

            sw.Restart();
            InsertionSort(b);
            sw.Stop();

            Console.WriteLine("Сортировка вставками: " + sw.ElapsedMilliseconds + " мс");

            Console.WriteLine("Массивы отсортированы одинаково: " + Check(a, b));
        }
        public void BubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }
        public void InsertionSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int temp = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j] > temp)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                arr[j + 1] = temp;
            }
        }
        public bool Check(int[] a, int[] b)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                    return false;
            }

            return true;
        }
        public void Base11()
        {
            Console.Clear();
            Console.WriteLine("Задание 11. Диагональ матрицы N×N");
            Console.WriteLine("Что сделать: найти сумму элементов главной диагонали матрицы N×N.");
            Console.WriteLine("Требования:" + Environment.NewLine +
              "Размер N вводится пользователем (минимум 2)" + Environment.NewLine +
              "Сумма считается без LINQ, в одном цикле for." + Environment.NewLine +
              "Вывести саму матрицу и сумму." + Environment.NewLine);
            Console.WriteLine("==========================================");
            Random rnd = new Random();
            Console.WriteLine("Введите число");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("==========================================");
            int[,] a = new int[n, n];
            for (int i = 0; i < n; i++)
            { for (int j = 0; j < n; j++) { a[i, j] = rnd.Next(10); Console.Write($"{a[i, j],4}"); } Console.Write(Environment.NewLine); }
            int sum = 0;
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                sum += a[i, count];
                count++;
            }
            Console.WriteLine($" Cуммаа диагонали равна {sum}");
            Console.WriteLine("==========================================");
        }
        public void Base12()
        {
            Console.Clear();
            Console.WriteLine("Задание 12. Палиндром (без учёта регистра/пробелов)");
            Console.WriteLine("Что сделать: проверить, является ли строка палиндромом.");
            Console.WriteLine("Требования:" + Environment.NewLine +
              "Игнорировать регистр (ToLower/ToUpper)." + Environment.NewLine +
              "Игнорировать пробелы и знаки пунктуации (или хотя бы пробелы)." + Environment.NewLine +
              "Не использовать LINQ Reverse." + Environment.NewLine);
            Console.WriteLine("==========================================");
            Console.WriteLine("Введите строку:");
            string text = Console.ReadLine();
            text = text.ToLower();
            string result = "";
            foreach (char c in text)
            {
                if (char.IsLetterOrDigit(c))
                {
                    result += c;
                }
            }
            bool palindrome = true;
            for (int i = 0; i < result.Length / 2; i++)
            {
                if (result[i] != result[result.Length - 1 - i])
                {
                    palindrome = false;
                    break;
                }
            }
            if (palindrome)
                Console.WriteLine("Это палиндром!");
            else
                Console.WriteLine("Это не палиндром!");
        }
        public void Base13()
        {
            Console.Clear();
            Console.WriteLine("Задание 13. Счётчик вхождений слов в тексте (Dictionary)");
            Console.WriteLine("Что сделать: посчитать, сколько раз каждое слово встречается в тексте.");
            Console.WriteLine("Требования:" + Environment.NewLine +
              "Использовать Dictionary<string, int>." + Environment.NewLine +
              "Разбить текст на слова (по пробелам и знакам пунктуации." + Environment.NewLine +
              "Привести слова к нижнему регистру." + Environment.NewLine + "Вывести пары «слово → количество», отсортированные по убыванию количества." + Environment.NewLine);
            Console.WriteLine("==========================================");
            string text = "Привет, мир! Привет всем. Как дела, мир? Снова привет!";

            Console.WriteLine($"Исходный текст:\n{text}\n");
            Console.WriteLine("Результат подсчета (от частых к редким):");
            Console.WriteLine("=========================================");
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();
            char[] separators = new char[] { ' ', ',', '.', '!', '?', ':', ';', '-', '\t', '\n', '"', '(', ')' };
            string[] words = text.ToLower().Split(separators, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                if (wordCounts.ContainsKey(word))
                {
                    wordCounts[word]++;
                }
                else
                {
                    wordCounts[word] = 1;
                }
            }
            List<KeyValuePair<string, int>> sortedList = new List<KeyValuePair<string, int>>(wordCounts);
            sortedList.Sort((x, y) => y.Value.CompareTo(x.Value));
            foreach (var pair in sortedList)
            {
                Console.WriteLine($"{pair.Key,-15} → {pair.Value}");
            }
            Console.WriteLine("=========================================");
        }
        public void Base14()
        {
            Console.Clear();
            Console.WriteLine("Задание 14. Возраст по дате рождения");
            Console.WriteLine("Что сделать: по дате рождения вычислить точный возраст в годах, месяцах и днях.");
            Console.WriteLine("Требования:" + Environment.NewLine +
              "Ввод даты через DateTime.TryParse (или TryParseExact)." + Environment.NewLine +
              "Учесть, что день рождения в этом году мог ещё не наступить." + Environment.NewLine +
              "Вывести «X лет, Y месяцев, Z дней». Некорректная дата — сообщение об ошибке, не падать." + Environment.NewLine);
            Console.WriteLine("==========================================");
            Console.WriteLine("Введите дату рождения (дд.мм.гггг):");
            DateTime birth;
            if (DateTime.TryParse(Console.ReadLine(), out birth))
            {
                DateTime today = DateTime.Today;
                birth = birth.Date;
                if (birth > today)
                {
                    Console.WriteLine("Ошибка: дата рождения не может быть в будущем!");
                    return;
                }
                int years = today.Year - birth.Year;
                if (birth.AddYears(years) > today)
                {
                    years--;
                }
                DateTime date = birth.AddYears(years);
                int months = 0;
                while (date.AddMonths(months + 1) <= today)
                {
                    months++;
                }
                date = date.AddMonths(months);
                int days = (today - date).Days;
                Console.WriteLine("Ваш возраст:");
                Console.WriteLine(years + " лет, " + months + " месяцев, " + days + " дней.");
            }
            else
            {
                Console.WriteLine("Ошибка: неправильный формат даты!");
            }
        }

    }
}
    
