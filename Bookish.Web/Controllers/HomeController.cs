using Bookish.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bookish.Web.Models;
using Microsoft.AspNet.Identity;

namespace Bookish.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            BookRepository library = new BookRepository();
            var myBooks = library.MyBooksOnLoan(User.Identity.Name);
            var bookViewModel = new BookViewModel(myBooks);
            //Get list of users books on loan
            return View(bookViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}