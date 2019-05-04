using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webproducts.Controllers
{
    public class ProductController : Controller
    {
       
        public ActionResult Index()
        {
            AdventureWorks2017Entities ctx = new AdventureWorks2017Entities();
            var products = ctx.Products.ToString();
            return View(products);
        }
    }
}