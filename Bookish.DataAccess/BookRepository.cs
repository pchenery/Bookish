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
            string SqlString = "select ISBN, Title, Copies from Books order by Title";

            return (List<Book>)db.Query<Book>(SqlString);
        }

        public List<Book> MyBooksOnLoan(string userName)
        {
            IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            //GetConnection();
            string SqlString = "select bc.ISBN, ol.barcode, ol.loandate, ol.duedate " +
                                "from BookCopy bc, OnLoan ol, Users u " +
                                "where bc.barcode = ol.barcode " +
                                "and ol.UserID = u.UserID " +
                                "and u.Username = @user order by Duedate";

            return (List<Book>)db.Query<Book>(SqlString, new { user = userName });
        }

        public List<Book> BookSearchbyAuthor(string authorName)
        {
            IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            //GetConnection();
            string SqlString = "select b.ISBN, b.Title, a.Firstname, a.Surname " +
                               "from Books b, Authors a, AuthorBook ab " +
                               "where b.ISBN = ab.ISBN " +
                               "and a.AuthorID = ab.AuthorID " +
                               "and a.surname = @author order by surname";

            return (List<Book>)db.Query<Book>(SqlString, new { author = authorName });
        }

        //select Copies
        //from Books
        //where ISBN = '978-9538782081'

        //select count(*) OnLoanCopies
        //    from BookCopy bc, OnLoan ol
        //    where bc.Barcode = ol.Barcode
        //    and ISBN = '978-9538782081'

        //select b.copies - ( 
        //select count(*)
        //    from BookCopy
        //    where ISBN = '978-9538782081'
        //and Barcode not in (select barcode from OnLoan))
        //from books b
        //    where ISBN = '978-9538782081'
    }
}
