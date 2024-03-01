using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class ClassController : Controller
    {
        // GET: Classes
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult ClassHeaderPartial()
        {
            return PartialView();
        }
    }
}