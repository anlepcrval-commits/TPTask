using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Task
{
    public class Adv
    {
        public void Swith(int i)
        {
            switch (i)
            {
                case 36: Adv36(); break;
                case 37: Adv37(); break;
                /* case 38: Adv38(); break;
                 case 39: Adv39(); break;
                 case 40: Adv40(); break;
                 case 41: Adv41(); break;
                 case 42: Adv42(); break;
                 case 43: Adv43(); break;
                 case 44: Adv44(); break;
                 case 45: Adv45(); break;
              */

                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
        }
        public void Adv36()
        {
            Console.Clear();
            Console.WriteLine("Задание 36. Дубликаты в List (HashSet + GroupBy)");
            Console.WriteLine("Что сделать: найти дубликаты в списке чисел двумя способами.");
            Console.WriteLine("Требования:" + Environment.NewLine +
              "Способ 1: через HashSet<int> с проверкой Contains." + Environment.NewLine +
              "Способ 2: через LINQ GroupBy(x => x).Where(g => g.Count() > 1)." + Environment.NewLine +
              "Вывести и сравнить результаты обоих способов." + Environment.NewLine
            );
            Console.WriteLine("========================================");

            List<int> numbers = new List<int> { 1, 2, 3, 2, 4, 5, 1, 6, 3 };
            Console.WriteLine("Исходный список: " + string.Join(", ", numbers));
            HashSet<int> seen = new HashSet<int>();
            HashSet<int> duplicates = new HashSet<int>();

            foreach (int i in numbers)
            {
                if (seen.Contains(i))
                {
                    duplicates.Add(i);
                }
                else
                {
                    seen.Add(i);
                }
            }
            var linqDubl = numbers
                .GroupBy(x => x)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .ToList();
            Console.Write("Дубликаты через HashSet: ");
            foreach (int i in duplicates)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            Console.Write("Дубликаты через LINQ:    ");
            foreach (int i in linqDubl)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            Console.WriteLine("========================================");
        }

        public void Adv37()
        {
            Console.Clear();
            Console.WriteLine("Задание 37. Мемоизация Фибоначчи через Dictionary");
            Console.WriteLine("Что сделать: реализовать мемоизированную функцию Фибоначчи.");
            Console.WriteLine("Требования:" + Environment.NewLine +
              "Обычная рекурсивная версия для сравнения." + Environment.NewLine +
              "Мемоизированная версия с Dictionary<int, long>." + Environment.NewLine +
              "Замерить время обеих на N = 35 через Stopwatch." + Environment.NewLine +
              "Вывести оба времени и разницу." + Environment.NewLine
            );
            Console.WriteLine("========================================");
            int n = 35;
            long Fibrec(int t)
            {
                if (t <= 1) return t;
                return Fibrec(t - 1) + Fibrec(t - 2);
            }
            Stopwatch sw = new Stopwatch();
            Console.WriteLine($"Вычисление числа Фибоначчи для N = {n} обычным методом...");
            sw.Start();
            long resultRecursive = Fibrec(n);
            sw.Stop();
            long timeRecursive = sw.ElapsedMilliseconds;
            sw.Reset();
            Console.WriteLine($"Результат: {resultRecursive}, время: {timeRecursive} мс.");
            Console.WriteLine("----------------------------------------");
            Dictionary<int, long> memo = new Dictionary<int, long>();

            long FibonacciMemo(int target, Dictionary<int, long> cache)
            {
                if (target <= 1) return target;

                if (cache.ContainsKey(target))
                    return cache[target];

                cache[target] = FibonacciMemo(target - 1, cache) + FibonacciMemo(target - 2, cache);
                return cache[target];
            }
            Console.WriteLine($"Вычисление числа Фибоначчи для N = {n} с мемоизацией...");
            sw.Start();
            long resultMemo = FibonacciMemo(n, memo);
            sw.Stop();
            long timeMemo = sw.ElapsedMilliseconds;
            Console.WriteLine($"Результат: {resultMemo}, время: {timeMemo} мс.");
            Console.WriteLine("========================================");
            Console.WriteLine($"Мемоизированная версия быстрее в {(timeRecursive > 0 ? timeRecursive / (double)timeMemo : timeMemo):F1} раз(а)!");
            Console.WriteLine("========================================");
        }
    }
}