using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                case 38: Adv38(); break;
                case 39: Adv39(); break;
                case 40: Adv40().GetAwaiter().GetResult(); break;
                case 41: Adv41().GetAwaiter().GetResult(); break;
                case 42: Adv42().GetAwaiter().GetResult(); break;
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

        public void Adv38()
        {
            Console.Clear();
            Console.WriteLine("Задание 38. List<T> vs LinkedList<T> (бенчмарк)");
            Console.WriteLine("Что сделать: сравнить вставку в середину List<T> и LinkedList<T>.");
            Console.WriteLine("Требования:" + Environment.NewLine +
              "Создать List<int> и LinkedList<int> по 100 000 элементов." + Environment.NewLine +
              "Вставить 1000 элементов в середину каждой коллекции." + Environment.NewLine +
              "Замерить время через Stopwatch и вывести объяснение результата." + Environment.NewLine
            );
            Console.WriteLine("========================================");

            int count = 100000;
            int inserti = 1000;
            Stopwatch sw = new Stopwatch();

            List<int> list = new List<int>(count);
            for (int i = 0; i < count; i++)
            {
                list.Add(i);
            }

            sw.Start();
            for (int i = 0; i < inserti; i++)
            {
                int middleIndex = list.Count / 2;
                list.Insert(middleIndex, i);
            }
            sw.Stop();
            long listTime = sw.ElapsedMilliseconds;
            sw.Reset();

            LinkedList<int> linkL = new LinkedList<int>();
            for (int i = 0; i < count; i++)
            {
                linkL.AddLast(i);
            }

            sw.Start();
            LinkedListNode<int> node = linkL.First;
            for (int j = 0; j < linkL.Count / 2; j++)
            {
                node = node.Next;
            }
            for (int i = 0; i < inserti; i++)
            {
                linkL.AddAfter(node, i);
            }
            sw.Stop();
            long linkTime = sw.ElapsedMilliseconds;

            Console.WriteLine($"Время вставки в List<T>: {listTime} мс.");
            Console.WriteLine($"Время вставки в LinkedList<T>: {linkTime} мс.");
            Console.WriteLine("========================================");
            Console.WriteLine("Объяснение результатов:");
            Console.WriteLine("• List<T> хранит элементы в непрерывном блоке памяти. Метод .Insert()");
            Console.WriteLine("  вынужден каждый раз физически сдвигать половину массива вправо (сложность O(N)).");
            Console.WriteLine("• LinkedList<T> не имеет индексов, но после нахождения нужного узла вставка");
            Console.WriteLine("  новых элементов происходит мгновенно O(1) за счет перепривязки ссылок соседей.");
            Console.WriteLine("========================================");
        }

        public static IEnumerable<int> GetEvenNumbers(int max)
        {
            for (int i = 0; i <= max; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine("Генератор нашёл число: " + i);
                    yield return i;
                }
            }
        }

        public static void Adv39()
        {
            Console.Clear();
            Console.WriteLine("Задание 39. yield return — генератор чётных чисел");
            Console.WriteLine("Что сделать: реализовать генератор чётных чисел.");
            Console.WriteLine("Требования:" + Environment.NewLine +
                "Метод GetEvenNumbers(int max) возвращает чётные числа до max." + Environment.NewLine +
                "Использовать yield return без промежуточного списка." + Environment.NewLine +
                "Продемонстрировать работу через foreach." + Environment.NewLine +
                "Показать ленивое выполнение генератора." + Environment.NewLine);

            Console.Write("Введите максимальное число: ");
            int max = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(Environment.NewLine + "Начинаем перебор:");

            foreach (int number in GetEvenNumbers(max))
            {
                Console.WriteLine("Получено число: " + number);
            }

            Console.WriteLine("Генератор завершил работу.");
        }

        public async System.Threading.Tasks.Task<string> DownloadAsync(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentException("Адрес пустой!");
            }

            Console.WriteLine("Начинается скачивание...");

            await System.Threading.Tasks.Task.Delay(1000);

            return "Скачивание завершено: " + url;
        }

        public async System.Threading.Tasks.Task Adv40()
        {
            Console.Clear();
            Console.WriteLine("Задание 40. async/await + обработка исключений");
            Console.WriteLine("Что сделать: асинхронный метод с эмуляцией скачивания.");
            Console.WriteLine("Требования:" + Environment.NewLine +
                "async Task<string> DownloadAsync(string url)." + Environment.NewLine +
                "Внутри Task.Delay(1000)." + Environment.NewLine +
                "Если url пустой — бросить ArgumentException." + Environment.NewLine +
                "Вызвать через await внутри try/catch." + Environment.NewLine +
                "Продемонстрировать успешный и ошибочный вызов." + Environment.NewLine);

            try
            {
                string result = await DownloadAsync("https://example.com");
                Console.WriteLine(result);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }

            try
            {
                string result = await DownloadAsync("");
                Console.WriteLine(result);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }

        public static async System.Threading.Tasks.Task<int> WorkAsync(int id)
        {
            await System.Threading.Tasks.Task.Delay(500);
            return id;
        }

        public static async System.Threading.Tasks.Task Adv41()
        {
            Console.Clear();
            Console.WriteLine("Задание 41. Task.WhenAll — параллельно 10 задач");
            Console.WriteLine("Что сделать: запустить 10 задач и сравнить время выполнения.");
            Console.WriteLine("Требования:" + Environment.NewLine +
                "Метод WorkAsync(int id) с задержкой Task.Delay(500)." + Environment.NewLine +
                "Последовательный запуск 10 задач через await." + Environment.NewLine +
                "Параллельный запуск через Task.WhenAll." + Environment.NewLine +
                "Замер времени через Stopwatch." + Environment.NewLine);

            Stopwatch stopwatch = new Stopwatch();

            Console.WriteLine("Последовательное выполнение...");
            stopwatch.Start();

            for (int i = 1; i <= 10; i++)
            {
                int result = await WorkAsync(i);
                Console.WriteLine($"Выполнена задача: {result}");
            }

            stopwatch.Stop();
            long sequentialTime = stopwatch.ElapsedMilliseconds;
            Console.WriteLine($"Время последовательного выполнения: {sequentialTime} мс\n");

            Console.WriteLine("Параллельное выполнение...");
            stopwatch.Restart();

            List<System.Threading.Tasks.Task<int>> tasks = new List<System.Threading.Tasks.Task<int>>();
            for (int i = 1; i <= 10; i++)
            {
                tasks.Add(WorkAsync(i));
            }

            int[] results = await System.Threading.Tasks.Task.WhenAll(tasks);

            stopwatch.Stop();
            long parallelTime = stopwatch.ElapsedMilliseconds;

            foreach (int result in results)
            {
                Console.WriteLine($"Выполнена задача: {result}");
            }

            Console.WriteLine($"Время параллельного выполнения: {parallelTime} мс\n");

            Console.WriteLine("========================================");
            Console.WriteLine("Сравнение результатов:");
            Console.WriteLine($"• Последовательно: {sequentialTime} мс (~5 секунд)");
            Console.WriteLine($"• Параллельно:     {parallelTime} мс (~0.5 секунды)");
            Console.WriteLine("========================================");
        }
        public async System.Threading.Tasks.Task LongOperationAsync(System.Threading.CancellationToken token)
        {
            for (int i = 0; i < 10; i++)
            {
                await System.Threading.Tasks.Task.Delay(500, token);

                Console.WriteLine("Выполняется операция: " + (i + 1));
            }
        }

        public async System.Threading.Tasks.Task Adv42()
        {
            Console.Clear();
            Console.WriteLine("Задание 42. CancellationToken — отмена через 2 сек");
            Console.WriteLine("Что сделать: реализовать долгую операцию с поддержкой отмены.");
            Console.WriteLine("Требования:" + Environment.NewLine +
                "async Task LongOperationAsync(CancellationToken token)." + Environment.NewLine +
                "Цикл с Task.Delay(500, token) 10 раз." + Environment.NewLine +
                "Создать CancellationTokenSource и отменить через 2 секунды." + Environment.NewLine +
                "Обработать OperationCanceledException." + Environment.NewLine +
                "Вывести сообщение об отмене." + Environment.NewLine);

            System.Threading.CancellationTokenSource cts =
                new System.Threading.CancellationTokenSource();

            try
            {
                
                var operation = LongOperationAsync(cts.Token);
                await System.Threading.Tasks.Task.Delay(2000);

                cts.Cancel();

                await operation;
            }
            catch (System.OperationCanceledException)
            {
                Console.WriteLine("Операция отменена.");
            }
            finally
            {
                cts.Dispose();
            }
        }
        class CustomException : Exception
        {
            public CustomException(string message) : base(message)
            {
            }
        }

        public static void DoWork(string text, int divisor, bool customError)
        {
            int number = int.Parse(text);

            if (customError)
            {
                throw new CustomException("Произошла собственная ошибка!");
            }

            int result = number / divisor;

            Console.WriteLine("Результат: " + result);
        }

        public static void Adv43()
        {
            Console.Clear();

            Console.WriteLine("Задание 43. Множественные типы исключений, порядок catch");
            Console.WriteLine("Что сделать: продемонстрировать порядок обработки исключений.");
            Console.WriteLine("Требования:" + Environment.NewLine +
                "Метод может вызывать FormatException, DivideByZeroException и CustomException." + Environment.NewLine +
                "Использовать несколько блоков catch." + Environment.NewLine +
                "Расположить catch от частного к общему." + Environment.NewLine +
                "Продемонстрировать все три исключения." + Environment.NewLine +
                "Использовать finally с сообщением «Завершено»." + Environment.NewLine);

            Console.WriteLine("Первый случай: FormatException");

            try
            {
                DoWork("abc", 2, false);
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: введён неправильный формат числа!");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Ошибка: деление на ноль!");
            }
            catch (CustomException ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Другая ошибка: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Завершено.");
            }

            Console.WriteLine(Environment.NewLine + "Второй случай: DivideByZeroException");

            try
            {
                DoWork("10", 0, false);
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: введён неправильный формат числа!");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Ошибка: деление на ноль!");
            }
            catch (CustomException ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Другая ошибка: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Завершено.");
            }

            Console.WriteLine(Environment.NewLine + "Третий случай: CustomException");

            try
            {
                DoWork("10", 2, true);
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: введён неправильный формат числа!");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Ошибка: деление на ноль!");
            }
            catch (CustomException ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Другая ошибка: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Завершено.");
            }
        }



    }
}