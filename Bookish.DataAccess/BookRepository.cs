using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Bookish.DataAccess
{
    public class BookRepository
    {
        //private IDbConnection GetConnection()
        //{
        //    IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        //    return db;
        //}

        public List<Book> AllBooks()
        {
            IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            //GetConnection();
            string SqlString = "SELECT ISBN, Title, Copies FROM Books ORDER BY Title";

            return (List<Book>)db.Query<Book>(SqlString);
        }
    }
}
