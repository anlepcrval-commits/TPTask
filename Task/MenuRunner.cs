using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public class Menu
    {
        public void MenuRunner()
        {
            Console.WriteLine("=====Практика======");
            Console.WriteLine("1. Уровень 1 — Базовый (задания 1–15)");
            Console.WriteLine("2. Уровень 2 — Средний (задания 16–35)");
            Console.WriteLine("3. Уровень 3 — Продвинутый (задания 36–50)");
            Console.WriteLine("4. Выход" + Environment.NewLine);
            Console.WriteLine("Выберите уровень: ");
            LevelMenu();
        }
        public void LevelMenu()
        {
            int o = Convert.ToInt32(Console.ReadLine());
            switch (o)
            {
                case (4):
                    Console.WriteLine(Environment.NewLine);
                    break;
                case 1: BaseLvl();
                    break;
                case 2:
                    AverageLevel();
                    break;
                case 3:
                    Advlvl();
                    break;


            }
        }
        public void BaseLvl()
        {
            Console.WriteLine("--- Уровень 1: Базовый ---");
            Console.WriteLine("Задание 1. Hello, World + текущая дата");
            Console.WriteLine("Задание 2. Переменные примитивных типов");
            Console.WriteLine("Задание 3. Калькулятор с обработкой деления на ноль");
            Console.WriteLine("Задание 4. Чётность числа (два способа)");
            Console.WriteLine("Задание 5. Таблица умножения 10×10");
            Console.WriteLine("Задание 6. Сумма цифр числа (строка + арифметика)");
            Console.WriteLine("Задание 7. Реверс строки без LINQ");
            Console.WriteLine("Задание 8. FizzBuzz 1–100");
            Console.WriteLine("Задание 9. Массивы: min/max/sum/avg");
            Console.WriteLine("Задание 10. Сортировка пузырьком + вставками");
            Console.WriteLine("Задание 11. Диагональ матрицы N×N");
            Console.WriteLine("Задание 12. Палиндром (без учёта регистра/пробелов)");
            Console.WriteLine("Задание 13. Счётчик вхождений слов в тексте (Dictionary)");
            Console.WriteLine("Задание 14. Возраст по дате рождения");
            Console.WriteLine("Задание 15. Git: репозиторий → ветка → merge → разрешение конфликта" + Environment.NewLine);
            Console.WriteLine("Выберите задание: ");
        }
        public void AverageLevel()
        {
            Console.WriteLine("--- Уровень 2 — Средний ---");
            Console.WriteLine("Задание 16. Методы расширения для string");
            Console.WriteLine("Задание 17. StringBuilder vs конкатенация (замер)");
            Console.WriteLine("Задание 18. TryParse vs try/catch");
            Console.WriteLine("Задание 19. Свой стек/очередь на массиве");
            Console.WriteLine("Задание 20. Обобщения: Swap<T>, Max<T> с IComparable<T>");
            Console.WriteLine("Задание 21. enum дни недели");
            Console.WriteLine("Задание 22. params-метод + перегрузка");
            Console.WriteLine("Задание 23. Nullable-типы, ??, ?.");
            Console.WriteLine("Задание 24. ООП: Animal → Dog/Cat/Bird");
            Console.WriteLine("Задание 25. Интерфейс IShape + сортировка фигур");
            Console.WriteLine("Задание 26. Паттерн «Стратегия» (скидки)");
            Console.WriteLine("Задание 27. IComparable / IComparer<T> для Student");
            Console.WriteLine("Задание 28. Equals / GetHashCode для Point");
            Console.WriteLine("Задание 29. Паттерн «Фабрика» (уведомления)");
            Console.WriteLine("Задание 30. BankAccount + свой Exception");
            Console.WriteLine("Задание 31. IDisposable + using");
            Console.WriteLine("Задание 32. Свойства с валидацией (Temperature)");
            Console.WriteLine("Задание 33. LINQ: сотрудники (top-3, avg по отделу, фильтр)");
            Console.WriteLine("Задание 34. LINQ: группировка слов по первой букве" + Environment.NewLine);
            Console.WriteLine("Выберите задание: ");
        }
        public void Advlvl()
        {
            Console.Clear();
            Console.WriteLine("--- Уровень: Эксперт / Профессиональный (Задания 36–50) ---");
            Console.WriteLine("Задание 36. Дубликаты в List (HashSet + GroupBy)");
            Console.WriteLine("Задание 37. Мемоизация Фибоначчи через Dictionary");
            Console.WriteLine("Задание 38. List<T> vs LinkedList<T> (бенчмарк)");
            Console.WriteLine("Задание 39. yield return — генератор чётных чисел");
            Console.WriteLine("Задание 40. async/await + обработка исключений");
            Console.WriteLine("Задание 41. Task.WhenAll — параллельно 10 задач");
            Console.WriteLine("Задание 42. CancellationToken — отмена через 2 сек");
            Console.WriteLine("Задание 43. Множественные типы исключений, порядок catch");
            Console.WriteLine("Задание 44. Мини-проект «Todo List» (классы + JSON)");
            Console.WriteLine("Задание 45. Мини-проект «Библиотека» + юнит-тесты коммита)" + Environment.NewLine);
            Console.WriteLine("Выберите задание: ");

            int a = Convert.ToInt32(Console.ReadLine());
            Advv program = new Advv();
            program.Swith(a);
        }
    }
}