using myFinPort_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace myFinPort_API.Controllers
{
    public class HomeController : Controller
    {
        private ApiDbContext db = new ApiDbContext();

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult TestConnection()
        {
            return View();
        }
    }
}
