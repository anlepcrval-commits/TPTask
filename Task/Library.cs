using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public class Library
    {
        public List<Book> Books { get; set; }

        public Library()
        {
            Books = new List<Book>();

            Books.Add(new Book("Гарри Поттер", "Джоан Роулинг"));
            Books.Add(new Book("Властелин колец", "Джон Толкин"));
            Books.Add(new Book("Преступление и наказание", "Фёдор Достоевский"));
            Books.Add(new Book("Маленький принц", "Антуан де Сент-Экзюпери"));
            Books.Add(new Book("Шерлок Холмс", "Артур Конан Дойл"));
            Books.Add(new Book("Мастер и Маргарита", "Михаил Булгаков"));
            Books.Add(new Book("Война и мир", "Лев Толстой"));
            Books.Add(new Book("Три мушкетёра", "Александр Дюма"));
            Books.Add(new Book("Отцы и дети", "Иван Тургенев"));
            Books.Add(new Book("Алиса в Стране чудес", "Льюис Кэрролл"));
        }

        public void BorrowBook(Book book, Reader reader)
        {
            if (!book.IsAvailable)
            {
                throw new InvalidOperationException("Эта книга уже выдана!");
            }

            if (reader.BorrowedBooks.Count >= 3)
            {
                throw new InvalidOperationException("Нельзя взять больше трёх книг!");
            }

            book.IsAvailable = false;
            reader.BorrowedBooks.Add(book);
        }

        public void ReturnBook(Book book, Reader reader)
        {
            if (!reader.BorrowedBooks.Contains(book))
            {
                throw new InvalidOperationException("У вас нет этой книги!");
            }

            reader.BorrowedBooks.Remove(book);
            book.IsAvailable = true;
        }

        public void ShowBooks()
        {
            Console.WriteLine("\n========== СПИСОК КНИГ ==========");

            for (int i = 0; i < Books.Count; i++)
            {
                string status;

                if (Books[i].IsAvailable)
                {
                    status = "Свободна";
                }
                else
                {
                    status = "Выдана";
                }

                Console.WriteLine(
                    (i + 1) + ". " +
                    Books[i].Title + " — " +
                    Books[i].Author + " [" + status + "]");
            }
        }

        public void Run()
        {
            Reader reader = new Reader("Читатель");

            while (true)
            {
                Console.WriteLine("\n========== БИБЛИОТЕКА ==========");
                Console.WriteLine("1. Посмотреть книги");
                Console.WriteLine("2. Взять книгу");
                Console.WriteLine("3. Отдать книгу");
                Console.WriteLine("4. Выход");

                Console.Write("\nВыберите действие: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowBooks();
                        break;

                    case "2":
                        ShowBooks();

                        Console.Write("\nВведите номер книги: ");
                        int bookNumber;

                        if (int.TryParse(Console.ReadLine(), out bookNumber) &&
                            bookNumber >= 1 && bookNumber <= Books.Count)
                        {
                            try
                            {
                                BorrowBook(Books[bookNumber - 1], reader);
                                Console.WriteLine("Книга успешно выдана!");
                            }
                            catch (InvalidOperationException ex)
                            {
                                Console.WriteLine("Ошибка: " + ex.Message);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Неверный номер книги!");
                        }

                        break;

                    case "3":
                        if (reader.BorrowedBooks.Count == 0)
                        {
                            Console.WriteLine("\nУ вас пока нет книг для возврата.");
                            break;
                        }

                        Console.WriteLine("\n========== ВАШИ КНИГИ ==========");

                        for (int i = 0; i < reader.BorrowedBooks.Count; i++)
                        {
                            Console.WriteLine(
                                (i + 1) + ". " +
                                reader.BorrowedBooks[i].Title);
                        }

                        Console.Write("\nВведите номер книги для возврата: ");
                        int returnNumber;

                        if (int.TryParse(Console.ReadLine(), out returnNumber) &&
                            returnNumber >= 1 &&
                            returnNumber <= reader.BorrowedBooks.Count)
                        {
                            try
                            {
                                Book book = reader.BorrowedBooks[returnNumber - 1];

                                ReturnBook(book, reader);

                                Console.WriteLine("Книга успешно возвращена!");
                            }
                            catch (InvalidOperationException ex)
                            {
                                Console.WriteLine("Ошибка: " + ex.Message);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Неверный номер книги!");
                        }

                        break;

                    case "4":
                        Console.WriteLine("Выход из библиотеки.");
                        return;

                    default:
                        Console.WriteLine("Такого пункта меню нет!");
                        break;
                }

                Console.WriteLine(
                    "\nУ вас книг: " + reader.BorrowedBooks.Count + " из 3");
            }
        }
    }
}
