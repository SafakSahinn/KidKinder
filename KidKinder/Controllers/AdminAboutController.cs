using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class AdminAboutController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            var values = context.Abouts.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var values = context.Abouts.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateAbout(About about)
        {
            var values = context.Abouts.Find(about.AboutId);
            values.Title = about.Title;
            values.Header = about.Header;
            values.Description = about.Description;
            values.BigImageUrl = about.BigImageUrl;
            values.SmallImageUrl = about.SmallImageUrl;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}