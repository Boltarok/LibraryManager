using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Database.Managers;
using Library.DataModel.Business;
using Library.DataModel.Entities;
using Library.DataModel.Enums;

namespace Frontend.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using(var manager = new BookManager(new DataModelContext()))
            {
                var book = manager.SetBook(new Book() { Title = "Señor de los Anillos", AmmountAvailable = 20, Status = BookStatus.Available.ToString() });
                var books = manager.GetBooks();
            }

            return View();
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