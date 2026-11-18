using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public class Book
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public bool IsAvailable { get; set; }
        public Book(string title, string author)
        {
            Title = title;
            Author = author;
            IsAvailable = true;
        }
    }
}
