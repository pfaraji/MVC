using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventHandlingApp.Areas.Userpanel.Controllers
{
    public class HomeController : Controller
    {
        // GET: Userpanel/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}