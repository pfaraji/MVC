using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webproduct_2.Controllers
{
    public class ProductController : Controller
    {
        
        public ActionResult Index()
        {
           AWEntities ctx = new AWEntities();
            var products = ctx.Products.ToString();

            return View(products);
        }
    }
}