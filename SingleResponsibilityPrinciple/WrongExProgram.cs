using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsibilityPrinciple
{
    class WrongExProgram
    {
        static void Main(string[] args)
        {
            Book book = new Book() { Id = 1, Title = "Book 1", Author = "Author 1" };
            book.Save(book);

            Console.Read();
        }

        class Book
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }

            public void Save(Book book)
            {
                Console.WriteLine("=========Save========");

                foreach (var item in book.GetType().GetProperties())
                {
                    Console.WriteLine(item.GetValue(book, null));
                }
            }
        }
    }
}
