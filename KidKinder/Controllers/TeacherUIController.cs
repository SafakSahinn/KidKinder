using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class TeacherUIController : Controller
    {
        // GET: TeacherUI
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult TeacherHeaderPartial()
        {
            return PartialView();
        }
    }
}