using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public class Reader
    {
        public string Name { get; set; }
        public List<Book> BorrowedBooks { get; set; }
        public Reader(string name)
        {
            Name = name;
            BorrowedBooks = new List<Book>();
        }
    }
}
