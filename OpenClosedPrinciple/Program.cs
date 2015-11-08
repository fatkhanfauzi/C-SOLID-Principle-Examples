using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosedPrinciple
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new BookPriceAuthor1() { Id = 1, Title = "Book 1", Author = "Author 1" };

            Book book2 = new BookPriceAuthor2() { Id = 2, Title = "Book 2", Author = "Author 2" };

            Persistence<Book>.Save(book1);
            Persistence<Book>.Save(book2);

            Console.Read();
        }

        abstract class Book
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public abstract void GetPrice(Book book);
        }

        class BookPriceAuthor1 : Book
        {
            public override void GetPrice(Book book)
            {
                Console.WriteLine(10000);
            }
        }

        class BookPriceAuthor2 : Book
        {
            public override void GetPrice(Book book)
            {
                Console.WriteLine(20000);
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
