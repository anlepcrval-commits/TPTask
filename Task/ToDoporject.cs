using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class ToDoproject
{
    private static readonly string filePath = "tasks.json";
    private List<TodoItem> tasks = new();

    public void Run()
    {
        Load();

        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("=== МЕНЕДЖЕР ЗАДАЧ (TODO LIST) ===");

            if (tasks.Count == 0)
            {
                Console.WriteLine("Список задач пуст.");
            }
            else
            {
                for (int i = 0; i < tasks.Count; i++)
                {
                    string status = tasks[i].IsDone ? "[x]" : "[ ]";
                    Console.WriteLine($"{i + 1}. {status} {tasks[i].Title}");
                }
            }

            Console.WriteLine("\n[1] Добавить задачу");
            Console.WriteLine("[2] Выполнить / Снять отметку");
            Console.WriteLine("[3] Удалить задачу");
            Console.WriteLine("[0] Вернуться в главное меню");
            Console.Write("Выберите пункт: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddTask();
                    break;
                case "2":
                    ToggleTaskStatus();
                    break;
                case "3":
                    RemoveTask();
                    break;
                case "0":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("\nНеверный выбор. Нажмите любую клавишу для продолжения...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private void AddTask()
    {
        Console.Write("\nВведите название новой задачи: ");
        string? title = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(title))
        {
            tasks.Add(new TodoItem { Title = title.Trim() });
            Save();
            Console.WriteLine("Задача добавлена!");
        }
        else
        {
            Console.WriteLine("Название не может быть пустым.");
        }
        Pause();
    }

    private void ToggleTaskStatus()
    {
        if (tasks.Count == 0) { Pause(); return; }

        Console.Write("\nВведите номер задачи для переключения статуса: ");
        if (int.TryParse(Console.ReadLine(), out int num) && num > 0 && num <= tasks.Count)
        {
            tasks[num - 1].IsDone = !tasks[num - 1].IsDone;
            Save();
            Console.WriteLine("Статус задачи обновлен!");
        }
        else
        {
            Console.WriteLine("Некорректный номер задачи.");
        }
        Pause();
    }

    private void RemoveTask()
    {
        if (tasks.Count == 0) { Pause(); return; }

        Console.Write("\nВведите номер задачи для удаления: ");
        if (int.TryParse(Console.ReadLine(), out int num) && num > 0 && num <= tasks.Count)
        {
            tasks.RemoveAt(num - 1);
            Save();
            Console.WriteLine("Задача удалена!");
        }
        else
        {
            Console.WriteLine("Некорректный номер задачи.");
        }
        Pause();
    }

    private void Save() => File.WriteAllText(filePath, JsonSerializer.Serialize(tasks));

    private void Load()
    {
        if (File.Exists(filePath))
        {
            try
            {
                string json = File.ReadAllText(filePath);
                tasks = JsonSerializer.Deserialize<List<TodoItem>>(json) ?? new();
            }
            catch
            {
                tasks = new();
            }
        }
    }

    private void Pause()
    {
        Console.WriteLine("\nНажмите любую клавишу, чтобы продолжить...");
        Console.ReadKey();
    }
}

public class TodoItem
{
    public string Title { get; set; } = "";
    public bool IsDone { get; set; }
}