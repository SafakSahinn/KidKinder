using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class AdminAboutListController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            var values = context.AboutLists.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult UpdateAboutList(int id)
        {
            var values = context.AboutLists.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateAboutList(AboutList aboutList)
        {
            var values = context.AboutLists.Find(aboutList.AboutListId);
            values.Description = aboutList.Description;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}