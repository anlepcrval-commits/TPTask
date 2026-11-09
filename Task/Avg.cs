using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public class MyStack<T>
    {
        private T[] _items;
        private int _count;

        public MyStack()
        {
            _items = new T[4];
            _count = 0;
        }

        public void Push(T item)
        {
            if (_count == _items.Length)
            {
                Array.Resize(ref _items, _items.Length * 2);
            }
            _items[_count++] = item;
            _count++;
        }
        public T Pop()
        {

            if (_count == 0)
            {
                throw new InvalidOperationException("Стек пуст");
            }
            _count--;
            T item = _items[_count];

            _items[_count] = default(T);
            return item;
        }

        public T Peek()
        {
            if (_count == 0)
            {
                throw new InvalidOperationException("Стек пуст");
            }
            return _items[_count - 1];
        }
        public int count()
        {
            return _count;
        }
        public bool IsEmpty()
        {
            return (_count == 0);
        }

    }

    public class Avg
    {
        public void Swith(int i)

        {
            switch (i)
            {
                case 16: avg16(); break;
                case 17: Avg17(); break;
                case 18: Avg18(); break;
                case 19: avg19(); break;
                case 20: avg20(); break;
                case 21: Avg21(); break;
                case 22: Avg22(); break;
                case 23: Avg23(); break;
                case 24: Avg24(); break;
                case 25: Avg25(); break;
                case 26: Avg26(); break;
                case 27 : Avg27(); break;
                case 28: Avg28 (); break;
                case 29: Avg29(); break;
                case 30: Avg30(); break;
                case 32: Avg32(); break;
                case 33: Avg33(); break;
                case 34: Avg34(); break;
               /*   case 4: avg4(); break;
                  case 5: avg5(); break;
                  case 7: avg7(); break;
                  case 6: avg6(); break;
                  case 8: avg8(); break;
                  case 10: avg10(); break;
                  case 11: avg11(); break;
                  case 9: avg9(); break;

                  case 12: avg12(); break;
                  case 12: avg12(); break;
                  case 13: avg13(); break;
                  case 14: avg14(); break; */

                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
        }
        public void avg16()
        {
            Console.Clear();
            Console.WriteLine("Задание 16. Методы расширения для string");
            Console.WriteLine("Что сделать: написать extension-методы для string.");
            Console.WriteLine("Требования:" + Environment.NewLine +
              "Реализовать в статическом классе StringExtensions." + Environment.NewLine +
              "Методы: IsPalindrome(), WordCount(), ReverseString()." + Environment.NewLine +
              "Методы должны быть public static с this string первым параметром." + Environment.NewLine + " Продемонстрировать вызов на 2–3 строках." + Environment.NewLine
              );
            string text1 = "Public";
            string text2 = "Шабаш";
            string text3 = "Environment";
            text1.ReverseString();
            text2.ReverseString();
            text3.ReverseString();
            text1.IsPalindrome();
            text2.IsPalindrome();
            text3.IsPalindrome();
            Console.WriteLine("Введите строку");
            string text4 = Console.ReadLine();
            text4.WordCount();

        }
        public void Avg17()
        {
            Console.Clear();
            Console.WriteLine("Задание 17. StringBuilder vs конкатенация (замер)");
            Console.WriteLine("Что сделать: сравнить производительность конкатенации через + и StringBuilder.");
            Console.WriteLine("Требования:" + Environment.NewLine +
              "Собрать строку из 10 000 (или 100 000) чисел двумя способами." + Environment.NewLine +
              "Замерить время каждого через Stopwatch." + Environment.NewLine +
              "Вывести оба времени и разницу." + Environment.NewLine +
              "Объяснить в комментарии, почему StringBuilder быстрее." + Environment.NewLine
              );

            string text1 = " ";

            StringBuilder text2 = new StringBuilder();
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            for (int i = 0; i < 10000; i++)
            {
                text1 += i + "";
            }

            stopwatch.Stop();
            long time1 = stopwatch.ElapsedMilliseconds;

            stopwatch.Restart();

            for (int i = 0; i < 10000; i++)
            {
                text2.Append(i + " ");
            }
            stopwatch.Stop();
            long time2 = stopwatch.ElapsedMilliseconds;

            Console.WriteLine("Результаты одинаковые: " + (text1 == text2.ToString()));
            Console.WriteLine("Время конкатенации через + " + time1 + "мс");
            Console.WriteLine("Время StringBuilder " + time2 + "мс");
            Console.WriteLine("Разница во времени " + Math.Abs(time1 - time2) + "мс");

        }
        static bool Method1(string text, out int number)
        {
            return int.TryParse(text, out number);
        }

        static bool Method2(string text, out int number)
        {
            try
            {
                number = int.Parse(text);
                return true;
            }
            catch (FormatException)
            {
                number = 0;
                return false;
            }
        }

        public void Avg18()
        {
            Console.Clear();
            Console.WriteLine("Задание 18. TryParse vs try/catch");
            Console.WriteLine("Что сделать: сравнить два способа обработки некорректного ввода числа.");
            Console.WriteLine("Требования:" + Environment.NewLine +
              "Способ 1: int.TryParse — вернуть bool + значение через out." + Environment.NewLine +
              "Способ 2: int.Parse внутри try/catch — ловить FormatException." + Environment.NewLine +
              "Оба оформить отдельными методами." + Environment.NewLine +
              "Продемонстрировать на корректном и некорректном вводе." + Environment.NewLine
              );

            string correctInput = "123";
            string incorrectInput = "abc";

            int number;

            Console.WriteLine("Метод 1 (TryParse):");

            if (Method1(correctInput, out number))
                Console.WriteLine("Результат: " + number);
            else
                Console.WriteLine("Ошибка ввода!");

            if (Method1(incorrectInput, out number))
                Console.WriteLine("Результат: " + number);
            else
                Console.WriteLine("Ошибка ввода!");

            Console.WriteLine("\n Метод 2 (try/catch):");

            if (Method2(correctInput, out number))
                Console.WriteLine("Результат: " + number);
            else
                Console.WriteLine("Ошибка ввода!");

            if (Method2(incorrectInput, out number))
                Console.WriteLine("Результат: " + number);
            else
                Console.WriteLine("Ошибка ввода!");
        }
        public void avg19()
        {
            Console.Clear();
            Console.WriteLine("Задание 19. Свой стек/очередь на массиве");
            Console.WriteLine("Что сделать: реализовать MyStack<T> и MyQueue<T> на массиве.");
            Console.WriteLine("Требования:" + Environment.NewLine +
              "Стек: Push, Pop, Peek, Count, IsEmpty." + Environment.NewLine +
              "Очередь: Enqueue, Dequeue, Peek, Count, IsEmpty." + Environment.NewLine +
              "При переполнении — расширять внутренний массив (удвоение)." + Environment.NewLine +
              "Pop/Dequeue на пустой коллекции — бросать InvalidOperationException." + Environment.NewLine
              );

            Console.WriteLine("=== Демонстрация MyStack<string> ===");
            MyStack<string> myStack = new MyStack<string>();


            myStack.Push("Элемент 1");
            myStack.Push("Элемент 2");
            myStack.Push("Элемент 3");
            myStack.Push("Элемент 4");
            myStack.Push("Элемент 5 (сработал Resize)");

            Console.WriteLine($"Количество элементов в стеке: {myStack.count()}");
            Console.WriteLine($"Верхний элемент (Peek): {myStack.Peek()}");
            Console.WriteLine($"Извлекаем элемент (Pop): {myStack.Pop()}");
            Console.WriteLine($"Элементов после Pop: {myStack.count()}");
            Console.WriteLine($"Стек пуст? {myStack.IsEmpty()}");


            Console.WriteLine(Environment.NewLine + "=== Проверка исключения (Pop на пустом стеке) ===");
            try
            {
                MyStack<int> emptyStack = new MyStack<int>();
                emptyStack.Pop(); // Должно выбросить InvalidOperationException
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Поймали ожидаемое исключение: {ex.Message}");
            }


        }
        enum DayOfWeek
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }

        static bool IsWeekend(DayOfWeek day)
        {
            return day == DayOfWeek.Saturday || day == DayOfWeek.Sunday;
        }

        static string GetRussianName(DayOfWeek day)
        {
            switch (day)
            {
                case DayOfWeek.Monday:
                    return "Понедельник";

                case DayOfWeek.Tuesday:
                    return "Вторник";

                case DayOfWeek.Wednesday:
                    return "Среда";

                case DayOfWeek.Thursday:
                    return "Четверг";

                case DayOfWeek.Friday:
                    return "Пятница";

                case DayOfWeek.Saturday:
                    return "Суббота";

                case DayOfWeek.Sunday:
                    return "Воскресенье";

                default:
                    return "Неизвестный день";
            }
        }

        public void Avg21()
        {
            Console.Clear();
            Console.WriteLine("Задание 21. enum дни недели");
            Console.WriteLine("Что сделать: описать дни недели через enum и определить тип дня.");
            Console.WriteLine("Требования:" + Environment.NewLine +
              "enum DayOfWeek { Monday, ..., Sunday }." + Environment.NewLine +
              "Метод IsWeekend(DayOfWeek day) — true для субботы и воскресенья." + Environment.NewLine +
              "Метод GetRussianName(DayOfWeek day) — возвращает название на русском." + Environment.NewLine +
              "Продемонстрировать на всех 7 днях." + Environment.NewLine
              );

            DayOfWeek[] days = { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday, DayOfWeek.Sunday };

            foreach (DayOfWeek day in days)
            {
                Console.WriteLine(
                    GetRussianName(day) + " - " +
                    (IsWeekend(day) ? "Выходной" : "Рабочий день")
                );
            }
        }

        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }


        public static T Max<T>(T a, T b) where T : IComparable<T>
        {
            if (a.CompareTo(b) > 0)
            {
                return a;
            }
            return b;
        }

        public void avg20()
        {
            Console.Clear();
            Console.WriteLine("Задание 20. Обобщения: Swap<T>, Max<T> с IComparable<T>");
            Console.WriteLine("Что сделать: написать обобщённые методы.");
            Console.WriteLine("Требования:" + Environment.NewLine +
              "Swap<T>(ref T a, ref T b) — меняет значения местами." + Environment.NewLine +
              "Max<T>(T a, T b) where T : IComparable<T> — возвращает большее." + Environment.NewLine +
              "Продемонстрировать на int, string, double." + Environment.NewLine +
              "Swap — без ограничений, Max — с ограничением." + Environment.NewLine
              );


            Console.WriteLine("=== Демонстрация Swap<T> ===");


            int int1 = 5, int2 = 10;
            Console.WriteLine($"До Swap (int): a = {int1}, b = {int2}");
            Swap(ref int1, ref int2);
            Console.WriteLine($"После Swap (int): a = {int1}, b = {int2}");


            string str1 = "Привет", str2 = "Мир";
            Console.WriteLine($"\nДо Swap (string): a = \"{str1}\", b = \"{str2}\"");
            Swap(ref str1, ref str2);
            Console.WriteLine($"После Swap (string): a = \"{str1}\", b = \"{str2}\"");


            double dbl1 = 3.14, dbl2 = 2.71;
            Console.WriteLine($"\nДо Swap (double): a = {dbl1}, b = {dbl2}");
            Swap(ref dbl1, ref dbl2);
            Console.WriteLine($"После Swap (double): a = {dbl1}, b = {dbl2}");

            Console.WriteLine(Environment.NewLine + "=== Демонстрация Max<T> ===");

            int maxInt = Max(15, 42);
            Console.WriteLine($"Max из int (15 и 42) = {maxInt}");

            string maxStr = Max("Яблоко", "Ананас");
            Console.WriteLine($"Max из string (\"Яблоко\" и \"Ананас\") = {maxStr}");

            double maxDbl = Max(5.55, 2.18);
            Console.WriteLine($"Max из double (5.55 и 2.18) = {maxDbl}");
        }
        abstract class Animal
        {
            public string Name { get; set; }

            public Animal(string name)
            {
                Name = name;
            }

            public abstract void MakeSound();

            public override string ToString()
            {
                return "Животное: ";
            }
        }

        class Dog : Animal
        {
            public Dog(string name) : base(name)
            {
            }

            public override string ToString()
            {
                return "Животное: Собака";
            }

            public override void MakeSound()
            {
                Console.WriteLine("Его имя: " + Name + ". Он говорит: Гав!");
            }
        }

        class Cat : Animal
        {
            public Cat(string name) : base(name)
            {
            }

            public override string ToString()
            {
                return "Животное: Кошка";
            }

            public override void MakeSound()
            {
                Console.WriteLine("Ее имя: " + Name + ". Она говорит: Мяу!");
            }
        }

        class Bird : Animal
        {
            public Bird(string name) : base(name)
            {
            }

            public override string ToString()
            {
                return "Животное: Попугай";
            }

            public override void MakeSound()
            {
                Console.WriteLine("Его имя: " + Name + ". Он говорит: Чирик!");
            }

            public void Fly()
            {
                Console.WriteLine(Name + " летит!");
            }
        }

        public static void Avg24()
        {
            Console.Clear();
            Console.WriteLine("Задание 24. ООП: Animal → Dog/Cat/Bird");
            Console.WriteLine("Что сделать: построить иерархию животных.");
            Console.WriteLine("Требования:" + Environment.NewLine +
                "Абстрактный класс Animal: свойство Name, абстрактный метод MakeSound(), переопределённый ToString()." + Environment.NewLine +
                "Классы Dog, Cat, Bird — наследники, реализуют MakeSound()." + Environment.NewLine +
                "Bird дополнительно имеет метод Fly()." + Environment.NewLine +
                "Продемонстрировать полиморфизм: List<Animal> с разными животными, вызов MakeSound() в цикле." + Environment.NewLine);

            List<Animal> animals = new List<Animal>();

            animals.Add(new Dog("Шарик"));
            animals.Add(new Cat("Мурка"));
            animals.Add(new Bird("Кеша"));

            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal.ToString());
                animal.MakeSound();
            }

        }
        public int Sum(params int[] numbers)
        {
            int sum = 0;

            foreach (int number in numbers)
            {
                sum += number;
            }

            return sum;
        }
        public void Avg22()
        {
            Console.Clear();
            Console.WriteLine("Задание 22. params-метод + перегрузка");
            Console.WriteLine("Что сделать: написать метод суммы с params и его перегрузку.");
            Console.WriteLine("Требования:" + Environment.NewLine +
                "Sum(params int[] numbers) — сумма произвольного числа чисел." + Environment.NewLine +
                "Перегрузка Sum(int[] numbers) — та же логика для массива." + Environment.NewLine +
                "Продемонстрировать: Sum(1, 2, 3), Sum(new[] { 1, 2, 3 }), Sum()." + Environment.NewLine +
                "Пустой вызов — вернуть 0." + Environment.NewLine);

            Console.WriteLine("Сумма чисел: " + Sum(1, 2, 3));

            Console.WriteLine("Сумма массива: " + Sum(new int[] { 1, 2, 3 }));

            Console.WriteLine("Пустой вызов: " + Sum());
        }

        Dictionary<string, int> values = new Dictionary<string, int>()
           {
               { "Первый", 10 },
               { "Второй", 20 },
               { "Третий", 30 }
            };

        // Поиск значения по ключу
        public int? FindValue(string key)
        {
            if (values.ContainsKey(key))
            {
                return values[key];
            }
            else
            {
                return null;
            }
        }

        public void Avg23()
        {
            Console.Clear();
            Console.WriteLine("Задание 23. Nullable-типы, ??, ?.");
            Console.WriteLine("Что сделать: продемонстрировать работу с nullable.");
            Console.WriteLine("Требования:" + Environment.NewLine +
                "Метод int? FindValue(string key) — возвращает null, если ключа нет." + Environment.NewLine +
                "Использовать ?? для значения по умолчанию." + Environment.NewLine +
                "Использовать ?. для безопасного доступа к свойству объекта." + Environment.NewLine +
                "Использовать HasValue / Value с проверкой." + Environment.NewLine);
            int? number1 = FindValue("Первый");

            if (number1.HasValue)
            {
                Console.WriteLine("Найденное значение: " + number1.Value);
            }
            else
            {
                Console.WriteLine("Значение не найдено.");
            }

            int? number2 = FindValue("Четвертый");

            if (number2.HasValue)
            {
                Console.WriteLine("Найденное значение: " + number2.Value);
            }
            else
            {
                Console.WriteLine("Значение не найдено.");
            }
            int number3 = FindValue("Четвертый") ?? 0;
            Console.WriteLine("Значение по умолчанию: " + number3);
            string text = null;
            int? length = text?.Length;
            Console.WriteLine("Длина строки: " + (length ?? 0));
        }
        public interface IShape
        {
            double Area();
            double Perimeter();
        }
        class circle : IShape
        {
            public double r;
            public double Area()
            {
                return Math.Pow(r, 2) * 3.14;
            }
            public double Perimeter()
            {
                return 2 * 3.14 * r;
            }
        }
        class Rectangle : IShape
        {
            public double width;
            public double height;
            public double Area()
            {
                return width * height;
            }
            public double Perimeter()
            {
                return 2 * (width + height);
            }
        }
        class Square : IShape
        {
            public double side;
            public double Area()
            {

                return Math.Pow(side, 2);
            }
            public double Perimeter() { return side * 4; }
        }
        class RightTriangle : IShape
        {
            public double a;
            public double b;

            public double Area()
            {
                return (a * b) / 2.0;
            }

            public double Perimeter()
            {
                double hypotenuse = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
                return a + b + hypotenuse;
            }
        }

        class Rhombus : IShape
        {
            public double side;
            public double height;

            public double Area()
            {
                return side * height;
            }

            public double Perimeter()
            {
                return 4 * side;
            }

        }
        public void Avg25()
        {
            Console.Clear();
            Console.WriteLine("Задание 25. Интерфейс IShape + сортировка фигур");
            Console.WriteLine("Что сделать: реализовать интерфейс фигур и отсортировать их.");
            Console.WriteLine("Требования:" + Environment.NewLine +
                "IShape с методами Area() и Perimeter()." + Environment.NewLine +
                "Классы Circle, Rectangle, Triangle — реализуют IShape." + Environment.NewLine +
                "Создать List<IShape> из 5+ фигур." + Environment.NewLine +
                "Отсортировать по площади (через List.Sort с лямбдой или OrderBy)." + Environment.NewLine +
                "Вывести фигуры с площадями до и после сортировки." + Environment.NewLine);

           
            List<IShape> shapes = new List<IShape>
            {
                new circle { r = 5 },                  
                new Rectangle { width = 4, height = 3 }, 
                new Square { side = 4 },               
                new RightTriangle { a = 3, b = 4 },    
                new Rhombus { side = 5, height = 4 }     
            };

            Console.WriteLine("--- Фигуры ДО сортировки ---");
            foreach (var shape in shapes)
            {

                Console.WriteLine($"{shape.GetType().Name}: площадь = {shape.Area():F2}");
            }


            shapes.Sort((s1, s2) => s1.Area().CompareTo(s2.Area()));

            Console.WriteLine(Environment.NewLine + "--- Фигуры ПОСЛЕ сортировки по площади ---");
            foreach (var shape in shapes)
            {
                Console.WriteLine($"{shape.GetType().Name}: площадь = {shape.Area():F2}");
            }
        }
        interface IDiscountStrategy
        {
            decimal Apply(decimal price);
        }

        class NoDiscount : IDiscountStrategy
        {
            public decimal Apply(decimal price)
            {
                return price;
            }
        }

       
        class VipDiscount : IDiscountStrategy
        {
            public decimal Apply(decimal price)
            {
                return price * 0.9m;
            }
        }

     
        class PromoDiscount : IDiscountStrategy
        {
            public decimal Apply(decimal price)
            {
                return price * 0.8m;
            }
        }

       
        class PriceCalculator
        {
            IDiscountStrategy strategy;

            public PriceCalculator(IDiscountStrategy strategy)
            {
                this.strategy = strategy;
            }

            public decimal Calculate(decimal price)
            {
                return strategy.Apply(price);
            }
        }
        public void Avg26()
        {
            Console.Clear();
            Console.WriteLine("Задание 26. Паттерн Стратегия (скидки)");
            Console.WriteLine("Что сделать: реализовать калькулятор скидок через паттерн Стратегия.");
            Console.WriteLine("Требования:" + Environment.NewLine +
                "Интерфейс IDiscountStrategy с методом Apply(decimal price)." + Environment.NewLine +
                "Реализации: NoDiscount, VipDiscount (10%), PromoDiscount (20%)." + Environment.NewLine +
                "Класс PriceCalculator, принимающий стратегию в конструкторе." + Environment.NewLine +
                "Продемонстрировать расчёт цены с каждой стратегией." + Environment.NewLine);

            Console.Write("Введите начальную цену: ");
            decimal price = decimal.Parse(Console.ReadLine());
            PriceCalculator calculator1 = new PriceCalculator(new NoDiscount());
            PriceCalculator calculator2 = new PriceCalculator(new VipDiscount());
            PriceCalculator calculator3 = new PriceCalculator(new PromoDiscount());
            Console.WriteLine("Начальная цена: " + price);
            Console.WriteLine("Без скидки: " + calculator1.Calculate(price));
            Console.WriteLine("VIP скидка 10%: " + calculator2.Calculate(price));
            Console.WriteLine("Промо скидка 20%: " + calculator3.Calculate(price));
        }
        class Student : IComparable<Student>
        {
            public string Name { get; set; }
            public double AverageGrade { get; set; }

            public Student(string name, double averageGrade)
            {
                Name = name;
                AverageGrade = averageGrade;
            }

            public int CompareTo(Student other)
            {
                return other.AverageGrade.CompareTo(AverageGrade);
            }
        }

        class ByNameComparer : IComparer<Student>
        {
            public int Compare(Student student1, Student student2)
            {
                return string.Compare(student1.Name, student2.Name);
            }
        }

        static void Avg27()
        {
            Console.Clear();
            Console.WriteLine("Задание 27. IComparable / IComparer<T> для Student");
            Console.WriteLine("Что сделать: научить Student сортироваться.");
            Console.WriteLine("Требования:" + Environment.NewLine +
                "Класс Student: Name, AverageGrade." + Environment.NewLine +
                "Реализовать IComparable<Student> — сортировка по среднему баллу (по убыванию)." + Environment.NewLine +
                "Реализовать IComparer<Student> ByNameComparer — сортировка по имени." + Environment.NewLine +
                "Продемонстрировать обе сортировки на List<Student>." + Environment.NewLine);

            List<Student> students = new List<Student>();

            students.Add(new Student("Иван", 4.5));
            students.Add(new Student("Анна", 5.0));
            students.Add(new Student("Пётр", 3.8));
            students.Add(new Student("Мария", 4.7));

            students.Sort();

            Console.WriteLine("Сортировка по среднему баллу:");

            foreach (Student student in students)
            {
                Console.WriteLine(student.Name + " - " + student.AverageGrade);
            }

            students.Sort(new ByNameComparer());

            Console.WriteLine("\nСортировка по имени:");

            foreach (Student student in students)
            {
                Console.WriteLine(student.Name + " - " + student.AverageGrade);
            }
        }
        class InsufficientFundsException : Exception
        {
            public InsufficientFundsException(string message) : base(message)
            {
            }
        }

        class BankAccount
        {
            private decimal balance;

            public void Deposit(decimal amount)
            {
                if (amount <= 0)
                {
                    Console.WriteLine("Сумма должна быть больше нуля!");
                    return;
                }

                balance += amount;
                Console.WriteLine("Счёт пополнен на " + amount);
            }

            public void Withdraw(decimal amount)
            {
                if (amount > balance)
                {
                    throw new InsufficientFundsException("Недостаточно денег на счёте!");
                }

                if (amount <= 0)
                {
                    Console.WriteLine("Сумма должна быть больше нуля!");
                    return;
                }

                balance -= amount;
                Console.WriteLine("Снято со счёта: " + amount);
            }

            public decimal GetBalance()
            {
                return balance;
            }
        }
        public static void Avg30()
        {
            Console.Clear();
            Console.WriteLine("Задание 30. BankAccount + свой Exception");
            Console.WriteLine("Что сделать: реализовать банковский счёт с собственным исключением.");
            Console.WriteLine("Требования:" + Environment.NewLine +
                "Класс BankAccount с приватным балансом." + Environment.NewLine +
                "Методы Deposit(decimal), Withdraw(decimal)." + Environment.NewLine +
                "Свой класс InsufficientFundsException : Exception." + Environment.NewLine +
                "Withdraw бросает исключение, если сумма больше баланса." + Environment.NewLine +
                "Продемонстрировать: успешное снятие и попытку снять больше баланса (с try/catch)." + Environment.NewLine);

            BankAccount account = new BankAccount();

            Console.Write("Введите сумму пополнения: ");
            decimal deposit = Convert.ToDecimal(Console.ReadLine());

            account.Deposit(deposit);

            try
            {
                Console.Write("Введите сумму для снятия: ");
                decimal withdraw1 = Convert.ToDecimal(Console.ReadLine());

                account.Withdraw(withdraw1);
                Console.WriteLine("Остаток: " + account.GetBalance());

                Console.Write("Введите ещё одну сумму для снятия: ");
                decimal withdraw2 = Convert.ToDecimal(Console.ReadLine());

                account.Withdraw(withdraw2);
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }

            Console.WriteLine("Итоговый баланс: " + account.GetBalance());
        }
        enum NotificationType
        {
            Email,
            Sms,
            Push
        }

        interface INotification
        {
            void Send(string message);
        }
        class EmailNotification : INotification
        {
            public void Send(string message)
            {
                Console.WriteLine("Email: " + message);
            }
        }
        class SmsNotification : INotification
        {
            public void Send(string message)
            {
                Console.WriteLine("SMS: " + message);
            }
        }
        class PushNotification : INotification
        {
            public void Send(string message)
            {
                Console.WriteLine("Push: " + message);
            }
        }
        class NotificationFactory
        {
            public static INotification Create(NotificationType type)
            {
                switch (type)
                {
                    case NotificationType.Email:
                        return new EmailNotification();

                    case NotificationType.Sms:
                        return new SmsNotification();

                    case NotificationType.Push:
                        return new PushNotification();

                    default:
                        return null;
                }
            }
        }
        public void Avg29()
        {
            Console.Clear();
            Console.WriteLine("Задание 29. Паттерн Фабрика (уведомления)");
            Console.WriteLine("Что сделать: реализовать фабрику уведомлений.");
            Console.WriteLine("Требования:" + Environment.NewLine +
                "Интерфейс INotification с методом Send(string message)." + Environment.NewLine +
                "Реализации: EmailNotification, SmsNotification, PushNotification." + Environment.NewLine +
                "NotificationFactory.Create(NotificationType type) — возвращает нужную реализацию." + Environment.NewLine +
                "enum NotificationType { Email, Sms, Push }." + Environment.NewLine +
                "Продемонстрировать создание и отправку через фабрику." + Environment.NewLine);

            Console.Write("Введите сообщение: ");
            string message = Console.ReadLine();

            INotification notification1 = NotificationFactory.Create(NotificationType.Email);
            INotification notification2 = NotificationFactory.Create(NotificationType.Sms);
            INotification notification3 = NotificationFactory.Create(NotificationType.Push);

            notification1.Send(message);
            notification2.Send(message);
            notification3.Send(message);
        }

        class Point : IEquatable<Point>
        {
            public int x;
            public int y;

            public bool Equals(Point other)
            {
                if (other == null) return false;
                return x == other.x && y == other.y;
            }

            public override bool Equals(object obj)
            {

                return Equals(obj as Point);
            }
            public override int GetHashCode()
            {
                unchecked
                {
                    int hash = 17;
                    hash = hash * 31 + x;
                    hash = hash * 31 + y;
                    return hash;
                }
            }
        }
            public void Avg28()
            {
                Console.Clear();
                Console.WriteLine("Задание 28. Переопределение Equals и GetHashCode для Point");
                Console.WriteLine("Что сделать: проверить корректность сравнения точек и работу HashSet.");
                Console.WriteLine("Требования:" + Environment.NewLine +
                    "Класс Point реализует IEquatable<Point>." + Environment.NewLine +
                    "Переопределены Equals(object) и GetHashCode()." + Environment.NewLine +
                    "Две точки с одинаковыми координатами равны." + Environment.NewLine +
                    "HashSet<Point> не увеличивает Count при добавлении дубликатов." + Environment.NewLine);
                HashSet<Point> points = new HashSet<Point>();
                Point p1 = new Point { x = 5, y = 10 };
                Point p2 = new Point { x = 5, y = 10 };
                Point p3 = new Point { x = 1, y = 2 };
                points.Add(p1);
                points.Add(p2); 
                points.Add(p3);
                Console.WriteLine($"Добавлено точек: 3 (из них две одинаковые).");
                Console.WriteLine($"Количество элементов в HashSet (Count): {points.Count}");
                Console.WriteLine($"Ожидается: 2 (так как дубликат не должен был добавиться).");
                Console.WriteLine(Environment.NewLine + $"Прямая проверка p1.Equals(p2): {p1.Equals(p2)}");
            }

        class Temperature
        {
            private double celsius;

            public double Celsius
            {
                get
                {
                    return celsius;
                }
                set
                {
                    if (value < -273.15)
                    {
                        throw new ArgumentOutOfRangeException("Celsius", "Температура не может быть ниже -273.15!");
                    }

                    celsius = value;
                }
            }

            public double Fahrenheit
            {
                get
                {
                    return celsius * 9 / 5 + 32;
                }
            }
        }
        public void Avg32()
        {
            Console.Clear();
            Console.WriteLine("Задание 32. Свойства с валидацией (Temperature)");
            Console.WriteLine("Что сделать: класс Temperature с валидацией в set.");
            Console.WriteLine("Требования:" + Environment.NewLine +
                "Свойство Celsius с проверкой: не ниже -273.15." + Environment.NewLine +
                "При некорректном значении — бросать ArgumentOutOfRangeException." + Environment.NewLine +
                "Вычисляемое свойство Fahrenheit (только get)." + Environment.NewLine +
                "Продемонстрировать корректное и некорректное присваивание." + Environment.NewLine);

            Temperature temperature = new Temperature();

            temperature.Celsius = 25;

            Console.WriteLine("Температура в Цельсиях: " + temperature.Celsius);
            Console.WriteLine("Температура в Фаренгейтах: " + temperature.Fahrenheit);

            try
            {
                temperature.Celsius = -300;
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Ошибка: температура не может быть ниже -273.15!");
            }
        }
        class Employee
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public decimal Salary { get; set; }
            public string Department { get; set; }

            public Employee(string name, int age, decimal salary, string department)
            {
                Name = name;
                Age = age;
                Salary = salary;
                Department = department;
            }
        }

        public static void Avg33()
        {
            Console.Clear();

            Console.WriteLine("Задание 33. LINQ: сотрудники");
            Console.WriteLine("Что сделать: выполнить LINQ-запросы по списку сотрудников.");
            Console.WriteLine("Требования:" + Environment.NewLine +
                "Класс Employee: Name, Age, Salary, Department." + Environment.NewLine +
                "Список из 10 и более сотрудников." + Environment.NewLine +
                "- Топ-3 сотрудника по зарплате." + Environment.NewLine +
                "- Средняя зарплата по каждому отделу (GroupBy + Average)." + Environment.NewLine +
                "- Сотрудники старше 30 лет (Where)." + Environment.NewLine +
                "Вывести результаты." + Environment.NewLine);

            List<Employee> employees = new List<Employee>()
    {
        new Employee("Алексей", 25, 50000, "IT"),
        new Employee("Мария", 32, 70000, "Бухгалтерия"),
        new Employee("Иван", 40, 90000, "IT"),
        new Employee("Елена", 28, 60000, "Продажи"),
        new Employee("Дмитрий", 35, 85000, "IT"),
        new Employee("Ольга", 45, 75000, "Бухгалтерия"),
        new Employee("Андрей", 22, 45000, "Продажи"),
        new Employee("Наталья", 38, 80000, "Продажи"),
        new Employee("Сергей", 31, 65000, "Бухгалтерия"),
        new Employee("Анна", 27, 55000, "IT")
    };

            Console.WriteLine("Топ-3 сотрудника по зарплате:");

            var top3 = employees
                .OrderByDescending(e => e.Salary)
                .Take(3);

            foreach (Employee employee in top3)
            {
                Console.WriteLine(employee.Name + " - " + employee.Salary);
            }

            Console.WriteLine(Environment.NewLine + "Средняя зарплата по отделам:");

            var averageSalary = employees
                .GroupBy(e => e.Department)
                .Select(group => new
                {
                    Department = group.Key,
                    Average = group.Average(e => e.Salary)
                });

            foreach (var department in averageSalary)
            {
                Console.WriteLine(department.Department + " - " + department.Average);
            }

            Console.WriteLine(Environment.NewLine + "Сотрудники старше 30 лет:");

            var olderEmployees = employees
                .Where(e => e.Age > 30);

            foreach (Employee employee in olderEmployees)
            {
                Console.WriteLine(employee.Name + " - " + employee.Age + " лет");
            }
        }
        class FileWriter : IDisposable
        {
            private StreamWriter writer;
            private bool disposed = false; 

            public FileWriter(string path)
            {
        
                writer = new StreamWriter(path, false, Encoding.UTF8);
            }

            public void WriteLine(string text)
            {
  
                if (disposed)
                {
                    Console.WriteLine("Предупреждение: попытка записи в уже закрытый файл!");
                    return;
                }
                writer.WriteLine(text);
            }

            public void Dispose()
            {

                if (!disposed)
                {
                    writer?.Dispose(); 
                    disposed = true;   
                }
            }
        }
        public void Avg31()
        {
            Console.Clear();
            Console.WriteLine("Задание 31. IDisposable + using");
            Console.WriteLine("Что сделать: реализовать IDisposable для класса, работающего с файлом.");
            Console.WriteLine("Требования:" + Environment.NewLine +
                "Класс FileWriter с полем StreamWriter." + Environment.NewLine +
                "Реализовать Dispose() (закрыть StreamWriter)." + Environment.NewLine +
                "Продемонстрировать использование через using." + Environment.NewLine +
                "Дополнительно: продемонстрировать using-декларацию (C# 8+, using var)." + Environment.NewLine);

            
            Console.WriteLine("--- 1. Классический блок using ---");
            using (FileWriter fw1 = new FileWriter("test1.txt"))
            {
                fw1.WriteLine("Строка записана через классический using(FileWriter ...).");
                Console.WriteLine("Данные успешно отправлены в test1.txt.");
            } 

            
            Console.WriteLine(Environment.NewLine + "--- 2. using-декларация (using var) ---");
            {
                using var fw2 = new FileWriter("test2.txt");
                fw2.WriteLine("Строка записана через using var.");
                Console.WriteLine("Данные успешно отправлены в test2.txt.");
            } 

            Console.WriteLine(Environment.NewLine + "Файлы успешно сформированы и закрыты.");
        }
    }
}


    

