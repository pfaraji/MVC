using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcDemo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            AdventureWorks2017Entities ctx = new AdventureWorks2017Entities();
            var products = ctx.Products.ToList();
            return View(products);
        }
    }
}