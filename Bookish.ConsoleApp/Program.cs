using Bookish.DataAccess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Bookish.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            BookRepository library = new BookRepository();
            //List<Book> ourBooks = library.AllBooks();
            List<Book> ourBooks = library.MyBooksOnLoan("aardvark");

            foreach (var book in ourBooks)
            {
                Console.WriteLine(new string('-', 20));
                Console.WriteLine("\nBook ISBN: " + book.ISBN);
                Console.WriteLine("Copy Number " + book.Copies);
                Console.WriteLine("Title " + book.Title + "\n");
                Console.WriteLine(new string('-', 20));
            }
            Console.ReadLine();
        }
    }
}
