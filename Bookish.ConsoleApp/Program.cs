using Bookish.DataAccess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Bookish.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            string SqlString = "SELECT TOP 100 [ISBN], [Title] FROM [Books]";
            var ourBooks = (List<Book>)db.Query<Book>(SqlString);

            foreach (var book in ourBooks)
            {
                Console.WriteLine(new string('*', 20));
                Console.WriteLine("\nBook ISBN: " + book.ISBN);
                Console.WriteLine("Title " + book.Title + "\n");
                Console.WriteLine(new string('*', 20));
            }

            Console.ReadLine()
        }
    }
}
