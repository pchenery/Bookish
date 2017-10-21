using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bookish.DataAccess;

namespace Bookish.Web.Models
{
    public class BookViewModel
    {
        public List<Book> Books;

        public BookViewModel(List<Book> myBooks)
        {
            this.Books = myBooks;
        }

        public string ISBN { get; set; }
        public string Title { get; set; }
        public int Copies { get; set; }
        public int Barcode { get; set; } 
        public DateTime Loandate { get; set; }
        public DateTime Duedate { get; set; }
    }
}