using KidKinder.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class GalleryController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            var values = context.Galleries.Where(x => x.Status == true).ToList();
            return View(values);
        }

        public PartialViewResult GalleryHeaderPartial()
        {
            return PartialView();
        }
    }
}