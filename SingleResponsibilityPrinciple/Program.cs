using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsibilityPrinciple
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book() { Id=1, Title="Book 1", Author="Author 1" };
            Persistence<Book>.Save(book);

            Console.Read();
        }
        
        class Book
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
        }

        class Persistence<T> where T:class
        {
            public static void Save(T obj)
            {
                Console.WriteLine("=========Save========");

                foreach (var item in obj.GetType().GetProperties())
                {
                    Console.WriteLine(item.GetValue(obj, null));
                }
            }
        }
    }
}
