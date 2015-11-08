using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosedPrinciple
{
    class WrongExProgram
    {
        static void Main(string[] args)
        {
            Book book1 = new Book() { Id = 1, Title = "Book 1", Author = "Author 1" };

            Book book2 = new Book() { Id = 2, Title = "Book 2", Author = "Author 2" };

            Persistence<Book>.Save(book1);
            Persistence<Book>.Save(book2);

            Console.Read();
        }

        class Book
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }

            public void GetPrice(Book book)
            {
                switch (book.Author)
                {
                    case "Author 1":
                        Console.WriteLine(10000);
                        break;
                    case "Author 2":
                        Console.WriteLine(20000);
                        break;
                    default:
                        Console.WriteLine(30000);
                        break;
                }
            }
        }

        class Persistence<T> where T : class
        {
            public static void Save(T obj)
            {
                Console.WriteLine("=========Save========");

                foreach (var item in obj.GetType().GetProperties())
                {
                    Console.WriteLine(item.GetValue(obj, null));
                }

                foreach (var item in obj.GetType().GetMethods().Where(m => !m.IsSpecialName && m.DeclaringType != typeof(object)))
                {
                    Console.WriteLine(item.Invoke(obj, new object[] { obj }));
                }
            }
        }
    }
}
